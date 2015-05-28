using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.LogSystem {
	public static class LogManager {

		public static void SubmitLog(string logCategory, string methodName, object objectToLog) {

			AbstractLog logger = LogFactory.Create("File");
			logger.Save(logCategory, methodName, objectToLog);
		}
	}
}