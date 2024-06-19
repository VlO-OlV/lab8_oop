namespace Library
{
    public class Project : Entity<Project>
    {
        public int cost { get; private set; }
        public Department department { get; private set; }

        public Project(string name, int cost, Department department) : base(name)
        {
            this.cost = cost;
            this.department = department;
        }

        public override void updateData(Project newData)
        {
            this.name = newData.name;
            this.cost = newData.cost;
        }
    }
}
