using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Dictionary<int, BankAccount> accounts = new Dictionary<int, BankAccount>();
        string commands;

        while ((commands = Console.ReadLine()) != "End")
        {
            string[] command = commands.Split();
            int accountId = int.Parse(command[1]);

            switch (command[0])
            {
                case "Create":
                    if (accounts.ContainsKey(accountId))
                    {
                        Console.WriteLine("Account already exists");
                    }
                    else
                    {
                        accounts.Add(accountId, new BankAccount { Id = accountId });
                    }
                    break;
                case "Deposit":
                    if (ValidateAccountExists(accountId, accounts))
                    {
                        int deposit = int.Parse(command[2]);
                        accounts[accountId].Deposit(deposit);
                    }
                    break;
                case "Withdraw":
                    if (ValidateAccountExists(accountId, accounts))
                    {
                        int withdraw = int.Parse(command[2]);
                        accounts[accountId].Withdraw(withdraw);
                    }
                    break;
                case "Print":
                    if (ValidateAccountExists(accountId, accounts))
                    {
                        Console.WriteLine(accounts[accountId]);
                    }
                    break;
            }
        }
    }

    static bool ValidateAccountExists(int accountId, Dictionary<int, BankAccount> accounts)
    {
        if (accounts.ContainsKey(accountId))
        {
            return true;
        }
        else
        {
            Console.WriteLine("Account does not exist");
            return false;
        }
    }
}

