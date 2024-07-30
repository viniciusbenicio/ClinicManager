using System.Xml.Linq;

namespace ClinicManager.Core.DTOs
{
    public class CareDTO
    {
        public string NamePatient { get; set; }
        public string EmailPatient { get; set; }
        public string ServiceName { get; set; }
        public string ServiceDescription { get; set; }
        public string NameDoctor { get; set; }
        public string EmailDoctor { get; set; }
        public string HealthyPlan { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public int TypeService { get; set; }

      
    }
}
