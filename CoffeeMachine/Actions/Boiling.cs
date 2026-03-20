using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Boiling(Water ingr) : SomeAction(ingr)
    {
        public override string Name => "Вскипятить";
        public override void Execute()
        {
            ingr.Temprature = 100;
            Console.WriteLine($"Ингредиент {ingredient.Name} массой {ingredient.Weight} был нагрет до {ingr.Temprature} °С");
        }
    }
}