using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Models
{
    public class ExpenseIndexModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Decimal Amount { get; set; }
    }
}
