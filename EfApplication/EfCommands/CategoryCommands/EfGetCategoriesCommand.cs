using EfApplication.Commands;
using EfApplication.DataAccess;
using EfApplication.DTOs;
using EfApplication.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.EfCommands
{
    public class EfGetCategoriesCommand : BaseEfCommand, IGetCategoriesCommand
    {
        public EfGetCategoriesCommand(WMContext context):base(context)
        {

        }

        public List<CategoryDto> Execute()
        {
            try
            {
                var query = Context.Categories.AsQueryable();

                return query.Select(x => new CategoryDto
                {
                    CategoryId = x.category_id,
                    CategoryName = x.category_name
                }).ToList();
            }
            catch (CustomException e)
            {
                throw new CustomException("Doslo je do greske prilikom konekcije!");
            }
        }
    }
}
