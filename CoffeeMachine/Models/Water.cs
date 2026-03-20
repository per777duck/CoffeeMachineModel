using System;

namespace CoffeeMachine.Models
{
    public class Water(double weight) : Ingredient(weight)
    {
        public override string Name => "Вода";
        public int Temprature { get; set; } = 20;

        public override string ToString()
        { 
            return $"{Name} - Темпетратура \"{Name}\": {Temprature} °С";
        }
    }
}