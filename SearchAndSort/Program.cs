using System;
using System.CodeDom;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace BInarySearch
{
    enum SearchOption
    {
        Lineary,
        Binary
    };
    enum SortOption
    {
        Bubble,
        Insertion,
        Selection
    };

    class Program
    {
        static void Main(string[] args)
        {
            int numOfActivity, amount;

            int[] arrayForsearch = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

            Console.WriteLine("Выберите действие:");
            Console.WriteLine("1 - Сортировка");
            Console.WriteLine("2 - Поиск");
            Int32.TryParse(Console.ReadLine(), out numOfActivity);

            switch (numOfActivity)
            {
                case 1:
                    {
                        Console.WriteLine("Введите количество элементов:");
                        Int32.TryParse(Console.ReadLine(), out amount);
                        Console.WriteLine("Выберете тип сортировки:");
                        Console.WriteLine("1 - Сортировка пуырьком");
                        Console.WriteLine("2 - Сортировка выбором");
                        Console.WriteLine("3 - Сортировка вставками");
                        Int32.TryParse(Console.ReadLine(), out int numOfSort);
                        switch (numOfSort)
                        {
                            case 1:
                                BubbleSort(CreateArray(amount));
                                break;
                            case 2:
                                SelectionSort(CreateArray(amount));
                                break;
                            case 3:
                                InsertionSort(CreateArray(amount));
                                break;
                            default:
                                Console.WriteLine("Poshel' v jopu");
                                break;
                        }
                    }
                    break;
                case 2:
                    {
                        Console.WriteLine("Введите число для поиска от 0 до 10");
                        Int32.TryParse(Console.ReadLine(), out int findx);

                        Console.WriteLine("Выберете тип поиска:");
                        Console.WriteLine("1 - Линейный поиск");
                        Console.WriteLine("2 - Бинарный поиск");

                        Int32.TryParse(Console.ReadLine(), out int numOfSearch);
                        switch (numOfSearch)
                        {
                            case 1:
                                Console.WriteLine(LinearSearch(arrayForsearch, findx));
                                break;
                            case 2:
                                Console.WriteLine(BinarySearch(arrayForsearch, findx, 0, 9));
                                break;
                            default:
                                Console.WriteLine("poshel' v jopu");
                                break;
                        }
                    }
                    break;
                default:
                    Console.WriteLine("Введите номер типа действия");
                    break;
            }
            Console.Read();
            Console.ReadKey();
        }

        public static int BinarySearch(int[] array, int findX, int firstInx, int lastInx)
        {
            if (firstInx > lastInx)
            {
                return -1;
            }
            int middleInx = (firstInx + lastInx) / 2;
            int middleValue = array[middleInx];

            if (findX == middleValue)
            {
                return middleInx;
            }

            if (findX < middleValue)
            {
                return BinarySearch(array, findX, firstInx, middleInx - 1);
            }
            else
            {
                return BinarySearch(array, findX, middleInx + 1, lastInx);
            }
        }

        public static int LinearSearch(int[] array, int searchedValue)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                if (array[i] == searchedValue)
                {
                    return i;
                }
            }
            return -1;
        }

        public static int Search(int[] array, int searchedValue, SearchOption typeOfSearching)
        {
            switch (typeOfSearching)
            {
                case SearchOption.Lineary:
                    return LinearSearch(array, searchedValue);
                case SearchOption.Binary:
                    return BinarySearch(array, searchedValue, 0, array.Length - 1);
                default: return -1;
            }
        }
        public static void BubbleSort(int[] array)
        {
            int temp;
            for (int j = 0; j < array.Length; j++)
            {
                for (int i = 0; i < array.Length - 1; i++)
                {
                    if (array[i] > array[i + 1])
                    {
                        temp = array[i + 1];
                        array[i + 1] = array[i];
                        array[i] = temp;
                    };
                }
            }
            PrintArray(array);
        }

        public static void InsertionSort(int[] array)
        {

            for (var i = 1; i < array.Length; i++)
            {
                var key = array[i];
                var j = i;
                while ((j > 1) && (array[j - 1] > key))
                {
                    Swap(ref array[j - 1], ref array[j]);
                    j--;
                }

                array[j] = key;
            }
            PrintArray(array);
        }
        static void Swap(ref int e1, ref int e2)
        {
            var temp = e1;
            e1 = e2;
            e2 = temp;
        }
        public static void SelectionSort(int[] array)
        {
            int temp;
            for (int i = 0; i < array.Length - 1; i++)
            {
                int min = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[min])
                    {
                        min = j;
                    }
                }

                if (min != i)
                {
                    temp = array[i];
                    array[i] = array[min];
                    array[min] = temp;
                }
            }
            PrintArray(array);
        }

        public static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
        }

        public static int[] CreateArray(int amount)
        {
            int[] createdArray = new int[amount];
            var rand = new Random();
            for (int i = 0; i < amount; i++)
            {
                createdArray[i] = rand.Next(-50, 50);
            }
            return createdArray;
        }
    }
}
