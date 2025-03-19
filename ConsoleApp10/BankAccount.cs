using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class BankAccount
    {
        private decimal balance;
        public decimal Balance { get; }
        public string AccountNumber { get; }
        public string OwnerName { get; set; }

        public BankAccount(decimal balans)
        {
            
        }
        public void Deposit(decimal amount)
        {if(amount<=0)
            {
                Console.WriteLine("mebleg musbet olmalidir");
            }
            else if(amount>=0)
            {
                balance += amount;
                Console.WriteLine("hesaba mebleg elave edildi");
            }

            

        }
         public void WithDraw(decimal amount)
        {
            if(amount<=0)
            {
                Console.WriteLine( "cixarilan mebleg musbet olmalidir");
                       
             }
            else if(amount>balance)
            {
                Console.WriteLine("balansda kifayet qeder mebleg yoxdur");
            }

            else
            {
                balance -= amount;
                Console.WriteLine($"{amount} cixarildi, cari balans: {balance}");
            }
        }  
       
        public void DisplayAcoountInfo()
        {
            Console.WriteLine($"account number:{AccountNumber}");
            Console.WriteLine($"owner name: {OwnerName}");
            Console.WriteLine($"balance:{balance}");
        }

        public void TransferFunds(BankAccount recipient, decimal amount)

        {
            if (amount > 0 && amount <= balance)
            {
                balance -= amount;
                recipient.balance+=amount;
                Console.WriteLine($"{amount} AZN kocuruldu {recipient.OwnerName}.");
            }
            else
            {
                Console.WriteLine("pul transferi mumkun deyil.");
            }
        }
    }
}
