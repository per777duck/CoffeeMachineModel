using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Spilling(Ingredient ingr) : SomeAction(ingr)
    {
        public override string Name => "Пролить";
        public override void Execute()
        {
            Console.WriteLine($"{ingredient.Name} массой {ingredient.Weight} был пролит через кофе");
        }
    }
}