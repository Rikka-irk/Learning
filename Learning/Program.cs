using System;

namespace ConsoleApp1
{

    struct Student
    {
        public string name;
        public string surname;
        public int group;
    }

    class Students
    {
        public Student[] students;
        public int size;

        public Students(int maxSize)
        {
            this.size = 0;
            this.students = new Student[maxSize];
        }

        public void add(Student student)
        {
            if (size < students.Length)
            {
                students[size] = student;
                size = size + 1;
            }
        }

        public void findByGroupId(int groupId)
        {
            for (int i = 0; i < this.size; ++i)
            {
                if (groupId == this.students[i].group)
                {
                    Console.WriteLine(this.students[i].name);
                }
            }
        }

    }


    class Program
    {

        static void Main(string[] args)
        {
            Students students = new Students(2);

            Student student = new Student() { group = 7, name = "Ekaterina", surname = "" };
            students.add(student);
            students.findByGroupId(7);

            ConsoleKeyInfo c = Console.ReadKey();
        }
    }
}