using System;
namespace CoffeeMachine.Models
{
    public class Syrup(double weight, string taste = "Шоколадный") : Ingredient(weight)
    {
        public override string Name => "Сироп";
        public string Taste { get; set; } = taste;

        public override string ToString()
        {
            return $"{Name} - Вкус \"{Name}\": {Taste}";
        }
    }
}