using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace UnitTestProject1
{
    [TestClass]
    public class HackerRankWarmUps
    {
        [TestMethod]
        public void SockMerchantTest()
        {
            int[] testArray = { 1,2,1,2,1,3,2 };
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
            int[] clouds1 = { 0, 0, 0, 0, 1, 0};
            Assert.AreEqual(3, JumpingOnClouds(clouds1));
            int[] clouds2 = { 0, 0, 1, 0, 0, 1, 0};
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
    }
}
