using ExpenseWeb.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Database
{
    public interface IExpenseDatabase
    {
        Expense Insert(Expense contact);
        IEnumerable<Expense> GetExpense();
        Expense GetExpense(int id);
        void Delete(int id);
        //void Update(int id, Expense updatedContact);
    }

    public class ExpenseDatabase : IExpenseDatabase
    {
        private int _counter;
        private readonly List<Expense> _Expense;

        public ExpenseDatabase()
        {
            if (_Expense == null)
            {
                _Expense = new List<Expense>();
            }
        }

        public Expense GetExpense(int id)
        {
            return _Expense.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Expense> GetExpense()
        {
            return _Expense;
        }

        public Expense Insert(Expense Expense)
        {
            _counter++;
            Expense.Id = _counter;
            _Expense.Add(Expense);
            return Expense;
        }

        public void Delete(int id)
        {
            var contact = _Expense.SingleOrDefault(x => x.Id == id);
            if (contact != null)
            {
                _Expense.Remove(contact);
            }
        }

        //public void Update(int id, Expense updatedExpense)
        //{
        //    var Expense = _Expense.SingleOrDefault(x => x.Id == id);
        //    if (Expense != null)
        //    {
        //        Expense.FirstName = updatedExpense.FirstName;
        //        Expense.LastName = updatedExpense.LastName;
        //        Expense.Email = updatedExpense.Email;
        //        Expense.BirthDate = updatedExpense.BirthDate;
        //        Expense.Description = updatedExpense.Description;
        //        Expense.PhoneNumber = updatedExpense.PhoneNumber;
        //        Expense.Addres = updatedExpense.Addres;
        //        Expense.PhotoUrl = updatedExpense.PhotoUrl;
        //    }
        //}
    }
}
