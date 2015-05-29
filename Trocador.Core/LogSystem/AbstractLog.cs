using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Core.LogSystem {

	public abstract class AbstractLog {

		public AbstractLog(IConfigurationUtility configurationUtility) {

			this.ConfigurationUtility = configurationUtility;
		}

		protected IConfigurationUtility ConfigurationUtility { get; set; }

		public abstract void Save(string logCategory, string methodName, object objectToLog);
	}
}
