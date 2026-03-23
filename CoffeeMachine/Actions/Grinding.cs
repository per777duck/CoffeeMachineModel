using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Grinding(CoffeeBean? ingr) : SomeAction(ingr)
    {
        public override string Name => "Перемолоть";
        public override void Execute()
        {
            if (ingredient != null && ingr != null)
            {
                ingr.IsGrinded = true;
                Console.WriteLine($"Перемалываем \'{ingredient.Name}\' массой {ingredient.Weight}(г/мл)");
            }
            else
            {
                Console.WriteLine("Все добавленные зерна уже перемолоты!");
            }
        }
    }
}