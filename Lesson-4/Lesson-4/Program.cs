using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Lesson_4
{
    class Program
    {
        static void Main(string[] args)
        {
            /*Напишите тесты производительности для расчёта дистанции между точками с помощью BenchmarkDotNet.
             Рекомендуем сгенерировать заранее массив данных, чтобы расчёт шёл с различными значениями,
             но сам код генерации должен происходить вне участка кода, время которого будет тестироваться.
             Для каких методов потребуется написать тест:
                1.Обычный метод расчёта дистанции со ссылочным типом(PointClass — координаты типа float).
                2.Обычный метод расчёта дистанции со значимым типом(PointStruct — координаты типа float).
                3.Обычный метод расчёта дистанции со значимым типом(PointStruct — координаты типа double).
                4.Метод расчёта дистанции без квадратного корня со значимым типом(PointStruct — координаты типа float).
            */

            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
            
        } 
    }
    public class PointClass
    {
        public int X;
        public int Y;
    }

    public struct PointStruct
    {
        public int X;
        public int Y;
    }

    public class BechmarkClass
    {
        [Benchmark]
        [ArgumentsSource(nameof(ValuesPointClass))]
        public float PointDistanceFloatClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        [ArgumentsSource(nameof(ValuesPointStruct))]
        public float PointDistanceFloatStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        [ArgumentsSource(nameof(ValuesPointStruct))]
        public double PointDistanceDoubleStruct(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

        [Benchmark]
        [ArgumentsSource(nameof(ValuesPointStruct))]
        public float PointDistanceFloatShort(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        public int RandomNum()
        {
            Random rand = new Random(10);
            int num = rand.Next();
            return num;
        }

        public IEnumerable<object[]> ValuesPointClass()
        {
            int num = RandomNum();

            yield return new object[] { new PointClass { X = num }, new PointClass { Y = num } };            
        }

        public IEnumerable<object[]> ValuesPointStruct()
        {
            int num = RandomNum();

            yield return new object[] { new PointStruct { X = RandomNum() }, new PointStruct { Y = RandomNum() } };
            yield return new object[] { new PointStruct { X = RandomNum() }, new PointStruct { Y = RandomNum() } };
            yield return new object[] { new PointStruct { X = RandomNum() }, new PointStruct { Y = RandomNum() } };
        }

    }
}
