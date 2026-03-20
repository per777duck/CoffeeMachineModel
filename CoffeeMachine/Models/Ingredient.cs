using System;

namespace CoffeeMachine.Models
{
    public abstract class Ingredient(double weight) : IElement
    {
        public abstract string Name { get; }
        public double Weight { get; set; } = weight;
    }
}