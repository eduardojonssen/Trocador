using System;
using System.Collections.Generic;
using System.Linq;
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
                
                response.Change = new List<KeyValuePair<int, MoneyUnit>>();

                int changeValue = request.PaidAmount - request.ProductAmount;

                //valores de notas e moedas.
                int[] notes = { 10000, 5000, 2000, 1000, 500, 200 };
                int[] coins = { 100, 50, 25, 10, 5, 1 };

                //Cria o MoneyUnit para cada nota e moeda.
                List<MoneyUnit> moneyUnitList = new List<MoneyUnit>();
                foreach (int noteValue in notes) {
                    moneyUnitList.Add(new MoneyUnit() { Name = "BILL", AmountInCents = noteValue });
                }
                foreach (int coinValue in coins) {
                    moneyUnitList.Add(new MoneyUnit() { Name = "COIN", AmountInCents = coinValue });
                }
                
                moneyUnitList = moneyUnitList.OrderByDescending(x => x.AmountInCents).ToList();

                int currentValue = changeValue;

                for (int i = 0; i < moneyUnitList.Count(); i++) {
                    //Verifica se a nota em questão será utilizada no troco.
                    if (currentValue % moneyUnitList[i].AmountInCents != currentValue) {
                        response.Change.Add(new KeyValuePair<int, MoneyUnit>(currentValue / moneyUnitList[i].AmountInCents, moneyUnitList[i]));
                    }
                    currentValue = currentValue % moneyUnitList[i].AmountInCents;
                    if (currentValue == 0) { break; }
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
