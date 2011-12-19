using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using Ninject;
using Ninject.Activation.Caching;
using Ninject.Extensions.Wcf;
using WcfRestService1.NinjectWcf;

namespace WcfRestService1
{
	// We replace HttpApplication with NinjectWcfApplication so Ninject can handle the activation and deactivation of
	// services using the Ninjection kernel for reach request for us.  
	//public class Global : HttpApplication
	public class Global : NinjectWcfApplication
	{
		private readonly OnePerRequestModule onePerRequestModule;

		public Global()
		{
			// We create an instance of OnePerRequestModule and initialize it with our HttpApplication so it can handle
			// deactivation of instances created via the Kernel when the Http request is done
			this.onePerRequestModule = new OnePerRequestModule();
			this.onePerRequestModule.Init(this);
		}

		// NinjectHttpApplication needs to do some initialization and it does this by hooking the Application_Started
		// method for us.  When usiong NinjectHttpApplication, move any code you would put in Application_Started
		// to the OnApplicationStarted method below.
		/*
		void Application_Start(object sender, EventArgs e)
		{
			RegisterRoutes();
		}
		 * */

		// OnApplicationStarted is a virtual method provided by NinjectWcfApplication so you can do startup logic that you
		// would normally do in Application_Started.  One nice side effect of this is that you can use the Ninject Kernel
		// to resolve services that might be needed during application startup.
		protected override void OnApplicationStarted()
		{
			RegisterRoutes();
		}

		// Since Ninject depends on a Kernel with the appropriate bindings, NinjectHttpApplication gets this from us
		// via the abstract method CreateKernel.  
		protected override IKernel CreateKernel()
		{
			// The actual bindings are provided via ServiceModule.  Alternatively, we could call the StandardKernel overload that finds
			// NinjectModules based on paths to assemblies, etc.
			return new StandardKernel(new ServiceModule());
		}

		private void RegisterRoutes()
		{
			// We replace WebServiceHostFactory with NinjectWebServiceHostFactory so Ninject can handle creation of
			// the services using the Ninjection kernel for each inbound request.
			//RouteTable.Routes.Add(new ServiceRoute("Service1", new WebServiceHostFactory(), typeof(Service1)));
			RouteTable.Routes.Add(new ServiceRoute("Service1", new NinjectWebServiceHostFactory(), typeof(Service1)));
		}
	}
}
