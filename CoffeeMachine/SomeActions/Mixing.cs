using CoffeeMachine.Models;

namespace CoffeeMachine.SomeActions
{
    public class Mixing : SomeAction
    {
        public override string Name => "Перемешать";
        public override void Execute()
        {
            foreach (var element in Elements)
            {
                if (element is Ingredient ingr)
                {
                    Console.WriteLine($"Перемешиваем \'{ingr.Name}\' массой {ingr.Weight}(г/мл)");
                }
                else if (element is SomeAction act)
                {
                    act.Execute();
                }
            }
        }
    }
}