using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs.Create;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.EfCommands
{
    public class EfAddProductCommand : BaseEfCommand, IAddProductCommand
    {
        public EfAddProductCommand(WMContext context):base(context)
        {
			Manufacturers = new EfAddProductManufacturersCommand(context);
			Suppliers = new EfAddProductSuppliersCommand(context);
        }

		private EfAddProductManufacturersCommand Manufacturers { get; }
		private EfAddProductSuppliersCommand Suppliers { get; }
		public void Execute(CreateProductDto request)
        {
			Product product = CreateNewProduct(request);

			var productId = product.product_id;
			Manufacturers.Execute(request, productId);
			Suppliers.Execute(request, productId);
			Context.SaveChanges();
		}

		#region Dodavanje proizvoda
		private Product CreateNewProduct(CreateProductDto request)
		{
			var product = new Product
			{
				category_id = request.CategoryId,
				description = request.Description,
				name = request.Name,
				price = request.Price
			};

			Context.Products.Add(product);
			Context.SaveChanges();
			return product;
		}
		#endregion
	}
}
