using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoffeeOrder;
using System;

namespace CoffeeOrder.Tests
{
    [TestClass]
    public class BeverageClassifierTests
    {
        [TestMethod]
        public void KidSafe_NoShots_ReturnsTrue()
        {
            var bev = new Beverage("Tea", "Tall", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            Assert.IsTrue(BeverageClassifier.IsKidSafe(bev));
        }

        [TestMethod]
        public void KidSafe_WithShots_ReturnsFalse()
        {
            var bev = new Beverage("Latte", "Tall", "Hot", null, null, 2,
                Array.Empty<string>(), Array.Empty<string>(), false);
            Assert.IsFalse(BeverageClassifier.IsKidSafe(bev));
        }

        [TestMethod]
        public void VeganFriendly_NoMilk_ReturnsTrue()
        {
            var bev = new Beverage("Tea", "Tall", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), false);
            Assert.IsTrue(BeverageClassifier.IsVeganFriendly(bev));
        }

        [TestMethod]
        public void DairyFree_WithPlantMilk_ReturnsTrue()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, "Oat", 0,
                Array.Empty<string>(), Array.Empty<string>(), false);

            Assert.IsTrue(BeverageClassifier.IsDairyFree(bev));
        }

        [TestMethod]
        public void DecafFlag_ReturnsTrue()
        {
            var bev = new Beverage("Latte", "Grande", "Hot", null, null, 0,
                Array.Empty<string>(), Array.Empty<string>(), true);
            Assert.IsTrue(BeverageClassifier.IsDecaf(bev));
        }

    }
}
