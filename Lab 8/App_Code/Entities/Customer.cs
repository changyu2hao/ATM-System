﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5Solution.Entities
{
    public class Customer
    {
        public string Name { get; set; }       
        
        public Enums.CustomerStatus Status { get; set; }
        public CheckingAccount Checking { get; set; }
        public SavingAccount Saving { get; set; }        
        public Customer(string name)
        {
            this.Name = name;
            //Saving = InitialMoney;
        }

    }
}
