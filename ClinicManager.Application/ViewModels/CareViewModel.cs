namespace ClinicManager.Application.ViewModels
{
    public class CareViewModel
    {
        public CareViewModel(int patientId, int serviceId, int medicalId, string healthinsurance, DateTime start, DateTime end, int typeService)
        {
            PatientId = patientId;
            ServiceId = serviceId;
            MedicalId = medicalId;
            Healthinsurance = healthinsurance;
            Start = start;
            End = end;
            TypeService = typeService;
        }

        public int PatientId { get;  set; }
        public int ServiceId { get;  set; }
        public int MedicalId { get;  set; }
        public string Healthinsurance { get;  set; }
        public DateTime Start { get;  set; }
        public DateTime End { get;  set; }
        public int TypeService { get;  set; }
    }
}
