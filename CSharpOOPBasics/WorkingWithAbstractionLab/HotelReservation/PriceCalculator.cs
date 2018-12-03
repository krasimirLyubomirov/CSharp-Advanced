namespace HotelReservation
{
    using System;

    public class PriceCalculator
    {
        private decimal pricePerNight;
        private int nights;
        private Seasons season;
        private Discounts discount;

        public PriceCalculator(string command)
        {
            string[] tokens = command.Split();
            pricePerNight = decimal.Parse(tokens[0]);
            nights = int.Parse(tokens[1]);
            season = Enum.Parse<Seasons>(tokens[2]);
            discount = Discounts.None;
            if (tokens.Length > 3)
            {
                discount = Enum.Parse<Discounts>(tokens[3]);
            }
        }

        public string CalculatePrice()
        {
            decimal tempTotal = pricePerNight * nights * (int)season;
            decimal discountPercentage = ((decimal)100 - (int)discount) / 100;
            decimal totalPrice = tempTotal * discountPercentage;
            return totalPrice.ToString("F2");
        }
    }
}