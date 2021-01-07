using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public static class Day4
    {
        public static string Input => GetInput();

        public static void GetResult1()
        {
            string[] passports = Input.Split(new string[] { "\r\n\r\n" },
                               StringSplitOptions.RemoveEmptyEntries);

            var validCounter = 0;
            foreach (var item in passports)
            {
                int count = item.Count(x => x == ':');
                if(count == 8)
                {
                    if (Validate(item))
                    {
                        validCounter++;
                    }
                    continue;
                }
                if(count == 7)
                {
                    if (item.Contains("cid"))
                    {
                        continue;
                    }
                    if (Validate(item))
                    {
                        validCounter++;
                    }
                }
            }
            Console.WriteLine(validCounter);
        
        }

        public static bool Validate(string row)
        {
            var fis = row.Replace("\r\n", " ");
            var kvp = fis.Split(' ');

            foreach (var item in kvp)
            {
                if (item.StartsWith("byr"))
                {
                    //four digits; at least 1920 and at most 2002
                    var value = item.Split(':');
                    if (value[1].Length != 4) { return false; }
                    Int32.TryParse(value[1], out int byr);
                    if(byr < 1920 || byr > 2002) { return false; }
                }
                if (item.StartsWith("iyr"))
                {
                    //(Issue Year) - four digits; at least 2010 and at most 2020.
                    var value = item.Split(':');
                    if (value[1].Length != 4) { return false; }
                    Int32.TryParse(value[1], out int iyr);
                    if (iyr < 2010 || iyr > 2020) { return false; }
                }
                if (item.StartsWith("eyr"))
                {
                    //(Expiration Year) -four digits; at least 2020 and at most 2030.
                    var value = item.Split(':');
                    if (value[1].Length != 4) { return false; }
                    Int32.TryParse(value[1], out int result);
                    if (result < 2020 || result > 2030) { return false; }
                }
                if (item.StartsWith("hgt"))
                {
                    /*(Height) - a number followed by either cm or in:
                        If cm, the number must be at least 150 and at most 193.
                        If in, the number must be at least 59 and at most 76.*/
                    var value = item.Split(':');
                    if (value[1].EndsWith("cm")) 
                    {
                        var cm = value[1].Replace("cm", String.Empty);
                        Int32.TryParse(cm, out int hgtcm);
                        if (hgtcm < 150 || hgtcm > 193) { return false; }

                    }
                    else if (value[1].EndsWith("in")) 
                    {
                        var cm = value[1].Replace("in", String.Empty);
                        Int32.TryParse(cm, out int hgtin);
                        if (hgtin < 59 || hgtin > 76) { return false; }
                    }
                    else { return false; }
                }
                if (item.StartsWith("hcl"))
                {
                    //(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
                    var value = item.Split(':');

                    if (!Regex.IsMatch(value[1], @"#[0-9a-f]{6}")) { return false; }
                }
                if (item.StartsWith("ecl"))
                {
                    //(Eye Color) - exactly one of: amb blu brn gry grn hzl oth
                    var value = item.Split(':');
                    var ecls = new List<string>() {"amb",
                                                   "blu",
                                                   "brn",
                                                   "gry",
                                                   "grn",
                                                   "hzl",
                                                   "oth"};

                    if (!ecls.Contains(value[1]))
                    {
                        return false;
                    }

                }
                if (item.StartsWith("pid"))
                {
                    //(Passport ID) - a nine-digit number, including leading zeroes.
                    var value = item.Split(':');
                    if (value[1].Length != 9) { return false; }
                    Int32.TryParse(value[1], out int byr);
                    if(byr == 0) { return false; }
                }
                if (item.StartsWith("cid"))
                {

                }
            }

            return true;
        }

        private static string GetInput()
        {
            //varr data = File.ReadAllText("InputDay3.txt");
            var data = File.ReadAllText("InputDay4.txt");
            return data;
        }
    }

    public class Passport
    {
        public string byr { get; set; }
        public string iyr { get; set; }
        public string eyr { get; set; }
        public string hgt { get; set; }
        public string hcl { get; set; }
        public string ecl { get; set; }
        public string pid { get; set; }
        public string cid { get; set; }

    }
}
