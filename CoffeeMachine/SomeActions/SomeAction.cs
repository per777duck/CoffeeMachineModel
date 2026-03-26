using CoffeeMachine.Models;
using System.Xml.Linq;

namespace CoffeeMachine.SomeActions
{
    public abstract class SomeAction : IElement
    {
        public SomeAction Owner { get; set; }
        public abstract string Name { get; }
        public List<IElement> Elements { get; set; } = new List<IElement>();
        public abstract void Execute();

        public void AddElement(IElement element)
        {
            if (element != null)
            {
                Elements.Add(element);
                if (element is Ingredient ingr)
                {
                    ingr.Owner = this;
                }
            }
        }

        public void ClearOwnerReferences()
        {
            foreach (var elem in Elements)
            {
                if (elem is Ingredient ingr)
                {
                    ingr.Owner = null;
                }
            }
        }
    }
}
