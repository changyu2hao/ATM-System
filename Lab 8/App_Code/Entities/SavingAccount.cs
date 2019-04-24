using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class SavingAccount:Account
    {
        public static double PrimierAmount = 2000.0;

        public static double WithdrawPenaltyAmount = 10.0;
        private string customer;

        //public Enums.CustomerStatus Status { get; set; }

        public SavingAccount(Customer owner)
            :base(owner)
        {
            Owner = owner;
        }

        //public SavingAccount(string customer)
        //{
        //    this.customer = customer;
        //}

        public SavingAccount(Customer owner,double money):base(owner,money)
        {
            //Owner = owner;
            //Balance = money;
            if (Balance >= PrimierAmount)
            {
                Owner.Status = Enums.CustomerStatus.PREMIER;
            }
            else
            {
                Owner.Status = Enums.CustomerStatus.REGULAR;
            }
        }
        //constructor
        public override Enums.TransactionResult transact(Transaction transaction)
        {
            if (transaction.Type == Enums.TransactionType.DEPOSIT|| transaction.Type == Enums.TransactionType.TRANSFER_IN)
            {
                base.transact(transaction);
                if (Balance >= PrimierAmount)
                {
                    Owner.Status = Enums.CustomerStatus.PREMIER;

                    //return Enums.TransactionResult.SUCCESS;
                }
                else
                {
                    Owner.Status = Enums.CustomerStatus.REGULAR;

                    //return Enums.TransactionResult.SUCCESS;
                }
                return Enums.TransactionResult.SUCCESS;
            }

            else if (transaction.Type == Enums.TransactionType.WITHDRAW)
            {
                Entities.Enums.TransactionResult result1 = base.transact(transaction);
                if (result1 == Enums.TransactionResult.INSUFFIVIENT_FUND)
                {
                    return Enums.TransactionResult.INSUFFIVIENT_FUND;
                }
                else
                {
                    if (Balance >= PrimierAmount)
                    {
                        Owner.Status = Enums.CustomerStatus.PREMIER;

                        //return Enums.TransactionResult.SUCCESS;
                    }

                    else
                    {
                        Owner.Status = Enums.CustomerStatus.REGULAR;
                        if (Balance + transaction.Amount < PrimierAmount)
                        {
                            Balance -= WithdrawPenaltyAmount;
                        }
                        //return Enums.TransactionResult.SUCCESS;
                    }
                    return Enums.TransactionResult.SUCCESS;
                }

            }
            else if(transaction.Type == Enums.TransactionType.TRANSFER_OUT)
            {
                Entities.Enums.TransactionResult result1 = base.transact(transaction);
                if (result1 == Enums.TransactionResult.INSUFFIVIENT_FUND)
                {
                    return Enums.TransactionResult.INSUFFIVIENT_FUND;
                }
                else
                {
                    if (Balance >= PrimierAmount)
                    {
                        Owner.Status = Enums.CustomerStatus.PREMIER;

                        //return Enums.TransactionResult.SUCCESS;
                    }

                    else
                    {
                        Owner.Status = Enums.CustomerStatus.REGULAR;                       
                        //return Enums.TransactionResult.SUCCESS;
                    }
                    return Enums.TransactionResult.SUCCESS;
                }
            }

            else if (transaction.Type == Enums.TransactionType.PENALTY)
            {
                if (Balance + transaction.realamout < PrimierAmount)
                {
                    TransactionHistory.Add(transaction);
                }
                return Enums.TransactionResult.SUCCESS;
            }
            else
            {
                return base.transact(transaction);
            }
        }       
    }
}
