using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class Subject
    {
        public int Code { get; private set; }
        public string Name { get; private set; }
        public int Credits { get; private set; }

        public Subject(int code, string name, int credits)
        {
            Code = code;
            Name = name;
            Credits = credits;
        }

        public void PrintSubjectInfo()
        {
            Console.WriteLine();
            Console.WriteLine($"Subject:\n" +
                                $"Name: {Name}\n" +
                                $"Code: {Code}\n" +
                                $"Credits: {Credits}");
            Console.WriteLine();
        }


    }
}
