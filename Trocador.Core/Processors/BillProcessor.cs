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
    }
}
