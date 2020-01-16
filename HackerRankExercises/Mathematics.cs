using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankExercises
{
    [TestClass]
    public class Mathematics
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/find-point/problem
        /// </summary>
        [TestMethod]
        public void FindPointTest()
        {
            int px1 = 0;
            int py1 = 0;
            int qx1 = 1;
            int qy1 = 1;
            Assert.AreSame(new int[] { 2, 2 }, FindPoint(px1, py1, qx1, qy1), "1");
        }

        int[] FindPoint(int px, int py, int qx, int qy)
        {
            int r1x = 2 * qx - px;
            int r1y = 2 * qy - py;
            
            return new int[] { r1x, r1y };            
        }

        /*
(2 in 0-9) is 1.
(0+1)*10^0 = 1
(d + 1)*10^d
(2 in 0-99) is 10 + 10
(1+1)*10^1 = 20
 0  1  2  3  4  5  6  7  8  9 (1)
10 11 12 13 14 15 16 17 18 19 (1)
20 21 22 23 24 25 26 27 28 29 (1 + 10)
..
90 91 92 93 94 95 96 97 98 99 (1)
(2 in 0-999) 100 + 100 + 100
(2 + 1)*10^2 = 300
000 001   2   3   4   5   6   7   8   9 (1 + 0 + 0)
010 011  12  13  14  15  16  17  18  19 (1 + 0 + 0)
020 021  22  23  24  25  26  27  28  29 (1 + 10 + 0)
..
090 091 092 093 094 095 096 097  98  99 (1 + 0 + 0)
100 101 102 103 104 105 106 107 108 109 (1 + 0 + 0)
..
200 201 202 203 204 205 206 207 208 209 (1 +  0 + 10)
210 211 212 213 214 215 216 217 218 219 (1 +  0 + 10)
220 221 222 223 224 225 226 227 228 229 (1 + 10 + 10)
..
290 291 292 293 294 295 296 297 298 299 (1 + 0 + 10)
..
300 301 302 303 304 305 306 307 308 309 (1 + 0 + 0)
..
320 321 322 323 324 325 326 327 328 329 (1 + 10 + 0)

990 991 992 993 994 995 996 997 998 999 (1 + 0 + 0)

22:         

61523:
0:          Is 6152(3). 2(2)
            3 is bigger than 2.

            61523 -> 61522.  22 -> 22
            (6152 + 1) * 1 Times * (2 in 0).

            00002 
            00012
            00022
            ..
            00092
            ..
            15092
            ..
            61522

1st:        Is 615(2).
            2 is equal to 2.
            (615) * 10 Times. (61400 / 100) * 10 + 3 * 1
            61523 -> 61520. 00020,00120,00220,0032,0042,0052,0062,0072,0082,0092,0102,0112,...,6072,...,6142,6152                        

            00020-00029 (10)
            00120-00129 (10)
            00220-00229 (10)
            00320-00329 (10)
            00420-00429 (10)
            ........
            10720-10729 (10)
            61320-61329 (10)
            61420-61429 (10)
            61520-61523 (3)

            61,500 -> 62,000 i=2 10^2 = 100, 1000
            61523 / 1000 = (61 + 1) * 1000

2nd:        Is 61(5)00.
            (5) is bigger than 2.
            (61 + 1) * 100 Times. (62000 / 1000) * 100
            615 -> 612. 002,012,022,032,042,052,..152,592,602,612

            00200-00299, (100)
            01200-01299, (100)
            02200-02299, (100)
            03200-03299, (100)
            04200-04299, (100)
            05200-05299, (100)
            06200-06299, (100)
            07200-07299, (100)
            08200-08299, (100)
            09200-09299, (100)
            10200-10299, (100)
            11200-11299, (100)
            12200-12299, (100)
            13200-13299, (100)
            ...........
            60200-60299, (100)
            61200-61299, (100)

3rd:        Is 6(1)000.
            (1) is smaller than 2.
            61,000 -> 52,000. (while digit in 3rd place not equal to 2 than reduce 10^3)
            61 -> 52,42,32,22,12,01 (6)
            like 60,000.
            (5 + 1) * 1,000 Times                                           * (2 in 0-999)
            02000–02999, (1,000)
            12000–12999, (1,000)
            22000–22999, (1,000)
            32000 32999, (1,000)
            42000–42999, (1,000)
            52000–52999 (1,000)

4rd:        Is (6)0000.
            6 -> 2 (1). (while number not equal to 2 than reduce 10^1) *1= total digit - index = 5 - 4.
            60,000 -> 20,000. (while digit in 4rd place not equal to 2 than reduce 10^4)


            (0 + 1) * 10,000 Times                                          * (2 in 0 - 9999)
            20000-29999 (10,000)
 */

        [TestMethod]
        public void NumberOfOccurrencesOfDigitTest()
        {
            Assert.AreEqual(20, NumberOfOccurrencesOfDigit(100), "1");
            Assert.AreEqual(20, NumberOfOccurrencesOfDigit(101), "2");
            Assert.AreEqual(21, NumberOfOccurrencesOfDigit(102), "3");
            Assert.AreEqual(21, NumberOfOccurrencesOfDigit(103), "4");
            Assert.AreEqual(2, NumberOfOccurrencesOfDigit(12), "5");
            Assert.AreEqual(9, NumberOfOccurrencesOfDigit(25), "6"); //01,02,03,04,05,06,07,08,09,10,11,12,13,14,15,16,17,18,19,20,21,22,23,24,25
         }

        int NumberOfOccurrencesOfDigit(int n)
        {
            int result = 0;

            int[] digits = DigitArray(n);

            for (int i = 0; i < digits.Length; i++)
            {
                int powerOf10 = (int)Math.Pow(10, i);
                int nextPowerOf10 = powerOf10 * 10;

                int roundUp = (n / nextPowerOf10 + 1) * nextPowerOf10;
                int roundDown = roundUp - nextPowerOf10;

                int digit = (n / powerOf10) % 10;
                
                int left;
                int add;
                if (digit < 2)
                {
                    left = roundDown / 10;
                    add = left;
                }
                else if (digit == 2)
                {
                    left = roundDown / 10;
                    add = left + n % powerOf10 + 1;
                }
                else
                {
                    left = roundUp / 10;
                    add = left;
                }

                result += add;
            }
            return result;
        }


        [TestMethod]
        public void NumbersInTest()
        {
            int[] numbers = DigitArray(159);
            Console.Write(numbers);
        }

        public int[] DigitArray(int value)
        {
            var numbers = new Queue<int>();

            for (; value > 0; value /= 10)
                numbers.Enqueue(value % 10);

            return numbers.ToArray();
        }
    }

    public static class MathExtensions
    {
        public static int RoundNearest(this int i, int nearest)
        {
            if (nearest <= 0 || nearest % 10 != 0)
                throw new ArgumentOutOfRangeException("nearest", "Must round to a positive multiple of 10");

            return (i + 5 * nearest / 10) / nearest * nearest;
        }
    }

}