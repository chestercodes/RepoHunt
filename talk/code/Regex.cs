using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace code
{
    public class PostCodeRegex 
    {
        public string ParsePostCodeRegion(string input)
        {
            const string Region = "Region";
            
            var p = "(?<" + Region + ">^[A-Z]{1,2})\\d{1,2}\\s*\\d{1,2}[A-Z]{1,2}$";
            
            var match = new Regex(p).Match(input);

            if (match.Success)
            {
                return match.Groups[Region].Value;
            }

            return null;
        }

        public void Run()
        {
            var postcode = "AB12 34CD";
            var result = ParsePostCodeRegion(postcode);
            Console.WriteLine(result != null ? result : "could not parse");
        }
    }
}
