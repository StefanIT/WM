using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EfApplication.DataAccess;
using EfApplication.DTOs.Create;

namespace EfApplication.EfCommands.SupplierCommands
{
	public class EfDeleteProductSuppliersCommand : BaseEfCommand
	{
		public EfDeleteProductSuppliersCommand(WMContext context) : base(context)
		{
		}

		public void RemoveExistingProductSuppliers(CreateProductDto request)
		{
			var productSuppliers = Context.ProductSuppliers.Where(x => x.product_id == request.Id).ToList();
			Context.ProductSuppliers.RemoveRange(productSuppliers);
		}
	}
}
