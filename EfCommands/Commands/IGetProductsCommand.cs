using DataAccess;
using EfCommands.DTOs;
using EfCommands.Interfaces;
using EfCommands.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfCommands.Commands
{
	public interface IGetProductsCommand : ICommand<product, PageResponse<ProductDto>>
	{
	}
}
