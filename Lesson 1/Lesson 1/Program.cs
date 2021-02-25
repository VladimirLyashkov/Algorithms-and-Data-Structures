using System;

namespace Lesson_1
{
    class Program
    {
        /// <summary>
        /// Метод по проверке числа на простое или нет
        /// </summary>
        /// <param name="number"></param>
        static void SimpleOrDifficult(int number)
        {            
            int d = 0;
            int i = 2;
            while (i < number)
            {
                if (number % i == 0)
                {
                    d++;
                }
                i++;
            }            

            if (d==0)
            {
                Console.WriteLine($"{number} - Число простое");
            }
            else
            {
                Console.WriteLine($"{number} - Число не простое");
            }
        }

        /// <summary>
        /// Метод проверки числа на ноль и отрицательное число
        /// </summary>
        /// <returns></returns>
        static int CheckNum()
        {
            Console.WriteLine("Введите число: ");
            int num = ReadInt();
            if (num < 0)
            {
                Console.WriteLine("Отрицательное число не может быть проверенно на простое или нет");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else if (num == 0)
            {
                Console.WriteLine("Число 0 явлется составным, так как ноль имеет бесконечное число делителей");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return num;
        }

        /// <summary>
        /// метод конвертирования строки в число
        /// </summary>
        /// <returns></returns>
        static int ReadInt()
        {
            int num = 0;
            try
            {
                string str = Console.ReadLine();
                num = int.Parse(str);
            }
            catch (Exception)
            {
                Console.WriteLine("Вы ввели не число");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return num;
        }

        /// <summary>
        /// Рекурсивный метод нахождения чисел Фибоначчи
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        static long FibonachiRecursion(int num)
        {
            if (num < 3)
            {
                return 1;
            }
            else
            {
                return FibonachiRecursion(num - 2) + FibonachiRecursion(num - 1);
            }
        }

        static void Fibonachi(int num)
        {
            int a = 1, b = 1, c = 1;
            if (num <= 2)
            {
                Console.WriteLine(1);
            }
            else
            {
                for (int i = 2; i < num; i++)
                {
                    Console.Write($"{c} ");
                    c = a + b;                    
                    a = b;
                    b = c;
                }
            }
            Console.WriteLine();
        }

        static void Main(string[] args)
        {
            #region Задание 1

            /*Требуется реализовать на C# функцию согласно блок-схеме. Блок-схема описывает алгоритм проверки, простое число или нет.
                1. Написать консольное приложение.
                2. Алгоритм реализовать отдельно в функции согласно блок - схеме.
                3. Написать проверочный код в main функции .
                4. Код выложить на GitHub.
            */

            Console.WriteLine("Какое число проверить на простое или нет?");
            SimpleOrDifficult(CheckNum());
            Console.ReadKey();
            Console.Clear();

            #endregion

            #region Задание 2

            //Вычислите асимптотическую сложность функции из примера ниже.

            /*
            public static int StrangeSum(int[] inputArray)
            {
                int sum = 0;
                for (int i = 0; i < inputArray.Length; i++)
                {
                    for (int j = 0; j < inputArray.Length; j++)
                    {
                        for (int k = 0; k < inputArray.Length; k++)
                        {
                            int y = 0;

                            if (j != 0)
                            {
                                y = k / j;
                            }

                            sum += inputArray[i] + i + k + j + y;
                        }
                    }
                }

                return sum;
            }
            */

            //Асимптотическая сложно функции равна = O(N^3)

            #endregion

            #region Задание 3

            /*
                Требуется реализовать рекурсивную версию и версию без рекурсии (через цикл).
                Пример чисел Фибоначчи:
                F(0) = 0,
                F(1) = 1.
                Для остальных чисел:
                F(N) = F(N - 2) + F(N - 1).
                То есть для F(2) будет F(2) = F(0) + F(1) = 0 + 1 = 1.
                F(3) будет F(3) = F(1) + F(2) = 1 + 1 = 2.
            */

            Console.WriteLine("Введите число до какого считать ряд Фибоначчи");
            int fibNum = ReadInt();
            Console.WriteLine("Через рекурсию: ");
            for (int i = 1; i < fibNum; i++)
            {
                Console.Write($"{FibonachiRecursion(i)} ");
            }
            
            Console.WriteLine("\nЧерез цикл: ");
            Fibonachi(fibNum);
            #endregion
        }
    }
}
