using Dlp.Framework.Container;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Core.LogSystem {

	public static class LogFactory {

		public static AbstractLog Create() {

			// Obtém a instancia do configurationUtility a partir do container.
			IConfigurationUtility configurationUtility = IocFactory.Resolve<IConfigurationUtility>();

			string logType = configurationUtility.LogType;

			if (string.IsNullOrEmpty(logType)) {
				throw new Exception("Undefined log type (TRM:24A0FE6C)");
			}

			switch (logType) {
				case "File":
					return new FileLog();
				case "EventViewer":
					return new EventViewerLog();
				default:
					return new EventViewerLog();
			}
		}
	}
}
