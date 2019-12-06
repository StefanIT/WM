using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs.Create;
using EfApplication.Interfaces;

namespace EfApplication.EfCommands
{
	public class EfAddProductManufacturersCommand : BaseEfCommand
	{
		public EfAddProductManufacturersCommand(WMContext context):base(context)
		{
		}

		public void Execute(CreateProductDto request,int productId)
		{
			var productManufacturer = new List<ProductManufacturer>();
			request.ManufacturerId.ForEach(x => productManufacturer.Add(new ProductManufacturer
			{
				manufacturer_id = x,
				product_id = productId
			}));

			Context.ProductManufacturers.AddRange(productManufacturer);
		}
	}
}
