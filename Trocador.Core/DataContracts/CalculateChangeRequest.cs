using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.DataContracts {
    public class CalculateChangeRequest {
        public int PaidAmount { get; set; }

        public int ProductAmount { get; set; }

    }
}
