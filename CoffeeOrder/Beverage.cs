namespace CoffeeOrder
{
    public class Beverage
    {
        public string BaseDrink { get; }
        public string Size { get; }
        public string Temp { get; }
        public string Milk { get; }
        public string PlantMilk { get; }
        public int Shots { get; }
        public string[] Syrups { get; }
        public string[] Toppings { get; }
        public bool IsDecaf { get; }

        public Beverage(string baseDrink, string size, string temp,
                        string milk, string plantMilk, int shots,
                        string[] syrups, string[] toppings, bool isDecaf)
        {
            BaseDrink = baseDrink;
            Size = size;
            Temp = temp;
            Milk = milk;
            PlantMilk = plantMilk;
            Shots = shots;
            Syrups = syrups ?? new string[] { };
            Toppings = toppings ?? new string[] { };
            IsDecaf = isDecaf;
        }
    }
}
