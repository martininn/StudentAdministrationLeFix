using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentAdministration
{
    internal class Student
    {
        private string _name;
        private int _age;
        private string _program;
        public int Id { get; private set; }

        private List<int> _studentSubjects {  get; set; }
        private List<int> _studentGrades { get; set; }

        public Student(string name, int age, string program, int id, List<int> studentSubjects, List<int> studentGrades)
        {
            _name = name;
            _age = age;
            _program = program;
            _studentSubjects = studentSubjects;
            _studentGrades = studentGrades;
            Id = id;
        }

        private void AddSubject(Subject subjectCode)
        {
            _studentSubjects.Add(subjectCode.Code);
        }

        private void RemoveSubject(int subjectCode)
        {
            _studentSubjects.Remove(subjectCode);
        }


        public void GetSubjects(List<Subject> allSubjects, AdminSystem adminSystem, Student student)
        {
            foreach(int id in _studentSubjects)
            {
                foreach (var subject in allSubjects)
                {
                    if(subject.Code == id) subject.PrintSubjectInfo();

                }
            }

            Console.WriteLine("Do you want to see this students grades in any subjects?");
            adminSystem.HandleInput2(adminSystem, student);  
        }

        public string GetName() // dette er måten man gjør det på om name er private. 
        {
            return _name;
        }

        public void PrintInfo(AdminSystem adminSystem, Student student)
        {
            Console.WriteLine();
            Console.WriteLine($"Student:\n" +
                              $"Name: {_name} \n" +
                              $"Age: {_age} \n" +
                              $"Program: {_program} \n" +
                              $"Id: {Id} \n" +
                              $"\n");
            Console.WriteLine($"Do you want to see {GetName()}s subjects?");
            adminSystem.HandleInput1(adminSystem, student);
        }

        public void SubjectSelect(List<Subject> allSubjects, AdminSystem adminSystem, Student student)
        {
            Console.WriteLine("Please select a subject you want to view:");
            for (int i = 0; i < _studentSubjects.Count; i++)
            {
                string sub =
                    allSubjects.Where(subject => subject.Code == _studentSubjects[i]).FirstOrDefault().Name;
                Console.WriteLine($"{i + 1}. {sub}");
            }
            adminSystem.HandleInput3(adminSystem, student);
        }

    }
}


