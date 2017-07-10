using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using MyPractice.Code;
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
            var fileNames = new BlockingCollection<string>();
           var lines  = new BlockingCollection<string>(); 
             var words = new ConcurrentDictionary<string,int>();
            var items = new BlockingCollection<Info>();
            var colorItems = new BlockingCollection<Info>();
            Task t1 = PipelineStages.ReadFilenamesAsync(@"../../..",fileNames);
            ConsoleHelper.WriteLine("started stage 1 ");
            Task t2 = PipelineStages.LoadContentAsync(fileNames,lines);




            #endregion

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
