namespace ClinicManager.Application.ViewModels
{
    public class ServiceViewModel
    {
        public ServiceViewModel(string name, string description, decimal price, int duration)
        {
            Name = name;
            Description = description;
            Price = price;
            Duration = duration;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
    }
}
