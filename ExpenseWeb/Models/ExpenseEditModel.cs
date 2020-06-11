using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpenseEditModel
    {
        public string Description { get; set; }
        public DateTime Date { get; set; }
        [Range(1, Int32.MaxValue)]
        public Decimal Amount { get; set; }
    }
}
