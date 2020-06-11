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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Expense expenseFromDb = _expenseDatabase.GetExpense((int)id);

            ExpenseEditModel movie = new ExpenseEditModel()
            {
                Date = expenseFromDb.Date,
                Amount = expenseFromDb.Amount,
                Description = expenseFromDb.Description
            };

            return View(movie);
        }

        [HttpPost]
        public IActionResult Edit(int id, ExpenseEditModel expense)
        {
            if (!TryValidateModel(expense))
            {
                return View(expense);
            }

            _expenseDatabase.Update(id, new Expense()
            {
                Date = expense.Date,
                Amount = expense.Amount,
                Description = expense.Description
            });

            return RedirectToAction("Detail", new { Id = id });

        }
    }
}
