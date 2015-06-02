using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Core.LogSystem {

	public abstract class AbstractLog {

		public AbstractLog() {

			this.ConfigurationUtility = IocFactory.Resolve<IConfigurationUtility>();
		}

		protected IConfigurationUtility ConfigurationUtility { get; set; }

		public abstract void Save(string logCategory, object objectToLog, [CallerMemberName] string methodName = "");
	}
}
