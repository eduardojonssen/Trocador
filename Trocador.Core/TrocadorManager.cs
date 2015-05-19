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
            response.Errors = new List<string>();
            try {
                
                response.Errors = Validate(request.ProductAmount, request.PaidAmount);

                response.Coins = new Dictionary<int, int>();

                if (response.Errors.Count() > 0) {
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
                response.Errors.Add("Erro inesperado, tente novamente mais tarde");
            }

            return response;
        }

        private static List<string> Validate(int productAmount, int paidAmount) {
            List<string> returnValue = new List<string>();
            if (paidAmount < 0) {
                returnValue.Add("Valor pago não pode ser menor que zero.\r\n");
            }
            if (productAmount < 0) {
                returnValue.Add("Valor do produto não pode ser menor que zero.\r\n");
            }
            if (returnValue.Any() == false && (paidAmount < productAmount)) {
                returnValue.Add("Valor insuficiente para o produto escolhido. Acrescente mais dinheiro.\r\n");
            }
            return returnValue;
        }
    }
}
