using System;

namespace CoffeeMachine.Models
{
    public class Ice(double weight) : Ingredient(weight)
    {
        public override string Name => "Лёд";

        public override string ToString()
        {
            return $"{Name}";
        }
    }
}