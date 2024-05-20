using System.Runtime.CompilerServices;
using System.Security.Principal;

namespace MultiUserBank_Engle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank BigPockets = new Bank();
            string User;
            string PW;
            Console.WriteLine("Bank cash on hand: " + BigPockets.BankBalance.ToString("C") + "\n");
            do
            {
                User = LogOn("ID");
                PW = LogOn("PW");
                if (BigPockets.LogIn(User, PW) == User)
                {
                    Console.Clear();
                    Welcome(BigPockets);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine(BigPockets.LogIn(User, PW));
                }
            } while (true);

        }
        static string LogOn(string validation)
        {
            Console.Write("What is your " + validation + "?\n" + validation + ": ");
            return Console.ReadLine();
        }
        static void Welcome(Bank Account)
        {
            ConsoleKeyInfo selection;
            Console.WriteLine("Welcome " + Account.LoggedIn() + ".");
            do {
                Console.WriteLine("\nWhat would you like to do?\n\n(1) Check balance\n(2) Deposit\n(3) Withdraw\n(4) Logging out");
                selection = Console.ReadKey();
                //Check balance
                if (selection.Key == ConsoleKey.D1 || selection.Key == ConsoleKey.NumPad1)
                {
                    Console.Clear();
                    Console.WriteLine(Account.Balance);
                }
                //Deposit
                else if (selection.Key == ConsoleKey.D2 || selection.Key == ConsoleKey.NumPad2)
                {
                    Console.Clear();
                    Console.Write("How much would you like to deposit?\n$");
                    string amount = Console.ReadLine();
                    Console.Clear();
                    Console.Write(Account.Deposit(amount));
                    Console.WriteLine(Account.Balance);
                }
                //Withdraw
                else if (selection.Key == ConsoleKey.D3 || selection.Key == ConsoleKey.NumPad3)
                {
                    Console.Clear();
                    Console.Write("How much would you like to withdraw?\n$");
                    string amount = Console.ReadLine();
                    Console.Clear();
                    Console.Write(Account.Withdraw(amount));
                    Console.WriteLine(Account.Balance);
                }
                //Log out
                else if (selection.Key == ConsoleKey.D4 || selection.Key == ConsoleKey.NumPad4)
                {
                    Console.Clear();
                    Console.WriteLine("Bank cash on hand: " + Account.BankBalance.ToString("C")+"\n");
                    break;
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input");
                }
            }while (true);
        }
    }
}