using CoffeeMachine.SomeActions;

namespace CoffeeMachine.Models
{
    public abstract class Ingredient(double weight) : IElement
    {
        public SomeAction Owner { get; set; }
        public abstract string Name { get; }
        public double Weight { get; set; } = weight;
    }
}