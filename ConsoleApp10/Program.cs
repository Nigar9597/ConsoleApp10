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
            BankAccount bankAccount1 = new BankAccount(balans);
            string userAnswer = "";

            while (userAnswer != "0")
            {
                Console.WriteLine("Hansi emeliyyati icra etmek isteyirsen?");
                Console.WriteLine("1. Deposit\r\n  2. Withdraw\r\n  3. AccountInfo\r\n  4. Change OwnerName\r\n  5. TransferFunds\r\n  0. Quit Application");
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
                    case "5":
                        Console.WriteLine("transfer etmek istediyiniz meblegi daxil edin");
                        decimal transferfundsAmount = Convert.ToDecimal(Console.ReadLine());
                        bankAccount1.TransferFunds(transferfundsAmount);
                        break;

                    default:
                        Console.WriteLine("Sehv sechim etdin, yeniden sec");
                        break;
                }

            }

        }
    }
}
