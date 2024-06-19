namespace Library
{
    public class Department : Entity<Department>
    {
        public List<Employee> employees { get; private set; }
        public List<Project> projects { get; private set; }

        public Department(string name) : base(name)
        {
            this.employees = new List<Employee>();
            this.projects = new List<Project>();
        }

        public override void updateData(Department newData)
        {
            this.name = newData.name;
        }

        public void sortEmployeesByJob()
        {
            this.employees.Sort((firstEmployee, secondEmployee) => firstEmployee.job.name.CompareTo(secondEmployee.job.name));
        }
    }
}
