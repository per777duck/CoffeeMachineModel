using CoffeeMachine.Models;

namespace CoffeeMachine.SomeActions
{
    public class Beating : SomeAction
    {
        public override string Name => "Взбить";
        public override void Execute()
        {
            foreach (var element in Elements)
            {
                if (element is Ingredient ingr)
                {
                    Console.WriteLine($"Взбиваем \'{ingr.Name}\' массой {ingr.Weight}(г/мл)");
                }
                else if (element is SomeAction act)
                {
                    act.Execute();
                }
            }
        }
    }
}