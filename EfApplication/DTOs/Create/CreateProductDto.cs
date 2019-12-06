using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EfApplication.DTOs.Create
{
    public class CreateProductDto
    {
        public int? Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
		[Display(Name = "Manufacturer")]
        public List<int> ManufacturerId { get; set; }
		[Display(Name = "Supplier")]
		public List<int> SupplierId { get; set; }
        [Required]
		[Display(Name = "Category")]
		public int CategoryId { get; set; }
    }
}
