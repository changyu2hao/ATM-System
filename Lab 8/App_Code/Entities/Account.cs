using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class Account
    {
        public Customer Owner { get; set; }
        public double Balance { get; set; }

        public List<Transaction> TransactionHistory;

        public Account(Customer name)
        {

            this.Owner = name;
            TransactionHistory = new List<Transaction>();
        }//constructor

        public Account(Customer name,double money)
        {
            this.Owner = name;
            Balance = money;
            TransactionHistory = new List<Transaction>();
            if (Balance>2000)
            {
                Owner.Status = Enums.CustomerStatus.PREMIER;
            }
            else
            {
                Owner.Status = Enums.CustomerStatus.REGULAR;
            }
        }

        public virtual Enums.TransactionResult transact(Transaction transaction)
        {
            if(transaction.Type == Enums.TransactionType.DEPOSIT||transaction.Type==Enums.TransactionType.TRANSFER_IN)
            {
                Balance += transaction.Amount;

                TransactionHistory.Add(transaction);

                return Enums.TransactionResult.SUCCESS;
            }

            if(transaction.Type == Enums.TransactionType.WITHDRAW|| transaction.Type == Enums.TransactionType.TRANSFER_OUT)
            {
                if (Balance >= transaction.Amount)
                {
                    Balance -= transaction.Amount;

                    TransactionHistory.Add(transaction);

                    return Enums.TransactionResult.SUCCESS;
                }

                else
                {
                    return Enums.TransactionResult.INSUFFIVIENT_FUND;
                }
            }
            else
            {
                return Enums.TransactionResult.SUCCESS;
            }
            
        }             
    }
}
