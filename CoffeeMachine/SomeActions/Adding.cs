using CoffeeMachine.Models;

namespace CoffeeMachine.SomeActions
{
    public class Adding : SomeAction
    {
        public override string Name => "Добавить";  

        public override void Execute()
        {
            foreach (var element in Elements)
            {
                if (element is Ingredient ingr)
                {
                    Console.WriteLine($"Добавляем \'{ingr.Name}\' массой {ingr.Weight} (г/мл) в напиток");
                }
                else if (element is SomeAction act)
                {
                    act.Execute();
                }
            }
        }
    }
}
