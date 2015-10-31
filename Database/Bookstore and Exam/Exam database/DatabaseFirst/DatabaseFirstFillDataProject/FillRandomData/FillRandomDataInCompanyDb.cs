namespace FillRandomData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using DatabaseFirst.Data;
    
    public class FillRandomDataInCompanyDb
    {
        private static CompanyEntities db;
        private static RandomDataGenetator randomDataGenerator;

        public static void Main()
        {
            System.Threading.Thread.CurrentThread.CurrentCulture =
                System.Globalization.CultureInfo.InvariantCulture;

            Console.WriteLine("USE . !!!");
            Console.WriteLine();
            Console.WriteLine("if you are with EXPRESS change conection string in app.config file  PLEASE!\n\n");

            db = new CompanyEntities();

            db.Configuration.AutoDetectChangesEnabled = false;

            randomDataGenerator = RandomDataGenetator.Instance;

            int numberOfDepartments = 100;
            AddDepartments(numberOfDepartments);

            int numberOfProjects = 1000;
            AddProjects(numberOfProjects);

            int numberOfEmployees = 5000;
            AddEmployees(numberOfEmployees);

            int numberOfReports = 25000;
            AddReports(numberOfReports);

            AddProjectsToEmployees();
        }

        private static void AddProjectsToEmployees()
        {
            var employeeIds = db.Employees.Select(e => e.EmployeeID).ToList();
            var projectsIds = db.Projects.Select(e => e.ProjectID).ToList();

            int numberOfEmployeesForProject = 0;
            var selectdIds = new HashSet<int>();

            EmployeesProject empProject = null;
            int count = 0;

            Console.WriteLine("Add Employees projects");
            for (int i = 0; i < projectsIds.Count; i++)
            {
                numberOfEmployeesForProject = randomDataGenerator.GetRandomNumber(2, 20);

                selectdIds.Clear();
                for (int j = 0; j < numberOfEmployeesForProject; j++)
                {
                    var employeeID = employeeIds[randomDataGenerator.GetRandomNumber(0, employeeIds.Count - 1)];

                    if (!selectdIds.Contains(employeeID))
                    {
                        selectdIds.Add(employeeID);
                    }
                    else
                    {
                        j--;
                        continue;
                    }

                    empProject = new EmployeesProject()
                    {
                        EmployeeID = employeeID,
                        ProjectID = projectsIds[i],
                        StartDate = DateTime.Now,
                        EndDate = DateTime.Now.AddDays(randomDataGenerator.GetRandomNumber(1, 300))
                    };

                    count++;
                    db.EmployeesProjects.Add(empProject);

                    if (count % 100 == 0)
                    {
                        db.SaveChanges();
                        Console.Write(".");
                    }
                }
            }

            db.SaveChanges();
        }

        private static void AddReports(int numberOfReports)
        {
            var employeesIDs = db.Employees.Select(e => e.EmployeeID).ToList();


            Console.WriteLine("\nAdd Reports");
            for (int i = 0; i < numberOfReports; i++)
            {
                var report = new Report()
                                        {
                                            EmployeeID = employeesIDs[randomDataGenerator.GetRandomNumber(0, employeesIDs.Count - 1)],
                                            ReportTime = DateTime.Now.AddDays(randomDataGenerator.GetRandomNumber(0, 500))
                                        };

                db.Reports.Add(report);

                if (i % 50 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }

        private static void AddEmployees(int numberOfEmployees)
        {
            string firstName;
            string lastName;
            decimal salary;
            int departmentID;
            int? menagerID = null;

            var numberOfManagers = numberOfEmployees - (numberOfEmployees * 95 / 100);
            List<int> managersIDs = null;

            var departmentsIDs = db.Departments.Select(d => d.DepartmentID).ToList();

            Console.WriteLine("\nAdd Employees");

            for (int i = 0; i < numberOfEmployees; i++)
            {
                firstName = randomDataGenerator.GetRandomStringWithRandomLength(5, 20);
                lastName = randomDataGenerator.GetRandomStringWithRandomLength(5, 20);
                salary = randomDataGenerator.GetRandomNumber(50000, 200000);
                departmentID = departmentsIDs[randomDataGenerator.GetRandomNumber(0, departmentsIDs.Count - 1)];

                if (i > numberOfManagers && managersIDs == null)
                {
                    managersIDs = db.Employees.Select(e => e.EmployeeID).ToList();
                }

                if (i > numberOfManagers)
                {
                    menagerID = managersIDs[randomDataGenerator.GetRandomNumber(0, managersIDs.Count - 1)];
                }

                var employee = new Employee()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    YearSalary = salary,
                    DepartmentID = departmentID,
                    ManagerID = menagerID
                };

                db.Employees.Add(employee);

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }

        private static void AddProjects(int numberOfProjects)
        {
            var departmantsNames = new HashSet<string>();
            string projectName = "";

            Console.WriteLine("\nAdd Projects");
            for (int i = 0; i < numberOfProjects; i++)
            {
                projectName = randomDataGenerator.GetRandomStringWithRandomLength(5, 50);

                var project = new Project() { Name = projectName };

                db.Projects.Add(project);

                if (i % 100 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }

        private static void AddDepartments(int count)
        {
            var departmantsNames = new HashSet<string>();
            string departmantName = "";

            Console.WriteLine("\nAdd Departments");
            for (int i = 0; i < count; i++)
            {
                departmantName = randomDataGenerator.GetRandomStringWithRandomLength(10, 50);

                if (!departmantsNames.Contains(departmantName))
                {
                    departmantsNames.Add(departmantName);

                    var department = new Department() { Name = departmantName };

                    db.Departments.Add(department);
                }
                else
                {
                    i--;
                }

                if (i % 50 == 0)
                {
                    db.SaveChanges();
                    Console.Write(".");
                }
            }

            db.SaveChanges();
        }


    }
}
