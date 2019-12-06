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
    public class EfGetManufacturersCommand : BaseEfCommand, IGetManufacturersCommand
    {
        public EfGetManufacturersCommand(WMContext context):base(context)
        {

        }

        public List<ManufacturerDto> Execute()
        {
            try
            {
                var query = Context.Manufacturers.AsQueryable();

                return query.Select(x => new ManufacturerDto
                {
                    ManufacturerId = x.manufacturer_id,
                    ManufacturerName = x.manufacturer_name
                }).ToList();
            }
            catch (CustomException e)
            {
                throw new CustomException("Doslo je do greske prilikom konekcije!");
            }
        }
    }
}
