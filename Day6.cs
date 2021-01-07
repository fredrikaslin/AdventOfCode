using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Day6
    {
        public static string Input => FileHelper.GetInput("6");

        public static void GetResults1()
        {


            string[] groups = Input.Split(new string[] { "\r\n\r\n" },
                   StringSplitOptions.RemoveEmptyEntries);


            var uniqueCharInGroup = new List<string>();
            var totCount = 0;
            foreach (var group in groups)
            {
                var tot = "";
                var rows = group.Split("\r\n");
                foreach (var row in rows)
                {
                    tot += row;
                }
                var groupCount = tot.Distinct().Count();
                totCount += groupCount;
            }
            Console.WriteLine(totCount);
        }

        public static void GetResults2()
        {
            string[] groups = Input.Split(new string[] { "\r\n\r\n" },
                   StringSplitOptions.RemoveEmptyEntries);

            var res = 0;
            foreach (var group in groups)
            {
                var rows = group.Split("\r\n");


                res += Check(rows);

                //var groupCount = tot.Distinct().Count();
                //totCount += groupCount;
            }
            Console.WriteLine(res);
        }

        public static int Check(string[] rows)
        {
            var groupCount = rows.Length;
            if(groupCount == 1) { return rows[0].ToCharArray().Length; } 

            var matchedLetter = new List<char>();
            var firstRow = rows[0].ToCharArray().Distinct();
            List<char> iterateThis = new List<char>();

            iterateThis.AddRange(firstRow);

            for (int i = 1; i < groupCount; i++)
            {
                foreach (var letter in iterateThis)
                {
                    if (rows[i].Contains(letter))
                    {
                        matchedLetter.Add(letter);
                    }
                    else
                    {
                        matchedLetter.Remove(letter);
                    }
                }
                iterateThis.Clear();
                iterateThis.AddRange(matchedLetter);
            }
            

            Console.WriteLine("Group count: " + matchedLetter.Distinct().Count());

            return matchedLetter.Distinct().Count();


        }
    }
}
