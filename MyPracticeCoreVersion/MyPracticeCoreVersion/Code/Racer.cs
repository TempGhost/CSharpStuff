using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyPractice.Code
{


    public class FindCountry
    {

        private string Country;
        public FindCountry(string Country)
        {
            this.Country = Country;
        }

        public bool FindCountryPredicate(Racer CurrRacer)
        {
            if (CurrRacer==null)
            {
               throw  new ArgumentNullException("未将对象引用到实例。");
            }
            return CurrRacer.Country == this.Country;
        }
    }  

    class RacerTestProgram
    {
        public static void TestProgram()
        {
            List<Racer> RacerlList = new List<Racer>
            {
                new Racer(1, "I m so", "Dick", "China"),
                new Racer(2, "I m so", "Suck", "Zimbabwe")
            };  


            RacerlList.ForEach(CurrenRacer => {
                Console.WriteLine(CurrenRacer.ToString());
            });

            List<Racer> FindCountryResult = RacerlList.FindAll(new FindCountry("Zimbabwe").FindCountryPredicate);
            FindCountryResult.ForEach(r => Console.WriteLine(r.ToString())); 

          FindCountryResult = RacerlList.FindAll( new Predicate<Racer>(new FindCountry("Zimbabwe").FindCountryPredicate));
           FindCountryResult.ForEach(r => Console.WriteLine(r.ToString())); 

            Console.ReadLine();
        } 
    }
   public  class Racer :IComparable<Racer>,IFormattable
    {
        public Racer(int id, string firstName, string lastName, string country)  //重载 构造函数
            :this(id,firstName,lastName, country, 0)
        {
        }

        public Racer(int id, string firstName, string lastName, string country, int wins) //定义构造 函数  
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Country = country;
            Wins = wins;
        }

        public int Id { set; get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Country { get; set; }

        public int Wins { get; set; }

        public override string ToString()
        {
            return string.Format("{0} {1}", FirstName, LastName);
        }

        public string ToString(string format,IFormatProvider formatProvider)
        {
            if (format==null)
            {
                format = "N";
            }
            switch (format)
            {
                case "N":
                    return ToString();
                case "F":
                    return FirstName;
                case "L":
                    return LastName;
                case "W":
                    return string.Format("{0} wins:{1}", ToString(), Wins);
                case "C":
                    return  string.Format("{0} Country:{1} ", ToString(), Country);
                case "A":
                    return     string.Format("{0} Country:{1} wins:{2}", ToString(), Country, Wins);
                default:
                    throw  new FormatException(string.Format(formatProvider,"Format {0} is not spported",format));
            }
        }

        public string ToString(string format)
        {
            return ToString(format, null);
        }

        public int CompareTo(Racer Other)
        {
            if (Other == null)
            {
                return -1;
            }
            int compare = string.Compare(this.LastName,Other.LastName);
            if (compare==0)
            {
                compare  =  string.Compare(this.FirstName, Other.FirstName);
            }
            return compare;
        }
    }



}
