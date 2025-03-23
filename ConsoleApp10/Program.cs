using System.Security.Principal;
using System.Transactions;

namespace ConsoleApp10
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Balans ne qeder olacaq?");
            decimal balans = Convert.ToDecimal(Console.ReadLine());
            Console.WriteLine("Acoount numberi daxil edin");
            int accountnumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("OwnerName'i daxil edin");
            string ownerName = Console.ReadLine();
            Bank bank = new Bank();
            BankAccount bankAccount1 = new BankAccount(balans, accountnumber, ownerName);
            BankAccount bankAccount2 = new BankAccount(0, 123, "Nigar");
            bank.Add(bankAccount1);
            bank.Add(bankAccount2);
            string userAnswer = "";
            while (userAnswer != "0")
            {
                Console.WriteLine("Hansi emeliyyati icra etmek isteyirsen?");
                Console.WriteLine("1. Deposit\r\n2. Withdraw\r\n3. AccountInfo\r\n4. Change OwnerName\r\n5. TransferFunds\r\n6. Show Total Accounts\r\n7. Delete Account\r\n0. Quit Application ");
                userAnswer = Console.ReadLine();

                switch (userAnswer)
                {
                    case "1":
                        Console.WriteLine("Deposit elave etmek istediyiniz meblegi qeyd edin:");
                        decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                        bankAccount1.Deposit(depositAmount);
                        break;
                    case "2":
                        Console.WriteLine("Cixarmaq istediyiniz meblegi yazin");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        bankAccount1.WithDraw(withdrawAmount);
                        break;
                    case "3":
                        Console.Write("Hesab sahibinin adını daxil edin: ");
                        string infoName = Console.ReadLine();
                        BankAccount account = bank.GetBankAccountByOwner(infoName);
                        account.DisplayAcoountInfo();
                        break;
                    case "4":
                        Console.Write("Hesab sahibinin teze adını daxil edin: ");
                        string name = Console.ReadLine();
                        bankAccount1.OwnerName = name;
                        break;
                    case "5":
                        Console.WriteLine("kocurmeni qebul edecek hesabi qeyd edin");
                        string recipientName = Console.ReadLine();

                        Console.WriteLine("transfer etmek istediyiniz meblegi daxil edin");
                        decimal transferfundsAmount = Convert.ToDecimal(Console.ReadLine());

                        BankAccount recipient = bank.GetBankAccountByOwner(recipientName);

                        bankAccount1.TransferFunds(recipient, transferfundsAmount);
                        break;
                    case "6":
                        Console.WriteLine(bank.GetBankAccountsCount());
                        break;
                    case "7":
                        Console.Write("silmek istediyiniz hesabin account numberini daxil edin");
                        int accountNumber = Convert.ToInt32(Console.ReadLine());
                        bank.DeleteBankAccount(accountNumber);
                        break;
                    default:
                        Console.WriteLine("Sehv sechim etdin, yeniden sec");
                        break;
                }

            }
        }

    }
}