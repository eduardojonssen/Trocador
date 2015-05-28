using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.Processors {

    public class CoinProcessor : AbstractProcessor {

        public CoinProcessor() { }

        private int[] availableValues = { 100, 50, 25, 10, 5, 1 };

        internal override string CurrencyType {
            get { return "COIN"; }
        }

        internal override int[] MoneyValues {
            get { return this.availableValues; }
        }
    }
}
