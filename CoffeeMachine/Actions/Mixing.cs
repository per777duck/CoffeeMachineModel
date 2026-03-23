using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Mixing(Ingredient? ingr) : SomeAction(ingr)
    {
        public override string Name => "Перемешать";
        public override void Execute()
        {
            if (ingredient != null)
            {
                Console.WriteLine("Перемешиваем напиток");
            }
        }
    }
}