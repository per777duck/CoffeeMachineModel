namespace CoffeeMachine
{
    internal class MainProgram
    {
        static void Main()
        {
            Manager manager = new Manager();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("~ РОЖКОВАЯ КОФЕМАШИНА ~");
                Console.WriteLine("1. Создать новый напиток");
                Console.WriteLine("2. Показать все напитки");
                Console.WriteLine("3. Показать рецепт напитка");
                Console.WriteLine("4. Обновить напиток");
                Console.WriteLine("5. Приготовить напиток");
                Console.WriteLine("6. Удалить напиток");
                Console.WriteLine("0. Выход");
                Console.Write("Выбор: ");

                string choice = Console.ReadLine().Trim();

                switch (choice)
                {
                    case "1":
                        {
                            manager.CreateCocktail();
                            break;
                        }
                    case "2":
                        {
                            manager.ShowAllCocktails();
                            break;
                        }
                    case "3":
                        {
                            manager.ShowAllCocktails();
                            Console.Write("Введите номер напитка: ");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }
                            var cocktail = manager.FindCocktailById(id);
                            if (cocktail == null)
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }
                            
                            cocktail.Retrieve();
                            break;
                        }
                    case "4":
                        {
                            manager.ShowAllCocktails();
                            Console.Write("Введите номер напитка: ");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }
                            var cocktail = manager.FindCocktailById(id);
                            if (cocktail == null)
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            cocktail.Update();
                            break;
                        }
                    case "5":
                        {
                            manager.ShowAllCocktails();
                            Console.Write("Введите номер напитка: ");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }
                            var cocktail = manager.FindCocktailById(id);
                            if (cocktail == null)
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            cocktail.Prepare();
                            break;
                        }
                    case "6":
                        {
                            manager.ShowAllCocktails();
                            Console.Write("Введите номер напитка: ");
                            if (!int.TryParse(Console.ReadLine(), out int id))
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }
                            var cocktail = manager.FindCocktailById(id);
                            if (cocktail == null)
                            {
                                Console.WriteLine("Такого напитка не существует!");
                                Console.Write("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            cocktail.Delete();
                            manager.RemoveCocktail(id);
                            break;
                        }
                    case "0":
                        {
                            exit = true;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверный ввод команды!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                }
            }
        }
    }
}