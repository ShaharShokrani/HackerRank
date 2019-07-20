using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
{
    [TestClass]
    public class Arrays
    {
        [TestMethod]
        public void HourglassSumTest()
        {
            int[][] testArray1 =
            {
                new [] {1, 1, 1, 0, 0, 0},
                new [] {0, 1, 0, 0, 0, 0},
                new [] {1, 1, 1, 0, 0, 0},
                new [] {0, 0, 2, 4, 4, 0},
                new [] {0, 0, 0, 2, 0, 0},
                new [] {0, 0, 1, 2, 4, 0}
            };
            Assert.AreEqual(19, HourglassSum(testArray1));

            int[][] testArray2 =
            {
                new [] {-9, -9, -9, 1, 1, 1},
                new [] {0, -9,  0,  4, 3, 2},
                new [] {-9, -9, -9,  1, 2, 3},
                new [] {0,  0,  8,  6, 6, 0},
                new [] {0,  0,  0, -2, 0, 0},
                new [] { 0,  0,  1,  2, 4, 0 }
            };
            Assert.AreEqual(28, HourglassSum(testArray2));

            int[][] testArray3 =
            {
                new int[] { -1, -1, 0, -9, -2, -2 },
                new int[] { -2, -1, -6, -8, -2, -5 },
                new int[] { -1, -1, -1, -2, -3, -4 },
                new int[] { -1, -9, -2, -4, -4, -5 },
                new int[] { -7, -3, -3, -2, -9, -9 },
                new int[] { -1, -3, -1, -2, -4, -5 },
            };

            Assert.AreEqual(-6, HourglassSum(testArray3));
        }
        int HourglassSum(int[][] arr)
        {
            int result = Int32.MinValue;

            for (int i = 1; i < arr.Length - 1; i++)
            {
                for (int j = 1; j < arr[i].Length - 1; j++)
                {
                    int temp = arr[i - 1][j - 1] + arr[i - 1][j] + arr[i - 1][j + 1] + arr[i][j] + arr[i + 1][j - 1] + arr[i + 1][j] + arr[i + 1][j + 1];
                    if (temp > result)
                        result = temp;
                }
            }
            return result;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-array-left-rotation
        /// </summary>
        [TestMethod]
        public void RotLeftTest()
        {
            int[] testArray1 = { 1, 2, 3, 4, 5 };
            int[] expectedArray1 = { 3, 4, 5, 1, 2 };
            Assert.IsTrue(expectedArray1.SequenceEqual(RotLeft(testArray1, 2)));

            int[] testArray2 = { 1, 2, 3, 4, 5 };
            int[] expectedArray2 = { 5, 1, 2, 3, 4 };
            Assert.IsTrue(expectedArray2.SequenceEqual(RotLeft(testArray2, 4)));

            int[] testArray3 = { 1, 2, 3, 4, 5 };
            int[] expectedArray3 = { 2, 3, 4, 5, 1 };
            Assert.IsTrue(expectedArray3.SequenceEqual(RotLeft(testArray3, 1)));
        }

        int[] RotLeft(int[] a, int d)
        {
            int[] result = new int[a.Length];

            for (int i = 0; i < a.Length; i++)
            {
                if (i < d)
                {
                    result[a.Length - (d - i)] = a[i];
                }
                else
                {
                    result[i - d] = a[i];
                }
            }

            return result;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/new-year-chaos/
        /// </summary>
        [TestMethod]
        public void MinimumBribesTest()
        {
            // { 1, 2, 3, 4, 5 }
            int[] testArray1 = { 2, 1, 5, 3, 4 };
            // { 1,-1, 2,-1,-1 }
            int minimum1 = 0;
            string result = MinimumBribes(testArray1, out minimum1);
            Assert.AreEqual(3, minimum1);
            Assert.AreEqual(result, string.Empty);

            int[] testArray2 = { 2, 5, 1, 3, 4 };
            Assert.AreEqual("Too chaotic", MinimumBribes(testArray2, out _));

            int[] testArray3 = { 5, 2, 1, 3, 4 };
            Assert.AreEqual("Too chaotic", MinimumBribes(testArray3, out _));

            //                 { 1, 2, 3, 4 };
            int[] testArray7 = { 3, 2, 1, 4 };
            //                   2, 0,-2, 0
            int minimum7 = 0;
            string result7 = MinimumBribes(testArray7, out minimum7);
            Assert.AreEqual(3, minimum7);
            Assert.AreEqual(result7, string.Empty);

            //                 { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] testArray4 = { 1, 2, 5, 3, 4, 7, 8, 6 };
            //                   0, 0, 2,-1,-1, 1, 1,-2  
            int minimum4 = 0;
            string result4 = MinimumBribes(testArray4, out minimum4);
            Assert.AreEqual(4, minimum4);
            Assert.AreEqual(result4, string.Empty);

            int[] testArray5 = { 2, 1, 5, 6, 3, 4, 9, 8, 11, 7, 10, 14, 13, 12, 17, 16, 15, 19, 18, 22, 20, 24, 23, 21, 27, 28, 25, 26, 30, 29, 33, 32, 31, 35, 36, 34, 39, 38, 37, 42, 40, 44, 41, 43, 47, 46, 48, 45, 50, 52, 49, 51, 54, 56, 55, 53, 59, 58, 57, 61, 63, 60, 65, 64, 67, 68, 62, 69, 66, 72, 70, 74, 73, 71, 77, 75, 79, 78, 81, 82, 80, 76, 85, 84, 83, 86, 89, 90, 88, 87, 92, 91, 95, 94, 93, 98, 97, 100, 96, 102, 99, 104, 101, 105, 103, 108, 106, 109, 107, 112, 111, 110, 113, 116, 114, 118, 119, 117, 115, 122, 121, 120, 124, 123, 127, 125, 126, 130, 129, 128, 131, 133, 135, 136, 132, 134, 139, 140, 138, 137, 143, 141, 144, 146, 145, 142, 148, 150, 147, 149, 153, 152, 155, 151, 157, 154, 158, 159, 156, 161, 160, 164, 165, 163, 167, 166, 162, 170, 171, 172, 168, 169, 175, 173, 174, 177, 176, 180, 181, 178, 179, 183, 182, 184, 187, 188, 185, 190, 189, 186, 191, 194, 192, 196, 197, 195, 199, 193, 198, 202, 200, 204, 205, 203, 207, 206, 201, 210, 209, 211, 208, 214, 215, 216, 212, 218, 217, 220, 213, 222, 219, 224, 221, 223, 227, 226, 225, 230, 231, 229, 228, 234, 235, 233, 237, 232, 239, 236, 241, 238, 240, 243, 242, 246, 245, 248, 249, 250, 247, 244, 253, 252, 251, 256, 255, 258, 254, 257, 259, 261, 262, 263, 265, 264, 260, 268, 266, 267, 271, 270, 273, 269, 274, 272, 275, 278, 276, 279, 277, 282, 283, 280, 281, 286, 284, 288, 287, 290, 289, 285, 293, 291, 292, 296, 294, 298, 297, 299, 295, 302, 301, 304, 303, 306, 300, 305, 309, 308, 307, 312, 311, 314, 315, 313, 310, 316, 319, 318, 321, 320, 317, 324, 325, 322, 323, 328, 327, 330, 326, 332, 331, 329, 335, 334, 333, 336, 338, 337, 341, 340, 339, 344, 343, 342, 347, 345, 349, 346, 351, 350, 348, 353, 355, 352, 357, 358, 354, 356, 359, 361, 360, 364, 362, 366, 365, 363, 368, 370, 367, 371, 372, 369, 374, 373, 376, 375, 378, 379, 377, 382, 381, 383, 380, 386, 387, 384, 385, 390, 388, 392, 391, 389, 393, 396, 397, 394, 398, 395, 401, 400, 403, 402, 399, 405, 407, 406, 409, 408, 411, 410, 404, 413, 412, 415, 417, 416, 414, 420, 419, 422, 421, 418, 424, 426, 423, 425, 428, 427, 431, 430, 429, 434, 435, 436, 437, 432, 433, 440, 438, 439, 443, 441, 445, 442, 447, 444, 448, 446, 449, 452, 451, 450, 455, 453, 454, 457, 456, 460, 459, 458, 463, 462, 464, 461, 467, 465, 466, 470, 469, 472, 468, 474, 471, 475, 473, 477, 476, 480, 479, 478, 483, 482, 485, 481, 487, 484, 489, 490, 491, 488, 492, 486, 494, 495, 496, 498, 493, 500, 499, 497, 502, 504, 501, 503, 507, 506, 505, 509, 511, 508, 513, 510, 512, 514, 516, 518, 519, 515, 521, 522, 520, 524, 517, 523, 525, 526, 529, 527, 531, 528, 533, 532, 534, 530, 537, 536, 539, 535, 541, 538, 540, 543, 544, 542, 547, 548, 545, 549, 546, 552, 550, 551, 554, 553, 557, 555, 556, 560, 559, 558, 563, 562, 564, 561, 567, 568, 566, 565, 569, 572, 571, 570, 575, 574, 577, 576, 579, 573, 580, 578, 583, 581, 584, 582, 587, 586, 585, 590, 589, 588, 593, 594, 592, 595, 591, 598, 599, 596, 597, 602, 603, 604, 605, 600, 601, 608, 609, 607, 611, 612, 606, 610, 615, 616, 614, 613, 619, 618, 617, 622, 620, 624, 621, 626, 625, 623, 628, 627, 631, 630, 633, 629, 635, 632, 637, 636, 634, 638, 640, 642, 639, 641, 645, 644, 647, 643, 646, 650, 648, 652, 653, 654, 649, 651, 656, 658, 657, 655, 661, 659, 660, 663, 664, 666, 662, 668, 667, 670, 665, 671, 673, 669, 672, 676, 677, 674, 679, 675, 680, 678, 681, 684, 682, 686, 685, 683, 689, 690, 688, 687, 693, 692, 691, 696, 695, 698, 694, 700, 701, 702, 697, 704, 699, 706, 703, 705, 709, 707, 711, 712, 710, 708, 713, 716, 715, 714, 718, 720, 721, 719, 723, 717, 722, 726, 725, 724, 729, 728, 727, 730, 733, 732, 735, 734, 736, 731, 738, 737, 741, 739, 740, 744, 743, 742, 747, 746, 745, 750, 748, 752, 749, 753, 751, 756, 754, 758, 755, 757, 761, 760, 759, 764, 763, 762, 767, 765, 768, 766, 771, 770, 769, 774, 773, 776, 772, 778, 777, 779, 775, 781, 780, 783, 784, 782, 786, 788, 789, 787, 790, 785, 793, 791, 792, 796, 795, 794, 798, 797, 801, 799, 803, 800, 805, 802, 804, 808, 806, 807, 811, 809, 810, 814, 812, 813, 817, 816, 819, 818, 815, 820, 821, 823, 822, 824, 826, 827, 825, 828, 831, 829, 830, 834, 833, 836, 832, 837, 839, 838, 841, 835, 840, 844, 842, 846, 845, 843, 849, 847, 851, 850, 852, 848, 855, 854, 853, 857, 856, 858, 861, 862, 860, 859, 863, 866, 865, 864, 867, 870, 869, 868, 872, 874, 875, 871, 873, 877, 878, 876, 880, 881, 879, 884, 883, 885, 882, 888, 886, 890, 891, 889, 893, 887, 895, 892, 896, 898, 894, 899, 897, 902, 901, 903, 905, 900, 904, 908, 907, 910, 909, 906, 912, 911, 915, 913, 916, 918, 914, 919, 921, 917, 923, 920, 924, 922, 927, 925, 929, 928, 926, 932, 931, 934, 930, 933, 935, 937, 939, 940, 938, 936, 943, 944, 942, 941, 947, 946, 948, 945, 951, 950, 949, 953, 952, 956, 954, 958, 957, 955, 961, 962, 963, 959, 964, 966, 960, 965, 969, 968, 971, 967, 970, 974, 972, 976, 973, 975, 979, 977, 981, 982, 978, 980, 983, 986, 984, 985, 989, 988, 987, 990, 993, 991, 995, 994, 997, 992, 999, 1000, 996, 998 };
            int minimum5 = 0;
            string result5 = MinimumBribes(testArray5, out minimum5);
            Assert.AreEqual(966, minimum5);
            Assert.AreEqual(result5, string.Empty);


            //                 { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] testArray6 = { 1, 2, 5, 3, 7, 8, 6, 4 };
            //                   0, 0, 2,-1, 2, 2,-1,-4              
            int minimum6 = 0;
            string result6 = MinimumBribes(testArray6, out minimum6);
            Assert.AreEqual(7, minimum6);
            Assert.AreEqual(result6, string.Empty);
        }
        string MinimumBribes(int[] q, out int count)
        {
            int temp = 0;
            count = 0;
            int[] bribe = new int[1000000];
            bool isSorted = false;
            while (isSorted != true)
            {
                isSorted = true;
                for (int i = q.Length - 1; i > 0; --i)
                {
                    if (q[i] < q[i - 1])
                    {
                        temp = q[i - 1];
                        q[i - 1] = q[i];
                        q[i] = temp;
                        bribe[q[i]]++;
                        count++;
                        if (bribe[q[i]] > 2)
                        {
                            return "Too chaotic";
                        }
                        isSorted = false;
                    }
                }
            }

            return string.Empty;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/minimum-swaps-2/
        /// </summary>
        [TestMethod]
        public void MinimumSwaps2Test()
        {
            //                 { 1, 2, 3, 4, 5, 6, 7 }
            int[] testArray1 = { 7, 1, 3, 2, 4, 5, 6 };
            //                  -6,-1, 0,-2,-1,-1,-1
            //                 -----------------------
            //                 { 2, 1, 3, 7, 4, 5, 6 } 1 ////////// { 1, 7, 3, 2, 4, 5, 6 } 1
            //                 { 1, 2, 3, 7, 4, 5, 6 } 2 ////////// { 1, 2, 3, 7, 4, 5, 6 } 1
            //                 { 1, 2, 3, 4, 7, 5, 6 } 3
            //                 { 1, 2, 3, 4, 5, 7, 6 } 4
            //                 { 1, 2, 3, 4, 5, 6, 7 } 5
            Assert.AreEqual(5, MinimumSwaps2(testArray1));

            //                 { 1, 2, 3, 4 }
            int[] testArray2 = { 4, 3, 1, 2 };
            //                  -3,-1,-2,-2
            //                 ----------------
            //                 { 1, 3, 4, 2 } 1
            //                   0, 1, 1,-2
            //                 ----------------
            //                 { 1, 2, 4, 3 } 2
            //                   0, 0, 1,-2
            //                 ----------------
            //                 { 1, 2, 3, 4 } 3
            Assert.AreEqual(3, MinimumSwaps2(testArray2));
            //                   0, 1, 2, 3, 4
            //                 { 1, 2, 3, 4, 5 }
            int[] testArray3 = { 2, 3, 4, 1, 5 };
            //                  -1, 1, 1,-1, 0
            //                 ----------------
            //                 { 1, 3, 4, 2, 5 } 1
            //                 { 1, 2, 4, 3, 5 } 2
            //                 { 1, 2, 3, 4, 5 } 3
            Assert.AreEqual(3, MinimumSwaps2(testArray3));

            //                 { 1, 2, 3, 4, 5, 6, 7 }
            int[] testArray4 = { 1, 3, 5, 2, 4, 6, 7 };
            //                   0, 1, 2,-2,-1, 0, 0
            //                 -----------------------
            //                 { 1, 2, 5, 3, 4, 6, 7 } 1
            //                 { 1, 2, 3, 5, 4, 6, 7 } 2
            //                 { 1, 2, 3, 4, 5, 6, 7 } 3
            Assert.AreEqual(3, MinimumSwaps2(testArray4));
        }

        int MinimumSwaps2(int[] arr)
        {
            int result = 0;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > i + 1)
                {
                    int minIndex = i;

                    while (arr[minIndex] - i != 1)
                        minIndex++;

                    int temp = arr[i];
                    arr[i] = arr[minIndex];
                    arr[minIndex] = temp;
                    result++;
                }
            }

            return result;
        }

        [TestMethod]
        public void ArrayManipulationTest()
        {
            //a b k
            //1 5 3
            //4 8 7
            //6 9 1
            int[][] queries = {
                new int[3] { 1, 5, 3 },
                new int[3] { 1, 3, 1 },
                new int[3] { 4, 8, 7 },
                new int[3] { 6, 9, 1 }
            };
            //         0  1  2  3   4   5  6  7  8  9
            //index->  1  2  3  4   5   6  7  8  9  10
            //        [0, 0, 0, 0,  0,  0, 0, 0, 0, 0]
            //        [3, 3, 3, 3,  3,  0, 0, 0, 0, 0]
            //        [3, 3, 3, 10, 10, 7, 7, 7, 0, 0]
            //        [3, 3, 3, 10, 10, 8, 8, 8, 1, 0]

            Assert.AreEqual(10, ArrayManipulation(10, queries));
        }

        long ArrayManipulation(int n, int[][] queries)
        {
            long max = 0;
            int[] helpArray = new int[n];

            for (int j = 0; j < queries.Length; j++)
            {
                int a = queries[j][0];
                int b = queries[j][1];
                int k = queries[j][2];

                helpArray[a - 1] += k;
                helpArray[b] -= k;
            }

            int sum = 0;
            foreach (var num in helpArray)
            {
                sum += num;
                if (max < sum)
                    max = sum;
            }

            return max;
        }

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

        static string SortString(string input)
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
        }

        long CountTriplets(List<long> arr, long r)
        {
            long result = 0;
            Dictionary<long, long> dict = new Dictionary<long, long>();

            for (int i = 0; i < arr.Count; i++)
            {
                long item = arr[i];

                if (dict.ContainsKey(item / r) && dict[item / r] > 0
                    && dict.ContainsKey(item / (r * r)))
                {
                    result += dict[item / r];
                }

                if (dict.ContainsKey(item / r))
                {
                    if (dict.ContainsKey(item))
                    {
                        dict[item]++;
                    }
                    else
                    {
                        dict.Add(item, Math.Max(dict[item / r], 1));
                    }
                }
                else
                {
                    dict[item] = 0;
                }
            }

            return result;
        }
    }
}