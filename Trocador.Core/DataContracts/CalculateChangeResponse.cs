using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.DataContracts {

    public class CalculateChangeResponse {

        public CalculateChangeResponse() {

            this.Change = new List<KeyValuePair<int, MoneyUnit>>();

            this.ErrorReportList = new List<ErrorReport>();
        }

        public List<ErrorReport> ErrorReportList { get; set; }

        public List<KeyValuePair<int, MoneyUnit>> Change { get; set; }

        public int TotalChangeAmount { get; set; }

    }
}
