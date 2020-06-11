using ExpenseWeb.Database;
using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Controllers
{
    public class ExpenseController : Controller
    {

        private readonly IExpenseDatabase _expenseDatabase;

        public ExpenseController(IExpenseDatabase ExpenseDatabase)
        {
            _expenseDatabase = ExpenseDatabase;
        }
        public IActionResult Index()
        {
            var Expense = _expenseDatabase.GetExpense().Select(item => new ExpenseIndexModel()
            {
                Id = item.Id,
                Date = item.Date,
                Amount = item.Amount
            });
            return View(Expense);
        }

        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(ExpenseCreateModel expense)
        {
            if (!TryValidateModel(expense))
            {
                return View(expense);
            }
            Expense newExpense = new Expense()
            {
                Description = expense.Description,
                Amount = expense.Amount,
                Date = expense.Date
            };

            _expenseDatabase.Insert(newExpense);

            return RedirectToAction("Index");
        }
    }
}
