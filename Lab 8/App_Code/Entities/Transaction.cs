using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class Transaction
    {
       public double Amount { get; set; }

        public Enums.TransactionType Type { get; set; }

        public DateTime TransactionDate{ get; set; }

        public double realamout { get; set; }

        public Transaction(double Amount, Enums.TransactionType Type)
        {

            this.Amount = Amount;

            this.Type = Type;

            TransactionDate = DateTime.Now;

        }//constructor
        public Transaction(double Amount,double penalty, Enums.TransactionType Type)
        {
            this.realamout = Amount;

            this.Amount = penalty;

            this.Type = Type;

            TransactionDate = DateTime.Now;

        }//constructor
    }
}
