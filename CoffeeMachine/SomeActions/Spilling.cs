using CoffeeMachine.Models;

namespace CoffeeMachine.SomeActions
{
    public class Spilling : SomeAction
    {
        public override string Name => "Пролить";
        public override void Execute()
        {
            foreach (var element in Elements)
            {
                if (element is Ingredient ingr)
                {
                    Console.WriteLine($"Проливаем \'{ingr.Name}\' массой {ingr.Weight}(г/мл)");
                }
                else if (element is SomeAction act)
                {
                    act.Execute();
                }
            }
        }
    }
}