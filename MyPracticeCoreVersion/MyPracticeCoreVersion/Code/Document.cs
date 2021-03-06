﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.Code
{
    public class Document
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public byte Priority { get; set; }

        public Document(string title, string content)
        {
            this.Title = title;
            this.Content = content;
        }

        public Document()
        {
        }

        /// <summary>
        /// 拓展构造函数可定义优先级    
        /// </summary>
        /// <param name="title">标题</param>
        /// <param name="content">正文</param>
        /// <param name="priority">优先级</param>
        public Document(string title, string content,byte priority) :this(title, content)
        {
            this.Priority = priority;
        }
    }
}
