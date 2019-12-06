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
    public class EfGetSuppliersCommand : BaseEfCommand, IGetSuppliersCommand
    {
        public EfGetSuppliersCommand(WMContext context):base(context)
        {

        }

        public List<SupplierDto> Execute()
        {
            try
            {
                var query = Context.Suppliers.AsQueryable();

                return query.Select(x => new SupplierDto
                {
                    SupplierId = x.supplier_id,
                    SupplierName = x.supplier_name
                }).ToList();
            }
            catch (CustomException e)
            {
                throw new CustomException("Doslo je do greske prilikom konekcije!");
            }
        }
    }
}
