using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace UnitTestProject1
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
    }
}