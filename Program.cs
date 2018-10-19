using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Konovalov Denis
namespace HardSorting
{
    class Program
    {
        static int[] generateArray(int size)
        {
            Random r = new Random();
            int[] result = new int[size];

            for (int i = 0; i < size; i++)
            {
                result[i] = r.Next(100);
            }
            return result;
        }

        static void print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                if (i != 0 && i % 10 == 0) Console.WriteLine();
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine("\n\n");
        }

        //Реализовать сортировку подсчетом.
        static int[] sortingByCounting(int[] sourceArray)
        {
            int k = sourceArray.Length;
            int[] result = new int[k]; // Частотный массив

            for (int i = 0; i < k; i++)
                result[i] = 0;
            for (int i = 0; i < k; i++)
                result[sourceArray[i]]++;

            int b = 0;
            for (int j = 0; j < k; j++)
                for (int i = 0; i < result[j] - 1; i++)
                    sourceArray[b++] = j;

            return result;
        }

        //Реализовать быструю сортировку
        static int[] sortingByFast(int[] A)
        {
            int k = A.Length;
            int[] result = new int[k]; // Частотный массив

            return result;
        }

        static void Main(string[] args)
        {
            int size;
            int[] testArray;

            Console.WriteLine("Введите режим работы: 1 - выборка из 100 элементов, 2 - выборка из 10 000, 3 - из 1 000 000: ");
            int mode = Console.Read();
            switch (mode)
            {
                case 2:
                    size = 10000;
                    break;
                case 3:
                    size = 1000000;
                    break;
                default:
                    size = 100;
                    break;
            }
            testArray = generateArray(size);
            Console.WriteLine("Исходный массив");
            print(testArray);
            
            //--== Задача 1. Реализовать сортировку подсчётом ==--
            Console.WriteLine("Частотный массив");
            
            DateTime start = DateTime.Now;
            int[] freq = sortingByCounting(testArray);
            TimeSpan dif = DateTime.Now - start;
            Console.WriteLine("Сортировка подсчётом: {0}s {1}ms {2}ticks", dif.Seconds, dif.Milliseconds, dif.Ticks);

            print(freq);

            Console.WriteLine("Отсортированный массив:");
            int[] sorted = new int[size];
            int k = 0; // Счётчик элементов в итоговом массиве
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                    for (int j = 0; j < freq[i]; j++)
                    {
                        sorted[k] = i;
                        k++;
                    }
            }
            print(sorted);

            //--== Задача 2. Реализовать быструю сортировку ==--
            start = DateTime.Now;
            sorted = sortingByFast(testArray);
            dif = DateTime.Now - start;
            Console.WriteLine("Быстрая сортировка: {0}s {1}ms {2}ticks", dif.Seconds, dif.Milliseconds, dif.Ticks);
            
            print(sorted);

            Console.ReadKey();
        }
    }
}
