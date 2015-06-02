using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Core.LogSystem {

	public class LogManager {

		public LogManager() { }

		public void Save(string logCategory, object objectToLog, [CallerMemberName] string methodName = "") {

			AbstractLog logger = LogFactory.Create();
			logger.Save(logCategory, objectToLog, methodName);
		}
	}
}