using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder;
using System;

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class ReceiptFormatterTests
    {
        [TestMethod]
        public void Receipt_IncludesTotalsAndName()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            var subtotal = PriceCalculator.CalculatePrice(bev);
            var total = subtotal;

            var receipt = ReceiptFormatter.FormatReceipt(new[] { bev }, subtotal, total, "YourName");

            StringAssert.Contains(receipt, "YourName");
            StringAssert.Contains(receipt, "TOTAL");
        }

        [TestMethod]
        public void Receipt_MultipleItems_ShowsEach()
        {
            var latte = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            var tea = new Beverage("Tea", "Tall", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(latte) + PriceCalculator.CalculatePrice(tea);
            var total = subtotal;

            var receipt = ReceiptFormatter.FormatReceipt(new[] { latte, tea }, subtotal, total, "YourName");

            StringAssert.Contains(receipt, "Latte");
            StringAssert.Contains(receipt, "Tea");
        }

        [TestMethod]
        public void Receipt_IncludesBaseDrinkName()
        {
            var bev = new Beverage("Mocha", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var receipt = ReceiptFormatter.FormatReceipt(new[] { bev }, subtotal, subtotal, "Tester");

            StringAssert.Contains(receipt, "Mocha");
        }

        [TestMethod]
        public void Receipt_ShowsCorrectSubtotalAndTotal()
        {
            var bev = new Beverage("Latte", "Tall", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var receipt = ReceiptFormatter.FormatReceipt(new[] { bev }, subtotal, subtotal, "Tester");

            StringAssert.Contains(receipt, subtotal.ToString("0.00"));
        }

        [TestMethod]
        public void Receipt_EmptyOrder_ShowsZeroTotal()
        {
            var order = Array.Empty<Beverage>();
            var receipt = ReceiptFormatter.FormatReceipt(order, 0.0m, 0.0m, "Tester");

            StringAssert.Contains(receipt, "Total");
            StringAssert.Contains(receipt, "0.00");
        }

    }
}
