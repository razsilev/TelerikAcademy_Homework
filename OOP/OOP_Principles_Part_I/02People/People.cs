using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _02People
{
    class People
    {
        static void Main()
        {
            List<Student> students = new List<Student>();
            List<Worker> workers = new List<Worker>();

            AddTenStudentsInGivanList(students);
            AddTenWorkersInGivanList(workers);
            
            SortStudentsTask(students);
            SortWorkersTask(workers);

            List<Human> mergetLists = new List<Human>();

            // Merget students and workers
            // add students in mergetList
            foreach (var student in students)
            {
                mergetLists.Add(student);
            }

            // add workers in mergetList
            foreach (var worker in workers)
            {
                mergetLists.Add(worker);
            }

            // sort merget list whit extensin methods by first name and last name
            var sortByFirstAndLastName = mergetLists.OrderBy(h => h.GetFirstName).ThenBy(h => h.GetLastName);

            Console.WriteLine("\nHuman sorted by first name and last name:");
            foreach (Human human in sortByFirstAndLastName)
            {
                Console.WriteLine("{0, -7} {1, -10}", human.GetFirstName, human.GetLastName);
            }
        }

        private static void SortWorkersTask(List<Worker> workers)
        {
            var sortedWorkers = from w in workers
                                orderby w.MoneyPerHour() descending
                                select w;

            Console.WriteLine("\nWorkers sorted by money per hour:");
            foreach (var worker in sortedWorkers)
            {
                Console.WriteLine("{0, -7} {2, -10}: {1:C}", worker.GetFirstName, worker.MoneyPerHour(), worker.GetLastName);
            }
        }

        private static void SortStudentsTask(List<Student> students)
        {
            var sortedStudents = from stud in students
                                 orderby stud.Grade
                                 select stud;

            Console.WriteLine("Students sorted by grade:");
            foreach (var student in sortedStudents)
            {
                Console.WriteLine(student);
            }
        }

        private static void AddTenStudentsInGivanList(List<Student> students)
        {
            students.Add(new Student("Mihaela", "Mihova", 5));
            students.Add(new Student("Ioan", "Aleksiev", 4));
            students.Add(new Student("Tanq", "Aleksandrova", 11));
            students.Add(new Student("Stoqn", "Ivanov", 16));
            students.Add(new Student("Ivan", "Ivanov", 8));
            students.Add(new Student("Pesho", "Petrov", 12));
            students.Add(new Student("Pada", "Kalcheva", 12));
            students.Add(new Student("Hristo", "Chavdarov", 11));
            students.Add(new Student("Petar", "Georev", 8));
            students.Add(new Student("Mimi", "Mileva", 17));
        }

        private static void AddTenWorkersInGivanList(List<Worker> workers)
        {
            workers.Add(new Worker("Mihaela", "Veleva", 680.24f, 8));
            workers.Add(new Worker("Ioan", "Aleksandrov", 405.33f, 4));
            workers.Add(new Worker("Tanq", "Todorova", 1050, 9));
            workers.Add(new Worker("Stoqn", "Stoqnov", 2400, 8));
            workers.Add(new Worker("Ivan", "Geoshev", 656.54f, 8));
            workers.Add(new Worker("Pesho", "Peshev", 289, 4));
            workers.Add(new Worker("Pada", "Giurova", 1000, 12));
            workers.Add(new Worker("Hristo", "Nikolov", 700, 8));
            workers.Add(new Worker("Petar", "Domuschiev", 612.57f, 8));
            workers.Add(new Worker("Aneta", "Koleva", 2804.8f, 4));
        }
    }
}
