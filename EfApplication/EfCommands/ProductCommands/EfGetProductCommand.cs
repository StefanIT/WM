using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs;
using EfApplication.DTOs.Create;
using EfApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.EfCommands
{
	public class EfGetProductCommand : BaseEfCommand, IGetProductCommand
	{
		public EfGetProductCommand(WMContext context):base(context)
		{
			Suppliers = new EfGetProductSuppliers(context);
			Manufacturers = new EfGetProductManufacturers(context);
		}

		private EfGetProductSuppliers Suppliers { get; }
		private EfGetProductManufacturers Manufacturers { get; }

		public CreateProductDto Execute(int productId)
		{
			try
			{
				var query = Context.Products
								   .Where(p => p.product_id == productId)
								   .FirstOrDefault();

				return new CreateProductDto {
					CategoryId = query.Category.category_id,
					Description = query.description,
					ManufacturerId = Manufacturers.GetProductManufacturers(query).Select(m => m.manufacturer_id).ToList(),
					Price = query.price,
					Id = query.product_id,
					Name = query.name,
					SupplierId = Suppliers.GetProductSuppliers(query).Select(s => s.supplier_id).ToList()
				};
			}
			catch (CustomException e)
			{
				throw new CustomException("Doslo je do greske prilikom konekcije!");
			}
		}
	}
}
