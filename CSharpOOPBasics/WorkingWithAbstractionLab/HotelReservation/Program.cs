namespace HotelReservation
{
    using System;

    class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            PriceCalculator priceCalculator = new PriceCalculator(command);
            string totalPrice = priceCalculator.CalculatePrice();
            Console.WriteLine(totalPrice);
        }
    }
}