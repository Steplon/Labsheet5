using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5_BankAccount
{
    public class BankAccount
    {
        //properties
        protected int AcountNumber { get; set; }
        protected int SortCode { get; set; }
        protected string Name { get; set; }
        protected decimal Balance { get; set; }



        //constructors
        public BankAccount()
        {

        }

        public BankAccount(int acc_num, int sort_code, string name, decimal balance)
        {
            AcountNumber = acc_num;
            SortCode = sort_code;
            Name = name;
            Balance = balance;
        }

        //methods
        public override string ToString()
        {
            return string.Format($"{AcountNumber} - {Name}\n");
        }


        public virtual string DisplayAccount()
        {
            return string.Format($"Name:\t\t{Name}\nSort Code:\t{SortCode}\nAccount Number:\t{AcountNumber}\nBalance:\t\t{Balance:C2}\n");

        }

        public void Withdraw(decimal amount)
        {
            Balance -= amount;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }
    }
}
