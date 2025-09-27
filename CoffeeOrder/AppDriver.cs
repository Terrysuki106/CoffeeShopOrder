using System;

namespace CoffeeOrder
{
    public static class AppDriver
    {
        public static void Run()
        {
            Console.WriteLine("=<>= Welcome to TJ's Coffee Shop =<>=");

            var bev = new Beverage("Latte", "Grande", "Hot", null, "Oat", 2,
                new[] { "Vanilla" }, new[] { "Whipped Cream" }, false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var total = PromotionHelper.ApplyPromotion("HAPPYHOUR", new[] { bev }, subtotal);

            Console.WriteLine("Order:");
            Console.WriteLine($"{bev.Size} {bev.BaseDrink} with {bev.Milk} milk");
            Console.WriteLine($"Subtotal: ${subtotal:0.00}");
            Console.WriteLine($"TOTAL:    ${total:0.00}");

            Console.WriteLine("=-= Thank you! Come Again! =-=");
        }
    }
}
