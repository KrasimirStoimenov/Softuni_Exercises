using System;
using System.Collections.Generic;
using System.Text;

namespace _05._HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string article = Console.ReadLine();
            string content = Console.ReadLine();
            StringBuilder sb = new StringBuilder();

            string comments;
            while ((comments = Console.ReadLine()) != "end of comments")
            {
                sb.AppendLine("<div>");
                sb.AppendLine($"\t{comments}");
                sb.AppendLine("</div>");
            }

            Console.WriteLine($"<h1>\n\t{article}\n</h1>");
            Console.WriteLine($"<article>\n\t{content}\n</article>");
            Console.WriteLine(sb);
        }
    }
}
