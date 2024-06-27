namespace ClinicManager.Core.Entities
{
    public class Service : Entity
    {
        public Service(string name, string description, decimal price, int duration)
        {
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
            Active = true;
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }
        public bool Active { get; private set; }


        public void Update(string name, string description, decimal price, int duration)
        {
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
        }

        public void Remove()
        {
            Active = false;
        }

    }
}
