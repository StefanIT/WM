using EfApplication.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.EfCommands
{
	public class EfGetProductManufacturers : BaseEfCommand
	{
		public EfGetProductManufacturers(WMContext context):base(context)
		{
		}

		public IEnumerable<Manufacturer> GetProductManufacturers(Product product)
		{
			return product.ProductManufacturers.Join(Context.Manufacturers, pm => pm.manufacturer_id, m => m.manufacturer_id, (pm, m) => new { Manufacturer = m }).Select(m => m.Manufacturer);
		}
	}
}
