using System;
using System.Collections.Generic;

namespace E1News
{
    class Program
    {
        static void Main()
        {
            var newsParser = new NewsParser(10);
            PrintNews(newsParser.News);
        }

        private static void PrintNews(IEnumerable<NewsModel> news)
        {
            foreach (var newsModel in news)
            {
                Console.WriteLine(newsModel);
                Console.WriteLine("\n///////////////END///////////////\n");
            }
        }
    }
}
