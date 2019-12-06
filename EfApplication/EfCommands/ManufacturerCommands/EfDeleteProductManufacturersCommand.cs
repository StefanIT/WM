using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfApplication.DataAccess;
using EfApplication.DTOs.Create;

namespace EfApplication.EfCommands.ManufacturerCommands
{
	public class EfDeleteProductManufacturersCommand : BaseEfCommand
	{
		public EfDeleteProductManufacturersCommand(WMContext context) : base(context)
		{
		}

		public void RemoveExistingProductManufacturers(CreateProductDto request)
		{
			var productManufacturers = Context.ProductManufacturers.Where(x => x.product_id == request.Id).ToList();
			Context.ProductManufacturers.RemoveRange(productManufacturers);
		}
	}
}
