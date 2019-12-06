using EfApplication.DTOs;
using EfApplication.DTOs.Create;
using EfApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.Commands
{
	public interface IGetProductCommand : ICommand<int,CreateProductDto>
	{
	}
}
