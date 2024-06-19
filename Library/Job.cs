namespace Library
{
    public class Job : Entity<Job>
    {
        public int workingHours { get; private set; }
        public float startingSalary { get; private set; }
        public List<Employee> employees { get; private set; }

        public Job(string name, int workingHours, float startingSalary) : base(name)
        {
            this.workingHours = workingHours;
            this.startingSalary = startingSalary;
            this.employees = new List<Employee>();
        }

        public override void updateData(Job newData)
        {
            this.name = newData.name;
            this.workingHours = newData.workingHours;
            this.startingSalary = newData.startingSalary;
        }

        public Employee getBestEmployee()
        {
            this.employees.Sort((firstEmployee, secondEmployee) =>
            {
                int firstSum = 0;
                int secondSum = 0;
                foreach (Project project in firstEmployee.projects)
                {
                    firstSum += project.cost;
                }
                foreach (Project project in secondEmployee.projects)
                {
                    secondSum += project.cost;
                }
                float firstRatio = firstEmployee.experience / firstSum;
                float secondRatio = secondEmployee.experience / secondSum;
                return firstRatio.CompareTo(secondRatio);
            });
            return this.employees[0];
        }
    }
}
