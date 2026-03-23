using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Adding(Ingredient? ingr) : SomeAction(ingr)
    {
        public override string Name => "Добавить";  

        public override void Execute()
        {
            if (ingredient != null)
            {
                Console.WriteLine($"Добавляем \'{ingredient.Name}\' массой {ingredient.Weight} (г/мл) в напиток");
            }
        }
    }
}
