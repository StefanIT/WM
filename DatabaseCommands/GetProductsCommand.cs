using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using EfCommands.Commands;
using EfCommands.DTOs;
using EfCommands.Response;

namespace DatabaseCommands
{
	public class GetProductsCommand : BaseCommand, IGetProductsCommand
	{
		public GetProductsCommand(productEntities _entities) : base(_entities)
		{
		}

		public PageResponse<ProductDto> Execute(product request)
		{
			var query = Entities.products
								.Join(Entities.product_manufacturer, p => p.product_id, pm => pm.product_id, (p, pm) => new { product = p,product_manufacturer = pm })
								.Join(Entities.manufacturers, m => m.product_manufacturer.manufacturer_id, pm => pm.manufacturer_id, (m, pm) => new { product = m, product_manufacturer = pm })
								.Join(Entities.categories, p => p.product.product.category_id, c => c.category_id, (p, c) => new { product = p, category = p })
								.AsQueryable();
								

			var totalRecords = query.Count();
			var response = new PageResponse<ProductDto>
			{
				TotalRecords = totalRecords,
				Data = query.Select(u => new ProductDto
				{
					Id = u.product.product.product.product_id,
					Price = u.product.product.product.price,
					CategoryName = u.product.product.product.category.category_name,
					Description = u.product.product.product.description,
					ProductName = u.product.product.product.name
				})
			};

			return response;
		}
	}
}
