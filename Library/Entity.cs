namespace Library
{
    public abstract class Entity<T>
    {
        public string name { get; protected set; }

        public Entity(string name)
        {
            this.name = name;
        }

        public abstract void updateData(T newData);
    }
}
