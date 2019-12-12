using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class Implementation
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/magic-square-forming/problem
        /// </summary>
        [TestMethod]
        public void FormingMagicSquareTest()
        {
            var s1 = new int[3][];

            s1[0] = new int[3];
            s1[1] = new int[3];
            s1[2] = new int[3];

            s1[0][0] = 5;
            s1[0][1] = 3;
            s1[0][2] = 4;
            s1[1][0] = 1;
            s1[1][1] = 5;
            s1[1][2] = 8;
            s1[2][0] = 6;
            s1[2][1] = 4;
            s1[2][2] = 2;
            Assert.AreEqual(7, FormingMagicSquare(s1), "1");
        }

        int FormingMagicSquare(int[][] s)
        {
            int result = 81;

            //c − b         c +(a + b)  c − a
            //c − (a − b)   c           c +(a − b)
            //c + a         c − (a + b) c + b

            // 2,9,4
            // 7,5,3
            // 6,1,8


            int[][] magics = new int[][]
            {
                new int[] { 8, 1, 6, 3, 5, 7, 4, 9, 2},
                new int[] { 6, 1, 8, 7, 5, 3, 2, 9, 4},
                new int[] { 4, 9, 2, 3, 5, 7, 8, 1, 6},
                new int[] { 2, 9, 4, 7, 5, 3, 6, 1, 8},
                new int[] { 8, 3, 4, 1, 5, 9, 6, 7, 2},
                new int[] { 4, 3, 8, 9, 5, 1, 2, 7, 6},
                new int[] { 6, 7, 2, 1, 5, 9, 8, 3, 4},
                new int[] { 2, 7, 6, 9, 5, 1, 4, 3, 8}
            };
            //for (int a = 0; a <= 9; a++)
            //{
            //    for (int b = 0; b <= 9; b++)
            //    {
            //        for (int c = 0; c <= 9; c++)
            //        {
            //            if ((0 < a && a < b &&  b < (c - a)) && 
            //                b != 2 * a &&
            //                a + b + c < 10)
            //            {
            //                int[][] vs = new int[3][];
            //                vs[0] = new int[] { c - b, c + a + b, c - a };
            //                vs[1] = new int[] { c - (a - b), c, c + (a - b) };
            //                vs[2] = new int[] { c + a, c - (a + b), c + b };

            //                posibilities.Add(vs);
            //            }
            //        }
            //    }
            //}

            //allMagics.Select(ar => ar.Zip(square, (a, b) => Math.Abs(a - b)).Sum()).Min()

            for (int i = 0; i < magics.Length; i++)
            {
                int crt_cost = 0;
                for (int j = 0; j < magics[i].Length; i++)
                {
                    crt_cost += Math.Abs(s[i][j] - magics[i][j]);

                    if (crt_cost < result)
                        result = crt_cost;
                }
            }

            return result;
        }
        public int[][] FormingMagicSquareHelp(int currentI, int currentJ)
        {
            int[][] s = new int[3][];
            s[0] = new int[3];
            s[1] = new int[3];
            s[2] = new int[3];



            return s;
        }

        [TestMethod]
        public void LRUTest()
        {
            //Assert.AreEqual(7, LRU(s1), "1");
        }
        void LRU()
        {

        }

        [TestMethod]
        public void GetLuckyFloorNumberTest()
        {
            //Real:  1  2  3  4  5  6  7  8  9  10  11  12  13  14
            //Lucky: 1  2  3  5  6  7  8  9  10 11  12  15  16  17
            int n1 = 1;
            int n2 = 4;
            int n3 = 5;
            int n4 = 12;
            int n5 = 14;

            Assert.AreEqual(1, GetLuckyFloorNumber(n1), "1");
            Assert.AreEqual(5, GetLuckyFloorNumber(n2), "2");
            Assert.AreEqual(6, GetLuckyFloorNumber(n3), "3");
            Assert.AreEqual(15, GetLuckyFloorNumber(n4), "4");
            Assert.AreEqual(17, GetLuckyFloorNumber(n5), "5");
        }
        int GetLuckyFloorNumber(int n)
        {
            int result = n;

            for (int i = 1; i <= n; i++)
            {
                if (i.ToString().Contains("4") ||
                    i.ToString().Contains("13"))
                {
                    result++;
                    while (result.ToString().Contains("4") ||
                        result.ToString().Contains("13"))
                    {
                        result++;
                    }
                }

            }

            return result;
        }

        [TestMethod]
        public void PackNumbersTest()
        {
            //['5:3', '7:2', 3, 4, 7]
            List<int> arr1 = new List<int>()
            {
                5, 5, 5, 7, 7, 3, 4, 7
                //5, 5, 5
            };
            List<string> result = PackNumbers(arr1);

            CollectionAssert.AreEquivalent(new List<string> { "5:3", "7:2", "3", "4", "7" }, result, "1");
        }
        List<string> PackNumbers(List<int> arr)
        {
            List<string> result = new List<string>();
            string resultText;

            if (arr.Count == 1)
                return new List<string>() { arr[0].ToString() };

            int sameNeighbors = 1;
            for (int i = 1; i < arr.Count; i++)
            {
                int current = arr[i];
                int previous = arr[i - 1];

                if (current == previous)
                {
                    sameNeighbors = sameNeighbors + 1;
                }
                else
                {
                    if (sameNeighbors == 1)
                        resultText = $"{previous}";
                    else
                        resultText = $"{previous}:{sameNeighbors}";

                    result.Add(resultText);
                    sameNeighbors = 1;
                }
            }

            if (sameNeighbors == 1)
                resultText = $"{arr[arr.Count - 1]}";
            else
                resultText = $"{arr[arr.Count - 1]}:{sameNeighbors}";
            result.Add(resultText);

            return result;
        }
    }

    public class LRUCache
    {
        private readonly Queue<string> _queue;
        private readonly HashSet<string> _keys;
        private readonly int _pointer;

        LRUCache(int n)
        {
            this._queue = new Queue<string>(n);
            this._keys = new HashSet<string>();
        }

        void AddInput(string input)
        {
            if (this._keys.Contains(input))
                RemoveLast();
            else
                RemoveByIndex(input);


        }

        private void RemoveByIndex(string input)
        {
            throw new NotImplementedException();
        }

        private void RemoveLast()
        {
            throw new NotImplementedException();
        }
    }
}