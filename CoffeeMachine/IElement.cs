using CoffeeMachine.SomeActions;

namespace CoffeeMachine
{
    public interface IElement 
    {
        SomeAction Owner { get; set; }
    }
}