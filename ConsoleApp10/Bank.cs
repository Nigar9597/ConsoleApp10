using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp10
{
    class Bank
    {
        private BankAccount[] _bankAccounts = new BankAccount[0];

        public BankAccount[] BankAccounts
        {
            get
            {
                return _bankAccounts;
            }
        }

        public void Add(BankAccount bankAccount)
        {
            Array.Resize(ref _bankAccounts, _bankAccounts.Length + 1);
            _bankAccounts[_bankAccounts.Length - 1] = bankAccount;
            Console.WriteLine($"Hesab əlavə olundu: {bankAccount.OwnerName}");
        }

        public BankAccount GetBankAccountByOwner(string ownerName)
        {
            foreach (var account in _bankAccounts)
            {
                if (account.OwnerName == ownerName)
                    return account;
            }
            Console.WriteLine("Account tapılmadı!");
            return null;
        }

        public int GetBankAccountsCount()
        {
            return _bankAccounts.Length;
        }

        public void DeleteBankAccount(int accountNumber)
        {
            for (int i = 0; i < _bankAccounts.Length; i++)
            {
                if (accountNumber == _bankAccounts[i].AccountNumber)
                {
                    (_bankAccounts[i], _bankAccounts[_bankAccounts.Length - 1]) = (_bankAccounts[_bankAccounts.Length - 1], _bankAccounts[i]);
                    Array.Resize(ref _bankAccounts, _bankAccounts.Length - 1);
                    Console.WriteLine("Account silindi.");
                    return;
                }
            }
            Console.WriteLine("Account tapılmadı.");
        }
    }
}
