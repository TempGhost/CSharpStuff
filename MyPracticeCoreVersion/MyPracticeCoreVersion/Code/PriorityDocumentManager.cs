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
            priorityNodes = new List<LinkedListNode<Document>>(10);
             for (int i = 0; i < 10; i++)
             {
                //循环0-9  为链表集合添加10个空的链表元素    
                 
                priorityNodes.Add(new LinkedListNode<Document>(null));
             }
        }

        public int  Length {
            get { return documentList.Count; }
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

         
         /**********************************前方高能开始**************************************************/
        private void AddDocumentToPriorityNode(Document doc, int priority)
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
                 if (priority >= 0)//若降完仍然大于等于0 说明还可再降 加入到下轮
                 {
                     AddDocumentToPriorityNode(doc, priority);
                 }
                 else
                 {//若降完不在a （实际情况应该是等于-1）说明已经降无可降 当前优先级依然没有待处理文档 说明当前队列为空，加入到链表文档集合的最后一位
                     documentList.AddLast(doc);
                     priorityNodes[doc.Priority] = documentList.Last; //设置优先级链表的指针
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
                     priorityNodes[doc.Priority] = priorityNode.Next; //一当前文档优先级为索引访问该元素，更新优先级链表指针
                    //怀疑在链表的世界中 a = b.next   a将自动将p指针指向b  那么同时b的指针n也指向a 那么 a  = b.next
                    //可能等 b.next = a;
                 }
                 else//当文档优先级与当前递减的优先级不等  说明文档的优先级已经降到合适位置 应放在当前文档所有优先级的第一位
                 {
                    //初始化链表元素
                     LinkedListNode<Document> firstPriorityNode= priorityNode;
                    //当当前文档优先级的链表元素p指针有上一个元素 
                     while (firstPriorityNode.Previous!=null&& firstPriorityNode.Previous.Value.Priority==priorityNode.Value.Priority)
                     {
                        //这里妈妈的好复杂
                        //2017-07-06 这里其实很简单逆向遍历链表节点 
                        //当当前节点p属性不为空时（表示前面仍然有当处理的任务），切当前节点的上一个节点的优先级与当前文档任务优先级相等
                       //指针移动到上指针指向的上一个元素
                       //
                         firstPriorityNode = priorityNode.Previous;
                         priorityNode = firstPriorityNode;
                     }
                    //当循环退出，priorityNode与firstPriorityNode 应该指向文档所属优先级的第一个链表元素
                    documentList.AddBefore(firstPriorityNode, doc);//在这个链表元素的前面插入文档任务
                     priorityNodes[doc.Priority] = firstPriorityNode.Previous; //以当前文档优先级未索引，获取链表元素，并将其设置为当前优先级的链表的最后一个元素的上一个元素
                 }
             }
         }
        /**********************************前方高能结束**************************************************/
        //总结
        //其实documentList时所有待处理文档任务的集合，里面保护所有待处理问题，
        //为了对这个链表集合实现按优先级排序插入，需要记录每个优先级节点的最后一个元素的位置
        //而这个元素的位置使用链表元素集合 list<linkednode<T>> priorityNodes 来记录；
        //当有待处理文档进来时，先判断优先级链表中对应优先级的链表元素指针是否存在，如不存在
        //代表该优先级无待处理任务那么可以对文档做降优先级处理，因为在 没有1、2、3、4、5、6、7 优先级的文档任务时
        //传入的文档优先级时1、2、3、4、5、6 都是没有意义的

        public void DisplayAllNodes()
        {
            foreach (Document itemDocument in documentList)
            {
                Console.WriteLine("priority:{0} ,tilte :{1},content:{2}",itemDocument.Priority,itemDocument.Title,itemDocument.Content);
            }
        }

        public Document GetDocument()
        {
            Document currDocuemnt = documentList.First.Value;
            documentList.RemoveFirst();;
            return currDocuemnt;

        }

    }
}