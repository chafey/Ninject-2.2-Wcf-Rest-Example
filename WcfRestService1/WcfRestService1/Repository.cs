using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WcfRestService1
{
	public class Repository : IRepository
	{
	
		public List<SampleItem> GetCollection()
		{
			GC.Collect();
			return new List<SampleItem>() { new SampleItem() { Id = 1, StringValue = "Hello" } };
		}
	}
}