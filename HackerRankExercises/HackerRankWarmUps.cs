using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HackerRankExercises
{
    [TestClass]
    public class HackerRankWarmUps
    {
        [TestMethod]
        public void SockMerchantTest()
        {
            int[] testArray = { 1, 2, 1, 2, 1, 3, 2 };
            Assert.AreEqual(2, SockMerchant(testArray));
        }
        int SockMerchant(int[] ar)
        {
            HashSet<int> hashSet = new HashSet<int>();
            int count = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                int key = ar[i];
                if (hashSet.Contains(key))
                {
                    count++;
                    hashSet.Remove(key);
                }
                else
                {
                    hashSet.Add(key);
                }
            }
            return count;
        }

        /// <summary>
        /// 
        /// </summary>
        [TestMethod]
        public void CountingValleysTest()
        {
            string path = "UDDDUDUU";
            Assert.AreEqual(1, CountingValleys(path));
            path = "DDUUDDUDUUUD";
            Assert.AreEqual(2, CountingValleys(path));
        }
        int CountingValleys(string s)
        {
            int result = 0;
            int current = 0;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'U')
                    current++;
                else
                    current--;

                if (current == 0 && s[i] == 'U')
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/jumping-on-the-clouds
        /// </summary>
        [TestMethod]
        public void JumpingOnTheCloudsTest()
        {
            int[] clouds1 = { 0, 0, 0, 0, 1, 0 };
            Assert.AreEqual(3, JumpingOnClouds(clouds1));
            int[] clouds2 = { 0, 0, 1, 0, 0, 1, 0 };
            Assert.AreEqual(4, JumpingOnClouds(clouds2));
            int[] clouds3 = { 0, 1, 0, 0, 0, 1, 0 };
            Assert.AreEqual(3, JumpingOnClouds(clouds3));
            int[] clouds4 = { 0, 0, 0, 1, 0, 0 };
            Assert.AreEqual(3, JumpingOnClouds(clouds4));
        }
        //int JumpingOnClouds(int[] c)
        //{
        //    int result = 0;            

        //    for (int i = 0; i < c.Length ; i++)
        //    {
        //        if (c[i] == 0 && i!=0)
        //        {
        //            result++;
        //        }                

        //        if (i+2 < c.Length && c[i+2] == 0)
        //        {
        //            i++;
        //        }
        //    }

        //    return result;
        //}

        //int JumpingOnClouds(int[] c)
        //{
        //    int result = 0;

        //    for (int i = 0; i < c.Length - 1; i++, result++)
        //    {
        //        if (i + 2 < c.Length && c[i + 2] == 0)
        //        {
        //            i++;
        //        }
        //    }

        //    return result;
        //}
        int JumpingOnClouds(int[] c)
        {
            int jumps = 0;

            for (int i = 0; i < c.Length - 1; i += 2, jumps += 1)
            {
                if (c[i] == 1) i--;
            }

            return jumps;
        }

        [TestMethod]
        public void RepeatedStringTest()
        {
            string s1 = "abcac";
            long n1 = 5;
            Assert.AreEqual(2, RepeatedString(s1, n1));
            string s2 = "aba";
            long n2 = 10;
            Assert.AreEqual(7, RepeatedString(s2, n2));
            string s3 = "abcac";
            long n3 = 10;
            Assert.AreEqual(4, RepeatedString(s3, n3));
            string s4 = "a";
            long n4 = 10000000000;
            Assert.AreEqual(10000000000, RepeatedString(s4, n4));
        }
        //private long RepeatedString(string s, long n)
        //{
        //    long result = 0;

        //    int j = 0;
        //    for (int i = 0; i < n; i++)
        //    {
        //        if (s[j] == 'a')
        //            result++;

        //        if (j == s.Length - 1)
        //        {
        //            j = 0;
        //        }
        //        else
        //        {
        //            j++;
        //        }
        //    }

        //    return result;
        //}
        private long RepeatedString(string s, long n)
        {
            long result = 0;
            long iterations = n / s.Length;
            long module = n % s.Length;

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == 'a')
                {
                    result += iterations + (i < module ? 1 : 0);
                }
            }

            return result;
        }

        [TestMethod]
        public void CompareTripletsTest()
        {
            List<int> a1 = new List<int>() { 5, 6, 7 };
            List<int> b1 = new List<int>() { 3, 6, 10 };
            List<int> r1 = new List<int>() { 1, 1 };

            CollectionAssert.AreEqual(r1, CompareTriplets(a1, b1));


            List<int> a2 = new List<int>() { 17, 28, 30 };
            List<int> b2 = new List<int>() { 99, 16, 8 };
            List<int> r2 = new List<int>() { 2, 1 };

            CollectionAssert.AreEqual(r2, CompareTriplets(a2, b2));
        }
        List<int> CompareTriplets(List<int> a, List<int> b)
        {
            List<int> result = new List<int>();
            int aWins = 0;
            int bWins = 0;

            for (int i = 0; i < a.Count; i++)
            {
                if (a[i] > b[i])
                    aWins++;
                else if (a[i] < b[i])
                    bWins++;
            }

            result.Add(aWins);
            result.Add(bWins);

            return result;
        }

        [TestMethod]
        public void DiagonalDifferenceTest()
        {
            List<List<int>> arr1 = new List<List<int>> {
                new List<int> { 11, 2, 4 },
                new List<int> { 4, 5, 6 },
                new List<int> { 10, 8, - 12 }
            };

            Assert.AreEqual(15, DiagonalDifference(arr1));
        }
        int DiagonalDifference(List<List<int>> arr)
        {
            int result = 0;

            int leftToRightDiagonalSum = 0;
            int rightToLeftDiagonalSum = 0;

            for (int i = 0; i < arr.Count; i++)
            {
                int length = arr[i].Count;
                for (int j = 0; j < length; j++)
                {
                    if (j == i)
                        leftToRightDiagonalSum += arr[i][j];
                    if (j == length - 1 - i)
                        rightToLeftDiagonalSum += arr[i][j];
                }
            }

            result = Math.Abs(leftToRightDiagonalSum - rightToLeftDiagonalSum);

            return result;
        }

        [TestMethod]
        public void PlusMinusTest()
        {
            int[] arr1 = { 1, 1, 0, -1, -1 };
            decimal[] expected1 = { 2m / 5m, 2m / 5m, 1m / 5m };

            CollectionAssert.AreEqual(expected1, PlusMinus(arr1));
        }
        decimal[] PlusMinus(int[] arr)
        {
            decimal[] result = new decimal[3];
            int positive = 0;
            int zero = 0;
            int negative = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] > 0)
                    positive++;
                else if (arr[i] < 0)
                    negative++;
                else
                    zero++;
            }

            result[0] = (decimal)((decimal)positive / (decimal)arr.Length);
            result[1] = (decimal)((decimal)negative / (decimal)arr.Length);
            result[2] = (decimal)((decimal)zero / (decimal)arr.Length);
            return result;
        }

        [TestMethod]
        public void StaircaseTest()
        {
            Staircase(6);
        }

        void Staircase(int n)
        {
            int count = 1;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (j < n - count)
                        sb.Append(" ");
                    else
                        sb.Append("#");
                }
                count++;
                sb.AppendLine();
            }

            Console.Write(sb.ToString());
        }

        [TestMethod]
        public void MiniMaxSumTest()
        {
            int[] arr = { 256741038, 623958417, 467905213, 714532089, 938071625 };
            MiniMaxSum(arr);
        }
        void MiniMaxSum(int[] arr)
        {
            long sum = 0;
            int min = arr[0];
            int max = arr[0];
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
                sum += arr[i];
            }

            Console.Write(sum - max + " ");
            Console.Write(sum - min);
        }

        [TestMethod]
        public void BirthdayCakeCandlesTest()
        {
            int[] arr = { 3, 2, 1, 3 };
            BirthdayCakeCandles(arr);
        }
        int BirthdayCakeCandles(int[] ar)
        {
            int result;
            int max = int.MinValue;

            Dictionary<int, int> keys = new Dictionary<int, int>();
            for (int i = 0; i < ar.Length; i++)
            {
                if (ar[i] > max)
                {
                    max = ar[i];
                }
                if (keys.ContainsKey(ar[i]))
                    keys[ar[i]]++;
                else
                    keys.Add(ar[i], 1);
            }

            result = keys[max];
            return result;
        }


    }
}
