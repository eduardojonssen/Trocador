using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.DataContracts {

    public abstract class AbstractRequest {

        public AbstractRequest() {
            this.ErrorReportList = new List<ErrorReport>();
        }

        internal bool IsValid {
            get {
                this.ErrorReportList.Clear();
                this.Validate();
                return (this.ErrorReportList.Any() == false);
            }
        }

        private List<ErrorReport> ErrorReportList { get; set; }

        /// <summary>
        /// Adiciona um erro à lista de erros de validação.
        /// </summary>
        /// <param name="errorMessage">Mensagem de erro a ser adicionada.</param>
        protected void AddError(string fieldName, string errorMessage) {

            // Sai do método caso não exista uma mensagem de erro a ser adicionada.
            if (string.IsNullOrWhiteSpace(fieldName) == true ||
                string.IsNullOrWhiteSpace(errorMessage) == true) { return; }

            ErrorReport errorReport = new ErrorReport();

            errorReport.FieldName = this.GetType().Name + "." + fieldName;
            errorReport.Message = errorMessage;

            // Adiciona a mensagem a lista de erros validação.
            this.ErrorReportList.Add(errorReport);
        }

        /// <summary>
        /// Obtém a lista de erros de validação encontrados.
        /// </summary>
        /// <returns>Retorna uma lista contendo cada erro encontrado.</returns>
        internal IEnumerable<ErrorReport> GetErrors() {
            
            return this.ErrorReportList;
        }

        protected abstract void Validate();
    }
}
