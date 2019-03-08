using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise5_BankAccount
{
    public class SavingsAccount : BankAccount
    {
        //properties
        protected decimal SavingsRate { get; set; }


        //constructors
        public SavingsAccount()
        {

        }

        public SavingsAccount(int acc_num, int sort_code, string name, decimal balance, decimal savings_rate) 
            : base(acc_num,sort_code,name,balance)
        {
            SavingsRate = savings_rate;
        }

        //methods
        public override string DisplayAccount()
        {
            return base.DisplayAccount() + string.Format($"Savings Rate:\t{SavingsRate:P2}\n");
        }

        public void AddInterest()
        {
            Balance *= 1 + SavingsRate;
        }

    }
}
