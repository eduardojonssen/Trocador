using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.Processors {

    public class BillProcessor : AbstractProcessor {

        public BillProcessor() { }

        private int[] availableValues = { 10000, 5000, 2000, 1000, 500, 200 };

        internal override string CurrencyType {
            get { return "BILL"; }
        }
        internal override int[] MoneyValues {
            get { return this.availableValues; }
        }

        internal override Dictionary<int, int> CalculateChange(int currentMoneyAmount) {

            Dictionary<int, int> changeDictionary = new Dictionary<int, int>();

            for (int i = 0; i < this.MoneyValues.Count(); i++) {

                //Verifica se a nota em questão será utilizada no troco.
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
