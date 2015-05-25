using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.Processors {
    public class SilverProcessor : AbstractProcessor {

        public SilverProcessor() { }

        internal override string CurrencyType {
            get { return "SILVER"; }
        }

        private int[] availableValues = { 100000, 50000 };

        internal override int[] MoneyValues {
            get { return this.availableValues; }
        }

        public override Dictionary<int, int> CalculateChange(int currentMoneyAmount) {

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
