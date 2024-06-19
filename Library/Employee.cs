namespace Library
{
    public class Employee : Entity<Employee>
    {
        public string lastName { get; private set; }
        public string bankAccount { get; private set; }
        public Department department { get; private set; }
        public Job job { get; private set; }
        public float experience { get; private set; }
        public List<Project> projects { get; private set; }
        public float salary { get; private set; }

        public Employee(string name, string lastName, string bankAccount, float experience, Department department, Job job) : base(name)
        {
            this.lastName = lastName;
            this.bankAccount = bankAccount;
            this.department = department;
            this.job = job;
            this.experience = experience;
            this.projects = new List<Project>();
            this.salary = this.job.startingSalary * (1 + this.experience / 10);
        }

        public override void updateData(Employee newData)
        {
            this.department.employees.Remove(this);
            this.job.employees.Remove(this);
            this.name = newData.name;
            this.lastName = newData.lastName;
            this.bankAccount = newData.bankAccount;
            this.department = newData.department;
            this.job = newData.job;
            this.experience = newData.experience;
            this.salary = this.job.startingSalary * (1 + this.experience / 10);
            this.department.employees.Add(this);
            this.job.employees.Add(this);
        }
    }
}