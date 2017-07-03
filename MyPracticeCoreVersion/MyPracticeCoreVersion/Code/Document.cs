using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.Code
{
    class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

    }
}
