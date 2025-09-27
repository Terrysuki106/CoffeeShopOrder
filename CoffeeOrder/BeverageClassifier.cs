namespace CoffeeOrder
{
    public static class BeverageClassifier
    {
        public static bool IsKidSafe(Beverage bev)
        {
            return bev.Shots == 0 || bev.IsDecaf;
        }

        public static bool IsDairyFree(Beverage bev)
        {
            return string.IsNullOrWhiteSpace(bev.Milk);
        }

        public static bool IsVeganFriendly(Beverage bev)
        {
            return IsDairyFree(bev);
        }

        public static bool IsDecaf(Beverage bev)
        {
            return bev.IsDecaf;
        }
    }
}
