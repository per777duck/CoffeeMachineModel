namespace CoffeeMachine
{
    public class Manager
    {
        private List<Cocktail> cocktails = new List<Cocktail>();
        private int NextId = 1;

        public void CreateCocktail()
        {
            Cocktail cocktail = new Cocktail() { Id = NextId++};
            cocktail.Create();
            cocktails.Add(cocktail);
        }

        public void ShowAllCocktails()
        {
            if (cocktails.Count == 0)
            {
                Console.WriteLine("Список напитков пуст!");
                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
                return;
            }

            Console.WriteLine("\n~ Список напитков ~");
            foreach (Cocktail cocktail in cocktails)
            {
                Console.WriteLine($"{cocktail.Id}. {cocktail.Name} ({cocktail.Recipe.Count} элементов)");
            }
        }

        public Cocktail FindCocktailById(int id)
        {
            return cocktails.FirstOrDefault(c => c.Id == id);
        }

        public void RemoveCocktail(int id)
        {
            var cocktail = FindCocktailById(id);
            if (cocktail != null)
            {
                cocktails.Remove(cocktail);
                Console.WriteLine($"Напиток '{cocktail.Name}' удален из коллекции!");
                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
            }
        }
    }
}
