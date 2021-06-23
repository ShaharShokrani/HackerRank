using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HackerRankExercises
{
    [TestClass]
    public class DynamicProgramming
    {
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
    }

}