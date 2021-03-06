using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankExercises
{
    [TestClass]
    public class Recursion
    {
        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-fibonacci-numbers/
        /// </summary>
        [TestMethod]
        public void FibonacciTest()
        {
            int n1 = 3;
            Assert.AreEqual(2, Fibonacci(n1), "1");
        }
        int Fibonacci(int n)
        {
            if (n == 0)
                return 0;
            else if (n == 1)
                return 1;
            else
                return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        ///// <summary>
        ///// https://www.hackerrank.com/challenges/ctci-recursive-staircase/
        ///// </summary>
        //[TestMethod]
        //public void StepPermsTest()
        //{
        //    int n1 = 3;
        //    Assert.AreEqual(2, Fibonacci(n1), "1");
        //}
        //int StepPerms(int n)
        //{
        //    if (n == 0)
        //        return 0;
        //    else if (n == 1)
        //        return 1;
        //    else
        //        return Fibonacci(n - 1) + Fibonacci(n - 2);
        //}

        [TestMethod]
        public void PowerSumTest()
        {
            int x1 = 10; //1^2 + 3^2
            int N1 = 2;
            Assert.AreEqual(1, PowerSum(x1, N1), "1");

            int x2 = 100;
            int N2 = 2;
            Assert.AreEqual(3, PowerSum(x2, N2), "2");

            int x3 = 13; //2^2 + 3^2
            int N3 = 2;
            Assert.AreEqual(1, PowerSum(x3, N3), "3");
        }

        int PowerSum(int x, int N)
        {
            return HelpPowerSum(1, x, N);
        }

        int HelpPowerSum(int index, int left, int N)
        {
            int power = (int)Math.Pow(index, N);

            if (power < left)
                return HelpPowerSum(index + 1, left - power, N) +
                    HelpPowerSum(index + 1, left, N);
            else if (power == left)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/recursive-digit-sum/problem
        /// It fails over stackoverflow exception for test case 3.
        /// </summary>
        [TestMethod]
        public void SuperDigitTest()
        {
            string n1 = "148";
            int k1 = 3;
            Assert.AreEqual(3, SuperDigit(n1, k1), "1");

            string n2 = "9875";
            int k2 = 4;
            Assert.AreEqual(8, SuperDigit(n2, k2), "2");

            string n3 = "7404954009694227446246375747227852213692570890717884174001587537145838723390362624487926131161112710589127423098959327020544003395792482625191721603328307774998124389641069884634086849138515079220750462317357487762780480576640689175346956135668451835480490089962406773267569650663927778867764315211280625033388271518264961090111547480467065229843613873499846390257375933040086863430523668050046930387013897062106309406874425001127890574986610018093859693455518413268914361859000614904461902442822577552997680098389183082654625098817411306985010658756762152160904278169491634807464356130877526392725432086439934006728914411061861235300979536190100734360684054557448454640750198466877185875290011114667186730452681943043971812380628117527172389889545776779555664826488520325234792648448625225364535053605515386730925070072896004645416713682004600636574389040662827182696337187610904694029221880801372864040345567230941110986028568372710970460116491983700312243090679537497139499778923997433720159174153";
            int k3 = 100000;
            Assert.AreEqual(3, SuperDigit(n3, k3), "3");
        }

        int SuperDigit(string n, int k)
        {
            return (int)RecursiveSuperDigit((k * HelpSuperDigit(n)).ToString());
        }

        long RecursiveSuperDigit(string n)
        {
            if (n.Length == 1)
                return int.Parse(n);

            long super = HelpSuperDigit(n);

            return RecursiveSuperDigit(super.ToString());
        }
        long HelpSuperDigit(string n)
        {
            long result = 0;
            for (int i = 0; i < n.Length; i++)
            {
                result += n[i] - '0';
            }
            return result;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/ctci-recursive-staircase/problem
        /// </summary>
        [TestMethod]
        public void StepPermsTest()
        {
            int n1 = 5;
            Assert.AreEqual(13, stepPerms(n1), "1");

            int n2 = 1;
            Assert.AreEqual(1, stepPerms(n2), "2");

            int n3 = 3;
            Assert.AreEqual(4, stepPerms(n3), "3");

            int n4 = 7;
            Assert.AreEqual(44, stepPerms(n4), "4");
        }
        Dictionary<int, int> _dict = new Dictionary<int, int>();
        int stepPerms(int n)
        {
            if (n < 0)
                return 0;
            if (n == 0)
                return 1;
            int step1, step2, step3;

            if (_dict.TryGetValue(n - 1, out int value1))
                step1 = value1;
            else
            {
                step1 = stepPerms(n - 1);
                _dict.Add(n - 1, step1);
            }

            if (_dict.TryGetValue(n - 2, out int value2))
                step2 = value2;
            else
            {
                step2 = stepPerms(n - 2);
                _dict.Add(n - 2, step2);
            }

            if (_dict.TryGetValue(n - 3, out int value3))
                step3 = value3;
            else
            {
                step3 = stepPerms(n - 3);
                _dict.Add(n - 3, step3);
            }

            return step1 + step2 + step3;
        }

        /// <summary>
        /// https://www.hackerrank.com/challenges/crossword-puzzle/problem
        /// </summary>
        [TestMethod]
        public void CrosswordPuzzleTest()
        {
            string[] crossword1 = new string[10]
            {
                "+-++++++++",
                "+-++++++++",
                "+-------++",
                "+-++++++++",
                "+-++++++++",
                "+------+++",
                "+-+++-++++",
                "+++++-++++",
                "+++++-++++",
                "++++++++++"
            };
            string words1 = "AGRA;NORWAY;ENGLAND;GWALIOR";

            string[] output1 = new string[10]
            {
                "+E++++++++",
                "+N++++++++",
                "+GWALIOR++",
                "+L++++++++",
                "+A++++++++",
                "+NORWAY+++",
                "+D+++G++++",
                "+++++R++++",
                "+++++A++++",
                "++++++++++"
            };
            CollectionAssert.AreEqual(output1, crosswordPuzzle(crossword1, words1), "1");
        }
        string[] crosswordPuzzle(string[] crossword, string words)
        {
            string[] result = new string[10];

            for (int i = 0; i < crossword.Length; i++)
            {
                foreach (char c in crossword[i])
                {
                }
            }

            return result;
        }


        ///// <summary>
        ///// https://www.hackerrank.com/challenges/stone-division-2/problem
        ///// </summary>
        //public void StoneDivisionTest()
        //{
        //    long n1;
        //    long[] s1;


        //}
        //long stoneDivision(long n, long[] s)
        //{

        //}
    }
}