using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication4
{
    public class DantriCrawler: Crawler
    {
        public Article CrawlDetail(string url)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h1[contains(@class, 'dt-news__title')]");
            var title = titleNode.InnerText;
            var contentNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'dt-news__content')]");
            var content = contentNode.InnerHtml;
            var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//div[contains(@class, 'dt-news__content')]/figure/img");
            var image = imageNode.Attributes["src"].Value;
            var article = new Article()
            {
                Title = title,
                Content = content,
                Image = image,
                Url = url
            };
            return article;
        }

        public List<string> GetListLink(string urlToGetListLink)
        {
            var listLink = new List<string>();
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(urlToGetListLink);
            var listNodeA = htmlDocument.DocumentNode.SelectNodes("//h2[contains(@class, 'news-item__title')]/a");
            for (int i = 0; i < listNodeA.Count; i++)
            {
                var list = listNodeA.ElementAt(i).Attributes["href"].Value;
                listLink.Add($"http://dantri.com.vn{list}");
            }

            return listLink;

        }
    }
}