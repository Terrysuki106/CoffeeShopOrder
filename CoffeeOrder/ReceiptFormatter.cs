using System;
using System.Text;

namespace CoffeeOrder
{
    public static class ReceiptFormatter
    {
        public static string FormatReceipt(Beverage[] order, decimal subtotal, decimal total, string name)
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Receipt for {name} - {DateTime.Now}");
            sb.AppendLine("---------------------------------");

            foreach (var bev in order)
            {
                sb.AppendLine($"{bev.Size} {bev.BaseDrink} - ${PriceCalculator.CalculatePrice(bev):0.00}");
            }

            sb.AppendLine("---------------------------------");
            sb.AppendLine($"Subtotal: ${subtotal:0.00}");
            sb.AppendLine($"Total:    ${total:0.00}");
            return sb.ToString();
        }
    }
}
