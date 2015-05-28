using System.Linq;
using System.Collections.Generic;

namespace Trocador.Core.Processors {

    public abstract class AbstractProcessor {

        public AbstractProcessor() { }

        /// <summary>
        /// Obtém o tipo da moeda.
        /// </summary>
        internal abstract string CurrencyType { get; }

        /// <summary>
        /// Obtém a lista de valores disponíveis.
        /// </summary>
        internal abstract int[] MoneyValues { get; }

        /// <summary>
        /// Contabiliza as unidades monetárias necessárias para atingir o valor do troco especificado.
        /// </summary>
        /// <param name="currentMoneyAmount">Valor do troco a ser calculado.</param>
        /// <returns>Retorna um dicionário onde a chave é a unidade monetária e valor é a quantidade desta unidade.</returns>
        internal virtual Dictionary<int, int> CalculateChange(int currentMoneyAmount) {

            Dictionary<int, int> changeDictionary = new Dictionary<int, int>();

            for (int i = 0; i < this.MoneyValues.Count(); i++) {

                // Verifica se a nota em questão será utilizada no troco.
                if (currentMoneyAmount % this.MoneyValues[i] != currentMoneyAmount) {
                    changeDictionary.Add(this.MoneyValues[i], currentMoneyAmount / this.MoneyValues[i]);
                }

                currentMoneyAmount = currentMoneyAmount % this.MoneyValues[i];

                if (currentMoneyAmount == 0) { break; }
            }

            return changeDictionary;
        }
    }
}
