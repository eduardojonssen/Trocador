using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Core.LogSystem {

	public static class LogManager {

		public static void SubmitLog(string logCategory, string methodName, object objectToLog) {

			IConfigurationUtility configurationUtility = new ConfigurationUtility();

			AbstractLog logger = LogFactory.Create(configurationUtility);
			logger.Save(logCategory, methodName, objectToLog);
		}
	}
}