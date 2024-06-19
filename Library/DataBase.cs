namespace Library
{
    public class DataBase : ISearch
    {
        public List<Employee> employees { get; private set; }
        public List<Department> departments { get; private set; }
        public List<Job> jobs { get; private set; }
        public List<Project> projects { get; private set; }

        public DataBase()
        {
            this.employees = new List<Employee>();
            this.departments = new List<Department>();
            this.jobs = new List<Job>();
            this.projects = new List<Project>();
        }

        public void addEmployee(Employee employee)
        {
            this.employees.Add(employee);
            employee.job.employees.Add(employee);
            employee.department.employees.Add(employee);
        }

        public void removeEmployee(int employeeId)
        {       
            this.employees[employeeId].department.employees.Remove(this.employees[employeeId]);
            this.employees[employeeId].job.employees.Remove(this.employees[employeeId]);
            this.employees.Remove(employees[employeeId]);
        }

        public void sortEmployeesByFirstName()
        {
            this.employees.Sort((firstEmployee, secondEmployee) => firstEmployee.name.CompareTo(secondEmployee.name));
        }

        public void sortEmployeesByLastName()
        {
            this.employees.Sort((firstEmployee, secondEmployee) => firstEmployee.lastName.CompareTo(secondEmployee.lastName));
        }

        public void sortEmployeesBySalary()
        {
            this.employees.Sort((firstEmployee, secondEmployee) => firstEmployee.salary.CompareTo(secondEmployee.salary));
        }

        public List<Employee> searchEmployees(string keyWord)
        {
            List<Employee> results = new List<Employee>();
            foreach (Employee employee in this.employees)
            {
                if (employee.name.Contains(keyWord) || employee.lastName.Contains(keyWord)) {
                    results.Add(employee);
                }
            }
            return results;
        }

        public List<Employee> searchEmployeeExtended(string? firstName, string? lastName, string? bankAccount, Department? department, Job? job)
        {
            List<Employee> results = new List<Employee>();
            foreach (Employee employee in this.employees)
            {
                if ((firstName == null || employee.name == firstName) && (lastName == null || employee.lastName == lastName) && (bankAccount == null || employee.bankAccount == bankAccount) && (department == null || employee.department == department) && (job == null || employee.job == job))
                {
                    results.Add(employee);
                }
            }
            return results;
        }

        public void addDepartment(Department department)
        {
            this.departments.Add(department);
        }

        public void sortDepartmentsByTotalProjectsCost()
        {
            this.departments.Sort((firstDepartment, secondDepartment) =>
            {
                int firstSum = 0;
                int secondSum = 0;
                foreach (Project project in firstDepartment.projects)
                {
                    firstSum += project.cost;
                }
                foreach (Project project in secondDepartment.projects)
                {
                    secondSum += project.cost;
                }
                return firstSum.CompareTo(secondSum);
            });
        }

        public List<Department> searchDepartments(string keyWord)
        {
            List<Department> results = new List<Department>();
            foreach (Department department in this.departments)
            {
                if (department.name.Contains(keyWord))
                {
                    results.Add(department);
                }
            }
            return results;
        }

        public void addJob(Job job)
        {
            this.jobs.Add(job);
        }

        public List<Job> getBestJobs()
        {
            List<Job> bestJobs = new List<Job>();
            this.jobs.Sort((firstJob, secondJob) =>
            {
                float firstRatio = firstJob.workingHours / firstJob.startingSalary;
                float secondRatio = secondJob.workingHours / secondJob.startingSalary;
                return firstRatio.CompareTo(secondRatio);
            });

            for (int i = 0; i < (this.jobs.Count > 5 ? 5 : this.jobs.Count); i++)
            {
                bestJobs.Add(this.jobs[i]);
            }
            return bestJobs;
        }

        public List<Job> searchJobs(string keyWord)
        {
            List<Job> results = new List<Job>();
            foreach (Job job in this.jobs)
            {
                if (job.name.Contains(keyWord))
                {
                    results.Add(job);
                }
            }
            return results;
        }

        public void addProject(Project project)
        {
            this.projects.Add(project);
            project.department.projects.Add(project);
            foreach (Employee employee in project.department.employees)
            {
                employee.projects.Add(project);
            }
        }

        public List<Project> searchProjects(string keyWord)
        {
            List<Project> results = new List<Project>();
            foreach (Project project in this.projects)
            {
                if (project.name.Contains(keyWord)) {
                    results.Add(project);
                }
            }
            return results;
        }
    }
}
