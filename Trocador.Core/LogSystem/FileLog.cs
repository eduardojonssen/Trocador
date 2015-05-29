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
	class FileLog : AbstractLog{

		public FileLog(IConfigurationUtility configurationUtility) : base(configurationUtility) { }

		public override void Save(string logCategory, string methodName, object objectToLog) {

			string serializedData = Serializer.JsonSerialize(objectToLog);

			string logRegister = string.Format("{0}|{1}|{2}|{3}", DateTime.UtcNow, logCategory, methodName, serializedData);

			string registerSeparator = Environment.NewLine;

			logRegister += registerSeparator;

			ConfigurationUtility configurationUtility = new ConfigurationUtility();

			if (Directory.Exists(configurationUtility.LogPath) == false) {
				Directory.CreateDirectory(configurationUtility.LogPath);
			}

			File.AppendAllText(configurationUtility.LogFullPath, logRegister);

			/* Escrita de arquivo com FileStream.
			FileStream fileStream = new FileStream(LogFullPath, FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			streamWriter.WriteLine(logRegister);
			streamWriter.Close();
			*/
		}
	}
}
