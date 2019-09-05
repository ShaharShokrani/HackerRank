using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class Strings
    {
        [TestMethod]
        public void MakeAnagramTest()
        {
            string a1 = "cde";
            string b1 = "abc";
            Assert.AreEqual(4, MakeAnagram(a1, b1), "1");

            string a7 = "a";
            string b7 = "aaaaabc";
            Assert.AreEqual(6, MakeAnagram(a7, b7), "7");

            string a2 = "abc";
            string b2 = "aaaaabc";
            Assert.AreEqual(4, MakeAnagram(a2, b2), "2");

            string a3 = "abc";
            string b3 = "kkkkkbc";
            Assert.AreEqual(6, MakeAnagram(a3, b3), "3");

            string a4 = "showman";
            string b4 = "woman";
            Assert.AreEqual(2, MakeAnagram(a4, b4), "4");

            string a5 = "aa";
            string b5 = "aaaaa";
            Assert.AreEqual(3, MakeAnagram(a5, b5), "5");

            string a6 = "abs";
            string b6 = "abkkkskk";
            Assert.AreEqual(5, MakeAnagram(a6, b6), "6");
        }
        int MakeAnagram(string a, string b)
        {
            int result = a.Length + b.Length;
            Dictionary<char, int> keys = new Dictionary<char, int>();

            string shorter;
            string longer;
            if (a.Length <= b.Length)
            {
                shorter = a;
                longer = b;
            }
            else
            {
                shorter = b;
                longer = a;
            }

            for (int i = 0; i < shorter.Length; i++)
            {
                if (keys.ContainsKey(shorter[i]))
                {
                    keys[shorter[i]]++;
                }
                else
                {
                    keys.Add(shorter[i], 1);
                }
            }

            int removedCount = 0;
            for (int j = 0; j < longer.Length; j++)
            {
                if (keys.ContainsKey(longer[j]))
                {
                    keys[longer[j]]--;
                    if (keys[longer[j]] == 0)
                    {
                        keys.Remove(longer[j]);
                        removedCount++;
                    }
                    result -= 2;
                    if (removedCount == shorter.Length)
                        break;
                }
            }

            return result;
        }


        [TestMethod]
        public void AlternatingCharactersTest()
        {
            string s1 = "AABAAB";
            Assert.AreEqual(2, AlternatingCharacters(s1), "1");

            string s2 = "AAAA";
            Assert.AreEqual(3, AlternatingCharacters(s2), "2");

            string s3 = "BBBBB";
            Assert.AreEqual(4, AlternatingCharacters(s3), "3");

            string s4 = "ABABABAB";
            Assert.AreEqual(0, AlternatingCharacters(s4), "4");

            string s5 = "BABABA";
            Assert.AreEqual(0, AlternatingCharacters(s5), "5");

            string s6 = "AAABBB";
            Assert.AreEqual(4, AlternatingCharacters(s6), "6");

        }
        int AlternatingCharacters(string s)
        {
            int result = 0;

            for (int i = 0; i < s.Length - 1; i++)
            {
                if (s[i] == s[i + 1])
                {
                    result++;
                }
            }

            return result;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/sherlock-and-valid-string/
        /// </summary>
        [TestMethod]
        public void IsValidTest()
        {
            string s1 = "abc";
            Assert.AreEqual("YES", IsValid(s1), "1");

            string s2 = "abcc";
            Assert.AreEqual("YES", IsValid(s2), "2");

            string s3 = "aabbcd";
            Assert.AreEqual("NO", IsValid(s3), "3");

            string s4 = "aabbccddeefghi";
            Assert.AreEqual("NO", IsValid(s4), "4");

            string s5 = "aafghi";
            Assert.AreEqual("YES", IsValid(s5), "5");

            string s6 = "abcdefghhgfedecba";
            Assert.AreEqual("YES", IsValid(s6), "6");

            string s7 = "aaaabbcc";
            Assert.AreEqual("NO", IsValid(s7), "7");

            string s8 = "aabbc";
            Assert.AreEqual("YES", IsValid(s8), "8");
        }
        string IsValid(string s)
        {
            string result = "NO";

            Dictionary<char, int> dict = new Dictionary<char, int>();
            Dictionary<int, int> freqDict = new Dictionary<int, int>();

            for (int i = 0; i < s.Length; i++)
            {
                char currentChar = s[i];
                int previousFreq;

                if (dict.ContainsKey(currentChar))
                {
                    previousFreq = dict[currentChar];
                    dict[currentChar]++;
                }
                else
                {
                    previousFreq = 0;
                    dict.Add(currentChar, 1);
                }

                //TODO: move it up
                if (freqDict.ContainsKey(previousFreq))
                {
                    freqDict[previousFreq]--;
                    if (freqDict[previousFreq] == 0)
                        freqDict.Remove(previousFreq);                    
                }

                int currentFreq = dict[currentChar];
                if (freqDict.ContainsKey(currentFreq))
                {
                    freqDict[currentFreq]++;
                }
                else
                {
                    freqDict.Add(currentFreq, 1);
                }
            }

            if (freqDict.Count == 1)
            {
                result = "YES";
            }
            else if (freqDict.Count == 2)
            {
                //aabbccddeefghi -> [2,5],[1,4]
                //aabbc -> [2,2],[1,1]
                if (Math.Abs(freqDict.ElementAt(0).Key - freqDict.ElementAt(1).Key) == 1)
                {                    
                    if (freqDict.ElementAt(0).Key > freqDict.ElementAt(1).Key)
                    {
                        if (freqDict.ElementAt(1).Value == 1 && freqDict.ElementAt(1).Key == 1)
                            result = "YES";
                        else if (freqDict.ElementAt(0).Value == 1)
                            result = "YES";
                    }
                    else
                    {
                        if (freqDict.ElementAt(0).Value == 1 && freqDict.ElementAt(0).Key == 1)
                            result = "YES";
                        else if (freqDict.ElementAt(1).Value == 1)
                            result = "YES";
                    }
                }
                else
                {
                    result = "NO";
                }
            }
            else
            {
                result = "NO";
            }

            return result;
        }

        [TestMethod]
        public void IsValid2Test()
        {
            string s1 = "abc";
            Assert.AreEqual("YES", IsValid2(s1), "1");

            string s2 = "abcc";
            Assert.AreEqual("YES", IsValid2(s2), "2");

            string s3 = "aabbcd";
            Assert.AreEqual("NO", IsValid2(s3), "3");

            string s4 = "aabbccddeefghi";
            Assert.AreEqual("NO", IsValid2(s4), "4");

            string s5 = "aafghi";
            Assert.AreEqual("YES", IsValid2(s5), "5");

            string s6 = "abcdefghhgfedecba";
            Assert.AreEqual("YES", IsValid2(s6), "6");

            string s7 = "aaaabbcc";
            Assert.AreEqual("NO", IsValid2(s7), "7");

            string s8 = "aabbc";
            Assert.AreEqual("YES", IsValid2(s8), "8");
        }
        string IsValid2(string s)
        {
            string result = "NO";

            int[] letters = new int[26];
            for (int i = 0; i < s.Length; i++)
            {
                letters[s[i] - 'a']++;
            }
            Array.Sort(letters);

            int j = 0;
            while (letters[j] == 0)
            {
                j++;
            }           
            int min = letters[j];   
            int max = letters[25];
            
            if (min == max)
            {
                result = "YES";
            }
            else
            {
                if ((max - min == 1 && max > letters[24]) ||
                    (min == 1) && (letters[j + 1] == max))
                {
                    result = "YES";
                }
            }

            return result;
        }

        [TestMethod]
        public void SubstrCountTest()
        {
            int n1 = 5;
            string s1 = "asasd";
            Assert.AreEqual(7, SubstrCount(n1, s1), "1");

            int n2 = 5;
            string s2 = "abcbaba";
            Assert.AreEqual(10, SubstrCount(n2, s2), "2");

            int n3 = 5;
            string s3 = "aaaab";
            Assert.AreEqual(11, SubstrCount(n3, s3), "3");

            int n4 = 5;
            string s4 = "aaaa"; //[0123,012,013,123,01,02,03,0,1,2,3]
                                //[aaaa,1],[aaa,3],[aa,2],[a,4]

            Assert.AreEqual(10, SubstrCount(n4, s4), "4");
        }

        private class CharAndCount
        {
            public char MyChar { get; set; }
            public long MyCount { get; set; }
        }

        long SubstrCount(int n, string s)
        {
            long result = 0;
            int sameCount = 0;
            char current = char.MinValue;
            List<CharAndCount> chars = new List<CharAndCount>();

            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == current)
                {
                    sameCount++;
                }
                else
                {
                    if (current != char.MinValue)
                    {
                        chars.Add(new CharAndCount()
                        {
                            MyChar = current,
                            MyCount = sameCount
                        });
                    }
                    current = s[i];
                    sameCount = 1;
                }
            }

            chars.Add(new CharAndCount()
            {
                MyChar = current,
                MyCount = sameCount
            });

            foreach (var item in chars)
            {
                result += (item.MyCount * (item.MyCount + 1)) / 2;
            }

            for (int i = 1; i < chars.Count - 1; i++)
            {
                var previousItem = chars[i - 1];
                var currentItem = chars[i];
                var nextItem = chars[i + 1];
                if (previousItem.MyChar == nextItem.MyChar &&
                    currentItem.MyCount == 1)
                {
                    result += Math.Min(previousItem.MyCount, nextItem.MyCount);
                }
            }

            return result;
        }

        //long SubstrCount(int n, string s)
        //{
        //    long result = 0;
        //    HashSet<string> keys = new HashSet<string>();

        //    int sameCount = 0;
        //    for (int i = 1; i < s.Length; i++)
        //    {
        //        char previous = s[i - 1];
        //        char current = s[i];

        //        if (current == previous)
        //        {
        //            sameCount++;
        //        }
        //        else if (current != previous)
        //        {
        //            int leftIndex = i - (sameCount + 1);
        //            string left = s.Substring(leftIndex, sameCount + 1);

        //            //Determine if same chars: aaaaaa
        //            if (sameCount >= 1 && !keys.Contains(left))
        //            {
        //                result += NCR(sameCount + 1, 2);
        //            }

        //            if (i + 1 + sameCount < s.Length)
        //            {
        //                int rightIndex = i + 1;
        //                string right = s.Substring(rightIndex, sameCount + 1);

        //                if (left == right)
        //                {
        //                    string leftCurrentRight = left + current + right;
        //                    if (!keys.Contains(leftCurrentRight))
        //                    {
        //                        result++;
        //                    }
        //                }
        //            }

        //            sameCount = 0;
        //        }
        //    }

        //    //Determine if same chars: aaaaaa
        //    if (sameCount >= 1)
        //    {
        //        int leftIndex = s.Length - (sameCount + 1);
        //        string left = s.Substring(leftIndex, sameCount + 1);

        //        if (!keys.Contains(left))
        //            result += NCR(sameCount + 1, 2);
        //    }

        //    return result;
        //}

        //private long NCR(int n, int r)
        //{
        //    return Factorial(n) / (Factorial(r) * Factorial(n - r));
        //}

        //private long Factorial(int i)
        //{
        //    if (i <= 1)
        //        return 1;
        //    return i * Factorial(i - 1);
        //}

        [TestMethod]
        public void CommonChildTest()
        {
            string s1a = "AAABCD";
            string s1b = "ABDCAA";
            Assert.AreEqual(3, CommonChild(s1a, s1b), "1");

            string s2a = "HARRY";
            string s2b = "SALLY";
            Assert.AreEqual(2, CommonChild(s2a, s2b), "2");

            string s3a = "AA";
            string s3b = "BB";
            Assert.AreEqual(0, CommonChild(s3a, s3b), "3");

            string s4a = "SHINCHAN";
            string s4b = "NOHARAAA";
            Assert.AreEqual(3, CommonChild(s4a, s4b), "4");

            string s5a = "ABCDEF";
            string s5b = "FBDAMN";
            Assert.AreEqual(2, CommonChild(s5a, s5b), "5");

            string s6a = "OUDFRMYMAW";
            string s6b = "AWHYFCCMQX";
            Assert.AreEqual(2, CommonChild(s6a, s6b), "6");

            string s7a = "VBGGGQWEFF";
            string s7b = "FFZXCGGGAS";
            Assert.AreEqual(3, CommonChild(s7a, s7b), "7");
        }
        int CommonChild(string s1, string s2)
        {
            int[,] matrix = new int[s1.Length + 1, s2.Length + 1];

            for (int i = 0; i <= s1.Length; i++)
            {
                for (int j = 0; j <= s2.Length; j++)
                {
                    if (i == 0 || j == 0)
                    {
                        matrix[i, j] = 0;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        matrix[i, j] = matrix[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        matrix[i, j] = System.Math.Max(matrix[i, j - 1], matrix[i - 1, j]);
                    }
                }
            }
            
            return matrix[s1.Length, s2.Length];
        }
    }
}