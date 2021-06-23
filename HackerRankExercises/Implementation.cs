using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerRankExercises
{
    public class Square
    {
        public int Side;
    }

    public interface IRectangle
    {
        int Width { get; }
        int Height { get; }
    }

    public static class ExtensionMethods
    {
        public static int Area(this IRectangle rc)
        {
            return rc.Width * rc.Height;
        }
    }

    public class SquareToRectangleAdapter : IRectangle
    {

        public SquareToRectangleAdapter(Square square)
        {
            this.Width = square.Side;
            this.Height = square.Side;
        }

        public int Width { get; }

        public int Height { get; }
        // todo
    }

    [TestClass]
    public class Implementation
    {
        [TestMethod]
        public void ExceptionDataTest()
        {
            ExceptionData();
        }
        public void ExceptionData()
        {

        }
        /// <summary>
        /// https://www.hackerrank.com/challenges/magic-square-forming/problem
        /// </summary>
        [TestMethod]
        public void FormingMagicSquareTest()
        {
            var s1 = new int[3][];

            s1[0] = new int[3];
            s1[1] = new int[3];
            s1[2] = new int[3];

            s1[0][0] = 5;
            s1[0][1] = 3;
            s1[0][2] = 4;
            s1[1][0] = 1;
            s1[1][1] = 5;
            s1[1][2] = 8;
            s1[2][0] = 6;
            s1[2][1] = 4;
            s1[2][2] = 2;
            Assert.AreEqual(7, FormingMagicSquare(s1), "1");
        }

        int FormingMagicSquare(int[][] s)
        {
            int result = 81;

            //c − b         c +(a + b)  c − a
            //c − (a − b)   c           c +(a − b)
            //c + a         c − (a + b) c + b

            // 2,9,4
            // 7,5,3
            // 6,1,8


            int[][] magics = new int[][]
            {
                new int[] { 8, 1, 6, 3, 5, 7, 4, 9, 2},
                new int[] { 6, 1, 8, 7, 5, 3, 2, 9, 4},
                new int[] { 4, 9, 2, 3, 5, 7, 8, 1, 6},
                new int[] { 2, 9, 4, 7, 5, 3, 6, 1, 8},
                new int[] { 8, 3, 4, 1, 5, 9, 6, 7, 2},
                new int[] { 4, 3, 8, 9, 5, 1, 2, 7, 6},
                new int[] { 6, 7, 2, 1, 5, 9, 8, 3, 4},
                new int[] { 2, 7, 6, 9, 5, 1, 4, 3, 8}
            };
            //for (int a = 0; a <= 9; a++)
            //{
            //    for (int b = 0; b <= 9; b++)
            //    {
            //        for (int c = 0; c <= 9; c++)
            //        {
            //            if ((0 < a && a < b &&  b < (c - a)) && 
            //                b != 2 * a &&
            //                a + b + c < 10)
            //            {
            //                int[][] vs = new int[3][];
            //                vs[0] = new int[] { c - b, c + a + b, c - a };
            //                vs[1] = new int[] { c - (a - b), c, c + (a - b) };
            //                vs[2] = new int[] { c + a, c - (a + b), c + b };

            //                posibilities.Add(vs);
            //            }
            //        }
            //    }
            //}

            //allMagics.Select(ar => ar.Zip(square, (a, b) => Math.Abs(a - b)).Sum()).Min()

            for (int i = 0; i < magics.Length; i++)
            {
                int crt_cost = 0;
                for (int j = 0; j < magics[i].Length; i++)
                {
                    crt_cost += Math.Abs(s[i][j] - magics[i][j]);

                    if (crt_cost < result)
                        result = crt_cost;
                }
            }

            return result;
        }
        public int[][] FormingMagicSquareHelp(int currentI, int currentJ)
        {
            int[][] s = new int[3][];
            s[0] = new int[3];
            s[1] = new int[3];
            s[2] = new int[3];



            return s;
        }

        [TestMethod]
        public void LRUTest()
        {
            //Assert.AreEqual(7, LRU(s1), "1");
        }
        void LRU()
        {

        }

        [TestMethod]
        public void GetLuckyFloorNumberTest()
        {
            //Real:  1  2  3  4  5  6  7  8  9  10  11  12  13  14
            //Lucky: 1  2  3  5  6  7  8  9  10 11  12  15  16  17
            int n1 = 1;
            int n2 = 4;
            int n3 = 5;
            int n4 = 12;
            int n5 = 14;

            Assert.AreEqual(1, GetLuckyFloorNumber(n1), "1");
            Assert.AreEqual(5, GetLuckyFloorNumber(n2), "2");
            Assert.AreEqual(6, GetLuckyFloorNumber(n3), "3");
            Assert.AreEqual(15, GetLuckyFloorNumber(n4), "4");
            Assert.AreEqual(17, GetLuckyFloorNumber(n5), "5");
        }
        int GetLuckyFloorNumber(int n)
        {
            int result = n;

            for (int i = 1; i <= n; i++)
            {
                if (i.ToString().Contains("4") ||
                    i.ToString().Contains("13"))
                {
                    result++;
                    while (result.ToString().Contains("4") ||
                        result.ToString().Contains("13"))
                    {
                        result++;
                    }
                }

            }

            return result;
        }

        [TestMethod]
        public void PackNumbersTest()
        {
            //['5:3', '7:2', 3, 4, 7]
            List<int> arr1 = new List<int>()
            {
                5, 5, 5, 7, 7, 3, 4, 7
                //5, 5, 5
            };
            List<string> result = PackNumbers(arr1);

            CollectionAssert.AreEquivalent(new List<string> { "5:3", "7:2", "3", "4", "7" }, result, "1");
        }
        List<string> PackNumbers(List<int> arr)
        {
            List<string> result = new List<string>();
            string resultText;

            if (arr.Count == 1)
                return new List<string>() { arr[0].ToString() };

            int sameNeighbors = 1;
            for (int i = 1; i < arr.Count; i++)
            {
                int current = arr[i];
                int previous = arr[i - 1];

                if (current == previous)
                {
                    sameNeighbors = sameNeighbors + 1;
                }
                else
                {
                    if (sameNeighbors == 1)
                        resultText = $"{previous}";
                    else
                        resultText = $"{previous}:{sameNeighbors}";

                    result.Add(resultText);
                    sameNeighbors = 1;
                }
            }

            if (sameNeighbors == 1)
                resultText = $"{arr[arr.Count - 1]}";
            else
                resultText = $"{arr[arr.Count - 1]}:{sameNeighbors}";
            result.Add(resultText);

            return result;
        }

        [TestMethod]
        public void ShuffleDeckOfCardsTest()
        {
            int[] cards1 = { 2, 1, 3, 4, 5 };
            ShuffleDeckOfCards(cards1);
        }

        private int[] ShuffleDeckOfCards(int[] cards)
        {
            Random random = new Random();

            for (int i = 0; i < cards.Length; i++)
            {
                int index = (int)random.Next(cards.Length - i) + i;
                Swap(ref cards[index], ref cards[i]);
            }

            return cards;
        }

        public static void Swap(ref int v1, ref int v2)
        {
            int temp = v1;
            v1 = v2;
            v2 = temp;
        }

        [TestMethod]
        public void PhotoRenameTest()
        {
            string text = @"photo.jpg, Warsaw, 2013-09-05 14:08:15
john.png, London, 2015-06-20 15:13:22
myFriends.png, Warsaw, 2013-09-05 14:07:13
Eiffel.jpg, Paris, 2015-07-23 08:03:02
pisatower.jpg, Paris, 2015-07-22 23:59:59
BOB.jpg, London, 2015-08-05 00:02:03
notredame.png, Paris, 2015-09-01 12:00:00
me.jpg, Warsaw, 2013-09-06 15:40:22
a.png, Warsaw, 2016-02-13 13:33:50
b.jpg, Warsaw, 2016-01-02 15:12:22
c.jpg, Warsaw, 2016-01-02 14:34:30
d.jpg, Warsaw, 2016-01-02 15:15:01
e.png, Warsaw, 2016-01-02 09:49:09
f.png, Warsaw, 2016-01-02 10:55:32
g.jpg, Warsaw, 2016-02-29 22:13:11";

            string result = @"Warsaw02.jpg
London1.png
Warsaw01.png
Paris2.jpg
Paris1.jpg
London2.jpg
Paris3.png
Warsaw03.jpg
Warsaw09.png
Warsaw07.jpg
Warsaw06.jpg
Warsaw08.jpg
Warsaw04.png
Warsaw05.png
Warsaw10.jpg";
            Assert.AreEqual(result, PhotoRename(text), "1");
        }

        string PhotoRename(string text)
        {
            string result = null;

            string[] photosTexts = text.Split(
                new[] { Environment.NewLine },
                StringSplitOptions.None
            );

            Photo[] photos = new Photo[photosTexts.Length];
            var citiesGroup = new Dictionary<string, List<Photo>>();

            for (int i = 0; i < photosTexts.Length; i++)
            {
                string photoText = photosTexts[i];

                string name = null;
                int indexOfDot = photoText.IndexOf('.');
                if (indexOfDot > 0)
                {
                    name = photoText.Substring(0, indexOfDot);
                }

                string extension = null;
                int indexOfFirstComma = photoText.IndexOf(",");
                if (indexOfFirstComma > 0)
                {
                    extension = photoText.Substring(indexOfDot + 1, indexOfFirstComma - (indexOfDot + 1));
                }

                string city = null;
                int indexOfSeccondComma = photoText.IndexOf(",", indexOfFirstComma + 1);
                if (indexOfSeccondComma > 0)
                {
                    city = photoText.Substring(indexOfFirstComma + 1 + 1, indexOfSeccondComma - (indexOfFirstComma + 1 + 1));
                }

                DateTime date = DateTime.MinValue;
                if (indexOfSeccondComma > 0) //TODO: Add length validation.
                {
                    date = DateTime.Parse(photoText.Substring(indexOfSeccondComma + 1 + 1)); //TODO: switch to parse exact.
                }

                var photo = new Photo()
                {
                    Name = name,
                    Extension = extension,
                    City = city,
                    DateTime = date
                };

                //Memoiz
                if (citiesGroup.ContainsKey(city))
                    citiesGroup[city].Add(photo);
                else
                    citiesGroup.Add(city, new List<Photo>() { photo });

                photos[i] = photo;
            }

            foreach (KeyValuePair<string, List<Photo>> cityGroup in citiesGroup)
            {
                var myList = cityGroup.Value;
                var orderedList = cityGroup.Value.OrderBy(p => p.DateTime);

                double digits = Math.Floor(Math.Log10(myList.Count) + 1);
                int index = 1;
                foreach (var photo in orderedList)
                {
                    photo.Index = index.ToString($"D{digits}");
                    index++;
                }
            }

            result = string.Join(Environment.NewLine, photos.Select(p => p.City + p.Index + "." + p.Extension));

            return result;

        }
    }
    public class Photo
    {
        public string Name { get; set; }
        public DateTime DateTime { get; set; }
        public string Index { get; set; }
        public string Extension { get; set; }
        public string City { get; set; }
    }

    public class LRUCache
    {
        private readonly Queue<string> _queue;
        private readonly HashSet<string> _keys;
        private readonly int _pointer;

        LRUCache(int n)
        {
            this._queue = new Queue<string>(n);
            this._keys = new HashSet<string>();
        }

        void AddInput(string input)
        {
            if (this._keys.Contains(input))
                RemoveLast();
            else
                RemoveByIndex(input);


        }

        private void RemoveByIndex(string input)
        {
            throw new NotImplementedException();
        }

        private void RemoveLast()
        {
            throw new NotImplementedException();
        }
    }


    public class Flight
    {
        public string Origin { get; set; }
        public string Destination { get; set; }
        public DateTime Start { get; set; }
        public int Cost { get; set; }
    }
    [TestClass]
    public class RouteTraveler
    {
        // Amsterdam -> Paris -> Amsterdam
        // Amsterdam -> Paris -> Berlin -> Amsterdam
        private List<Flight> _flights => new List<Flight>() //
        {
            new Flight()
            {
                Origin = "Amsterdam",
                Destination = "Paris",
                Start = new DateTime(2019,10,1),
                Cost = 150
            },
            new Flight()
            {
                Origin = "Paris",
                Destination = "Berlin",
                Start = new DateTime(2019,10,5),
                Cost = 200
            },
            new Flight()
            {
                Origin = "Paris",
                Destination = "Amsterdam",
                Start = new DateTime(2019,10,4),
                Cost = 150
            },
            new Flight()
            {
                Origin = "Berlin",
                Destination = "Amsterdam",
                Start = new DateTime(2019,10,5),
                Cost = 450
            }
        };

        [TestMethod]
        public void FindMaxRouteTest()
        {
            var list = FindMaxRoute("Amsterdam");
            Assert.IsNull(list);
        }

        public List<string> FindMaxRoute(string origin)
        {
            StringBuilder sb = new StringBuilder();

            List<string> result = new List<string>();
            List<string> destinations = this._flights.Where(f => f.Origin == origin).Select(f => f.Destination).ToList();

            foreach (var destination in destinations)
            {
                IEnumerable<Flight> filteredFlights = this._flights.Where(f => f.Origin == destination);
                foreach (var filteredFlight in filteredFlights)
                {
                    List<string> temp = new List<string>();
                    if (filteredFlight.Destination == origin)
                    {
                        temp.Add(filteredFlight.Destination);
                        return temp;
                    }
                    else
                    {
                        temp.Add(filteredFlight.Destination);
                        FindMaxRoute(filteredFlight.Destination);                        
                    }
                }
            }
            return result;
        }
    }



    public class Soldiers
    {
        private string[] _soldiers;
        private Dictionary<int, Medal> _medals = new Dictionary<int, Medal>();

        public Soldiers(string[] soldier)
        {
            this._soldiers = soldier;
        }

        public Medal this[int index]
        {
            get
            {
                Medal medal = new Medal();
                this._medals.Add(index, medal);
                return this._medals[index];
            }
        }

        public override string ToString()
        {
            var soldierList = new List<string>();
            for (var i = 0; i < this._soldiers.Length; i++)
            {
                string soldier = this._soldiers[i];
                if (this._medals.ContainsKey(i))
                    soldier = soldier + ", Medal: " + this._medals.ElementAt(i).ToString();
                soldierList.Add(soldier);
            }
            return string.Join("; ", soldierList);
        }

        public class Medal
        {
            public bool Bronze;
            public bool Silver;
            public bool Gold;

            public override string ToString()
            {
                return (this.Bronze ? "Bronze," : "") + (this.Silver ? "Silver," : "") + (this.Gold ? "Gold" : "");
            }
        }
    }
}