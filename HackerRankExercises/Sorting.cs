using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
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

        private static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

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

        private static void QuickSort(int[] array)
        {
            QuickSort(array, 0, array.Length - 1);
        }
        private static void QuickSort(int[] array, int left, int right)
        {
            if (left >= right)
                return;

            int pivot = array[(left + right) / 2];
            int partition = Partition(array, left, right, pivot);
            QuickSort(array, left, partition - 1);
            QuickSort(array, partition, right);
        }
        private static int Partition(int[] array, int left, int right, int pivot)
        {
            while (left <= right)
            {
                while (array[left] < pivot)
                {
                    left++;
                }
                while (array[right] > pivot)
                {
                    right--;
                }

                if (left <= right)
                {
                    Swap(ref array[left], ref array[right]);
                    left++;
                    right--;
                }
            }
            return left;
        }

        [TestMethod]
        public void ActivityNotificationsTest()
        {
            int[] expenditure3 = { 20, 10, 30, 40, 50 };
            int d3 = 3;
            Assert.AreEqual(1, ActivityNotifications(expenditure3, d3));

            int[] expenditure1 = { 1, 2, 3, 4, 4 };
            int d1 = 4;
            Assert.AreEqual(0, ActivityNotifications(expenditure1, d1));

            int[] expenditure2 = { 2, 3, 4, 2, 3, 6, 8, 4, 5 };
            int d2 = 5;
            Assert.AreEqual(2, ActivityNotifications(expenditure2, d2));
        }
        int ActivityNotifications(int[] expenditure, int d)
        {
            int result = 0;

            bool isEven = false;
            if (d % 2 == 0)
            {
                isEven = true;
            }

            for (int i = d; i < expenditure.Length; i++)
            {
                double median;
                QuickSort(expenditure, i - d, i - 1);

                if (isEven)
                {
                    double middle = (d - 1) / 2;
                    int medianIndex1 = (int)Math.Floor(middle);
                    int medianIndex2 = (int)Math.Ceiling(middle);

                    int sum = expenditure[i - medianIndex1] + expenditure[i - medianIndex2];
                    median = (double)sum / (double)d;
                }
                else
                {
                    median = expenditure[i - ((d + 1) / 2)];
                }

                if (expenditure[i] >= median * 2)
                {
                    result++;
                }
            }

            return result;
        }

        //int ActivityNotifications(int[] expenditure, int d)
        //{

        //}
    }
}