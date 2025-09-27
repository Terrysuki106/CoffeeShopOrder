using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder;
using System;

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class PriceCalculatorTests
    {
        [TestMethod]
        public void Price_BaseTallLatte_Returns250()
        {
            var bev = new Beverage("Latte", "Tall", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            Assert.AreEqual(2.50m, PriceCalculator.CalculatePrice(bev));
        }

        [TestMethod]
        public void Price_WithShotsAndSyrups_AddsExtras()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 2,
                new[] { "Vanilla" }, Array.Empty<string>(), false);
            var price = PriceCalculator.CalculatePrice(bev);
            Assert.AreEqual(3.00m + 2 * 0.50m + 0.25m, price);
        }

        [TestMethod]
        public void Price_WithToppings_AddsCost()
        {
            var bev = new Beverage("Latte", "Venti", "Hot", null, null, 0,
                Array.Empty<string>(), new[] { "Whipped Cream" }, false);
            var price = PriceCalculator.CalculatePrice(bev);
            Assert.AreEqual(3.50m + 0.20m, price);
        }

        [TestMethod]
        public void Price_InvalidSize_ReturnsZero()
        {
            var bev = new Beverage("Latte", "Mega", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            var price = PriceCalculator.CalculatePrice(bev);
            Assert.AreEqual(0.0m, price);
        }

    }
}
