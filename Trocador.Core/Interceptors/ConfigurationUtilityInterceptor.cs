using Dlp.Framework.Container.Interceptors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trocador.Core.Interceptors {
	
	public class ConfigurationUtilityInterceptor : IInterceptor {

		public void Intercept(IInvocation invocation) {

			// Caso o método ou propriedade não possua o atributo Intercept, apenas executamos o método chamado.
			if (Attribute.IsDefined(invocation.MethodInvocationTarget, typeof(InterceptAttribute)) == false) {

				invocation.Proceed();
			}
			else {

				// TODO: Implementar lógica de interceptação.

				invocation.Proceed();
			}
		}
	}
}
