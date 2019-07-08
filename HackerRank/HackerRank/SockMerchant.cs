using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/*
 * Sample Inputs 0:
 * 5 4
 * 1 2 3 4 5
 * Sample Output 0:
 * 5 1 2 3 4
 */
namespace HackerRankWarmUps
{
    /// <summary>
    /// Sock Merchant
    /// https://www.hackerrank.com/challenges/sock-merchant/
    /// </summary>
    public class SockMerchant
    {
        static int sockMerchant(int n, int[] ar)
        {
            var dict = new Dictionary<int, int>();
            int count = 0;
            for (int i = 0; i < ar.Length; i++)
            {
                int key = ar[i];
                if (dict.ContainsKey(key))
                {
                    count++;
                    dict.Remove(key);
                }
                else
                {
                    dict.Add(key, key);
                }
            }
            return count;
        }

        public static void Main(string[] args)
        {
            int n = Convert.ToInt32(Console.ReadLine());

            int[] ar = Array.ConvertAll(Console.ReadLine().Split(' '), arTemp => Convert.ToInt32(arTemp))
            ;
            int result = sockMerchant(n, ar);
            Console.Write(result);

            Console.ReadKey();
        }
    }
}