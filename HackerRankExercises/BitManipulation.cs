using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankExercises
{
    [TestClass]
    public class BitManipulation
    {
        [TestMethod]
        public void AddTest()
        {
            int x1 = 1;
            int y1 = 3;

            Assert.AreEqual(4, Add(x1, y1), "1");
        }
        int Add(int x, int y)
        {
            int index = 0;
            // Iterate till there is no carry 
            while (y != 0)
            {
                Console.WriteLine($"index: {index} ------------------------");
                Console.WriteLine($"x: {Convert.ToString(value: x, toBase: 2)}");
                Console.WriteLine($"y: {Convert.ToString(value: y, toBase: 2)}");

                // carry now contains common 
                // set bits of x and y 
                int carry = x & y;
                Console.WriteLine($"x & y: {Convert.ToString(value: carry, toBase: 2)}");
                // Sum of bits of x and  
                // y where at least one  
                // of the bits is not set 
                x = x ^ y;
                Console.WriteLine($"x = x ^ y:");
                Console.WriteLine($"{Convert.ToString(value: x, toBase: 2)}");

                // Carry is shifted by  
                // one so that adding it  
                // to x gives the required sum 
                y = carry << 1;
                Console.WriteLine($" y = y << 1:");
                Console.WriteLine($"{Convert.ToString(value: y, toBase: 2)}");
                index++;
            }


            Console.WriteLine($"base 2 ------------------------");
            for (int i = 0; i < 11; i++)
            {
                Console.WriteLine($"{i}: {Convert.ToString(value: i, toBase: 2)}");
            }


            return x;


        }
        /// <summary>
        /// https://www.hackerrank.com/challenges/lonely-integer/problem
        /// </summary>
        [TestMethod]
        public void FindPointTest()
        {
            int[] a1 = new int[] { 1, 2, 3, 4, 3, 2, 1 };
            Assert.AreEqual(4, Lonelyinteger(a1), "1");
            Assert.AreEqual(4, Lonelyinteger2(a1), "1");
        }

        int Lonelyinteger(int[] a)
        {
            int result = 0;
            int[] countArray = new int[100 + 1];
            for (int i = 0; i < a.Length; i++)
            {
                int item = a[i];
                countArray[item] = countArray[item] ^ item;
            }

            for (int i = 0; i < countArray.Length; i++)
            {
                if (countArray[i] != 0)
                {
                    result = countArray[i];
                    break;
                }
            }
            return result;
        }

        int Lonelyinteger2(int[] a)
        {
            //return a.Aggregate(0, (subsum, next) =>
            //{
            //    Console.WriteLine("-------------------------------------------------------");
            //    Console.WriteLine($"subsum: {Convert.ToString(value: subsum, toBase: 2)}");
            //    Console.WriteLine($"next: {Convert.ToString(value: next, toBase: 2)}");
            //    int temp = subsum ^ next;
            //    Console.WriteLine($"subsum^next: {Convert.ToString(value: temp, toBase: 2)}");
            //    return temp;
            //});
            return a.Aggregate(0, (subsum, next) => subsum ^ next);
        }

        [TestMethod]
        public void MaximizingXorTest()
        {
            int l1 = 10;
            int r1 = 15;
            Assert.AreEqual(7, MaximizingXor(l1, r1), "1");

            int l2 = 11;
            int r2 = 12;
            Assert.AreEqual(7, MaximizingXor(l2, r2), "2");
        }
        /// <summary>
        /// https://www.hackerrank.com/challenges/maximizing-xor/problem
        /// </summary>
        /// <param name="l">an integer, the lower bound, inclusive</param>
        /// <param name="r">an integer, the upper bound, inclusive</param>
        /// <returns></returns>
        int MaximizingXor(int l, int r)
        {
            int result = 0;
            while (l <= r)
            {
                for (int i = r-l; i >= 0; i--)
                {
                    int temp = l ^ (r - i);
                    if (temp > result)
                        result = temp;
                }
                l++;
            }

            return result;
        }

        [TestMethod]
        public void CounterGameTest()
        {
            long n1 = 6;
            Assert.AreEqual("Richard", CounterGame(n1), "1");
            long n2 = 132;
            Assert.AreEqual("Louise", CounterGame(n2), "2");

            //long[] powers = new long[64];
            //for (int i = 0; i < powers.Length; i++)
            //{
            //    powers[i] = (long)Math.Pow(2, i);
            //}

            //100 (2^0*0 + 2^1*0 + 2^2*1)

            //101 = 5

            /*
             101 >> 1 0
             010 >> 1 1
             001 >> 1 2
             000 
             */


            //1101001100
            //XOR
            //0101001100
            //----------
            //1000000000
        }
        /// <summary>
        /// https://www.hackerrank.com/challenges/counter-game/problem
        /// </summary>
        /// <param name="n">an integer to initialize the game counter</param>
        /// <returns></returns>
        string CounterGame(long n)
        {
            bool isLouiseTurn = false;            

            while (n != 1)
            {
                isLouiseTurn = !isLouiseTurn;

                if ((n & (n - 1)) != 0) //Is n power of 2?
                {                     
                    n -= FindLargestPowerOf2LowerThanN(n);
                }
                else
                {
                    n >>= 1;
                }                
            }
            return isLouiseTurn? "Louise" : "Richard";
        }

        private int log2(long n)
        {
            //log2n is the power to which the number 2 must be raised to obtain the value n.
            Assert.IsTrue(n > 0);

            int result = 0;
            while (n > 0)
            {
                n >>= 1;
                result++;
            }
            return result;
        }
        //private long FindLargestPowerOf2LowerThanN(long n)
        //{            
        //    int log2n = log2(n);
        //    long result = 1;

        //    return result <<= (log2n - 1);
        //}

    private long FindLargestPowerOf2LowerThanN(long n)
    {
        Assert.IsTrue(n > 0);

        int digits = 0;
        while (n > 0)
        {
            n >>= 1;
            digits++;
        }                            

        return 1 << (digits - 1);
    }


        string CounterGame2(ulong n)
        {
            bool isLouiseTurn = true;

            ulong[] powers = new ulong[64];
            for (int i = 0; i < powers.Length; i++)
            {
                powers[i] = (ulong)Math.Pow(2, i);
            }

            //int powerIndex 
            while (n != 1)
            {
                if ((n & (n - 1)) != 0) //Is n power of 2?
                {
                    ulong largest = FindLargestPowerOf2LowerThanN2(n, powers);
                    n = n - largest;
                    if (n == 1)
                        break;
                }
                else
                {
                    n = n / 2;
                    if (n == 1)
                        break;
                }

                isLouiseTurn = !isLouiseTurn;
            }
            return isLouiseTurn ? "Louise" : "Richard";
        }

        private ulong FindLargestPowerOf2LowerThanN2(ulong n, ulong[] powers)
        {
            ulong result = 0;
            for (int i = powers.Length - 1; i >= 0; i--)
            {
                if (powers[i] <= n)
                {
                    result = powers[i];
                    break;
                }
            }
            return result;
        }
    }
}