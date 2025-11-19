using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    static internal class Tasks
    {
        static public void Choose(int taskNum)
        {
            switch (taskNum)
            {
                case 0: break;
                case 1: Task1(); break;
                case 2: Task2(); break;
                case 3: Task3(); break;
                case 4: Task4(); break;
                case 5: Task5(); break;
                default: Console.WriteLine("Некорректный номер задания."); break;
            }
        }

        static private void Task1()
        {
            int size = InputValidation.InputIntegerWithValidation("\nВведите размер списка: ", 1, int.MaxValue);
            List<int> list = TaskFunctions.CreateList(size);
            Console.WriteLine("\nВаш список: ");
            TaskFunctions.PrintList(list);
            Console.WriteLine($"\n\nЕсть ли в списке одинаковые элементы: {TaskFunctions.ListHasDuplicateElements(list)}\n");
        }

        static private void Task2()
        {
            int size = InputValidation.InputIntegerWithValidation("\nВведите размер списка: ", 1, int.MaxValue);
            LinkedList<int> list = TaskFunctions.CreateLinkedList(size);
            Console.WriteLine("\nВаш список: ");
            TaskFunctions.PrintLinkedList(list);
            int n = InputValidation.InputIntegerWithValidation("\n\nВведите значение удаляемого элемента: ", int.MinValue, int.MaxValue);
            TaskFunctions.RemoveElementFromList(list, n);
            Console.WriteLine("\nВаш список: ");
            TaskFunctions.PrintLinkedList(list);
            Console.WriteLine("\n");
        }

        static private void Task3()
        {
            string[] allSongs = {
            "Golden Brown",
            "Soul Kitchen",
            "Долгая счастливая жизнь",
            "Мусорный ветер",
            "Во время дождя",
            "Never More",
            };

            Dictionary<string, HashSet<string>> musicLovers = new Dictionary<string, HashSet<string>>
            {
                ["Комаров П."] = new HashSet<string> {
                "Soul Kitchen",
                "Golden Brown",
                "Мусорный ветер"
                },
                ["Камаров Д."] = new HashSet<string> {
                "Долгая счастливая жизнь",
                "Soul Kitchen",
                "Во время дождя"
                },
                ["Иванов И."] = new HashSet<string> {
                "Во время дождя",
                "Мусорный ветер",
                "Soul Kitchen"
                }
            };

            Console.Write("\n");
            TaskFunctions.MusicPreferences(allSongs, musicLovers);

        }

        static private void Task4()
        {
            try
            {
                string text = File.ReadAllText("text.txt");
                List<char> vowels = TaskFunctions.FindUniqueVowels(text);
                Console.WriteLine("Все гласные буквы, которые не входят более чем в одно слово:\n");
                if (vowels.Count > 0)
                {
                    foreach (char vowel in vowels)
                    {
                        Console.Write($"{vowel}\n");
                    }
                    Console.Write("\n");
                }
                else
                {
                    Console.Write("Нет таких.\n\n");
                }
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        static private void Task5()
        {
            int choice = 0;
            do
            {
                choice = InputValidation.InputIntegerWithValidation("1 - ввод данных, 2 - запуск, 0 - выход\n", 0, 2);
                switch (choice)
                {
                    case 1: 
                        TaskFunctions.EnterResults("olympiad.txt"); 
                        Console.WriteLine("Данные введены");  
                        break;
                    case 2: 
                        TaskFunctions.WhoIsNotWinner("olympiad.txt"); 
                        break;
                }
            }
            while (choice != 0);
        }
    }
}

