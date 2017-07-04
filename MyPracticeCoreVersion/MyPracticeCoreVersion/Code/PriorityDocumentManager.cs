using System;
using System.Collections.Generic;
using System.Reflection;

namespace MyPractice.Code
{
    public class PriorityDocumentManager
    { 
       //定义链表泛型（document类型）集合  链表
       //有可用索引器访问集合中的元素，元素有两个指针 per 指向自己的上一个元素
       //next 指向自己的下一个元素的特点。
        private readonly LinkedList<Document> documentList;

        //定义泛型集合 集合的元素的类型是链表元素 （节点？） 
        //定义一个链表元素的集合
        private readonly List<LinkedListNode<Document>> priorityNodes;

        /// <summary>
        /// 构造函数
        /// </summary>
        public PriorityDocumentManager()
         {
            //执行链表的构造函数
            documentList = new LinkedList<Document>();
             for (int i = 0; i < 10; i++)
             {
                //循环0-9  为链表集合添加10个空的链表元素    
                priorityNodes.Add(new LinkedListNode<Document>(null));
             }
        }

        public void AddDocument(Document d)
        {
            if (d==null)
            {
                throw new ArgumentNullException("error");
            } 
            //若传入文档不为空 执行将文档添加的链表中的函数
            AddDocumentToPriorityNode(d,d.Priority);
       }

        public void AddDocumentToPriorityNode(Document doc, int priority)
         {

            //判断优先级 文档的优先级不能大于9不能小于0
             if (priority>9||priority<0)
             {
                throw new ArgumentException("Priority must be between 0 and 9 ");
             }
             //使用索引器访问文档集合中当前传入文档的优先级是否有待处理文档
             if (priorityNodes[priority].Value == null)
             {
                //若无 降低当前文档优先级
                 --priority; 
                 if (priority > 0)//若降完仍然大于0 说明还可再降 加入到下轮
                 {
                     AddDocumentToPriorityNode(doc, priority);
                 }
                 else
                 {//若降完不在大于0 （实际情况应该是等于0）说明已经降无可降 当前优先级依然没有待处理文档 说明当前队列为空，加入到链表文档集合的最后一位
                     documentList.AddLast(doc);
                 }
                 return;  //返回
             }
             else //当前优先级节点有待处理任务的情况
             { 
                //先初始化一个链表节点  引用当前链表优先级的元素
                 LinkedListNode<Document> priorityNode = priorityNodes[priority];
                 if (priority == doc.Priority)//判断若当前递减的优先级与文档的优先级相等 说明改文档优先级并未经历过降级 应放在文档所在优先级的最后一位
                 {
                     documentList.AddAfter(priorityNode,doc); //在链表中的最后插入一个待处理任务
                     priorityNodes[doc.Priority] = priorityNode.Next; //一当前文档优先级为索引访问该元素，未知意义
                    //怀疑在链表的世界中 a = b.next   a将自动将p指针指向b  那么同时b的指针n也指向a 那么 a  = b.next
                    //可能等 b.next = a;
                 }
                 else//当文档优先级与当前递减的优先级不等  说明文档的优先级已经降到合适问题 应放在当前文档所有优先级的第一位
                 {
                    //初始化链表元素
                     LinkedListNode<Document> firstPriorityNode= priorityNode;
                    //当当前文档优先级的链表元素p指针有上一个元素 
                     while (firstPriorityNode.Previous!=null&& firstPriorityNode.Previous.Value.Priority==priorityNode.Value.Priority)
                     {
                        //这里妈妈的好复杂
                         firstPriorityNode = priorityNode.Previous;
                         priorityNode = firstPriorityNode;
                     }
                     documentList.AddAfter(firstPriorityNode, doc);
                     priorityNodes[doc.Priority] = firstPriorityNode.Previous;
                 }
             }
         } 
    }
}