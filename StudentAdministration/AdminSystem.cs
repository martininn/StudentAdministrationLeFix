using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace StudentAdministration
{
    internal class AdminSystem
    {
        private List<Student> StudentsList { get; set; }
        public List<Grade> Grades { get; set; }
        public List<Subject> AllSubjects { get; set; }
        

        public AdminSystem()
        {
             StudentsList = new List<Student>() 
            {
                new("Camilla", 23, "Start IT",  1, [0, 1], [0, 1]),
                new("Bjarne", 44, "Start IT", 2, [0, 1, 2], [4, 2, 3])
            };

            AllSubjects = new List<Subject>()
            {
                new(0, "JavaScript",5),
                new(1, "C#",8),
                new(2, "NK", 3)
            };

            Grades = new List<Grade>()
            {
                new(StudentsList[0].Id,AllSubjects[0], 4),
                new(StudentsList[0].Id,AllSubjects[1], 3),
                new(StudentsList[0].Id,AllSubjects[2], 5),
                new(StudentsList[1].Id,AllSubjects[0], 6),
                new(StudentsList[1].Id,AllSubjects[1], 6),

            };
        }
        
        public void ShowStudents()
        {
            for (var i = 0; i < StudentsList.Count; i++)
            {
                Console.WriteLine($" {i +1}. {StudentsList[i].GetName()}");
            }
        }

        Student SelectStudent()
        {
            int input = Convert.ToInt32(Console.ReadLine());
            if (input < 0 || input > StudentsList.Count)
            {
                Console.WriteLine("Student does not exist. By default the first student will show.");
                input = 0;
            }
            return StudentsList[input -1];
        }


        public void MainMenu(AdminSystem adminSystem)
        {
            Console.Clear();
            Console.WriteLine("Welcome to student administration. Please pick a student:");
            ShowStudents();

            Student selectedStudent = SelectStudent();
            selectedStudent.PrintInfo(adminSystem, selectedStudent);  
        }

        public void HandleInput1(AdminSystem adminSystem, Student student)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Yes. \n2. No, I want to see another student. \n3. No, I want to exit.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Currently taking subjects:");
                        student.GetSubjects(AllSubjects, adminSystem, student);
                        running = false;
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        MainMenu(adminSystem);
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("You have to pick an option. Please try again.");
                        break;
                }
            }
        }

        public void HandleInput2(AdminSystem adminSystem, Student student)
        {
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Yes. \n2. No, I want to see another student. \n3. No, I want to exit.");
                int input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Directing you to the subject select menu");
                        student.SubjectSelect(AllSubjects, adminSystem, student);
                        running = false;
                        break;
                    case 2:
                        Console.WriteLine("Okay, showing the main menu again:");
                        MainMenu(adminSystem);
                        running = false;
                        break;
                    case 3:
                        Console.WriteLine("Goodbye!");
                        Environment.Exit(2);
                        break;
                    default:
                        Console.WriteLine("You have to pick an option. Please try again.");
                        break;
                }
            }
        }
        public void HandleInput3(AdminSystem adminSystem, Student student)
        {
            int input = Convert.ToInt32(Console.ReadLine());

            string subjectName = AllSubjects.Where(s => s.Code == input - 1).FirstOrDefault().Name;

            List<Grade> studentGrades = Grades.Where(g => g.StudentId == student.Id).ToList();

            Console.WriteLine($"Showing {student.GetName()}'s grade in {subjectName}:"); 
            Console.WriteLine($"{studentGrades[input - 1].GetGradeValue()}");

            HandleInput4(adminSystem, student);

        }
        public void HandleInput4(AdminSystem adminSystem, Student student)
        {
            Console.WriteLine("What do you want to do now?");
            bool running = true;

            while (running)
            {
                Console.WriteLine("1. Go back to subjects menu. \n2. Change student. \n3. Exit");
                int input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        student.SubjectSelect(AllSubjects, adminSystem, student); 
                        running = false;
                        break;
                    case 2:
                        MainMenu(adminSystem);
                        running = false;
                        break;
                    case 3:
                        Environment.Exit(3);
                        break;
                    default:
                        Console.WriteLine("You have to pick a valid option.");
                        break;
                }
            }
        }
    }

    
}
