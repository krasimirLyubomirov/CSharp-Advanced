using System;

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        account.Id = 1;
        account.Balance = 15;
        Console.WriteLine(account);
    }
}

