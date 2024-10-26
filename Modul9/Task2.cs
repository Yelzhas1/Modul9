using System;
using System.Collections.Generic;

namespace Event
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем список фамилий
            List<string> surnames = new List<string> { "Иванов", "Смирнов", "Петров", "Сидоров", "Кузнецов" };

            // Создаем объект NumberReader и подписываемся на событие
            NumberReader numberReader = new NumberReader();
            numberReader.NumberEnteredEvent += (number) => SortAndDisplaySurnames(number, surnames);

            while (true)
            {
                try
                {
                    numberReader.Read();
                }
                catch (MyException ex)
                {
                    Console.WriteLine("Произошло исключение! " + ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Произошло исключение! " + ex.Message);
                }
                finally
                {
                    Console.WriteLine("Попробуйте еще раз.");
                }
            }
        }

        static void SortAndDisplaySurnames(int number, List<string> surnames)
        {
            if (number == 1)
            {
                surnames.Sort(); // Сортировка по алфавиту (А-Я)
                Console.WriteLine("Список фамилий (А-Я):");
            }
            else if (number == 2)
            {
                surnames.Sort();
                surnames.Reverse(); // Сортировка в обратном порядке (Я-А)
                Console.WriteLine("Список фамилий (Я-А):");
            }

            foreach (string surname in surnames)
            {
                Console.WriteLine(surname);
            }
        }
    }

    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberEnteredEvent;

        public void Read()
        {
            Console.WriteLine();
            Console.WriteLine("Введите 1 для сортировки А-Я или 2 для сортировки Я-А:");

            int number = Convert.ToInt32(Console.ReadLine());
            if (number != 1 && number != 2) throw new MyException("Укажите правильное число 1 или 2");

            NumberEntered(number);

            Console.WriteLine("Введите 1 для сортировки А-Я или 2 для сортировки Я-А:");
        }

        protected virtual void NumberEntered(int number)
        {
            NumberEnteredEvent?.Invoke(number);
        }
    }

    // Создание собственного исключения
    class MyException : Exception
    {
        public MyException(string message) : base(message) { }
    }
}
