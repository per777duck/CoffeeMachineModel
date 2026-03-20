using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public abstract class SomeAction(Ingredient ingr) : IElement
    {
        public abstract string Name { get; }
        public Ingredient ingredient { get; set; } = ingr;
        public abstract void Execute();
    }
}
