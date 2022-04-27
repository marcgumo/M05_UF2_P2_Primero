using System;
using System.Diagnostics;

namespace ProyectoSorting
{
    public class SortingArray
    {
        public int[] array;
        public int[] arrayCreciente;
        public int[] arrayDecreciente;

        public SortingArray(int elements, Random random)
        {
            array = new int[elements];
            arrayCreciente = new int[elements];
            arrayDecreciente = new int[elements];
            for (int i = 0; i < elements; i++)
            {
                array[i] = random.Next(100);
            }
            Array.Copy(array, arrayCreciente, elements);
            Array.Sort(arrayCreciente);
            Array.Copy(arrayCreciente, arrayDecreciente, elements);
            Array.Reverse(arrayDecreciente);
        }

        public void Sort(Action<int[]> func)
        {
            Stopwatch time = new Stopwatch();
            int[] temp = new int[array.Length];
            Array.Copy(array, temp, array.Length);

            Console.WriteLine(func.Method.Name);

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Initial: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "ticks");

            time.Reset();
            
            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Increasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "ticks");

            time.Reset();

            Array.Reverse(temp);

            time.Start();

            func(temp);

            time.Stop();

            Console.WriteLine("Decreasing: " + time.ElapsedMilliseconds + "ms " + time.ElapsedTicks + "ticks");
        }
        public void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }
        public void BubbleSortEarlyExit(int[] array)
        {
            bool ordered = true;
            for (int i = 0; i < array.Length - 1; i++)
            {
                ordered = true;
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if(array[j] > array[j + 1])
                    {
                        ordered = false;
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
                if (ordered)
                    return;
            }
        }
        public void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        public void QuickSort(int[] array, int left, int right)
        {
            if(left < right)
            {
                int pivot = QuickSortPivot(array, left, right);
                QuickSort(array, left, pivot);
                QuickSort(array, pivot + 1, right);
            }
        }
        public int QuickSortPivot(int[] array, int left, int right)
        {
            int pivot = array[(left + right) / 2];
            while (true)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }
                if(left >= right)
                {
                    return right;
                }
                else
                {
                    int temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;
                    right--; left++;
                }
            }
        }

        public void InsertionSort(int[] array)
        {

        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("How many elements do you want?");
            int elements = int.Parse(Console.ReadLine());

            Console.WriteLine("What seed do you want to use?");
            int seed = int.Parse(Console.ReadLine());

            Random random = new Random(seed);
            SortingArray array = new SortingArray(elements, random);
            array.Sort(array.BubbleSort);
            array.Sort(array.BubbleSortEarlyExit);
            array.Sort(array.QuickSort);

        }
    }
}
