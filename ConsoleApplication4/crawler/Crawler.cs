using System;
using System.Collections.Generic;
using System.Linq;
using HtmlAgilityPack;

namespace ConsoleApplication4
{
    public interface Crawler
    {
        Article CrawlDetail(string url);

        List<string> GetListLink(string urlToGetListLink);

    }
}