using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.DataContracts {

    public class CalculateChangeRequest : AbstractRequest {

        public CalculateChangeRequest() : base() { }

        /// <summary>
        /// Valor a ser utilizado para pagar pelo produto.
        /// </summary>
        public int PaidAmount { get; set; }

        /// <summary>
        /// Valor do produto.
        /// </summary>
        public int ProductAmount { get; set; }

        protected override void Validate() {

            // Verifica se o valor pago é válido.
            if (this.PaidAmount < 0) {
                this.AddError("PaidAmount", "Valor pago não pode ser menor que zero.");
            }

            // Verifica se o valor do produto é válido.
            if (this.ProductAmount < 0) {
                this.AddError("ProductAmount", "Valor do produto não pode ser menor que zero.");
            }

            // Verifica se o valor pago é suficiente para cobrir o valor do produto.
            if (this.GetErrors().Any() == false && (this.PaidAmount < this.ProductAmount)) {
                this.AddError("PaidAmount", "Valor insuficiente para o produto escolhido. Acrescente mais dinheiro.");
            }
        }
    }
}
