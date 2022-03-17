using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBudget.Shared.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        
        [Required]
        public string Name { get; set; } = null!;

        public IEnumerable<Record> Records { get; set; } 
    }
}
