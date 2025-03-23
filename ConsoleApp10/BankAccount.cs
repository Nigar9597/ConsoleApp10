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
        private decimal _balance;
        public decimal Balance
        {
            get { return _balance; }
        }
        private int _accountnumber;

        public int AccountNumber
        {
            get { return _accountnumber; }
        }

        public string OwnerName { get; set; }
        public BankAccount(decimal balance, int accountnumber, string ownerName)
        {
            if (balance >= 0)
                _balance = balance;
            _accountnumber = accountnumber;
            OwnerName = ownerName;
        }

        public void Deposit(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("mebleg musbet olmalidir");
            }
            else
            {
                _balance += amount;
                Console.WriteLine("hesaba mebleg elave edildi");
            }
        }
        public void WithDraw(decimal amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("cixarilan mebleg musbet olmalidir");
            }
            else if (amount > _balance)
            {
                Console.WriteLine("balansda kifayet qeder mebleg yoxdur");
            }
            else
            {
                _balance -= amount;
                Console.WriteLine($"{amount} cixarildi, cari balans: {_balance}");
            }
        }

        public void DisplayAcoountInfo()
        {
            Console.WriteLine($"account number:{AccountNumber}");
            Console.WriteLine($"owner name: {OwnerName}");
            Console.WriteLine($"balance:{_balance}");
        }

        public void TransferFunds(BankAccount recipient, decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                WithDraw(amount);
                recipient.Deposit(amount);
                Console.WriteLine($"{amount} AZN kocuruldu {recipient.OwnerName}.");
            }
            else
            {
                Console.WriteLine("pul transferi mumkun deyil.");
            }
        }
    }
}
