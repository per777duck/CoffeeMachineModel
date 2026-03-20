using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Beating(Milk ingr) : SomeAction(ingr)
    {
        public override string Name => "Взбить";
        public override void Execute()
        {
            ingr.IsBeated = true;
            Console.WriteLine($"{ingredient.Name} массой {ingredient.Weight} был взбит");
        }
    }
}