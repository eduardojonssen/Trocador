using System;
using System.Collections.Generic;
using System.Linq;
using Trocador.Core.DataContracts;
using Trocador.Core.Processors;

namespace Trocador.Core {

    public class TrocadorManager {

        public CalculateChangeResponse CalculateChange(CalculateChangeRequest request) {

            CalculateChangeResponse response = new CalculateChangeResponse();

            try {
                // TODO: Salvar log do request.

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
                            Message = @"Não foi possivel processar seu troco. \r\n 
                                        Tente novamente mais tarde" 
                        });
                        break;
                    }

                    Dictionary<int, int> processorChange = processor.CalculateChange(currentChange);

                    foreach(KeyValuePair<int,int> change in processorChange){
                        currentChangeValues.Add( new KeyValuePair<int, MoneyUnit> (change.Value, new MoneyUnit() { 
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

                // TODO: Salvar log da exceção.
                //Se algum erro for disparado, retorna uma mensagem generica de erro.
                ErrorReport errorReport = new ErrorReport();
                errorReport.Message = "Erro inesperado, tente novamente mais tarde";
                response.ErrorReportList.Add(errorReport);
            }

            // TODO: Salvar log do response.

            return response;
        }
    }
}
