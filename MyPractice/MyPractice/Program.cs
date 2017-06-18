using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


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


              Func<double, double>[] DoubleOpWhitT = {MathOperations.MultiplyByTwo, MathOperations.Square};

                     DoubleOp[] operations = {MathOperations.MultiplyByTwo , MathOperations.Square};
              string c = "fuck";
              int Fuckint = 0 ;
              int Fuck2= 0;


            Func<int,int,int> fuck = (p1, p2) =>
              {
                  return p1 + p2;}
              ;
              for (int i = 0; i < DoubleOpWhitT.Length; i++)
              { 
                 Console.WriteLine("Using opeartions[{0}]",i);
                ProcessAndDisplayNuimber(DoubleOpWhitT[i],5.0);
            
              }
              Console.ReadLine();
              //int x = 40;
              //GetAString FuckDelegate =  new GetAString(x.ToString);
              //GetAString firstStringMethod = x.ToString;
              //Console.WriteLine("String is {0}",FuckDelegate());
              //Currency Balance = new Currency(34,50);
              // FuckDelegate = Balance.ToString;
              //Console.WriteLine("String is {0}", FuckDelegate());
              //FuckDelegate = new GetAString(Currency.GetCurrencyUint);
              //Console.WriteLine("String is {0}",FuckDelegate());
              //Console.ReadLine();


          }


        class BubbleSorter {
            public static void Sort<T>(IList<T> SortArray, Func<T, T, bool> comparison)
            {
                bool swapped = true;
                do
                {
                    swapped = false;
                    ;
                    for (int i = 0; i < SortArray.Count-1; i++) //定义第1层循环 每次循环Count -1 次
                    {
                        if (comparison(SortArray[i+1],SortArray[i])) //比较 i+1 项 与 i 项的大小  若 i+1 比 i大 将i+1 与 i 互换
                        {
                            T temp = SortArray[i];
                            SortArray[i] = SortArray[i + 1];
                            SortArray[i + 1] = temp;
                            swapped = true; //发生互换的表示
                        }
                        
                    }
                } while (swapped);
            }
        }

        class Employee
        {
            public string Name { get; set; }

            public decimal Salary
            {
                get; set;
                
            }

            public Employee(string name, decimal salary)
            {
                this.Name = name;
                this.Salary = salary;
            }

            public override string ToString()
            {
                return string.Format("{0},{1:C}", Name, Salary);

            }

            public static bool CompareSalary(Employee e1, Employee e2)
            {
                return e1.Salary < e2.Salary;}
             

        }
        static void ProcessAndDisplayNuimber(Func< double, double> action,double value)
        {
            double result = action(value);
            Console.WriteLine("Value is {0},result is {1}",value,result);
        }

        static void ProcessAndDisplayNumber(DoubleOp action, double value)
        {
            double result = action(value);
            Console.WriteLine("Value is {0}, result of operationrs is {1}",value,result);

        }


    
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
