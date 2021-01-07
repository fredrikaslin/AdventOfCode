using AdventOfCode.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode
{
    public static class Day5
    {
        public static string Input => FileHelper.GetInput("5");

        public static void GetResults1()
        {


            var rows = Input.Split("\r\n");
            //var rows = new string[] { "FBFBBFFRLR" };
            var seatIds = new List<int>();
            for (int i = 0; i < rows.Length; i++)
            {
                var rowRange = Enumerable.Range(0, 128).Select(x => x).ToArray();
                var colRange = Enumerable.Range(0, 8).Select(x => x).ToArray();
                var numberOfRows = 128;
                var numberOfCols = 8;

                for (int j = 0; j < rows[i].Length; j++)
                {
                    if (rows[i][j] == 'F')
                    {
                        numberOfRows /= 2;
                        rowRange = rowRange.Take(numberOfRows).ToArray();
                    }
                    if (rows[i][j] == 'B')
                    {
                        numberOfRows /= 2;
                        rowRange = rowRange.Skip(numberOfRows).Take(numberOfRows).ToArray();
                    }
                    if (rows[i][j] == 'R')
                    {
                        numberOfCols /= 2;
                        colRange = colRange.Skip(numberOfCols).Take(numberOfCols).ToArray();
                    }
                    if (rows[i][j] == 'L')
                    {
                        numberOfCols /= 2;
                        colRange = colRange.Take(numberOfCols).ToArray();
                    }
                    //Console.WriteLine($"row: {rowRange[0]} col: {colRange[0]}");
                }
                var seatId = rowRange[0] * 8 + colRange[0];
                seatIds.Add(seatId);
                //Console.WriteLine(seatId);
                //Console.WriteLine("------------------------------------------------------------");
                //Console.WriteLine(seatIds.Max());

            }
            seatIds.Sort();
            foreach (var item in seatIds)
            {
                var j = item + 1;
                if (seatIds.FindIndex(x=>x == j) == -1 )
                {

                }

                Console.WriteLine(item);

            }
        }


    }
}
