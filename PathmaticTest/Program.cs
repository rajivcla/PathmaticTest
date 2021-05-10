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
            //2. create bag of common words that need to be removed, ie llc, inc, com, co, corporation based on threshold
            //3. remove spaces and add all to hashset, as you add test if there are duplciates and output those.
            var lines = File.ReadAllLines(@"C:\Users\rajiv\Downloads\advertisers.txt");
            var filePath = @"C:\Users\rajiv\Downloads\advertisers.results.txt";
            var threshold = .003;
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
        // First algo I thought of but wouldn't be able to implement in 90 mins.
        //1. Remove common words w/ higher threshold (using above algo)
        //2. Convert string into a simple hash to get frequency distribution of characters as an int
        //3. Place characters into distribution histogram
        //4. normalize strings to 0 -9 a - z = 36 characters, 
        //5. compare nearest +/- 36 character frequencies and matched % w/ Longest Common Subsequence algo
        //6. make parallel
        //7. output matches to file

    }
}
