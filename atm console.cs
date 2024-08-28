using System;
namespace ATMSystem
{
    class ATM                  //Atm Class
    {
        private decimal balance;     // encapsulation
        private string pin;

        public ATM(decimal initialBalance, string initialPin)           // Constructor
        {
            balance = initialBalance;
            pin = initialPin;
        }

        public bool ValidatePIN(string inputPin)      // function

        {
            return pin == inputPin;                 // validatePin : it checks the user entered pin matches then it store into the account.
        }

        public void Deposit(decimal amount)            //Deposit :this func add money to the account.
        {
            if (amount > 0)                                  // it allows deposits if the amount is positive.
            {
                balance += amount;
                Console.WriteLine("Deposit Successful.");    
            }
            else
            {
                Console.WriteLine("Invalid Amount.");
            }
        }

        public void Withdraw(decimal amount)         //withdraw:this func allows users to withdraw money from the atm.
        {
            if (amount > 0 && amount <= balance)      //it checks the both conditions are true then money will be withdraw.
            {
                balance -= amount;
                Console.WriteLine("Withdrawal Successful.");
            }
            else
            {
                Console.WriteLine("Insufficient Balance");
            }
        }

        public void CheckBalance()                   // check Balance: this func used to check current balance.
        {
            Console.WriteLine($"Current Balance: {balance:C}"); 
        }
    }

    class Program                       //Main Class
    {
        static void Main(string[] args)
        {
            ATM atm = new ATM(1000, "1234");

            Console.WriteLine("Welcome to the ATM!");         // user interaction
            Console.Write("Enter your PIN: ");
            string inputPin = Console.ReadLine();     // this line captures the users input and store it in the inputpin variable. 


            if (atm.ValidatePIN(inputPin))       //pin validation (control stmt)
            {
                bool exit = false;
                while (!exit)            // while loop(controlling looping)
                {
                    Console.WriteLine("\n1. Check Balance\n2. Deposit\n3. Withdraw\n4. Exit");
                    Console.Write("Choose an option: ");
                    int choice = Convert.ToInt32(Console.ReadLine());

                    switch (choice)           // atm memu (controlling branching)
                    {
                        case 1:
                            atm.CheckBalance();
                            break;
                        case 2:
                            Console.Write("Enter amount to deposit: ");
                            decimal depositAmount = Convert.ToDecimal(Console.ReadLine());
                            atm.Deposit(depositAmount);
                            break;
                        case 3:
                            Console.Write("Enter amount to withdraw: ");
                            decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                            atm.Withdraw(withdrawAmount);
                            break;
                        case 4:
                            exit = true;
                            Console.WriteLine("Thank you for using the ATM. Goodbye!");
                            break;
                        default:
                            Console.WriteLine("Invalid choice. Please try again.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid PIN.");   //Error handling
            }
        }
    }
}
