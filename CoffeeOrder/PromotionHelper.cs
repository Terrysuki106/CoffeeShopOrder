using System;

namespace CoffeeOrder
{
    public static class PromotionHelper
    {
        public static decimal ApplyPromotion(string code, Beverage[] order, decimal subtotal)
        {
            if (code == "HAPPYHOUR")
            {
                decimal discount = 0;
                foreach (var bev in order)
                {
                    if (bev.Temp == "Hot")
                        discount += PriceCalculator.CalculatePrice(bev) * 0.20m;
                }
                return subtotal - discount;
            }
            else if (code == "BOGO" && order.Length >= 2)
            {
                decimal cheapest = decimal.MaxValue;
                foreach (var bev in order)
                {
                    var price = PriceCalculator.CalculatePrice(bev);
                    if (price < cheapest) cheapest = price;
                }
                return subtotal - cheapest;
            }

            return subtotal;
        }
    }
}
