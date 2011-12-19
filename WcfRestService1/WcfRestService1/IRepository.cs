using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestService1
{
	public interface IRepository
	{
		List<SampleItem> GetCollection();
	}
}