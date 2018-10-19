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

        /// <summary>
        /// Сортировка подсчетом. Данная реализация рассчитана на идеальные условия.
        /// Отсутствует поиск мин и макс
        /// </summary>
        /// <param name="sourceArray"></param>
        /// <returns></returns>
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
        static int[] quickSorting(int[] data, int first, int last)
        {
            int i = first, j = last, x = data[(first + last) / 2];
            do
            {
                while (data[i] < x && i < data.Length - 1)
                    i++;
                while (data[j] > x && j > 0)
                    j--;
                if (i <= j)
                {
                    if (data[i] > data[j])
                    {
                        int tmp = data[i];
                        data[i] = data[j];
                        data[j] = tmp;
                    }
                    i++;
                    j--;
                }
            } while (i <= j);

            if (i < last)
                data = quickSorting(data, i, last);
            if (first < j)
                data = quickSorting(data, first, j);

            return data;
        }

        static void Main(string[] args)
        {
            DateTime start;
            TimeSpan dif;
            int size;
            int[] testArray;
            int[] sorted;

            Console.WriteLine("Введите режим работы: 1 - выборка из 100 элементов, 2 - выборка из 10 000, 3 - из 1 000 000: ");
            int mode = Console.Read();
            switch (mode)
            {
                case 50:
                    size = 10000;
                    break;
                case 51:
                    size = 1000000;
                    break;
                default:
                    size = 100;
                    break;
            }
            testArray = generateArray(size);
            Console.WriteLine("Исходный массив:");
            if (mode != 51) print(testArray);
            
            //--== Задача 1. Реализовать сортировку подсчётом ==--
            start = DateTime.Now;
            int[] freq = sortingByCounting(testArray);
            dif = DateTime.Now - start;
            Console.WriteLine("Сортировка подсчётом: {0}s {1}ms {2}ticks", dif.Seconds, dif.Milliseconds, dif.Ticks);
            
            Console.WriteLine("Частотный массив:");
            if (mode != 51) print(freq);

            Console.WriteLine("Отсортированный массив:");
            sorted = new int[size];
            int k = 0; // счётчик элементов в итоговом массиве
            for (int i = 0; i < freq.Length; i++)
            {
                if (freq[i] > 0)
                    for (int j = 0; j < freq[i]; j++)
                    {
                        sorted[k] = i;
                        k++;
                    }
            }
            if (mode != 51) print(sorted);

            //--== Задача 2. Реализовать быструю сортировку ==--
            start = DateTime.Now;
            sorted = quickSorting(testArray, testArray[0], testArray[size-1]);
            dif = DateTime.Now - start;
            Console.WriteLine("Быстрая сортировка: {0}s {1}ms {2}ticks", dif.Seconds, dif.Milliseconds, dif.Ticks);

            if (mode != 51) print(sorted);

            Console.ReadKey();
        }
    }
}
