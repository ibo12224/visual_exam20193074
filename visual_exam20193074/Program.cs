using System;
using System.Threading;
namespace visualexam6_14_2
{
    class Account
    {
        private double balance;
        public Account(double initialdeposit) { balance = initialdeposit; }
        public double Balance{
            get { return balance; }
            set { balance = value; }
        }
        public void Deposit(double amount)
        {
            lock (this)
            {
                balance += amount;
            }
        }
    }
    class Teller
    {
        string name;
        Account account;
        double amount;
        public Teller(string name, Account account, double amount)
        {
            this.name = name;
            this.account = account;
            this.amount = amount;
        }
        public void TellerTask()
        {
            account.Deposit(amount);
            Console.WriteLine(name + " : " + account.Balance);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Account acc = new Account(3);
            Teller tel = new Teller("nam", acc, 300);
            tel.TellerTask();
            acc.Balance = 100;
            tel.TellerTask();
            acc.Balance = 10;
            tel.TellerTask();
            Teller tl = new Teller("nad", acc, 100);
            tl.TellerTask();
            acc.Balance = 10;
            tl.TellerTask();

        }
    }
}
