using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication4
{
    public class VnexpressCrawler: Crawler
    {
        public Article CrawlDetail(string url)
        {
            var htmlWeb = new HtmlWeb();
            var htmlDocument = htmlWeb.Load(url);
            var titleNode = htmlDocument.DocumentNode.SelectSingleNode("//h3[contains(@class, 'title-detail')]/a");
            var title = titleNode.InnerText;
            var contentNode = htmlDocument.DocumentNode.SelectSingleNode("//h3[contains(@class, 'title-new')]/a");
            var content = contentNode.InnerHtml;
            var imageNode = htmlDocument.DocumentNode.SelectSingleNode("//picture/img");
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
            var listNodeA = htmlDocument.DocumentNode.SelectNodes("//h3/a");
            for (int i = 0; i < listNodeA.Count; i++)
            {
                var list = listNodeA.ElementAt(i).Attributes["href"].Value;
                listLink.Add(list);
            }

            return listLink;

        }
    }
}