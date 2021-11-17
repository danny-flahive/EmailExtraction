using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using System.Linq;

namespace EmailExtraction
{
    class Program
    {
        static void Main(string[] args)
        {
            //Regex softwireEmail = new Regex("\\s[a-zA-Z]+@softwire.com");
            //Console.WriteLine($"There are {softwireEmail.Matches(text).Count} matches");

            string text = File.ReadAllText(@"C:\Users\Danny.Flahive\Training\EmailExtraction\input.txt");
            Regex email = new Regex("[a-zA-Z0-9_\\-\\.]+@[a-zA-Z0-9\\-]+.(com|co.uk|org|edu|au|nz)");
            Dictionary<string, int> domainFrequecies = new Dictionary<string, int>();
            foreach (Match match in email.Matches(text))
            {
                string matchStr = match.Value;
                int ampersandIndex = matchStr.IndexOf("@");
                int topLevelDomainIndex = matchStr.Substring(ampersandIndex).IndexOf(".");
                string domain = matchStr.Substring(ampersandIndex, topLevelDomainIndex);
                domainFrequecies[domain] = domainFrequecies.ContainsKey(domain) ? domainFrequecies[domain] + 1 : 0;
            }
            var sortedDomainFrequencies = domainFrequecies.OrderByDescending(p => p.Value);
            foreach (var pair in sortedDomainFrequencies)
            {
                Console.WriteLine($"Domain {pair.Key} appears {pair.Value} times");
            }
        }
    }
}
