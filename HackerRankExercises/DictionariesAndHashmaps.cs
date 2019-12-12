using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class DictionariesAndHashmaps
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-ransom-note/
        /// </summary>
        [TestMethod]
        public void CheckMagazineTest()
        {
            string[] magazine1 = { "give", "give", "me", "one", "grand", "today", "night" };
            string[] note1 = { "give", "give", "one", "grand", "today" };

            Assert.AreEqual("Yes", CheckMagazine(magazine1, note1));

            string[] magazine2 = { "two", "times", "three", "is", "not", "four" };
            string[] note2 = { "two", "times", "two", "is", "four" };

            Assert.AreEqual("No", CheckMagazine(magazine2, note2));


            string[] magazine3 = { "ive", "got", "a", "lovely", "bunch", "of", "coconuts" };
            string[] note3 = { "ive", "got", "some", "coconuts" };

            Assert.AreEqual("No", CheckMagazine(magazine3, note3));
        }

        string CheckMagazine(string[] magazine, string[] note)
        {
            bool result = true;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            for (int i = 0; i < magazine.Length; i++)
            {
                if (dict.ContainsKey(magazine[i]))
                    dict[magazine[i]] += 1;
                else
                    dict[magazine[i]] = 1;
            }
            for (int i = 0; i < note.Length; i++)
            {
                if (dict.ContainsKey(note[i]))
                {
                    dict[note[i]]--;
                    if (dict[note[i]] == 0)
                        dict.Remove(note[i]);
                }
                else
                {
                    result = false;
                    break;
                }
            }

            if (result)
                return "Yes";
            else
                return "No";
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/two-strings/
        /// </summary>
        [TestMethod]
        public void TwoStringsTest()
        {
            string s1_1 = "hello";
            string s2_1 = "world";
            Assert.AreEqual("Yes", TwoStrings(s1_1, s2_1));

            string s1_2 = "hi";
            string s2_2 = "world";
            Assert.AreEqual("No", TwoStrings(s1_2, s2_2));
        }

        static string TwoStrings(string s1, string s2)
        {
            string result = "No";

            HashSet<char> hash = new HashSet<char>();

            for (int i = 0; i < s1.Length; i++)
            {
                hash.Add(s1[i]);
            }

            for (int i = 0; i < s2.Length; i++)
            {
                if (hash.Contains(s2[i]))
                    return "Yes";
            }

            return result;
        }


        /// <summary>
        /// https://www.hackerrank.com/challenges/sherlock-and-anagrams/
        /// </summary>
        [TestMethod]
        public void SherlockAndAnagramsTest()
        {
            string s1 = "abba";
            // 0,3    01,23    2,3    012,123
            //[a,a], [ab,ba], [b,b], [abb,bba]
            Assert.AreEqual(4, SherlockAndAnagrams(s1));

            string s2 = "abcd";
            Assert.AreEqual(0, SherlockAndAnagrams(s2));

            string s3 = "cdcd";
            // 0,2    1,3    01,12    01,23    12,23
            //[c,c], [d,d], [cd,dc], [cd,cd], [dc,cd]
            Assert.AreEqual(5, SherlockAndAnagrams(s3));

            string s4 = "ifailuhkqq";
            // 0,3    8,9    012,123
            //[i,i], [q,q], [ifa,fai]
            Assert.AreEqual(3, SherlockAndAnagrams(s4));

            string s5 = "kkkk";
            // 0,1|0,2|0,3|1,2|1,3|2,3  01,12|01,23|12,23  012,123
            // [k,k]                  ,[kk,kk]           ,[kkk,kkk]
            Assert.AreEqual(10, SherlockAndAnagrams(s5));
        }

        public int SherlockAndAnagrams(string s)
        {
            int result = 0;

            // Size of our sliding window
            for (int i = 1; i < s.Length; i++)
            {
                Dictionary<string, int> found = new Dictionary<string, int>();

                // Starting index of our sliding window
                for (int j = 0; j + i <= s.Length; j++)
                {
                    string substr = s.Substring(j, i);
                    substr = SortString(substr);
                    if (found.ContainsKey(substr))
                    {
                        result += found[substr];
                        found[substr]++;
                    }
                    else
                    {
                        found[substr] = 1;
                    }
                }
            }

            return result;
        }
        private string SortString(string input)
        {
            char[] characters = input.ToArray();
            Array.Sort(characters);
            return new string(characters);
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/count-triplets-1/
        /// </summary>
        [TestMethod]
        public void CountTripletsTest()
        {
            List<long> list1 = new List<long>() { 1, 4, 16, 64 };
            long r1 = 4;
            //1,4,16 | 4,16,64
            //0,1,2    2,3, 4
            Assert.AreEqual(2, CountTriplets(list1, r1), "First");

            List<long> list2 = new List<long>() { 1, 2, 2, 4 };
            long r2 = 2;
            //1,2,4 | 1,2,4
            //0,1,3 | 0,2,3
            Assert.AreEqual(2, CountTriplets(list2, r2), "Second");

            List<long> list3 = new List<long>() { 1, 5, 5, 25, 125 };
            long r3 = 5;
            //1,5,25 | 1,5,25 | 
            //0,1,3  | 0,2,3  |
            Assert.AreEqual(4, CountTriplets(list3, r3), "Third");

            List<long> list4 = new List<long>() { 1, 1, 1, 1 };
            long r4 = 1;
            //1,1,1 | 1,1,1 | 1,1,1 | 1,1,1
            //0,1,2 | 0,1,3 | 0,2,3 | 1,2,3
            Assert.AreEqual(4, CountTriplets(list4, r4), "fourth");

            List<long> list5 = new List<long>() { 1, 2, 1, 2, 4 };
            long r5 = 2;
            //1,2,4 | 1,2,4 | 1,2,4
            //0,1,4 | 0,3,4 | 2,3,4
            Assert.AreEqual(3, CountTriplets(list5, r5), "fifth");

            List<long> list6 = new List<long>() { 2, 7, 21 };
            long r6 = 3;
            Assert.AreEqual(0, CountTriplets(list6, r6), "sixth");
        }

        long CountTriplets(List<long> arr, long r)
        {
            long result = 0;
            Dictionary<double, long> existingDict = new Dictionary<double, long>();
            Dictionary<double, long> secondDict = new Dictionary<double, long>();

            for (int i = 0; i < arr.Count; i++)
            {
                long item = arr[i];

                double pre = (double)item / (double)r;
                if (secondDict.ContainsKey(pre))
                {
                    result += secondDict[pre];
                }
                
                if (existingDict.ContainsKey(pre))
                {
                    if (secondDict.ContainsKey(item))
                    {
                        secondDict[item] += existingDict[pre];
                    }
                    else
                    {
                        secondDict[item] = Math.Max(existingDict[pre], 1);
                    }
                }

                if (existingDict.ContainsKey(item))
                {
                    existingDict[item]++;
                }
                else
                {
                    existingDict[item] = 1;
                }
            }

            return result;
        }


        [TestMethod]
        public void FreqQueryTest()
        {
            List<List<int>> queries1 = new List<List<int>> {
                new List<int> { 1, 1 }, //[1]
                new List<int> { 2, 2 }, //[1]
                new List<int> { 3, 2 }, //          0
                new List<int> { 1, 1 }, //[1,1]
                new List<int> { 1, 1 }, //[1,1,1]
                new List<int> { 2, 1 }, //[1,1]
                new List<int> { 3, 2 }  //          1
            };
            List<int> result1 = new List<int> { 0, 1 };

            CollectionAssert.AreEqual(result1, FreqQuery(queries1), "First");

            List<List<int>> queries2 = new List<List<int>> {
                new List<int> { 1, 5 },     //[5]
                new List<int> { 1, 6 },     //[5,6]
                new List<int> { 3, 2 },     //          0
                new List<int> { 1, 10 },    //[5,6,10]
                new List<int> { 1, 10 },    //[5,6,10,10]
                new List<int> { 1, 6 },     //[5,6,10,10,6]
                new List<int> { 2, 5 },     //[6,10,10,6]          
                new List<int> { 3, 2 }      //          1
            };
            List<int> result2 = new List<int> { 0, 1 };

            CollectionAssert.AreEqual(result2, FreqQuery(queries2), "Second");

            //List<List<int>> queries3 = new List<List<int>> {
            //    new List<int> { 1, 1 }, //[1] = [1->1]
            //    new List<int> { 1, 1 }, //[1,1] = [2->1]               
            //    new List<int> { 1, 1 }, //[1,1,1] = [3->1]
            //    new List<int> { 1, 2 }, //[1,1,1,2] = [3->1,1->1]
            //    new List<int> { 1, 3 }, //[1,1,1,2,3] = [3->1,1->2]
            //    new List<int> { 1, 3 }, //[1,1,1,2,3,3] = [3->1,1->2]
            //};
            //List<int> result3 = new List<int> { 0, 1 };

            //CollectionAssert.AreEqual(result3, FreqQuery(queries3), "Third");
        }
        List<int> FreqQuery(List<List<int>> queries)
        {
            List<int> result = new List<int>();

            Dictionary<int, int> dict = new Dictionary<int, int>();
            Dictionary<int, int> freqDict = new Dictionary<int, int>();

            for (int i = 0; i < queries.Count; i++)
            {
                int operation = queries[i][0];
                int value = queries[i][1];

                switch (operation)
                {
                    case 1: //Insert
                        if (dict.ContainsKey(value) && freqDict.ContainsKey(dict[value]) && freqDict[dict[value]] > 0)
                        {
                            freqDict[dict[value]]--;
                        }

                        if (dict.ContainsKey(value))
                        {
                            dict[value]++;
                        }
                        else
                        {
                            dict[value] = 1;
                        }

                        if (freqDict.ContainsKey(dict[value]))
                        {
                            freqDict[dict[value]]++;
                        }
                        else
                        {
                            freqDict[dict[value]] = 1;
                        }

                        break;
                    case 2: //Delete
                        if (dict.ContainsKey(value) && dict[value] > 0)
                        {
                            if (freqDict.ContainsKey(dict[value]))
                            {
                                freqDict[dict[value]]--;
                            }

                            dict[value]--;

                            if (freqDict.ContainsKey(dict[value]))
                            {
                                freqDict[dict[value]]++;
                            }
                            else
                            {
                                freqDict[dict[value]] = 1;
                            }
                        }

                        break;
                    case 3: //Print                        
                        result.Add(freqDict.ContainsKey(value) && freqDict[value] > 0 ? 1 : 0);
                        break;
                }
            }

            return result;
        }
    }
}