using CoffeeMachine.Models;

namespace CoffeeMachine.SomeActions
{
    public class Grinding : SomeAction
    {
        public override string Name => "Перемолоть";
        public override void Execute()
        {
            foreach (var element in Elements)
            {
                if (element is CoffeeBean ingr)
                {
                    Console.WriteLine($"Перемалываем \'{ingr.Name}\' массой {ingr.Weight}(г/мл)");
                }
                else if (element is Ice ingr1)
                {
                    Console.WriteLine($"Перемалываем \'{ingr1.Name}\' массой {ingr1.Weight}(г/мл)");
                }
                else if (element is SomeAction act)
                {
                    act.Execute();
                }
            }
        }
    }
}