using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using Ninject.Extensions.Wcf;

namespace WcfRestService1.NinjectWcf
{
	// WCF Rest uses WebServiceHost but the 2.2 Ninject WCF Extensions uses ServiceHost so we need to provide our
	// own implementaiton.  This same functionality is provided by the latest version of the Ninject WCF Extension so this 
	// can be deleted once that comes out.
	public class NinjectWebServiceHost : WebServiceHost
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="NinjectWebServiceHost"/> class.
		/// </summary>
		public NinjectWebServiceHost()
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NinjectWebServiceHost"/> class.
		/// </summary>
		/// <param name="serviceType">Type of the service.</param>
		public NinjectWebServiceHost(TypeCode serviceType)
			: base(serviceType)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NinjectWebServiceHost"/> class.
		/// </summary>
		/// <param name="singletonInstance">The singleton instance.</param>
		public NinjectWebServiceHost(object singletonInstance)
			: base(singletonInstance)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="NinjectWebServiceHost"/> class.
		/// </summary>
		/// <param name="serviceType">Type of the service.</param>
		/// <param name="baseAddresses">The base addresses.</param>
		public NinjectWebServiceHost(Type serviceType, params Uri[] baseAddresses)
			: base(serviceType, baseAddresses)
		{
		}

		/// <summary>
		/// Invoked during the transition of a communication object into the opening state.
		/// </summary>
		protected override void OnOpening()
		{
			Description.Behaviors.Add(new NinjectServiceBehavior());
			base.OnOpening();
		}
	}
}