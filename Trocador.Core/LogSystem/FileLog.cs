using Dlp.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.LogSystem {
	class FileLog : AbstractLog{

		public FileLog() { }

		private static string LogFullPath = "C:\\Logs\\log.log";
		private static string LogFileDirectory = "C:\\Logs\\";

		public override void Save(string logCategory, string methodName, object objectToLog) {
			string serializedData = Serializer.JsonSerialize(objectToLog);

			string logRegister = string.Format("{0}|{1}|{2}|{3}", DateTime.UtcNow, logCategory, methodName, serializedData);

			string registerSeparator = Environment.NewLine;

			logRegister += registerSeparator;

			if (Directory.Exists(LogFileDirectory) == false) {
				Directory.CreateDirectory(LogFileDirectory);
			}

			File.AppendAllText(LogFullPath, logRegister);

			/* Escrita de arquivo com FileStream.
			FileStream fileStream = new FileStream(LogFullPath, FileMode.Append);
			StreamWriter streamWriter = new StreamWriter(fileStream);
			streamWriter.WriteLine(logRegister);
			streamWriter.Close();
			*/
		}
	}
}
