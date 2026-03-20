using System;

namespace CoffeeMachine.Models
{
    public class Milk(double weight, double fatPercentage = 2.5) : Ingredient(weight)
    {
        public override string Name => "Молоко";
        public double FatPercentage { get; set; } = fatPercentage;
        public bool IsBeated = false;

        public override string ToString()
        {
            return $"{Name} - Процент жирности \"{Name}\": {FatPercentage}";
        }
    }
}