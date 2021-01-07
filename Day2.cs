using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day2
    {
        public static string Input => GetInput();

        public static void GetResult1()
        {
            var lines = Input.Split("\r\n");
            var counter = 0;

            foreach (var item in lines)
            {
                var countString = Regex.Match(item, @"\d*-\d*");
                var letter = Regex.Match(item, @"\w{1}(?=:)");
                var psw = Regex.Match(item, @"\: (.*)");

                var matches = Regex.Matches(psw.Value, @$"[{{{letter.Value}}}]{{1}}").Count;

                var counts = countString.Value.Split("-");
                if (matches >= Int32.Parse(counts[0]) && matches <= Int32.Parse(counts[1]))
                {
                    counter++;
                }

                Console.WriteLine(countString + " " + letter.Value + " " + psw.Value + " " + matches);
                Console.WriteLine(counter);

                // 15-16 m: mhmjmzrmmlmmmmmm
            }

        }
        public static void GetResult2()
        {

            var lines = Input.Split("\r\n");
            var counter = 0;

            foreach (var item in lines)
            {
                var countString = Regex.Match(item, @"\d*-\d*");
                var letter = Regex.Match(item, @"\w{1}(?=:)");
                var psw = Regex.Match(item, @"(?<=\: ).*").Value;

                var matches = Regex.Matches(psw, @$"[{{{letter.Value}}}]{{1}}").Count;

                var indexes = countString.Value.Split("-");
                var pos1 = psw[Int32.Parse(indexes[0]) - 1].ToString();
                var pos2 = psw[Int32.Parse(indexes[1]) - 1].ToString();

                if (pos1 == letter.Value && pos2 != letter.Value) 
                {
                    counter++;
                };
                if (pos1 != letter.Value && pos2 == letter.Value)
                {
                    counter++;
                };

                //Console.WriteLine(countString + " " + letter.Value + " " + psw + " " + matches);
                Console.WriteLine(counter);

                // 15-16 m: mhmjmzrmmlmmmmmm
            }

        }
        private static string GetInput()
        {
            var data = File.ReadAllText("InputDay2.txt");
            return data;
        }

        static class Pattern
        {
            //public int MyProperty { get; set; }
        }





    }
}
