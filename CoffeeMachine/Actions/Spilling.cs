using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Spilling(Ingredient? ingr) : SomeAction(ingr)
    {
        public override string Name => "Пролить";
        public override void Execute()
        {
            if (ingredient != null)
            {
                Console.WriteLine($"Проливаем \'{ingredient.Name}\' массой {ingredient.Weight}(г/мл)");
            }
            else
            {
                Console.WriteLine("Необходимо вскипятить воду и перемолоть зерно прежде чем делать пролив!(измените рецепт)");
            }
        }
    }
}