using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode.Common
{
    public static class FileHelper
    {
        public static string GetInput(string file)
        {
            var data = File.ReadAllText($"Inputs/{file}.txt");
            return data;
        }
    }
}
