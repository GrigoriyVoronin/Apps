using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace LentaNews
{
    class Program
    {
        static void Main()
        {
            var db = new NewsDbContext();
            db.Database.Migrate();
            var newsParser = new NewsParser(10);
            WriteToDb(db, newsParser.News);
            PrintDbData(db.News);
        }

        private static void WriteToDb(NewsDbContext dbContext, List<NewsModel> news)
        {
            dbContext.AddRange(news);
            dbContext.SaveChanges();
        }

        private static void PrintDbData(IEnumerable<NewsModel> news)
        {
            foreach (var newsModel in news)
                Console.WriteLine(newsModel);
        }
    }
}
