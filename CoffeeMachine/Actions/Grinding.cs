using CoffeeMachine.Models;

namespace CoffeeMachine.Actions
{
    public class Grinding(CoffeeBean ingr) : SomeAction(ingr)
    {
        public override string Name => "Перемолоть";
        public override void Execute()
        {
            ingr.IsGrinded = true;
            Console.WriteLine($"{ingredient.Name} массой {ingredient.Weight} был перемолот");
        }
    }
}