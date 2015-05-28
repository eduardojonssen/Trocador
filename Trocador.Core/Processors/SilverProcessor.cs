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
    }
}
