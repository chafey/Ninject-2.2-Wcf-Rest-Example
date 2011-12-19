using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;
using Ninject.Modules;
using WcfRestService1.NinjectWcf;

namespace WcfRestService1
{
	public class ServiceModule : NinjectModule
	{
		public override void Load()
		{
			// Binding services InRequestScope allows a single instance to be shared for all requests to the Ninject kernel for
			// instances of that type in a given WCF REST Request.  Other options include:
			//	 InTransientScope() - If you dont' want instances to be shared for a given WCF REST Request
			//   InSingletonScope() - If you want instances shared between all WCF REST Requests.  You of course need to handle thread safety in this case
			// You probably don't want to use InThreadScope() since IIS can re-use the same thread for multiple requests	
			this.Bind<IRepository>().To<Repository>().InRequestScope();
		}
	}
}