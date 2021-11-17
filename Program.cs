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
            Regex email = new Regex(@"\s[\w\-\.\'\%\+]+@[\w\\-]+\.(com|co\.uk|org|edu|au|nz|co\.nz|net)\b");
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

        public static bool MobileNumberValidation(string mobileNumber)
        {
            Regex validMobileNumber = new Regex(@"^(\+44|0)7\d{9}$");
            return validMobileNumber.IsMatch(mobileNumber);
        }
    }
}
