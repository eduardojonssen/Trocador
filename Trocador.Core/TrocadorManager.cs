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
                
                response.TotalChangeAmount = request.PaidAmount - request.ProductAmount;


                // TODO: Implementar lógica de escolha dos processadores e
                // montar o resultado para o cliente.
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
