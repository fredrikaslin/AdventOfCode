using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using static AdventOfCode.Day7.Row;

namespace AdventOfCode
{
    public static class Day7
    {
        public class Row
        {
            public Row(string row)
            {
                BagColor = GetBagNameFromInput(row);
                ContainingBags = GetBagsFromInput(row);
                OrgRow = row;
            }



            public string BagColor { get; set; }
            public List<Bag> ContainingBags { get; set; }
            public string OrgRow { get; set; }


            public class Bag
            {
                public string Color { get; set; }
                public int Count { get; set; }
            }

            private List<Bag> GetBagsFromInput(string row)
            {
                var list = GetContainningBags(row);
                var returnList = new List<Bag>();

                foreach (var item in list)
                {
                    var wordsArray = item.Split();
                    var name = wordsArray[1] + ' ' + wordsArray[2];


                    returnList.Add(
                        new Bag()
                        {
                            Color = name,
                            Count = GetBagCount(item)
                        });
                }

                return returnList;
            }
            private static List<string> GetContainningBags(string row)
            {
                var returnList = new List<string>();
                var index = row.IndexOf("contain");
                var containsBags = row.Substring(index + "contain".Length);

                var WordsArray = containsBags.Split(',');

                foreach (var item in WordsArray)
                {
                    returnList.Add(item.Trim());
                }

                return returnList;
            }

            private static int GetBagCount(string item)
            {
                if (item == "no other bags.") { return 0; }
                var WordsArray = item.Split();
                int count = int.Parse(WordsArray[0]);
                return count;
            }
            private string GetBagNameFromInput(string row)
            {
                var wordsArray = row.Split();
                return wordsArray[0] + ' ' + wordsArray[1];
            }
        }
        public static string Input => FileHelper.GetInput("7");

        private static string[] _rows => Input.Split("\r\n");
        private static int _counter = 0;
        private static int _bagCounter = 0;
        private static List<string> _checkList = new List<string>();
        private static List<Row> rowList = new List<Row>();
        private static List<Row> countedRows = new List<Row>();
        private static List<Bag> _bags = new List<Bag>();



        //---------------------------------Task2--------------------------------------------//

        public static void GetResults2()
        {
            string rootData = "";
            foreach (var row in _rows)
            {
                rowList.Add(new Row(row));
            }

            _bagCounter = Start("shiny gold");


            Console.WriteLine(_bagCounter);

        }

        private static int Start(string bagColor)
        {
            var count = 0;
            var bag = rowList.Where(x => x.BagColor == bagColor).ToList().FirstOrDefault();
            if (bag.ContainingBags.Any(x => x.Color == "other bags.")) return count;

            foreach (var item in bag.ContainingBags)
            {
                count += item.Count;
                for (int i = 0; i < item.Count; i++)
                {
                    count += Start(item.Color);
                }
            }
            return count;
        }



        //176656
        //121040



        //private static void RunCounter()
        //{
        //    int parentCount = 1;
        //    foreach (var row in correctLists)
        //    {
        //        int levelSum = 0;

        //        foreach (var bag in row.ContainingBags)
        //        {
        //            var bagCount = bag.Count;
        //            levelSum += bagCount * parentCount;

        //        }

        //        _bagCounter += levelSum;
        //        parentCount = levelSum;
        //    }

        //}




        //---------------------------------Task1--------------------------------------------//
        public static void GetResults1()
        {
            var containsGoldBag = new List<string>();
            foreach (var row in _rows)
            {
                if (row.Contains("shiny gold") && !row.StartsWith("shiny gold"))
                {
                    containsGoldBag.Add(row);
                    Console.WriteLine(row);
                    _checkList.Add(GetBagName(row));
                }
            }
            _counter += containsGoldBag.Count;

            GetBagsContainingGold(containsGoldBag);

            Console.WriteLine(_counter);
            Console.WriteLine(_checkList.Distinct().Count());
        }

        private static void GetBagsContainingGold(List<string> containsGoldBag)
        {
            if (containsGoldBag.Count == 0) { return; }
            var returnList = new List<string>();
            foreach (var bag in containsGoldBag)
            {
                var bagname = GetBagName(bag);

                foreach (var row in _rows)
                {
                    var index = row.IndexOf("contain");
                    var n = row.Substring(index);
                    if (n.Contains(bagname))
                    {
                        if (!_checkList.Contains(GetBagName(row)))
                        {
                            Console.WriteLine(GetBagName(row));
                            _checkList.Add(GetBagName(row));

                            _counter++;
                        }

                        returnList.Add(row);
                    }
                }
            }
            GetBagsContainingGold(returnList);
        }

        private static string GetBagName(string item)
        {
            var WordsArray = item.Split();
            string bag = WordsArray[0] + ' ' + WordsArray[1];
            return bag;
        }

        private static string GetBagNameFromSubstring(string item)
        {
            var WordsArray = item.Split();
            string bag = WordsArray[1] + ' ' + WordsArray[2];
            return bag;
        }

        /*  var bagsContainingGold = new List<string>();
            foreach (var item in hits)
            {
                string bag = GetBagName(item);

                if (bag != "shiny gold")
                {
                    Console.WriteLine(bag);
                    bagsContainingGold.Add(bag);
                }

            }
            count += bagsContainingGold.Count;

            var newList = new List<string>();
            foreach (var item in rows)
            {
                for (int i = 0; i < bagsContainingGold.Count; i++)
                {
                    var index = item.IndexOf("contain");
                    var n = item.Substring(index);
                    if (n.Contains(bagsContainingGold[i]))
                    {
                        newList.Add(GetBagName(item));
                        Console.WriteLine(item);
                    }
                }
            }
            count += newList.Count;


            var newList2 = new List<string>();
            foreach (var item in rows)
            {
                for (int i = 0; i < newList.Count; i++)
                {
                    var index = item.IndexOf("contain");
                    var n = item.Substring(index);
                    if (n.Contains(newList[i]))
                    {
                        newList2.Add(GetBagName(item));
                        Console.WriteLine(item);
                    }
                }
            }
            count += newList2.Count;*/

        //foreach (var item in rows)
        //{
        //    if (Regex.Match(item, @"(?<=\bcontain [0-9]\s)(\bshiny gold)").Value == "shiny gold") 
        //    {
        //        Console.WriteLine(item);
        //    };

        //}
    }
}
