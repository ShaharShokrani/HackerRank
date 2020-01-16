using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankExercises
{
    [TestClass]
    public class Sorting
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-bubble-sort/
        /// </summary>
        [TestMethod]
        public void CountSwapsTest()
        {
            int[] a1 = { 6, 4, 1 };
            Assert.AreEqual(3, CountSwaps(a1));
        }
        int CountSwaps(int[] a)
        {
            int result = 0;
            bool isArraySorted = false;
            int numOfNeedToBeSort = a.Length - 1;

            while (!isArraySorted)
            {
                isArraySorted = true;
                for (int i = 0; i < numOfNeedToBeSort; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        Swap(ref a[i], ref a[i + 1]);
                        isArraySorted = false;
                        result++;
                    }
                }
                numOfNeedToBeSort--;
            }

            Console.WriteLine($"Array is sorted in {result} swaps.");
            Console.WriteLine($"First Element: {a[0]}");
            Console.WriteLine($"Last Element: {a[a.Length - 1]}");
            return result;
        }

        public static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        [TestMethod]
        public void QuickSortTest()
        {
            int[] array2 = { 44, 88, 77, 22 };

            QuickSort(array2);
            CollectionAssert.AreEqual(new int[] { 22, 44, 77, 88 }, array2);

            int[] array1 = { 44, 88, 77, 22, 66, 11, 99, 55, 0, 33 };

            QuickSort(array1);
            CollectionAssert.AreEqual(new int[] { 0, 11, 22, 33, 44, 55, 66, 77, 88, 99 }, array1);
        }

        private static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right || right < 0)
                return;

            int pivot = array[left];
            int partition = Partition(array, left, right, pivot);
            QuickSort(array, left, partition - 1);
            QuickSort(array, partition + 1, right);
        }
        private static int Partition(int[] array, int left, int right, int pivotValue)
        {
            int partitionIndex = left;
            for (int j = partitionIndex + 1; j <= right; j++)
            {
                if (array[j] < pivotValue)
                {
                    partitionIndex++;
                    Swap(ref array[j], ref array[partitionIndex]);
                }
            }

            //Switch the pivot.
            if (partitionIndex != left)
            {                
                Swap(ref array[left], ref array[partitionIndex]);
            }

            return partitionIndex;
        }

        [TestMethod]
        public void CountingSortTest()
        {
            int[] array2 = { 1, 4, 1, 2 };            
            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 4 }, CountingSort(array2));

            int[] array1 = { 1, 4, 1, 2, 7, 5, 2 };
            CollectionAssert.AreEqual(new int[] { 1, 1, 2, 2, 4, 5, 7 }, CountingSort(array1));
        }

        private int[] CountingSort(int[] array)
        {
            int[] countArray = GetCountedArray(array);
            int[] sortedArray = GetSortedArray(array, countArray);
            return sortedArray;
        }
        private int[] GetCountedArray(int[] array)
        {
            int[] countArray = InitCountArray(array);
            int[] arithmeticCountArray = GetArithmeticCountArray(countArray);

            return countArray;
        }

        private int[] InitCountArray(int[] array)
        {
            int max = FindMax(array);
            int[] countArray = new int[200000 + 1];

            for (int i = 0; i < array.Length; i++)
            {
                int index = array[i];
                countArray[index]++;
            }

            return countArray;
        }        

        private int FindMax(int[] array)
        {
            int max = Int32.MinValue;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i]> max)
                {
                    max = array[i];
                }
            }
            return max;
        }

        private int[] GetArithmeticCountArray(int[] countArray)
        {
            for (int i = 1; i < countArray.Length; i++)
            {
                countArray[i] = countArray[i] + countArray[i - 1];
            }
            return countArray;
        }

        private int[] GetSortedArray(int[] array, int[] countArray)
        {            
            int[] sortedArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                int countIndex = array[i];
                int sortIndex = countArray[countIndex] - 1;
                countArray[countIndex] = countArray[countIndex] - 1;
                sortedArray[sortIndex] = array[i];
            }

            return sortedArray;
        }

        //private int[] GetSortedArray(int[] array, int[] countArray, int days)
        //{
        //    int[] sortedArray = new int[days];
        //    for (int i = 0; i < days; i++)
        //    {
        //        int countIndex = array[i];
                
        //        // Extract the sort index:
        //        int sortIndex = countArray[countIndex] - 1;

        //        // Decrease the count array:
        //        countArray[countIndex] = countArray[countIndex] - 1;

        //        // Final sorted array:
        //        sortedArray[sortIndex] = array[i];
        //    }

        //    return sortedArray;
        //}

        [TestMethod]
        public void MaximumToysTest()
        {
            int[] prices1 = { 1, 2, 3, 4 };
            int k1 = 7;
            Assert.AreEqual(3, MaximumToys(prices1, k1));

            int[] prices2 = { 1, 12, 5, 111, 200, 1000, 10 };
            int k2 = 50;
            Assert.AreEqual(4, MaximumToys(prices2, k2));
        }
        int MaximumToys(int[] prices, int k)
        {
            int result = 0;

            int sum = 0;
            QuickSort(prices);

            for (int i = 0; i < prices.Length; i++)
            {
                sum += prices[i];
                if (sum >= k)
                {
                    result = i;
                    break;
                }
            }

            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void ActivityNotificationsTest()
        {
            int[] expenditure3 = { 2, 1, 3, 4, 5 };
            int d3 = 3;
            Assert.AreEqual(2, ActivityNotifications(expenditure3, d3));

            int[] expenditure1 = { 1, 2, 3, 4, 4 };
            int d1 = 4;
            Assert.AreEqual(0, ActivityNotifications(expenditure1, d1));

            int[] expenditure2 = { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            int d2 = 5;
            Assert.AreEqual(2, ActivityNotifications(expenditure2, d2));
        }
        int ActivityNotifications(int[] expenditure, int days)
        {
            int result = 0;            

            int leftIndex = (int)Decimal.Floor((days - 1) / 2m);
            int rightIndex = (int)Decimal.Ceiling((days - 1) / 2m);

            int[] countArray = new int[200 + 1];
            for (int i = 0; i < days; i++)
            {
                countArray[expenditure[i]]++;
            }
            int m1 = 0, m2 = 0;

            for (int i = days; i < expenditure.Length; i++)
            {
                m1 = GetMedian(countArray, leftIndex);
                m2 = GetMedian(countArray, rightIndex);
                
                decimal m = (m1 + m2) / 2m;

                if (expenditure[i] >= m * 2) result++;

                // Replace subarray elements
                countArray[expenditure[i - days]]--;
                countArray[expenditure[i]]++;
            }

            return result;
        }

        private int GetMedian(int[] countArray, int leftIndex)
        {
            for (int j = 0, k = 0, length = countArray.Length; j < length; j++)
            {                
                if (k == leftIndex) //We walk through k different numbers to reach the value.
                    return j;
                k += countArray[j];
            }
            return 0;
        }
    }
}