﻿using System;

public class BankAccount
{
    private int id;

    public int Id
    {
        get { return id; }
        set { id = value; }
    }

    private decimal balance;

    public decimal Balance
    {
        get { return balance; }
        set { balance = value; }
    }

    public void Deposit(decimal amount)
    {
        Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (Balance < amount)
        {
            Console.WriteLine("Insufficient balance");
        }
        else
        {
            Balance -= amount;
        }
    }

    public override string ToString()
    {
        return $"Account ID{Id}, balance {Balance:f2}";
    }
}

