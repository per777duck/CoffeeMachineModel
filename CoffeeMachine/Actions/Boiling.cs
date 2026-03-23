using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Boiling(Water? ingr) : SomeAction(ingr)
    {
        public override string Name => "Вскипятить";
        public override void Execute()
        {
            if (ingredient != null && ingr != null)
            {
                ingr.Temprature = 100;
                Console.WriteLine($"Нагреваем \'{ingredient.Name}\' массой {ingredient.Weight}(г/мл) до {ingr.Temprature} °С");
            }
            else
            {
                Console.WriteLine("Вся вода нагрета до 100 °С");
            }
        }
    }
}