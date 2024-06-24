namespace ClinicManager.Core.Entities
{
    public class Care : Entity
    {
        public Care(int patientId, int serviceId, int medicalId, string healthinsurance, DateTime start, DateTime end, int typeService)
        {
            PatientId = patientId;
            ServiceId = serviceId;
            MedicalId = medicalId;
            Healthinsurance = healthinsurance;
            Start = start;
            End = end;
            TypeService = typeService;
        }

        public int PatientId { get; private set; }
        public int ServiceId { get; private set; }
        public int MedicalId { get; private set; }
        public string Healthinsurance { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int TypeService { get; private set; }
    }
}
