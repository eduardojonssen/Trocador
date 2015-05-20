using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.DataContracts;

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

                response.Coins = new Dictionary<int, int>();

                if (response.ErrorReportList.Count() > 0) {
                    return response;
                }

                int changeValue = request.PaidAmount - request.ProductAmount;

                int[] coins = { 100, 50, 25, 10, 5, 1 };

                int currentValue = changeValue;

                for (int i = 0; i < coins.Length; i++) {
                    response.Coins.Add(coins[i] ,currentValue / coins[i]);
                    currentValue = currentValue % coins[i];
                    if (currentValue == 0) { break; }
                }

            }
            catch (Exception ex) {

                // TODO: Salvar log da exceção.

                ErrorReport errorReport = new ErrorReport();
                errorReport.Message = "Erro inesperado, tente novamente mais tarde";
                response.ErrorReportList.Add(errorReport);
            }

            // TODO: Salvar log do response.

            return response;
        }
    }
}
