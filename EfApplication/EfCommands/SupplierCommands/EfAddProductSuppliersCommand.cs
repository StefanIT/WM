using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs.Create;

namespace EfApplication.EfCommands
{
	public class EfAddProductSuppliersCommand : BaseEfCommand
	{
		public EfAddProductSuppliersCommand(WMContext context):base(context)
		{
		}

		public void Execute(CreateProductDto request,int productId)
		{
			var suppliers = new List<ProductSupplier>();
			foreach(var supp in request.SupplierId)
			{
				var product = new ProductSupplier
				{
					supplier_id = supp,
					product_id = productId
				};

				suppliers.Add(product);
			}

			Context.ProductSuppliers.AddRange(suppliers);
		}
	}
}
