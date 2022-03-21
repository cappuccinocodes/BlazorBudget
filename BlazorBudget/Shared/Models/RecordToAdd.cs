using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBudget.Shared.Models
{
    public class RecordToAdd
    {
        public int RecordId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [Range(0.01, int.MaxValue, ErrorMessage = "Please enter a value bigger than {1}")]
        public decimal Value { get; set; } 
    }
}
