using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trocador.Core.Utility;

namespace Trocador.Test.Trocador.Core.Test.Mocks {

	public class ConfigurationUtilityMock : IConfigurationUtility {

		public ConfigurationUtilityMock() { }

		public string LogFileName { get; set; }

		public string LogFullPath { get; set; }

		public string LogPath { get; set; }

		public string LogType { get; set; }
	}
}
