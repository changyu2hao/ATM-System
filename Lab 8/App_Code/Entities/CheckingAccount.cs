using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class CheckingAccount:Account
    {
        public static double MaxWithdrawAmount = 300.0;
        private string customer;

        public CheckingAccount(Customer owner)
            :base(owner)
        {
            Owner = owner;
        }//constructor


        //public CheckingAccount(string customer)
        //{
        //    this.customer = customer;
        //}

        public override Enums.TransactionResult transact(Transaction transaction)
        {
            if(transaction.Type==Enums.TransactionType.WITHDRAW)
            {
                if (Owner.Status == Enums.CustomerStatus.REGULAR)
                {
                    if (transaction.Amount > MaxWithdrawAmount)
                    {
                        return Enums.TransactionResult.EXCEED_MAX_WITHDRAW_AMOUNT;
                    }
                    
                }
                
            }
            
                return base.transact(transaction);
            
            
        }

    }
}
