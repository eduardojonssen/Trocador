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
        public abstract Dictionary<int, int> CalculateChange(int currentMoneyAmount);
    }
}
