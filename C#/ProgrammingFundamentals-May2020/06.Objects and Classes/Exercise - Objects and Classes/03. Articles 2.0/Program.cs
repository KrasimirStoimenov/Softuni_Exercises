using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Articles_2._0
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Article> articleList = new List<Article>();

            Proccessing(articleList);
            PrintOutput(articleList);
        }

        static void PrintOutput(List<Article> articleList)
        {
            string order = Console.ReadLine();

            if (order == "title")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articleList.OrderBy(t => t.Title)));
            }
            else if (order == "content")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articleList.OrderBy(c => c.Content)));
            }
            else if (order == "author")
            {
                Console.WriteLine(string.Join(Environment.NewLine, articleList.OrderBy(a => a.Author)));
            }
        }

        static void Proccessing(List<Article> articleList)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] arguments = Console.ReadLine().Split(", ").ToArray();

                Article article = new Article(arguments[0], arguments[1], arguments[2]);
                articleList.Add(article);
            }
        }
    }
    //class Article
    //{
    //    public string Title { get; set; }
    //    public string Content { get; set; }
    //    public string Author { get; set; }

    //    public Article(string title, string content, string author)
    //    {
    //        this.Title = title;
    //        this.Content = content;
    //        this.Author = author;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Title} - {Content}: {Author}";
    //    }
    //}

}
