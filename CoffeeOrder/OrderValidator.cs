using System;
using System.Collections.Generic;

namespace CoffeeOrder
{
    public static class OrderValidator
    {
        public static ValidationResult Validate(Beverage beverage)
        {
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(beverage.BaseDrink))
                errors.Add("A base drink is required.");

            if (string.IsNullOrWhiteSpace(beverage.Size))
                errors.Add("A size selection is required.");

            if (string.IsNullOrWhiteSpace(beverage.Temp))
                errors.Add("Temperature (Hot/Iced) must be selected.");

            if (!string.IsNullOrWhiteSpace(beverage.Milk) &&
                !string.IsNullOrWhiteSpace(beverage.PlantMilk))
                errors.Add("Milk selection invalid: choose dairy OR plant milk, not both.");

            if (beverage.Shots < 0 || beverage.Shots > 4)
                errors.Add("Shots must be between 0 and 4 inclusive.");

            if (beverage.Syrups is null || beverage.Syrups.Length > 5)
                errors.Add("Syrups must contain 0..5 entries.");

            return errors.Count == 0
                ? ValidationResult.Ok()
                : ValidationResult.Fail(errors.ToArray());
        }
    }
}
