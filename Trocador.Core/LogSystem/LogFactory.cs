using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.LogSystem {
	public static class LogFactory {
		public static AbstractLog Create(string logType) {
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
