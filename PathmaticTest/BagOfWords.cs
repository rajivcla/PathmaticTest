using System;
using System.Collections.Generic;
using System.Text;

namespace PathmaticTest
{
    public class BagOfWords
    {
        Dictionary<string, int> bagOfWords { get; set; }
        double totalWordsAdded = 0;

        public BagOfWords()
        {
            bagOfWords = new Dictionary<string, int>();
        }

        // Adds words to current bag based on the input company names
        public void Add(string companyName) 
        {
            var words = companyName.Split(' ');
            foreach(var word in words)
            {
                totalWordsAdded++;
                if (bagOfWords.TryGetValue(word, out int val))
                {
                    bagOfWords[word]++;
                }
                else
                {
                    bagOfWords[word] = 1;
                }
            }   
        }

        // returns the most common words found in the set based on the threshold
        public HashSet<string> GetMostCommonWords(double threshold)
        {
            var common = new HashSet<string>();
            foreach(var d in bagOfWords)
            {
                if(d.Value / totalWordsAdded > threshold )
                {
                    common.Add(d.Key);
                }
            }
            return common;

        }
    }
}
