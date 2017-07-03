using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyPractice.Code
{
    public class PriorityDocumentManager
    {
        private readonly LinkedList<Document> documentList;
        private readonly List<LinkedListNode<Document>> priorityNodes;

        public PriorityDocumentManager()
         {
            documentList = new LinkedList<Document>();
             for (int i = 0; i < 10; i++)
             {
                  
                priorityNodes.Add(new LinkedListNode<Document>(null));
             }
        }

        public void AddDocument(Document d)
        {
            if (d==null)
            {
                throw new ArgumentNullException("error");
            } 
            AddDocumentToPriorityNode(d,d.Priority);
       }

        public void AddDocumentToPriorityNode(Document doc, int priority)
         {

             if (priority>9||priority<0)
             {
                throw new ArgumentException("Priority must be between 0 and 9 ");
             }
             if (priorityNodes[priority].Value == null)
             {
                 --priority;
                 if (priority > 0)
                 {
                     AddDocumentToPriorityNode(doc, priority);
                 }
                 else
                 {
                     documentList.AddLast(doc);
                 }
                 return;
             }
             else
             {
                 LinkedListNode<Document> priorityNode = priorityNodes[priority];
                 if (priority == doc.Priority)
                 {
                     documentList.AddAfter(priorityNode,doc);
                     priorityNodes[doc.Priority] = priorityNode.Next;
                 }
                 else
                 {
                     LinkedListNode<Document> firstPreviusNode = priorityNode;
                     while (firstPreviusNode.Previous!=null&&firstPreviusNode.Previous.Value.Priority==priorityNode.Value.Priority)
                     {
                         firstPreviusNode = priorityNode.Previous;
                         priorityNode = firstPreviusNode;
                     }
                     documentList.AddAfter(firstPreviusNode,doc);
                     priorityNodes[doc.Priority] = firstPreviusNode.Previous;
                 }
             }
         } 
    }
}