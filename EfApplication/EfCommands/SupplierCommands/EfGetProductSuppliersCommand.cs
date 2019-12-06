using EfApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.EfCommands
{
	public class EfGetProductSuppliers : BaseEfCommand
	{
		public EfGetProductSuppliers(WMContext context):base(context)
		{
		}

		public IEnumerable<Supplier> GetProductSuppliers(Product product)
		{
			return product.ProductSuppliers.Join(Context.Suppliers, ps => ps.supplier_id, s => s.supplier_id, (ps, s) => new { Supplier = s }).Select(s => s.Supplier);
		}
	}
}
