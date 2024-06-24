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
        }

        public string Name { get; private set; }
        public string Description { get; private set; }
        public decimal Price { get; private set; }
        public int Duration { get; private set; }
    }
}
