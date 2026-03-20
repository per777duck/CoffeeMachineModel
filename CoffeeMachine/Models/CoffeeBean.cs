using System;

namespace CoffeeMachine.Models
{
    public class CoffeeBean(double weight, string beanType = "Арабика") : Ingredient(weight)
    {
        public override string Name => "Кофейное зерно";
        public string BeanType { get; set; } = beanType;
        public bool IsGrinded = false;

        public override string ToString()
        {
            return $"{Name} - Тип \"{Name}\": {BeanType}";
        }
    }
}