using CoffeeMachine.Models;
using CoffeeMachine.Actions;
using System.Reflection.Metadata.Ecma335;

namespace CoffeeMachine
{
    public class Cocktail
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public List<IElement> Recipe { get; set; } = new List<IElement>();

        private void AddIngredient()
        {
            while (true)
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
                            if (!double.TryParse(Console.ReadLine().Trim(), out fat) || fat < 0)
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

        private void AddAction()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("~ Добавление действия в рецепт ~");
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Добавить (ингредиент)");
                Console.WriteLine("2. Перемешать");
                Console.WriteLine("3. Вскипятить");
                Console.WriteLine("4. Пролить");
                Console.WriteLine("5. Перемолоть");
                Console.WriteLine("6. Взбить");
                Console.WriteLine("0. Отмена");
                Console.Write("Ваш выбор: ");

                string choice = Console.ReadLine().Trim();

                if (choice == "0") { return; }

                switch (choice)
                {
                    case "1":
                        {
                            while (true)
                            {
                                Console.WriteLine("\nВыберите предмет, с которым будет производится действие");
                                int i = 1;
                                foreach (var elem in Recipe)
                                {
                                    if (elem is Ingredient ingr)
                                    {
                                        Console.WriteLine($"{i++}. {ingr.Name}");
                                    }
                                }
                                Console.Write("Ваш выбор: ");

                                if (!int.TryParse(Console.ReadLine().Trim(), out int ingr_choice) ||
                                    ingr_choice < 0 || ingr_choice > i)
                                {
                                    Console.WriteLine("Такого ингредиента нет!");
                                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                    Console.ReadLine();
                                    continue;
                                }

                                int find = 1;
                                Ingredient? ingr_to_choose = null;
                                foreach (var elem in Recipe)
                                {
                                    if (elem is Ingredient ingr && find == ingr_choice)
                                    {
                                        ingr_to_choose = ingr;
                                        break;
                                    }
                                    else if (elem is Ingredient ingr2)
                                    {
                                        find++;
                                    }
                                }

                                Recipe.Add(new Adding(ingr_to_choose));
                                Console.WriteLine("Действие успешно добавлено!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                break;
                            }
                            break;
                        }
                    case "2":
                        {
                            Recipe.Add(new Mixing(new Water(0)));
                            Console.WriteLine("Действие успешно добавлено!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "3":
                        {
                            Water? water_to_boil = null;
                            foreach(var elem in Recipe)
                            {
                                if (elem is Water wat && wat.Temprature != 100)
                                {
                                    water_to_boil = wat;
                                    break;
                                }
                            }
                            Recipe.Add(new Boiling(water_to_boil));
                            Console.WriteLine("Действие успешно добавлено!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "4":
                        {
                            Ingredient? bean_to_spill = null;
                            foreach(var elem in Recipe)
                            {
                                if (elem is CoffeeBean bean && bean.IsGrinded)
                                {
                                    bean_to_spill = bean;
                                    break;
                                }

                            }

                            Water? ingr_to_spill = null;
                            if (bean_to_spill != null)
                            {
                                foreach (var elem in Recipe)
                                {
                                    if (elem is Water wat && wat.Temprature == 100)
                                    {
                                        ingr_to_spill = wat;
                                        break;
                                    }

                                }
                            }
                            Recipe.Add(new Spilling(ingr_to_spill));
                            Console.WriteLine("Действие успешно добавлено!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "5":
                        {
                            CoffeeBean? coffee = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is CoffeeBean bean && !bean.IsGrinded)
                                {
                                    coffee = bean;
                                    break;
                                }
                            }

                            Recipe.Add(new Grinding(coffee));
                            Console.WriteLine("Действие успешно добавлено!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                    case "6":
                        {
                            Milk? milk = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is Milk mi && !mi.IsBeated)
                                {
                                    milk = mi;
                                    break;
                                }
                            }

                            Recipe.Add(new Beating(milk));
                            Console.WriteLine("Действие успешно добавлено!");
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
                            AddAction();
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
                    Console.WriteLine($"{stepNumber}. ДЕЙСТВИЕ: {action.Name}. ИНГРЕДИЕНТ: " +
                        $"{(action.ingredient != null ? action.ingredient.Name : "не выбран")}");
                }
                stepNumber++;
            }
            Console.WriteLine("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
        }

        public void Update()
        {
            Console.Clear();
            Console.WriteLine($"~ Обновление напитка: {Name} ~");
            Console.WriteLine("1. Изменить название");
            Console.WriteLine("2. Добавить элемент в рецепт");
            Console.WriteLine("3. Удалить элемент из рецепта");
            Console.WriteLine("4. Изменить элемент рецепта");
            Console.Write("Ваш выбор: ");

            string choice = Console.ReadLine().Trim();

            switch (choice)
            {
                case "1":
                    {
                        while (true)
                        {
                            Console.Write("Введите новое название или 0 чтобы отменить: ");
                            string new_name = Console.ReadLine().Trim();
                            if (string.IsNullOrEmpty(new_name))
                            {
                                Console.WriteLine("Название не может быть пустым!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            if (new_name == "0") { return; }

                            Name = new_name;
                            Console.WriteLine("Название обновлено!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                            break;
                    }

                case "2":
                    { 
                        while (true)
                        {
                            Console.WriteLine("Добавить: ");
                            Console.WriteLine("1. Ингредиент");
                            Console.WriteLine("2. Действие");
                            Console.WriteLine("0. Отмена");

                            if (!int.TryParse(Console.ReadLine().Trim(), out int addChoice) ||
                                addChoice < 1 || addChoice > 2)
                            {
                                Console.WriteLine("Неверная команда!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            if (addChoice == 0) { return; }

                            if (addChoice == 1) { AddIngredient(); }
                            else { AddAction(); }
                            break;
                        }
                        break;
                    }

                case "3":
                    {
                        while (true)
                        {
                            Retrieve();
                            Console.Write("Введите номер элемента для удаления или 0 чтобы отменить: ");

                            if (!int.TryParse(Console.ReadLine().Trim(), out int removeIndex) ||
                                removeIndex < 1 || removeIndex > Recipe.Count)
                            {
                                Console.WriteLine("Такого элемента не существует!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            if (removeIndex == 0) { return; }

                            Recipe.RemoveAt(removeIndex - 1);
                            Console.WriteLine("Элемент удален!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                        break;
                    }

                case "4":
                    {
                        while (true)
                        {
                            Retrieve();
                            Console.Write("Введите номер элемента для изменения или 0 чтобы отменить: ");
                            if (!int.TryParse(Console.ReadLine().Trim(), out int editIndex) ||
                                editIndex < 1 || editIndex > Recipe.Count)
                            {
                                Console.WriteLine("Такого элемента не существует!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            if (editIndex == 0) { return; }

                            Recipe.RemoveAt(editIndex);
                            while (true)
                            {
                                Console.WriteLine("Добавьте новый элемент:");
                                Console.WriteLine("1. Ингредиент");
                                Console.WriteLine("2. Действие");
                                if (!int.TryParse(Console.ReadLine().Trim(), out int newChoice) ||
                                newChoice < 1 || newChoice > 2)
                                {
                                    Console.WriteLine("Неверная команда!");
                                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                    Console.ReadLine();
                                    continue;
                                }

                                if (newChoice == 1) { AddIngredient(); }
                                else { AddAction(); }

                                break;
                            }
                            break;
                        }
                        break;
                    }
            }
        }

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

        public void Prepare()
        {
            Console.Clear();
            Console.WriteLine($"~ Приготовление напитка: {Name} ~");

            if (Recipe.Count == 0)
            {
                Console.WriteLine("Рецепт пуст! Невозможно приготовить напиток.");
                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                Console.ReadLine();
                return;
            }

            int step = 1;
            foreach (var element in Recipe)
            {
                Console.WriteLine($"\nШаг {step}:");

                if (element is Ingredient ingredient)
                {
                    Console.WriteLine($"  Берем \'{ingredient.Name}\' ({ingredient.Weight}г/мл)");
                }
                else if (element is SomeAction action)
                {
                    Console.Write("  ");
                    action.Execute();
                }

                step++;
            }

            Console.WriteLine($"\nНапиток '{Name}' готов!");
            Console.WriteLine("Нажмите Enter чтобы продолжить...");
            Console.ReadLine();
        }
    }
}