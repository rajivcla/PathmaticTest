using System;
using System.Collections.Generic;
using System.IO;

namespace PathmaticTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //1. Normalize strings
            //2. create bag of common words that need to be removed, ie llc, inc, com, co, corporation
            //3. remove spaces and add all to hashset, as you add test if there are duplciates
            var lines = File.ReadAllLines(@"C:\Users\rajiv\Downloads\advertisers.txt");
            var filePath = @"C:\Users\rajiv\Downloads\advertisers.results.txt";
            var threshold = .001;
            Console.WriteLine("takes ~1 min to run");
            var bg = new BagOfWords();
            List<string> normalizedNames = new List<string>();
            foreach (var line in lines)
            {
                var normalizedName = Util.NormalizeString(line);
                bg.Add(normalizedName);
                normalizedNames.Add(normalizedName);
            }

            Util.FindDuplicates(lines, normalizedNames, bg.GetMostCommonWords(threshold), filePath);



        }
    }
}
