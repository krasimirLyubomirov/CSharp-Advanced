using System;
using System.Collections.Generic;
using System.Linq;

namespace SoftUniParty
{
    class Program
    {
        private const int GuestLength = 8;

        static void Main(string[] args)
        {
            List<string> regularGuest = new List<string>();
            List<string> vipGuest = new List<string>();

            string guest;
            while ((guest = Console.ReadLine()) != "PARTY")
            {
                if (vipGuest.Contains(guest) == false && Char.IsDigit(guest[0]) && guest.Length == GuestLength)
                {
                    vipGuest.Add(guest);
                }
                else if (regularGuest.Contains(guest) == false && guest.Length == GuestLength)
                {
                    regularGuest.Add(guest);
                }
            }

            guest = Console.ReadLine();
            while (guest != "END")
            {
                if (vipGuest.Contains(guest))
                {
                    vipGuest.Remove(guest);
                }

                if (regularGuest.Contains(guest))
                {
                    regularGuest.Remove(guest);
                }

                guest = Console.ReadLine();
            }


            Console.WriteLine(vipGuest.Count + regularGuest.Count);
            foreach (var vip in vipGuest)
            {
                Console.WriteLine(vip);
            }

            foreach (var regular in regularGuest)
            {
                Console.WriteLine(regular);
            }
        }
    }
}
