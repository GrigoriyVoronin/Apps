using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace LentaNews
{
    public class NewsParser
    {
        private const string WorldCategory = "https://lenta.ru/rubrics/world/";
        private const string RussiaCategory = "https://lenta.ru/rubrics/russia/";
        private const string Lenta = "https://lenta.ru";
        private readonly HtmlWeb client = new HtmlWeb();

        public NewsParser(int count)
        {
            var worldNews = GetTopNews(count, WorldCategory,
                "//*[@id=\"root\"]/section[2]/div[2]/div/div");
            var russiaNews = GetTopNews(count, RussiaCategory,
                "//*[@id=\"root\"]/section[2]/div[2]/div/div");
            News.AddRange(GetNewsFromPages(worldNews, nameof(WorldCategory)));
            News.AddRange(GetNewsFromPages(russiaNews, nameof(RussiaCategory)));
        }

        public List<NewsModel> News { get; } = new List<NewsModel>();

        private IEnumerable<NewsModel> GetNewsFromPages(HtmlDocument[] newsPages, string categoryName)
        {
            return newsPages
                .Select(p => new NewsModel(GetTitle(p), GetText(p), GetDate(p), categoryName));
        }

        private string GetDate(HtmlDocument newsPage) =>
            newsPage.DocumentNode
                .SelectSingleNode(
                    "//div[contains(@class,'js-root')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'content')]" +
                    "//div[contains(@class,'header')]" +
                    "//div[contains(@class,'b-topic__info')]" +
                    "//time")
                ?.InnerText;

        private string GetText(HtmlDocument newsPage) =>
            newsPage.DocumentNode
                .SelectSingleNode(
                    "//div[contains(@class,'js-root')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'content')]" +
                    "//div[contains(@class,'text')]")
                ?.InnerText;

        private string GetTitle(HtmlDocument newsPage) =>
            newsPage.DocumentNode
                .SelectSingleNode(
                    "//div[contains(@class,'js-root')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'layout')]" +
                    "//div[contains(@class,'content')]" +
                    "//div[contains(@class,'header')]" +
                    "//h1[contains(@class,'title')]")
                ?.InnerText;

        private HtmlDocument[] GetTopNews(int count, string category, string xPath)
        {
            var newsPage = GetNewsPages(category).ToList();
            var links = new List<string>();
            var a = GetLinksFromNode(newsPage, $"{xPath}[1]/section");
            var b = GetLinksFromNode(newsPage, $"{xPath}[2]/section");
            var c = GetLinksFromNode(newsPage, $"{xPath}[3]/section");
            links.AddRange(a);
            links.AddRange(b);
            links.AddRange(c);
            return links
                .Take(count)
                .Select(l => GetNewsPage(Lenta + l))
                .ToArray();
        }

        private HtmlDocument GetNewsPage(string path) => client.Load(new Uri(path));

        private IEnumerable<string> GetLinksFromNode(IEnumerable<HtmlDocument> newsPages, string xPath)
        {
            foreach (var newsPage in newsPages)
            {
                var children = newsPage?.DocumentNode?.SelectSingleNode(xPath)?.ChildNodes;
                if (children == null)
                    continue;

                foreach (var child in children)
                {
                    var innerChild = child?.ChildNodes;
                    if (innerChild == null)
                        continue;

                    var link = innerChild.FirstOrDefault(cN => cN?.Attributes
                                   .Contains("href") ?? false)?.Attributes["href"]?.Value ??
                               child?.LastChild?.FirstChild?.FirstChild?.Attributes["href"]?.Value;

                    if (link != null)
                        yield return link;
                }
            }
        }

        private IEnumerable<HtmlDocument> GetNewsPages(string path)
        {
            for (var i = 0; i < 12; i++)
            for (var j = 0; j < 31; j++)
                yield return client
                    .Load(new Uri($"{path}{DateTime.Today.Year}/{1:D2}/{1:D2}"));
        }
    }
}