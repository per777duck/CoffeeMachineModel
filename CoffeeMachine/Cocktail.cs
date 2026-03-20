using CoffeeMachine.Models;
using CoffeeMachine.Actions;

namespace CoffeeMachine
{
    public class Cocktail
    {
        public string? Name { get; set; }
        public List<IElement> Recipe { get; set; } = new List<IElement>();

        private void AddIngredient()
        {
            bool isAdding = true;
            while (isAdding)
            {
                Console.Clear();
                Console.WriteLine("~ Добавление ингредиента в рецепт ~");
                Console.WriteLine("\nВыберите ингредиент:");
                Console.WriteLine("1. Вода");
                Console.WriteLine("2. Сироп");
                Console.WriteLine("3. Кофейное зерно");
                Console.WriteLine("4. Молоко");
                Console.WriteLine("5. Лёд");
                Console.WriteLine("0. Отмена");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine().Trim();

                if (choice == "0") { return; }

                Console.Write("Введите массу(г/мл): ");

                if (!double.TryParse(Console.ReadLine().Trim(), out double weight) || weight < 0)
                {
                    Console.WriteLine("Недопустимая масса!");
                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
                    continue;
                }

                switch (choice)
                {
                    case "1":
                        {
                            Recipe.Add(new Water(weight));
                            Console.WriteLine("Ингредиент успешно добавлен!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "2":
                        {
                            Console.Write("Введите вкус сиропа(по умолчанию шоколадный): ");
                            string taste = Console.ReadLine().Trim();
                            if (string.IsNullOrEmpty(taste))
                            {
                                Console.WriteLine("Название вкуса не может быть пустым, будет установлено значение по умолчанию");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();

                                Recipe.Add(new Syrup(weight));
                                Console.WriteLine("Ингредиент успешно добавлен!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                break;
                            }
                            Recipe.Add(new Syrup(weight, taste));
                            Console.WriteLine("Ингредиент успешно добавлен!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            Console.Write("Введите тип кофе(по умолчанию арабика): ");
                            string type = Console.ReadLine().Trim();
                            if (string.IsNullOrEmpty(type))
                            {
                                Console.WriteLine("Название типа не может быть пустым, будет установлено значение по умолчанию");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();

                                Recipe.Add(new CoffeeBean(weight));
                                Console.WriteLine("Ингредиент успешно добавлен!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                break;
                            }
                            Recipe.Add(new CoffeeBean(weight, type));
                            Console.WriteLine("Ингредиент успешно добавлен!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Введите процент жирности(по умолчанию 2.5): ");
                            double fat = 2.5;
                            if (double.TryParse(Console.ReadLine().Trim(), out fat) || fat < 0)
                            {
                                Console.WriteLine("Жирность должно быть положительным числом, будет установлено значение по умолчанию");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();

                                Recipe.Add(new Milk(weight));
                                Console.WriteLine("Ингредиент успешно добавлен!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                break;
                            }
                            Recipe.Add(new Milk(weight, fat));
                            Console.WriteLine("Ингредиент успешно добавлен!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            Recipe.Add(new Ice(weight));
                            Console.WriteLine("Ингредиент успешно добавлен!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
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

        //private void AddAction()
        //{
        //    bool isAdding = true;
        //    while (isAdding)
        //    {
        //        Console.Clear();
        //        Console.WriteLine("~ Добавление действия в рецепт ~");
        //        Console.WriteLine("\nВыберите действие:");
        //        Console.WriteLine("1. Добавить (ингредиент)");
        //        Console.WriteLine("2. Перемешать");
        //        Console.WriteLine("3. Вскипятить");
        //        Console.WriteLine("4. Пролить");
        //        Console.WriteLine("5. Перемолоть");
        //        Console.WriteLine("6. Взбить");
        //        Console.Write("Ваш выбор: ");

        //        string choice = Console.ReadLine().Trim();

        //        if (choice == "0") { return; }

        //        Console.Write("Введите массу(г/мл): ");

        //        if (!double.TryParse(Console.ReadLine().Trim(), out double weight) || weight < 0)
        //        {
        //            Console.WriteLine("Недопустимая масса!");
        //            Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //            Console.ReadLine();
        //            continue;
        //        }

        //        switch (choice)
        //        {
        //            case "1":
        //                {
        //                    Recipe.Add(new Water(weight));
        //                    Console.WriteLine("Ингредиент успешно добавлен!");
        //                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                    Console.ReadLine();
        //                    break;
        //                }
        //            case "2":
        //                {
        //                    Console.Write("Введите вкус сиропа(по умолчанию шоколадный): ");
        //                    string taste = Console.ReadLine().Trim();
        //                    if (string.IsNullOrEmpty(taste))
        //                    {
        //                        Console.WriteLine("Название вкуса не может быть пустым, будет установлено значение по умолчанию");
        //                        Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                        Console.ReadLine();

        //                        Recipe.Add(new Syrup(weight));
        //                        Console.WriteLine("Ингредиент успешно добавлен!");
        //                        Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                        Console.ReadLine();
        //                        break;
        //                    }
        //                    Recipe.Add(new Syrup(weight, taste));
        //                    Console.WriteLine("Ингредиент успешно добавлен!");
        //                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                    Console.ReadLine();
        //                    break;
        //                }
        //            case "3":
        //                {
        //                    Console.Write("Введите тип кофе(по умолчанию арабика): ");
        //                    string type = Console.ReadLine().Trim();
        //                    if (string.IsNullOrEmpty(type))
        //                    {
        //                        Console.WriteLine("Название типа не может быть пустым, будет установлено значение по умолчанию");
        //                        Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                        Console.ReadLine();

        //                        Recipe.Add(new CoffeeBean(weight));
        //                        Console.WriteLine("Ингредиент успешно добавлен!");
        //                        Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                        Console.ReadLine();
        //                        break;
        //                    }
        //                    Recipe.Add(new CoffeeBean(weight, type));
        //                    Console.WriteLine("Ингредиент успешно добавлен!");
        //                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                    Console.ReadLine();
        //                    break;
        //                }
        //            case "4":
        //                {
        //                    Console.Write("Введите процент жирности(по умолчанию 2.5): ");
        //                    double fat = 2.5;
        //                    if (double.TryParse(Console.ReadLine().Trim(), out fat) || fat < 0)
        //                    {
        //                        Console.WriteLine("Жирность должно быть положительным числом, будет установлено значение по умолчанию");
        //                        Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                        Console.ReadLine();

        //                        Recipe.Add(new Milk(weight));
        //                        Console.WriteLine("Ингредиент успешно добавлен!");
        //                        Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                        Console.ReadLine();
        //                        break;
        //                    }
        //                    Recipe.Add(new Milk(weight, fat));
        //                    Console.WriteLine("Ингредиент успешно добавлен!");
        //                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                    Console.ReadLine();
        //                    break;
        //                }
        //            case "5":
        //                {
        //                    Recipe.Add(new Ice(weight));
        //                    Console.WriteLine("Ингредиент успешно добавлен!");
        //                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                    Console.ReadLine();
        //                    break;
        //                }
        //            default:
        //                {
        //                    Console.WriteLine("Неверный ввод команды!");
        //                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
        //                    Console.ReadLine();
        //                    break;
        //                }
        //        }
        //    }
        //}

        public void Create() 
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("~ Создание нового напитка ~");
                Console.Write("Дайте новое название, новому напитку: ");

                string newName = Console.ReadLine().Trim();

                if (string.IsNullOrEmpty(newName))
                {
                    Console.WriteLine("Название не должно быть пустым!");
                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
                    continue;
                }

                Name = newName;
                Console.WriteLine("Название успешно добавлено!");
                break;
            }

            bool isAdding = true;
            while (isAdding)
            {
                Console.Clear();
                Console.WriteLine($"~ Создание нового напитка: {Name} ~");
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить ингредиент");
                Console.WriteLine("2. Добавить действие");
                Console.WriteLine("0. Завершить создание рецепта");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine().Trim();

                switch(choice)
                {
                    case "1":
                        {
                            AddIngredient();
                            break;
                        }
                    case "2":
                        {
                            //AddAction();
                            break;
                        }
                    case "0":
                        {
                            isAdding = false;
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Неверная команда!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                }
            }

        }

        public void Retrieve() 
        {
            Console.Clear();
            Console.WriteLine($"~ Рецепт напитка: {Name} ~");
            Console.WriteLine($"Всего элементов в рецепте: {Recipe.Count}\n");

            int stepNumber = 1;
            foreach (var element in Recipe)
            {
                if (element is Ingredient ingredient)
                {
                    Console.WriteLine($"{stepNumber}. ИНГРЕДИЕНТ: {ingredient.Name} - {ingredient.Weight} (г/мл)");
                }
                else if (element is SomeAction action)
                {
                    Console.WriteLine($"{stepNumber}. ДЕЙСТВИЕ: {action.Name}. ИНГРЕДИЕНТ: {action.ingredient.Name}");
                }
                stepNumber++;
            }
            Console.WriteLine("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
        }

        public void Update() { }

        public void Delete() 
        {
            Console.Clear();
            Console.WriteLine($"~ Удаление рецепта напитка: {Name} ~");
            Console.WriteLine($"Вы уверены, что хотите удалить напиток '{Name}'? (да/нет)");
            string choice = Console.ReadLine().Trim();

            if (choice.ToLower() == "да")
            {
                Recipe.Clear();
                Name = null;
                Console.WriteLine("Напиток успешно удален!");
                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Удаление отменено.");
                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
            }
        } 
    }
}
