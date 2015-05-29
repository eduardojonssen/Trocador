using System;

namespace Trocador.Core.Utility {

	public interface IConfigurationUtility {

		string LogFileName { get; }
		string LogFullPath { get; }
		string LogPath { get; }
		string LogType { get; }
	}
}
