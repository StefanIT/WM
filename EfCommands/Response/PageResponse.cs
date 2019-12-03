using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.Response
{
	public class PageResponse<T>
	{
		public int TotalRecords { get; set; }

		public IEnumerable<T> Data { get; set; }
	}
}
