using System;
using System.Linq;

namespace _02._Articles
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arguments = Console.ReadLine().Split(", ").ToArray();
            Article article = new Article(arguments[0], arguments[1], arguments[2]);

            Proccessing(article);

            Console.WriteLine(article);
        }

        static void Proccessing(Article article)
        {
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                string[] currentArgs = Console.ReadLine().Split(": ").ToArray();

                switch (currentArgs[0])
                {
                    case "Edit":
                        article.Edit(currentArgs[1]);
                        break;
                    case "ChangeAuthor":
                        article.ChangeAuthor(currentArgs[1]);
                        break;
                    case "Rename":
                        article.Rename(currentArgs[1]);
                        break;
                }
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

    //    public void Edit(string content)
    //    {
    //        this.Content = content;
    //    }

    //    public void ChangeAuthor(string author)
    //    {
    //        this.Author = author;
    //    }

    //    public void Rename(string title)
    //    {
    //        this.Title = title;
    //    }

    //    public override string ToString()
    //    {
    //        return $"{Title} - {Content}: {Author}";
    //    }
    //}

}
