using System;
using System.Collections.Generic;
using System.Text;

namespace _02._Articles
{
    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }

        public Article(string title, string content, string author)
        {
            this.Title = title;
            this.Content = content;
            this.Author = author;
        }

        public void Edit(string content)
        {
            this.Content = content;
        }

        public void ChangeAuthor(string author)
        {
            this.Author = author;
        }

        public void Rename(string title)
        {
            this.Title = title;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
