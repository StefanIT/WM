using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs;
using EfApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace EfApplication.EfCommands
{
	public class EfGetProductsCommand : BaseEfCommand, IGetProductsCommand
	{
		public EfGetProductsCommand(WMContext context) : base(context)
		{
			Suppliers = new EfGetProductSuppliers(context);
			Manufacturers = new EfGetProductManufacturers(context);
		}

		private EfGetProductSuppliers Suppliers { get; }
		private EfGetProductManufacturers Manufacturers { get; }

		public List<ProductDto> Execute()
		{
			try
			{
				var query = Context.Products.AsQueryable();

				return query.Select(x => new ProductDto
				{
					CategoryName = x.Category.category_name,
					Description = x.description,
					ManufacturerName = string.Join(",", Manufacturers.GetProductManufacturers(x).Select(m => m.manufacturer_name)),
					Price = x.price,
					ProductId = x.product_id,
					ProductName = x.name,
					SupplierName = string.Join(",", Suppliers.GetProductSuppliers(x).Select(s => s.supplier_name))
				}).ToList();
			}
			catch (CustomException e)
			{
				throw new CustomException("Doslo je do greske prilikom konekcije!");
			}
		}
	}
}
