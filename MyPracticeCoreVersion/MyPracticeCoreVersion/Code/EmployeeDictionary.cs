using System;
using System.Reflection.Metadata;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Cryptography.X509Certificates;


namespace MyPractice.Code
{
    [Serializable]
    public class EmployeeException : Exception
    {
        public EmployeeException(string msg) : base(msg)
        {
        }
    }

    [Serializable]
    public struct EmployeeId : IEquatable<EmployeeId>
    {
        private readonly char prefix;
        private readonly int number;

        public EmployeeId(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentNullException();
            }
            prefix = (id.ToUpper()[0]);
            int numLenth = id.Length - 1;
            try
            {
                number = int.Parse(id.Substring(1, numLenth > 6 ? 6 : numLenth));
            }
            catch (FormatException e)
            {
                Console.WriteLine(e);
                throw new EmployeeException("格式错了!!!");
            }
        }

        public override string ToString()
        {
            return prefix.ToString() + string.Format("{0,6:000000}", number);
        }

        public override int GetHashCode()
        {
            return (number ^ number << 16) * 0x15051505;
        }

        public bool Equals(EmployeeId other)
        {
            if (other == null)
            {
                return false;
            }
            return (this.prefix == other.prefix && this.number == other.number);
        }

        public static bool operator ==(EmployeeId left, EmployeeId right)
        {
            return left.Equals(right);
        }


        public static bool operator !=(EmployeeId left, EmployeeId right)
        {
            return !(left == right);
        }
    }

    [Serializable]
    public class Employee
    {
        private string name;
        private decimal salary;
        private readonly EmployeeId id;

        public Employee(EmployeeId id, string name, decimal salary)
        {
            this.id = id;
            this.salary = salary;
            this.name = name;
        }

        public override string ToString()
        {
            return string.Format("{0}:{1,20}    {2：C}", id.ToString(), name, salary);
        }
    }
}