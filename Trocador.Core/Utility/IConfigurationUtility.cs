using System;
using Trocador.Core.Interceptors;

namespace Trocador.Core.Utility {

	public interface IConfigurationUtility {

		string LogFileName { get; }

		[Intercept]
		string LogFullPath { get; }

		string LogPath { get; }
		string LogType { get; }
	}
}
