using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.Utility {

	public class ConfigurationUtility : IConfigurationUtility {

		public ConfigurationUtility() { }

		/// <summary>
		/// Obtém ou define o tipo de log a ser utilizado.
		/// </summary>
		public string LogType { get { return ConfigurationManager.AppSettings["LogType"]; } }

		/// <summary>
		/// Obtém ou define o nome do arquivo de log.
		/// Será utilizado apenas caso o tipo de log em arquivo tenha sido especificado.
		/// </summary>
		public string LogFileName { get { return ConfigurationManager.AppSettings["LogFileName"]; } }

		/// <summary>
		/// Obtém ou define o caminho do diretório onde será salvo o arquivo de log,
		/// caso este tenha sido definido.
		/// </summary>
		public string LogPath { get { return ConfigurationManager.AppSettings["LogPath"]; } }

		/// <summary>
		/// Obtém ou define o caminho completo do arquivo de log (Path + Name).
		/// </summary>
		public string LogFullPath { get { return Path.Combine(this.LogPath, this.LogFileName); } }

		// Exemplo de como obter uma configuração e converter para int.
		//public int TimeoutInSeconds { get { return Convert.ToInt32(ConfigurationManager.AppSettings["TimeoutInSeconds"] ?? "90"); } }
	}
}
