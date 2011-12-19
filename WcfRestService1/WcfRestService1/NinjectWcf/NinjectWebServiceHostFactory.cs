using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using Ninject;
using Ninject.Extensions.Wcf;
using Ninject.Parameters;

namespace WcfRestService1.NinjectWcf
{
	// WCF Rest uses WebServiceHostFactory but the 2.2 Ninject WCF Extensions uses ServiceHostFactory so we need to provide our
	// own implementation.  This same functionality is provided by the latest version of the Ninject WCF Extension so this can be 
	// deleted once that comes out.
	public class NinjectWebServiceHostFactory : WebServiceHostFactory
	{
		protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
		{
			var serviceTypeParameter = new ConstructorArgument("serviceType", serviceType);
			var baseAddressesParameter = new ConstructorArgument("baseAddresses", baseAddresses);
			return KernelContainer.Kernel.Get<NinjectWebServiceHost>(serviceTypeParameter, baseAddressesParameter);
		}

	}
}