using EfApplication.DTOs;
using EfApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace EfApplication.Commands
{
    public interface IGetProductsCommand : ICommand<List<ProductDto>>
    {
    }
}
