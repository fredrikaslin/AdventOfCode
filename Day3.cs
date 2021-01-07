using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public static class Day3
    {
        public static string Input => GetInput();


        public static void GetResult1()
        {
            var px = 0;
            var py = 0;

            var rows = Input.Split("\r\n");
            var treeCounter = 0;


            for (int i = 1; i < rows.Length; i++)
            {
               
                px += 3;
                py += 1;

                while (rows[py].Length < px)
                {
                    rows[py] += rows[py];
                }

                if (rows[py][px].ToString() == "#")
                {
                    treeCounter++;
                }
            }

            Console.WriteLine(treeCounter);
        }


        public static void GetResult2()
        {
            var one = new int[] { 1, 1 };
            var two = new int[] { 3, 1 };
            var three = new int[] { 5, 1 };
            var four = new int[] { 7, 1 };
            var five = new int[] { 1, 2 };

            var list = new List<int[]>() { one, two, three, four, five };

            var resultList = new List<int>();

            foreach (var item in list)
            {
                resultList.Add(GetResultFor2(item));
            }

            var result = 1;
            for (int i = 0; i < resultList.Count; i++)
            {
                result = result * resultList[i]; // or equivalently r *= mult[i];
            }
            Console.WriteLine(result);
        }


        private static int GetResultFor2(int[] values)
        {
            var px = 0;
            var py = 0;

            var rows = Input.Split("\r\n");
            var treeCounter = 0;


            for (int i = 1; i < rows.Length; i++)
            {

                px += values[0];
                py += values[1];

                if (rows.Length < py) { return treeCounter; }
                while (rows[py].Length <= px)
                {
                    rows[py] += rows[py];
                }

                if (rows[py][px].ToString() == "#")
                {
                    treeCounter++;
                }
            }

            Console.WriteLine(treeCounter);
            return treeCounter;
        }

        private static string GetInput()
        {
            //varr data = File.ReadAllText("InputDay3.txt");
            var data = File.ReadAllText("InputDay3.txt");
            return data;
        }
    }
}
