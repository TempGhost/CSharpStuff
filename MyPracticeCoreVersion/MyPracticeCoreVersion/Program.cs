using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DataLib;
using MyPractice.Code;
using MyPracticeCoreVersion.Code;
using MyPracticeCoreVersion.Code.pipeline;


namespace MyPractice
{ 
    class Program
    {

        class  MathOperations
        {
            public static double MultiplyByTwo(double value)
            {

                return value * 2;
            }
            public static double Square(double value)
            {
                return value * value;
            }
        }
        private delegate string GetAString();

        delegate double DoubleOp(double value);

        static void Main(string[] args)
        {
            #region lamda表达式练习代码
            /**********************************************lamda test *****************************************/
            //Func<double, double>[] DoubleOpWhitT = {MathOperations.MultiplyByTwo, MathOperations.Square};
            //DoubleOp[] operations = {MathOperations.MultiplyByTwo, MathOperations.Square};
            //string c = "fuck";
            //int Fuckint = 0;
            //int Fuck2 = 0;
            //Func<int, int, int> fuck = (p1, p2) => { return p1 + p2; }
            //    ;
            //for (int i = 0; i < DoubleOpWhitT.Length; i++)
            //{
            //    Console.WriteLine("Using opeartions[{0}]", i);
            //    ProcessAndDisplayNuimber(Do1ubleOpWhitT[i], 5.0);
            //}
            //Console.ReadLine(); 
            //int a = 1;
            /**********************************************lamda test *****************************************/
            #endregion
            #region 链表练习代码
            /**********************************************linkedtable test *****************************************/
            //RacerTestProgram.TestProgram();
            //Console.WriteLine("Done!");
            //Console.ReadLine();
            //PriorityDocumentManager  pdm = new PriorityDocumentManager();
            //pdm.AddDocument(new Document("im 7p doc", "7p", 7));
            //pdm.AddDocument(new Document("im 1p doc", "1p", 1));
            //pdm.AddDocument( new Document("im 7p doc" ,"7p2",7));
            //pdm.AddDocument(new Document("im 7p doc", "7p1", 7));
            //pdm.AddDocument(new Document("im 9p doc", "9p", 9));
            //pdm.AddDocument(new Document("im 1p doc", "1p", 1));
            //pdm.AddDocument(new Document("im 7p doc", "7p", 7));
            //pdm.AddDocument(new Document("im 8p doc", "8p", 8));
            //pdm.DisplayAllNodes();
            //Console.ReadLine();
            //int length = pdm.Length;
            //for (int i = 0; i < length; i++)
            //{
            //    Document itemDocument = pdm.GetDocument();
            //    Console.WriteLine("priority:{0} ,tilte :{1},content:{2}", itemDocument.Priority, itemDocument.Title, itemDocument.Content);
            //}
            //Console.ReadLine();
            /**********************************************linkedtable test *****************************************/
            #endregion
            #region 字典类练习代码1 
            /**********************************************Dictionary test *****************************************/

            // var employees = new Dictionary<EmployeeId, Employee>(31);
            //var idtony   = new EmployeeId("E1234");
            // var tony = new Employee(idtony,"tony",100);


            // var idjson = new EmployeeId("E1235");
            // var json = new Employee(idjson , "json", 100);
            // employees.Add(idtony,tony);
            // employees.Add(idjson,json);
            // while ( true)
            // {
            //     string input = Console.ReadLine();
            //     if (input != "X")
            //     {
            //         Employee curEmployee = null;
            //         if (employees.TryGetValue(new EmployeeId(input), out curEmployee))
            //         {
            //             Console.WriteLine(curEmployee.ToString());
            //         }
            //         else
            //         {
            //             Console.WriteLine("obj not found!");
            //         }
            //     }
            //     else
            //     { 
            //         break;
            //     } 
            // }
            #endregion

            #region  字典类练习代码

            /**************************************************************************************************/
            // Racer chinarRacer = new Racer(1, "china", "中国", "选手");
            // Racer UsaRacer = new Racer(2, "USA", "美国", "选手");
            // Racer chinar2Racer = new Racer(3, "china", "中国", "选手2");


            // List<Racer>  racers= new List<Racer> { 
            //      chinar2Racer,chinarRacer,UsaRacer
            //};
            //  var lookuparr  = racers.ToLookup(r => r.Country);
            // foreach (Racer itemRacer in lookuparr["选手"])
            // { 
            //     Console.WriteLine(itemRacer.FirstName);
            // }
            // Console.ReadLine();
            /**************************************************************************************************/
            #endregion

            #region 并发集合与管道练习代码
            ///*管道模型练习代码
            // 代码实现功能：遍历制定目录文件夹 下所 指定文件
            // 统计所有单词出现次数
            // 用颜色标注 采用并发集合及并发编程中的管道模型*/
            //var fileNames = new BlockingCollection<string>(); //新建线程安全集合  存放 所用待分析的文件路径猜测使用悲观锁实现（悲观锁
            ////使用前总是认为会有其他线程来访问所有在访问前加锁）
            //var lines  = new BlockingCollection<string>(); //线程安全集合2 存放所有待分析文本
            // var words = new ConcurrentDictionary<string,int>(); //线程安全字典，存放分析集合2所得到的单词
            //var items = new BlockingCollection<Info>();//线程安全集合3 存放统计单词所得到的信息（总数、值、用何种颜色标识）
            //var colorItems = new BlockingCollection<Info>();//有点迷 * _ *
            //Task t1 = PipelineStages.ReadFilenamesAsync(@"C:\Git\CSharpStuff\CollectionsSamples", fileNames);
            ////创建线程t1 任务为读取指定目录及所有子目录的文件
            //ConsoleHelper.WriteLine("started stage 1 ");
            //Task t2 = PipelineStages.LoadContentAsync(fileNames,lines);
            ////创建线程2 任务为读取任务1的结果并将文件内容读取到集合2 
            //ConsoleHelper.WriteLine("stated stage 2");
            //Task t3 = PipelineStages.ProcessContentAsync(lines, words);
            ////创建线程3 任务为分析线程2的结果统计所有单词出现次数
            //ConsoleHelper.WriteLine("stated stage 3");
            // Task.WhenAll(t1, t2, t3).Wait();

            //#region 并发集合分析与总结

            ////主线程挂起等待同步
            ////疑问？ 为何同为何T1，T2，T3 同步执行 却能保证运行顺序？
            ////若T2 已经遍历完集合内所有元素，T1 遇到了一个文件需要10秒来完成 10秒以后T2 如何得知T1 又添加了一个新元素
            ////还是如果出现这种情况 T1 的部分文档会得不到处理？
            ////验证  在T1 中加入 Thread.Sleep  模式该情况 ，结果是好像T2 在轮询从T1的集合1一样，无论隔了多久
            ////只要T1 有新文档加入 T2 马上就在处理
            ////至此并发集合原理基本清晰 
            ////原来在使用并发集合Add 方法之后 并发集合的状态会处理正在加入元素的状态， 之后的代码访问该集合
            ////若该集合仍在正在加入元素的状态，则其实根本不能访问该集合的最后一个元素；并不会抛出异常，因为该集合的最后一个元素
            ////可能其实指向一个线程阻塞的函数，所有需要访问最后一个元素的代码都会在这里被挂起，等待。那么是什么才释放呢
            ////在调用该函数 CompleteAdding();的时候，在使用该方法之后 该集合处于完成添加元素的状态，所有访问该集合最后一个元素的
            ////请求被放行/释放，这就是为什么只要T1一有新元素加入T2 就可以马上处理的奥秘，其实T2 一直无法访问最后一个元素N 
            ////当T1 增加元素N+1 时 那么最后一个元素的指针指向N+1 此时N可以访问，在处理完N之后又会在N+1 处挂起 知道集合调用
            ////CompleteAdding()方法
            ////猜测  虽然T2 依赖与T1 的结果 但却不需要在T1 完全执行完才能运行，

            //#endregion
            //ConsoleHelper.WriteLine("1,2,3 completed");
            //ConsoleHelper.WriteLine("stated stage 4");
            //Task t4 = PipelineStages.TransferContentAsync(words, items);
            //ConsoleHelper.WriteLine("stated stage 4");
            //Task t5 = PipelineStages.AddColorAsync(items, colorItems);
            //ConsoleHelper.WriteLine("stated stage 5");
            //Task t6 = PipelineStages.ShowContentAsyncCollection(colorItems);
            //Task.WaitAll(t4, t5, t6);
            //ConsoleHelper.WriteLine("4,5,6 completed");
            #endregion


            #region linq表达式练习代码
            //foreach (DataLib.Racer racer in DataLib.Formula1
            //    .GetChampions().Where(c => c.Country == "Brazil")
            //    .OrderByDescending(r => r.Wins))
            //{
            //     Console.WriteLine(string.Format("{0},{1}",racer.FirstName,racer.Country));
            //}

            //foreach (DataLib.Racer item in from s in DataLib.Formula1.GetChampions()
            //    where s.Country == "Brazil" && s.Wins > 1
            //    select s)
            //{
            //    Console.WriteLine(string.Format("{0},{1}", item.FirstName, item.Country));
            //}

            //var races = DataLib.Formula1.GetChampions().Where(
            //    (r, index) =>
            //    { 
            //        Console.WriteLine(index);
            //        return r.Country == "Brazil";
            //    });
            //foreach (var item in races)
            //{
            //    Console.WriteLine(item);
            //}

            //foreach (var itemRacer in from s in DataLib.Formula1.GetChampions() 
            //    from c in s.Cars where c == "Frrari"
            //    select s)
            //{
            //}
            var races2 = from r in Formula1.GetChampions() //linq 表达式 查询返回新的匿名对象集合
                from y in r.Years //from 子句 当对象的属性本身又是集合 使用from子句可降维
                select new //如二维对象  racer: {name: jack ,championyear :[2017,2016,2015]}
                {
                    //可降为  name:jack ,championyear:2017 
                    Year = y, // name:jack,championyear:2016
                    Name = r.FirstName //name:jack,championyear:2015 三条记录
                };
            var teams = from t in Formula1.GetContructorChampions() //作用同上
                from y in t.Years
                select new
                {
                    Year = y,
                    Name = t.Name,
                };
             //linq   join 查询
             //和将两个集合通过某种个字段/属性连接起来
             //返回一个新的匿名对象集合
            var racersAndTeams = (from r in races2  
                join t in teams on r.Year equals t.Year
                select new {r.Year, Champion = r.Name, Constructor = t.Name}).OrderBy(
                x => x.Year).Take(10);
            Console.WriteLine("Year Wrold Champion\t Constructor Title");
            foreach (var item in racersAndTeams)
            {
                Console.WriteLine("{0} :{1,-20} ,{2}", item.Year, item.Champion, item.Constructor);
            }
             
            Console.WriteLine("--------------------------------------------------------------------------------------");

            //合并join 语句版本
            var racersAndTeamsNew = (
                from r in from r1 in Formula1.GetChampions() //这里开始
                from yr in //这里是为了将对象降维
                r1.Years
                select new
                {
                    Year = yr,
                    Name = r1.FirstName
                }  //这里结束 是集合一
                join t in from t1 in Formula1.GetContructorChampions() // 这里开始
                from yr in t1.Years //同样 降维
                select new
                {
                    Year = yr,
                    Name = t1.Name
                }//这里结束 是集合2
                on r.Year equals t.Year //连接凭据 func <t1,t2,bool>
                select new {Year = r.Year, Racer = r.Name, Team = t.Name}).Take(10);

            foreach (var item in racersAndTeamsNew)
            {
                Console.WriteLine("{0} :{1,-20} ,{2}", item.Year, item.Racer, item.Team);
            }

            #endregion

            Console.ReadLine();
        }




        class BubbleSorter {
            public static void Sort<T>(IList<T> SortArray, Func<T, T, bool> comparison)
            {
                bool swapped = true;
                do
                { 
                    swapped = false; 
                    
                    ;
                    for (int i = 0; i < SortArray.Count - 1; i++) //定义第1层循环 每次循环Count -1 次
                    {
                        if (comparison(SortArray[i + 1], SortArray[i])) //比较 i+1 项 与 i 项的大小  若 i+1 比 i大 将i+1 与 i 互换
                        {
                            T temp = SortArray[i];
                            SortArray[i] = SortArray[i + 1];
                            SortArray[i + 1] = temp;
                            swapped = true; //发生交换， 更新状态。 
                        }
                    }
                } while (swapped);
            }
        }

        //class Employee
        //{
        //    public string Name { get; set; }

        //    public decimal Salary
        //    {
        //        get; set;
                
        //    }

        //    public Employee(string name, decimal salary)
        //    {
        //        this.Name = name;
        //        this.Salary = salary;
        //    }

        //    public override string ToString()
        //    {
        //        return string.Format("{0},{1:C}", Name, Salary);

        //    }

        //    public static bool CompareSalary(Employee e1, Employee e2)
        //    {
        //        return e1.Salary < e2.Salary;
        //    }
             

        //}
        //static void ProcessAndDisplayNuimber(Func< double, double> action,double value)
        //{
        //    double result = action(value);
        //    Console.WriteLine("Value is {0},result is {1}",value,result);
        //}
       
        //static void ProcessAndDisplayNumber(DoubleOp action, double value)
        //{
        //    double result = action(value);
        //    Console.WriteLine("Value is {0}, result of operationrs is {1}",value,result);

        //}


    
        struct Currency
        {

            public uint Dollares;
            public ushort Cents;

            public Currency(uint dollares, ushort cents)
            {
                this.Dollares = dollares;
                this.Cents = cents;
            }

            public override string ToString()
            {
                return String.Format("${0}.{1,2:00}",Dollares,Cents);
                //return .ToString();
            }

            public static string GetCurrencyUint()
            {
                int x, y, z;
                return "Dollar";
            }

            public static explicit operator Currency(float value )
            {
                checked
                {
                    uint dollares = (uint) value;
                    ushort cents = (ushort) ((value - dollares) * 100);
                    return  new Currency(dollares,cents);
                }
            }

            public static implicit operator float(Currency value)
            {
                return value.Dollares + (value.Cents / 100.0f);
            }
            public  static implicit  operator  Currency(uint value)
            {
                 return  new Currency(value,0);
                
            }

            public static implicit operator uint(Currency value)
            {
                return value.Dollares;
            }
        }
    }
}
