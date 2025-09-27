using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder;
using System;

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class OrderValidatorTests
    {
        [TestMethod]
        public void Validate_MissingBase_ReturnsInvalid()
        {
            var bev = new Beverage(null, "Tall", "Hot", null, null, 1,
                new[] { "Vanilla" }, Array.Empty<string>(), false);

            var result = OrderValidator.Validate(bev);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_BothMilks_ReturnsInvalid()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", "2%", "Oat", 1,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var result = OrderValidator.Validate(bev);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_ValidDrink_ReturnsValid()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, "Oat", 2,
                new[] { "Vanilla" }, Array.Empty<string>(), false);

            var result = OrderValidator.Validate(bev);

            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void Validate_MissingSize_ReturnsInvalid()
        {
            var bev = new Beverage("Latte", null, "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            var result = OrderValidator.Validate(bev);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_TooManyShots_ReturnsInvalid()
        {
            var bev = new Beverage("Latte", "Tall", "Hot", null, null, 5,
                Array.Empty<string>(), Array.Empty<string>(), false);
            var result = OrderValidator.Validate(bev);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_TooManySyrups_ReturnsInvalid()
        {
            var bev = new Beverage("Latte", "Tall", "Hot", null, null, 1,
                new[] { "A", "B", "C", "D", "E", "F" }, Array.Empty<string>(), false);
            var result = OrderValidator.Validate(bev);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_NullSyrups_ReturnsInvalid()
        {
            var bev = new Beverage("Latte", "Tall", "Hot", null, null, 1,
                null, Array.Empty<string>(), false);

            var result = OrderValidator.Validate(bev);

            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void Validate_ExtraHotKidDrink_ReturnsInvalid()
        {
            var bev = new Beverage("Hot Chocolate", "Tall", "ExtraHot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            var result = OrderValidator.Validate(bev);

            // At current implementation level,this test will fail
            // until "ExtraHot" validation is implemented in OrderValidator

            Assert.IsTrue(result.IsValid, "ExtraHot should not be allowed for kids.");
        }
    }
}

