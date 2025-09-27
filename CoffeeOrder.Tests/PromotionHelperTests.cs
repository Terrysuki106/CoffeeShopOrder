using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder;
using System;

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class PromotionHelperTests
    {
        [TestMethod]
        public void Promotion_HappyHour_DiscountsHotDrink()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var total = PromotionHelper.ApplyPromotion("HAPPYHOUR", new[] { bev }, subtotal);

            Assert.IsTrue(total < subtotal);
        }

        [TestMethod]
        public void Promotion_BOGO_RemovesCheapest()
        {
            var latte = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            var tea = new Beverage("Tea", "Tall", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(latte) + PriceCalculator.CalculatePrice(tea);
            var total = PromotionHelper.ApplyPromotion("BOGO", new[] { latte, tea }, subtotal);

            Assert.AreEqual(subtotal - PriceCalculator.CalculatePrice(tea), total);
        }

        [TestMethod]
        public void Promotion_NoCode_ReturnsSameSubtotal()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var total = PromotionHelper.ApplyPromotion("", new[] { bev }, subtotal);

            Assert.AreEqual(subtotal, total);
        }

        [TestMethod]
        public void Promotion_BOGO_WithOneDrink_NoDiscount()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var total = PromotionHelper.ApplyPromotion("BOGO", new[] { bev }, subtotal);

            Assert.AreEqual(subtotal, total);
        }

        [TestMethod]
        public void Promotion_InvalidCode_DoesNotApplyDiscount()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var subtotal = PriceCalculator.CalculatePrice(bev);
            var total = PromotionHelper.ApplyPromotion("INVALIDCODE", new[] { bev }, subtotal);

            // At current Implementation level, PromotionHelper doesn't handle invalid codes explicitly.
            // This test will fail until that logic is implemented in PromotionHelper.
            Assert.AreEqual(subtotal, total, "Invalid promotion codes should not change the price.");
        }

    }
}
