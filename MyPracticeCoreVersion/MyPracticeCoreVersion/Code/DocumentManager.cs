using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPractice.Code
{
    class DocumentManager
    {  
        
         //定义 Document队列  有先进先出 后进后出 每次拿出减少一个的特性
         private  readonly  Queue<Document> documentQueue  = new Queue<Document>();

        /// <summary>
        ///将文档加入队列
        /// </summary>
        /// <param name="doc"></param>
        public void AddDocument(Document doc)
        {
            lock (this)
            { 
                documentQueue.Enqueue(doc); 
            }
        }

        /// <summary>
        /// 获取文档 每次获取减少队列中的一个元素
        /// </summary>
        /// <returns></returns>
        public Document GetDocument()
        {
            Document doc = null;
            lock (this)
            {
                doc = documentQueue.Dequeue();
            }
            return doc;
        }

        /// <summary>
        /// 判断队列中是否有待处理的文档（是否可用）
        /// </summary>
        public bool IsDocumentAvailable
        {
            get { return documentQueue.Count > 0; }
        }
    } 
}
