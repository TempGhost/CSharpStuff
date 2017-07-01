using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MyPractice.Code
{
     static class RegularExpressionsPractice
    {
        public static void TestRegulare()
        {
            const string Text = @"XML has made a major impact in almost every aspect of 
            software development. Designed as an open, extensible, self-describing 
            language, it has become the standard for data and document delivery on 
            the web. The panoply of XML-related technologies continues to develop 
            at breakneck speed, to enable validation, navigation, transformation, 
            linking, querying, description, and messaging of data xML Xml xmlxmlxml.";
            string keyword = "XML";
            MatchCollection mc = Regex.Matches(Text, keyword);
            Console.WriteLine("Useing Regex.Matches(Text,keyword)");
            foreach (Match item in mc)
            {
                Console.WriteLine(item.ToString());
            }
            mc = Regex.Matches(Text, keyword, RegexOptions.IgnoreCase);
            Console.WriteLine("Useing Regex.Matches(Text, keyword,RegexOptions.IgnoreCase)");
            foreach (Match item in mc)
            {
                Console.WriteLine(item.ToString());
            }
            mc = Regex.Matches(Text, keyword, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);

            Console.WriteLine("Regex.Matches(Text, keyword, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);");

            foreach (Match item in mc)
            {
                Console.WriteLine(item.ToString());
            }
        }

    }
}
