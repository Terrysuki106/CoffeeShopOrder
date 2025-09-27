using System.Collections.Generic;

namespace CoffeeOrder
{
    public static class PriceCalculator
    {
        private static readonly Dictionary<string, decimal> BasePrices =
            new Dictionary<string, decimal>
            {
                { "Tall", 2.50m },
                { "Grande", 3.00m },
                { "Venti", 3.50m }
            };

        public static decimal CalculatePrice(Beverage bev)
        {
            if (!BasePrices.ContainsKey(bev.Size))
                return 0.0m;

            decimal total = BasePrices[bev.Size];

            total += bev.Shots * 0.50m;
            total += bev.Syrups.Length * 0.25m;
            total += bev.Toppings.Length * 0.20m;

            return total;
        }
    }
}
