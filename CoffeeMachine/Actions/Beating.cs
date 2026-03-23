using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Beating(Milk? ingr) : SomeAction(ingr)
    {
        public override string Name => "Взбить";
        public override void Execute()
        {
            if (ingredient != null && ingr != null)
            {
                ingr.IsBeated = true;
                Console.WriteLine($"Взбиваем \'{ingredient.Name}\' массой {ingredient.Weight}(г/мл)");
            }
            else
            {
                Console.WriteLine("Все молоко взбито до пенки!");
            }
        }
    }
}