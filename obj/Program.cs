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
            string text = File.ReadAllText(@"C:\Users\Danny.Flahive\Training\EmailExtraction\input.txt");
            Regex email = new Regex(@"\s[a-zA-Z0-9_\-\.\'\%\+]+@[a-zA-Z0-9\\-]+.(com|co.uk|org|edu|au|nz|co.nz|net)\s");
            Dictionary<string, int> domainFrequecies = new Dictionary<string, int>();
            foreach (Match match in email.Matches(text))
            {
                string matchStr = match.Value;
                int atIndex = matchStr.IndexOf("@");
                int topLevelDomainIndex = matchStr.Substring(atIndex).IndexOf(".");
                string domain = matchStr.Substring(atIndex, topLevelDomainIndex);
                domainFrequecies[domain] = domainFrequecies.ContainsKey(domain) ? domainFrequecies[domain] + 1 : 1;
            }
            var sortedDomainFrequencies = domainFrequecies.OrderByDescending(p => p.Value);
            foreach (var pair in sortedDomainFrequencies)
            {
                Console.WriteLine($"Domain {pair.Key} appears {pair.Value} times");
            }
        }
    }
}
