using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.LogSystem {
	public abstract class AbstractLog {
		public AbstractLog() {}

		public abstract void Save(string logCategory, string methodName, object objectToLog);
	}
}
