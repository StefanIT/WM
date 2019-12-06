using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs;
using EfApplication.DTOs.Create;
using EfApplication.EfCommands.ManufacturerCommands;
using EfApplication.EfCommands.SupplierCommands;
using EfApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.EfCommands
{
	public class EfEditProductCommand : BaseEfCommand, IEditProductCommand
	{
		public EfEditProductCommand(WMContext context):base(context)
		{
			Manufacturers = new EfAddProductManufacturersCommand(context);
			Suppliers = new EfAddProductSuppliersCommand(context);
			DeleteSuppliers = new EfDeleteProductSuppliersCommand(context);
			DeleteManufacturers = new EfDeleteProductManufacturersCommand(context);
		}

		private EfAddProductSuppliersCommand Suppliers { get; }
		private EfAddProductManufacturersCommand Manufacturers { get; }

		private EfDeleteProductSuppliersCommand DeleteSuppliers { get; }
		private EfDeleteProductManufacturersCommand DeleteManufacturers { get; }
		public void Execute(CreateProductDto request)
		{
			try
			{
				var query = Context.Products
								   .Where(p => p.product_id == request.Id)
								   .FirstOrDefault();

				query.category_id = request.CategoryId;
				query.description = request.Description;
				query.name = request.Name;
				query.price = request.Price;


				DeleteManufacturers.RemoveExistingProductManufacturers(request);
				DeleteSuppliers.RemoveExistingProductSuppliers(request);
				Context.SaveChanges();

				Manufacturers.Execute(request, (int)request.Id);
				Suppliers.Execute(request, (int)request.Id);
				Context.SaveChanges();
			}
			catch (CustomException e)
			{
				throw new CustomException("Doslo je do greske prilikom konekcije!");
			}
		}
	}
}
