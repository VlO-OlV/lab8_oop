using Library;

DataBase database = new DataBase();

void showDepartments(List<Department> departmentsToShow)
{
    int i = 0;
    foreach (Department department in departmentsToShow)
    {
        i++;
        Console.WriteLine(i + ") " + department.name + " (" + department.employees.Count + " employees)");
    }
}

void showFullDepartment(Department department)
{
    Console.WriteLine(department.name);
}

void showJobs(List<Job> jobsToShow)
{
    int i = 0;
    foreach (Job job in jobsToShow)
    {
        i++;
        Console.WriteLine(i + ") " + job.name + " (" + job.workingHours + " hours a week, " + job.startingSalary + "$)");
    }
}

Job getJobData()
{
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Working hours: ");
    int worlingHours = Convert.ToInt32(Console.ReadLine());
    Console.Write("Starting salary: ");
    float startingSalary = (float) Convert.ToDouble(Console.ReadLine());
    Console.Clear();
    return new Job(name, worlingHours, startingSalary);
}

void showProjects(List<Project> projectsToShow)
{
    int i = 0;
    foreach (Project project in projectsToShow)
    {
        i++;
        Console.WriteLine(i + ") " + project.name + ", " + project.cost + "$ (" + project.department.name + ")");
    }
}

Project getProjectData()
{
    Console.Write("Name: ");
    string name = Console.ReadLine();
    Console.Write("Cost: ");
    int cost = Convert.ToInt32(Console.ReadLine());
    showDepartments(database.departments);
    Console.Write("Department number: ");
    int departmentId = Convert.ToInt32(Console.ReadLine()) - 1;
    Console.Clear();
    return new Project(name, cost, database.departments[departmentId]);
}

void showEmployees(List<Employee> employeesToShow)
{
    int i = 0;
    Console.WriteLine("\n");
    foreach (Employee employee in employeesToShow)
    {
        i++;
        Console.WriteLine(i + ") " + employee.name + " " + employee.lastName + " (" + employee.job.name + " in " + employee.department.name + ")");
    }
}

void showFullEmployee(Employee employee)
{
    Console.WriteLine("\n" + employee.name + " " + employee.lastName + "\nposition: " + employee.job.name + "(in " + employee.department.name + ")\nexperience: " + employee.experience + "\nsalary: " + employee.salary + "\nbank account: " + employee.bankAccount);
}

Employee getEmployeeData()
{
    Console.Write("First name: ");
    string firstName = Console.ReadLine();
    Console.Write("Last name: ");
    string lastName = Console.ReadLine();
    Console.Write("Bank account: ");
    string bankAccount = Console.ReadLine();
    showDepartments(database.departments);
    Console.Write("Department number: ");
    int departmentId = Convert.ToInt32(Console.ReadLine()) - 1;
    showJobs(database.jobs);
    Console.Write("Job number: ");
    int jobId = Convert.ToInt32(Console.ReadLine()) - 1;
    Console.Write("Experience: ");
    float experience = (float) Convert.ToDouble(Console.ReadLine()) - 1;
    Console.Clear();
    return new Employee(firstName, lastName, bankAccount, experience, database.departments[departmentId], database.jobs[jobId]);
}

void employeesMenu()
{
    int option;
    do
    {
        Console.WriteLine("===========================\n       Employees Menu\n===========================\n1) Add employee\n2) Update employee\n3) Remove employee\n4) View employee's data\n5) View employee's projects\n6) View all employees\n7) Sort employees\n8) Back to main menu");
        option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (option)
        {
            case 1:
                if (database.departments.Count == 0 || database.jobs.Count == 0)
                {
                    Console.WriteLine("There must be al least 1 department and 1 job!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Add employee\n");
                    Employee newEmployee = getEmployeeData();
                    database.addEmployee(newEmployee);
                }
                break;
            case 2:
                if (database.employees.Count == 0)
                {
                    Console.WriteLine("There is no employees!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Update employee\n");
                    showEmployees(database.employees);
                    Console.Write("Number of employee to update: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    Employee updatedEmployee = getEmployeeData();
                    database.employees[employeeId].updateData(updatedEmployee);
                }
                break;
            case 3:
                if (database.employees.Count == 0)
                {
                    Console.WriteLine("There is no employees!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Remove employee\n");
                    showEmployees(database.employees);
                    Console.Write("Number of employee to update: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    database.removeEmployee(employeeId);
                }
                break;
            case 4:
                if (database.employees.Count == 0)
                {
                    Console.WriteLine("There is no employees!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("View employee's data\n");
                    showEmployees(database.employees);
                    Console.Write("Number of employee to view: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    showFullEmployee(database.employees[employeeId]);
                    Console.ReadLine();
                    Console.Clear();
                }
                break;
            case 5:
                if (database.employees.Count == 0)
                {
                    Console.WriteLine("There is no employees!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("View employee's projects\n");
                    showEmployees(database.employees);
                    Console.Write("Number of employee to view: ");
                    int employeeId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    showProjects(database.employees[employeeId].projects);
                    Console.ReadLine();
                    Console.Clear();
                }
                break;
            case 6:
                Console.WriteLine("View all employees\n");
                foreach (Employee employee in database.employees)
                {
                    showFullEmployee(employee);
                }
                Console.ReadLine();
                Console.Clear();
                break;
            case 7:
                Console.WriteLine("Sort employees\n");
                Console.WriteLine("1) by first name\n2)by last name\n3) by salary");
                int sortOption = Convert.ToInt32(Console.ReadLine());
                Console.Clear();
                if (sortOption == 1)
                {
                    database.sortEmployeesByFirstName();
                }
                if (sortOption == 2)
                {
                    database.sortEmployeesByLastName();
                }
                if (sortOption == 3)
                {
                    database.sortEmployeesBySalary();
                }
                break;
            default:
                break;
        }
    } while (option != 8);
}

void departmentsMenu()
{
    int option;
    do
    {
        Console.WriteLine("===========================\n      Departments Menu\n===========================\n1) Add department\n2) Update department\n3) View department's data\n4) View department's employees\n5) Sort department's employees by position\n6) Sort departments by total projects cost\n7) Back to main menu");
        option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (option)
        {
            case 1:
                Console.WriteLine("Add department\n");
                Console.Write("Department's name: ");
                string departmentName = Console.ReadLine();
                Console.Clear();
                database.addDepartment(new Department(departmentName));
                break;
            case 2:
                if (database.departments.Count == 0)
                {
                    Console.WriteLine("There is no departments!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Update department\n");
                    showDepartments(database.departments);
                    Console.Write("Number of department to update: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    Console.Write("Department's new name: ");
                    string updatedDepartmentName = Console.ReadLine();
                    Console.Clear();
                    database.departments[departmentId].updateData(new Department(updatedDepartmentName));
                }
                break;
            case 3:
                if (database.departments.Count == 0)
                {
                    Console.WriteLine("There is no departments!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("View department's data\n");
                    showDepartments(database.departments);
                    Console.Write("Number of department to view: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    showFullDepartment(database.departments[departmentId]);
                    Console.ReadLine();
                    Console.Clear();
                }
                break;
            case 4:
                if (database.departments.Count == 0)
                {
                    Console.WriteLine("There is no departments!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("View department's employees\n");
                    showDepartments(database.departments);
                    Console.Write("Number of department to view: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    showEmployees(database.departments[departmentId].employees);
                    Console.ReadLine();
                    Console.Clear();
                }
                break;
            case 5:
                if (database.departments.Count == 0)
                {
                    Console.WriteLine("There is no departments!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Sort department's employees by position\n");
                    showDepartments(database.departments);
                    Console.Write("Number of department for sort: ");
                    int departmentId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    database.departments[departmentId].sortEmployeesByJob();
                }
                break;
            case 6:
                database.sortDepartmentsByTotalProjectsCost();
                break;
            default:
                break;
        }
    } while (option != 7);
}

void jobsMenu()
{
    int option;
    do
    {
        Console.WriteLine("===========================\n        Jobs Menu\n===========================\n1) Add job\n2) Update job\n3) Top 5 jobs\n4) Best employee\n5) Back to main menu");
        option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (option)
        {
            case 1:
                Console.WriteLine("Add job\n");
                Job newJob = getJobData();
                database.addJob(newJob);
                break;
            case 2:
                if (database.jobs.Count == 0)
                {
                    Console.WriteLine("There is no jobs!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Update job\n");
                    showJobs(database.jobs);
                    Console.Write("Number of job to update: ");
                    int jobId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    Job updatedJob = getJobData();
                    database.jobs[jobId].updateData(updatedJob);
                }
                break;
            case 3:
                Console.WriteLine("Top 5 jobs\n");
                showJobs(database.getBestJobs());
                Console.ReadLine();
                Console.Clear();
                break;
            case 4:
                if (database.jobs.Count == 0)
                {
                    Console.WriteLine("There is no jobs!");
                    Console.ReadLine();
                    Console.Clear();
                }
                else
                {
                    Console.WriteLine("Best employee\n");
                    showJobs(database.jobs);
                    Console.Write("Number of job to pick: ");
                    int jobId = Convert.ToInt32(Console.ReadLine()) - 1;
                    Console.Clear();
                    showFullEmployee(database.jobs[jobId].getBestEmployee());
                    Console.ReadLine();
                    Console.Clear();
                }
                break;
            default:
                break;
        }
    } while (option != 5);
}

void projectsMenu()
{
    int option;
    do
    {
        Console.WriteLine("===========================\n       Projects Menu\n===========================\n1) Add project\n2) Update project\n3) Back to main menu");
        option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (option)
        {
            case 1:
                Console.WriteLine("Add project\n");
                Project newProject = getProjectData();
                database.addProject(newProject);
                break;
            case 2:
                Console.WriteLine("Update project\n");
                showProjects(database.projects);
                Console.Write("Number of project to update: ");
                int projectId = Convert.ToInt32(Console.ReadLine()) - 1;
                Console.Clear();
                Project updatedProject = getProjectData();
                database.projects[projectId].updateData(updatedProject);
                break;
            default:
                break;
        }
    } while (option != 3);
}

void searchMenu()
{
    int option;
    do
    {
        Console.WriteLine("===========================\n        Search Menu\n===========================\n1) Search in employees\n2) Search in projects\n3) Search in all data\n4) Extended search in employees\n5) Back to main menu");
        option = Convert.ToInt32(Console.ReadLine());
        Console.Clear();
        switch (option)
        {
            case 1:
                Console.WriteLine("Search in employees\n");
                Console.WriteLine("Keyword: ");
                string keyWordEmployee = Console.ReadLine();
                Console.Clear();
                foreach (Employee employee in database.searchEmployees(keyWordEmployee))
                {
                    showFullEmployee(employee);
                }
                Console.ReadLine();
                Console.Clear();
                break;
            case 2:
                Console.WriteLine("Search in projects\n");
                Console.WriteLine("Keyword: ");
                string keyWordProject = Console.ReadLine();
                Console.Clear();
                showProjects(database.searchProjects(keyWordProject));
                Console.ReadLine();
                Console.Clear();
                break;
            case 3:
                Console.WriteLine("Search in projects\n");
                Console.WriteLine("Keyword: ");
                string keyWordAll = Console.ReadLine();
                Console.Clear();
                List<Employee> foundedEmployees = database.searchEmployees(keyWordAll);
                List<Project> foundedProjects = database.searchProjects(keyWordAll);
                List<Job> foundedJobs = database.searchJobs(keyWordAll);
                List<Department> foundedDepartents = database.searchDepartments(keyWordAll);
                Console.WriteLine("Employees\n");
                if (foundedEmployees.Count == 0)
                {
                    Console.WriteLine("None");
                } else
                {
                    showEmployees(foundedEmployees);
                }
                Console.WriteLine("\nProjects\n");
                if (foundedProjects.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    showProjects(foundedProjects);
                }
                Console.WriteLine("\nJobs\n");
                if (foundedJobs.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    showJobs(foundedJobs);
                }
                Console.WriteLine("\nDepartments\n");
                if (foundedDepartents.Count == 0)
                {
                    Console.WriteLine("None");
                }
                else
                {
                    showDepartments(foundedDepartents);
                }
                Console.ReadLine();
                Console.Clear();
                break;
            case 4:
                Console.WriteLine("Extended search in employees\n");
                Employee searchEmployee = getEmployeeData();
                showEmployees(database.searchEmployeeExtended(searchEmployee.name, searchEmployee.lastName, searchEmployee.bankAccount, searchEmployee.department, searchEmployee.job));
                Console.ReadLine();
                Console.Clear();
                break;
            default:
                break;
        }
    } while (option != 5);
}

int mainOption = 0;

do
{
    Console.WriteLine("===========================\n             Menu\n===========================\n1) Employees management\n2) Departments management\n3) Jobs management\n4) Projects management\n5) Search\n6) Exit");
    mainOption = Convert.ToInt32(Console.ReadLine());
    Console.Clear();
    switch (mainOption)
    {
        case 1:
            employeesMenu();
            break;
        case 2:
            departmentsMenu();
            break;
        case 3:
            jobsMenu();
            break;
        case 4:
            projectsMenu();
            break;
        case 5:
            searchMenu();
            break;
        default:
            break;
    }
} while (mainOption != 6);