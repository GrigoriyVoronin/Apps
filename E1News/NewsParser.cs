using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace E1News
{
    public class NewsParser
    {
        private HtmlWeb client = new HtmlWeb();
        private const string E1News = "https://www.e1.ru/news";
        private const string E1 = "https://www.e1.ru";
        public IEnumerable<NewsModel> News { get; }

        public NewsParser(int count)
        {
            var allNewsPage = GetNewsPage();
            var newsCollection = GetTopNews(allNewsPage, count);
            var newsPages = GetNewsPages(newsCollection);
            News = GetNewsFromPages(newsPages);
        }

        private IEnumerable<NewsModel> GetNewsFromPages(HtmlDocument[] newsPages)
        {
            return newsPages
                .Select(p => new NewsModel(GetTitle(p), GetText(p), GetDate(p)));
        }

        private string GetDate(HtmlDocument newsPage)
        {
            return newsPage.DocumentNode
                .SelectSingleNode(
                    "//*[@id=\"record-header\"]/section/div/div[1]/div/time")?
                .InnerText ?? "Parse Error";
        }

        private string GetText(HtmlDocument newsPage)
        {
            return newsPage.DocumentNode
                .SelectSingleNode(
                    "//*[@id=\"app\"]/div[2]/div[3]/div/div[1]/div[3]/div[2]/div[1]/div[1]/div[1]/div[1]/div[2]/div")?
                .InnerText ?? "Parse Error";
        }

        private string GetTitle(HtmlDocument newsPage)
        {
            return newsPage.DocumentNode
                .SelectSingleNode(
                    "//*[@id=\"record-header\"]/section/div/div[2]/h2")?
                .InnerText ?? "Parse Error";
        }

        private HtmlDocument[] GetNewsPages(HtmlNode[] newsCollection)
        {
            return newsCollection
                .Select(n => client.Load(new Uri(E1 + n.FirstChild.Attributes["href"].Value)))
                .ToArray();
        }

        private HtmlNode[] GetTopNews(HtmlDocument newsPage, int count)
        {
            return newsPage.DocumentNode
                .SelectSingleNode(
                    "//*[@id=\"app\"]/div[2]/div[3]/div/div/div[2]/div/div[1]/div/div[3]")
                .ChildNodes
                .Where(n => n.HasClass("MZa1n"))
                .Take(count)
                .ToArray();
        }

        private HtmlDocument GetNewsPage()
        {
            return client.Load(new Uri(E1News));
        }
    }
}