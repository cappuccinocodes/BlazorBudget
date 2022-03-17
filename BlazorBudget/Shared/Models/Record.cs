using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorBudget.Shared.Models
{
    public class Record
    {
        public int RecordId { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public string Name { get; set; } = null!;
        public decimal Value { get; set; } 
    }
}
