using CoffeeMachine.Actions;
using CoffeeMachine.Models;
using CoffeeMachine.SomeActions;
using System.Reflection.Metadata.Ecma335;

namespace CoffeeMachine
{
    public class Cocktail
    {
        public string? Name { get; set; }
        public int Id { get; set; }
        public List<IElement> Recipe { get; set; } = new List<IElement>();

        private void BreakAggregation(IElement element)
        {
            if (element is Ingredient ingr)
            {
                ingr.Owner = null;
            }
            else if (element is SomeAction action)
            {
                action.ClearOwnerReferences();
            }
        }

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

                Console.Write("Введите массу (г/мл): ");

                if (!double.TryParse(Console.ReadLine().Trim(), out double weight) || weight < 0)
                {
                    Console.WriteLine("Недопустимая масса!");
                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
                    continue;
                }

                Ingredient? newIngredient = null;

                switch (choice)
                {
                    case "1":
                        newIngredient = new Water(weight);
                        break;
                    case "2":
                        {
                            Console.Write("Введите вкус сиропа (по умолчанию шоколадный): ");
                            string taste = Console.ReadLine().Trim();
                            if (string.IsNullOrEmpty(taste))
                            {
                                Console.WriteLine("Название вкуса не может быть пустым, будет установлено значение по умолчанию");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                newIngredient = new Syrup(weight);
                            }
                            else
                            {
                                newIngredient = new Syrup(weight, taste);
                            }

                            break;
                        }
                    case "3":
                        {
                            Console.Write("Введите тип кофе (по умолчанию арабика): ");
                            string type = Console.ReadLine().Trim();
                            if (string.IsNullOrEmpty(type))
                            {
                                Console.WriteLine("Название типа не может быть пустым, будет установлено значение по умолчанию");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                newIngredient = new CoffeeBean(weight);
                            }
                            else
                            {
                                newIngredient = new CoffeeBean(weight, type);
                            }
                            break;
                        }
                    case "4":
                        {
                            Console.Write("Введите процент жирности (по умолчанию 2.5): ");
                            double fat = 2.5;
                            if (!double.TryParse(Console.ReadLine().Trim(), out fat) || fat < 0)
                            {
                                Console.WriteLine("Жирность должна быть положительным числом, будет установлено значение по умолчанию");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                newIngredient = new Milk(weight);
                            }
                            else
                            {
                                newIngredient = new Milk(weight, fat);
                            }
                            break;
                        }
                    case "5":
                        newIngredient = new Ice(weight);
                        break;
                    default:
                        {
                            Console.WriteLine("Неверный ввод команды!");
                            Console.WriteLine("Нажмите Enter чтобы продолжить...");
                            Console.ReadLine();
                            break;
                        }
                }

                if (newIngredient != null)
                {
                    Recipe.Add(newIngredient);
                    Console.WriteLine("Ингредиент успешно добавлен!");
                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
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

                SomeAction? newAction = null;

                switch (choice)
                {
                    case "1":
                        {
                            while (true)
                            {
                                Console.WriteLine("\nВыберите предмет, с которым будет производиться действие:");
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
                                    ingr_choice < 1 || ingr_choice > i - 1)
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
                                    else if (elem is Ingredient)
                                    {
                                        find++;
                                    }
                                }

                                newAction = new Adding();
                                newAction.AddElement(ingr_to_choose);

                                Console.WriteLine("Действие успешно добавлено!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                break;
                            }
                            break;
                        }
                    case "2":
                        {
                            Ingredient? ingredientForMixing = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is Ingredient ingr)
                                {
                                    ingredientForMixing = ingr;
                                    break;
                                }
                            }
                            newAction = new Mixing();
                            newAction.AddElement(ingredientForMixing);
                            break;
                        }
                    case "3":
                        {
                            Water? water_to_boil = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is Water wat)
                                {
                                    water_to_boil = wat;
                                    break;
                                }
                            }
                            newAction = new Boiling();
                            newAction.AddElement(water_to_boil);
                            break;
                        }
                    case "4":
                        {
                            Ingredient? bean_to_spill = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is CoffeeBean bean)
                                {
                                    bean_to_spill = bean;
                                    break;
                                }
                            }

                            Water? water_to_spill = null;
                            if (bean_to_spill != null)
                            {
                                foreach (var elem in Recipe)
                                {
                                    if (elem is Water wat)
                                    {
                                        water_to_spill = wat;
                                        break;
                                    }
                                }
                            }
                            newAction = new Spilling();
                            newAction.AddElement(water_to_spill);
                            break;
                        }
                    case "5":
                        {
                            CoffeeBean? coffee = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is CoffeeBean bean)
                                {
                                    coffee = bean;
                                    break;
                                }
                            }
                            newAction = new Grinding();
                            newAction.AddElement(coffee);
                            break;
                        }
                    case "6":
                        {
                            Milk? milk = null;
                            foreach (var elem in Recipe)
                            {
                                if (elem is Milk mi)
                                {
                                    milk = mi;
                                    break;
                                }
                            }
                            newAction = new Beating();
                            newAction.AddElement(milk);
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

                if (newAction != null)
                {
                    Recipe.Add(newAction);
                    Console.WriteLine("Действие успешно добавлено!");
                    Console.WriteLine("Нажмите Enter чтобы продолжить...");
                    Console.ReadLine();
                }
            }
        }

        public void Create()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("~ Создание нового напитка ~");
                Console.Write("Дайте новое название новому напитку: ");

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

                switch (choice)
                {
                    case "1":
                        AddIngredient();
                        break;
                    case "2":
                        AddAction();
                        break;
                    case "0":
                        isAdding = false;
                        break;
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
                    string ownerInfo = ingredient.Owner != null ?
                        $"[Используется в: {ingredient.Owner.Name}]" : "[Не используется]";
                    Console.WriteLine($"{stepNumber}. ИНГРЕДИЕНТ: {ingredient.Name} - {ingredient.Weight} (г/мл) {ownerInfo}");
                }
                else if (element is SomeAction action)
                {
                    var ingredientsInAction = action.Elements
                        .OfType<Ingredient>()
                        .ToList();

                    string ingredientsList = ingredientsInAction.Any()
                        ? string.Join(", ", ingredientsInAction.Select(i => i.Name))
                        : "не выбран";

                    Console.WriteLine($"{stepNumber}. ДЕЙСТВИЕ: {action.Name}. ИНГРЕДИЕНТ: {ingredientsList}");
                }
                stepNumber++;
            }
            Console.WriteLine("\nНажмите Enter чтобы продолжить...");
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
                            Console.WriteLine("Добавить:");
                            Console.WriteLine("1. Ингредиент");
                            Console.WriteLine("2. Действие");
                            Console.WriteLine("0. Отмена");

                            if (!int.TryParse(Console.ReadLine().Trim(), out int addChoice) ||
                                addChoice < 0 || addChoice > 2)
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
                                removeIndex < 0 || removeIndex > Recipe.Count)
                            {
                                Console.WriteLine("Такого элемента не существует!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            if (removeIndex == 0) { return; }

                            var elementToRemove = Recipe[removeIndex - 1];
                            BreakAggregation(elementToRemove);

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
                                editIndex < 0 || editIndex > Recipe.Count)
                            {
                                Console.WriteLine("Такого элемента не существует!");
                                Console.WriteLine("Нажмите Enter чтобы продолжить...");
                                Console.ReadLine();
                                continue;
                            }

                            if (editIndex == 0) { return; }

                            var oldElement = Recipe[editIndex - 1];
                            BreakAggregation(oldElement);
                            Recipe.RemoveAt(editIndex - 1);

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
                foreach (var element in Recipe)
                {
                    BreakAggregation(element);
                }

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
                    Console.WriteLine($"  Берем '{ingredient.Name}' ({ingredient.Weight}г/мл)");
                }
                else if (element is SomeAction action)
                {
                    Console.Write("   ");
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