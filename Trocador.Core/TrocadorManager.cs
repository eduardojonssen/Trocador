using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Trocador.Core.DataContracts;
using Trocador.Core.LogSystem;
using Trocador.Core.Processors;
using Trocador.Core.Utility;

namespace Trocador.Core {

	public class TrocadorManager {

		public TrocadorManager(IConfigurationUtility configurationUtility = null) {

			this.Log = new LogManager(configurationUtility);
		}

		private LogManager Log { get; set; }

		public CalculateChangeResponse CalculateChange(CalculateChangeRequest request) {

			CalculateChangeResponse response = new CalculateChangeResponse();

			try {
				this.Log.Save("Request", request);

				// Verifica se algum erro foi encontrado nos dados recebidos.
				// Caso positivo, sai do método.
				if (request.IsValid == false) {
					response.ErrorReportList.AddRange(request.GetErrors());
					return response;
				}

				Nullable<int> totalChange = request.PaidAmount - request.ProductAmount;

				int currentChange = (int)totalChange;

				List<KeyValuePair<int, MoneyUnit>> currentChangeValues = new List<KeyValuePair<int, MoneyUnit>>();

				while (currentChange != 0) {
					AbstractProcessor processor = ProcessorFactory.Create(currentChange);

					if (processor == null) {
						response.ErrorReportList.Add(new ErrorReport() {
							FieldName = null,
							Message = "Não foi possivel processar seu troco. Tente novamente mais tarde"
						});
						break;
					}

					Dictionary<int, int> processorChange = processor.CalculateChange(currentChange);

					foreach (KeyValuePair<int, int> change in processorChange) {
						currentChangeValues.Add(new KeyValuePair<int, MoneyUnit>(change.Value, new MoneyUnit() {
							Name = processor.CurrencyType,
							AmountInCents = change.Key
						}));
						currentChange -= change.Key * change.Value;
					}
				}

				if (response.ErrorReportList.Any() == false) {
					response.Change = currentChangeValues;
					response.TotalChangeAmount = totalChange;
					response.Success = true;
				}
			}
			catch (Exception ex) {
				//Se algum erro for disparado, retorna uma mensagem generica de erro.
				this.Log.Save("Exception", ex.ToString());
				ErrorReport errorReport = new ErrorReport();
				errorReport.Message = "Erro inesperado, tente novamente mais tarde";
				response.ErrorReportList.Add(errorReport);
			}

			finally {
				this.Log.Save("Response", response);
			}

			return response;
		}
	}
}
