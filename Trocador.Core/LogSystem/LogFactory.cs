using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Core.LogSystem {
	public static class LogFactory {
		public static AbstractLog Create(IConfigurationUtility configurationUtility) {

			string logType = configurationUtility.LogType;

			if (string.IsNullOrEmpty(logType)) {
				throw new Exception("Undefined log type (TRM:24A0FE6C)");
			}

			switch (logType) {
				case "File":
					return new FileLog(configurationUtility);
				case "EventViewer":
					return new EventViewerLog(configurationUtility);
				default:
					return new EventViewerLog(configurationUtility);
			}
		}
	}
}
