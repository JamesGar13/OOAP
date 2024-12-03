using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ooap_lab3_reserve
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = GenerateArray(2000);

            Task bubbleSortTask = Task.Run(() => SortAndLog(array, BubbleSort, "Bubble Sort"));
            Task shellSortTask = Task.Run(() => SortAndLog(array, ShellSort, "Shell Sort"));
            Task quickSortTask = Task.Run(() => SortAndLog(array, QuickSort, "Quick Sort"));

            Task.WaitAll(bubbleSortTask, shellSortTask, quickSortTask);

            Console.WriteLine("Sorting complete. Check the sorting_times.txt file for results.");
        }

        static int[] GenerateArray(int size)
        {
            Random random = new Random();
            int[] array = new int[size];
            for (int i = 0; i < size; i++)
            {
                array[i] = random.Next(1, 10000);
            }
            return array;
        }

        static void SortAndLog(int[] array, Action<int[]> sortMethod, string sortName)
        {
            int[] arrayCopy = (int[])array.Clone();
            Stopwatch stopwatch = Stopwatch.StartNew();
            sortMethod(arrayCopy);
            stopwatch.Stop();

            string logMessage = $"{sortName} took {stopwatch.ElapsedMilliseconds} ms.";
            Logger.Instance.Log(logMessage);
        }

        static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        static void ShellSort(int[] array)
        {
            int n = array.Length;
            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = array[i];
                    int j;
                    for (j = i; j >= gap && array[j - gap] > temp; j -= gap)
                    {
                        array[j] = array[j - gap];
                    }
                    array[j] = temp;
                }
            }
        }

        static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }

        static void QuickSort(int[] array, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(array, low, high);
                QuickSort(array, low, pivotIndex - 1);
                QuickSort(array, pivotIndex + 1, high);
            }
        }

        static int Partition(int[] array, int low, int high)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                if (array[j] <= pivot)
                {
                    i++;
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                }
            }
            int temp1 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp1;

            return i + 1;
        }
    }
}
