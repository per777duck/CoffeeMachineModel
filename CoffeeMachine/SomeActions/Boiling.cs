using CoffeeMachine.Models;

namespace CoffeeMachine.SomeActions
{
    public class Boiling : SomeAction
    {
        public override string Name => "Вскипятить";
        public override void Execute()
        {
            foreach (var element in Elements)
            {
                if (element is Water ingr)
                {
                    Console.WriteLine($"Нагреваем \'{ingr.Name}\' массой {ingr.Weight}(г/мл) до 100 °С");
                }
                else if (element is SomeAction act)
                {
                    act.Execute();
                }
            }
        }
    }
}