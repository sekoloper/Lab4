namespace Lab4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice = -1;

            Console.WriteLine("Лабораторная 3\n~~~~~~~~~~~~~~~~\n");
            Console.WriteLine("Задания:\n");
            Console.WriteLine("1 - есть ли в списке хотя бы два одинаковых элемента");
            Console.WriteLine("2 - удалить из списка первое вхождение элемента, если такой есть");
            Console.WriteLine("3 - какие песни скольким меломанам нравятся");
            Console.WriteLine("4 - все гласные буквы, которые не входят более чем в одно слово из файла");
            Console.WriteLine("5 - нахождение лучшего участника олимпиады, на ставшего победителем\n");

            while (choice != 0)
            {
                choice = InputValidation.InputIntegerWithValidation("~~~~~~~~~~~~~~~~\nВведите номер задания или 0 для выхода:", 0, 8);
                Tasks.Choose(choice);
            }
        }
    }
}

