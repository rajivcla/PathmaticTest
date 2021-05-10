using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace PathmaticTest
{
    public static class Util
    {


        public static string NormalizeString(string str)
        {
            var normalized = Regex.Replace(str.ToLower(), "[^0-9a-z ]", String.Empty);
            return normalized;
        }

        public static void FindDuplicates(string[] companyNames,List<string> normalized, HashSet<string> common, string path)
        {
            Dictionary<string,int> uniqueCompanies = new Dictionary<string,int>();
            using(StreamWriter outputFile = new StreamWriter(path))
            {
                for (int i = 0; i < normalized.Count; i++)
                {
                    var c = normalized[i];
                    var splitName = c.Split(" ");
                    var uncommon = string.Join(" ",splitName.Where(s => !common.Contains(s)).ToList());
                    int val;
                    if (uniqueCompanies.TryGetValue(uncommon, out val)){
                        outputFile.WriteLine($"{companyNames[val]} => {companyNames[i]}"); 
                    }
                    else if(uncommon != "")
                    {
                        uniqueCompanies.Add(uncommon, i);
                    }
                }
            }


        }
    }
}
