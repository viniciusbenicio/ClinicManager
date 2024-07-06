namespace ClinicManager.Core.Entities
{
    public class Care : Entity
    {
        public Care(int patientId, int serviceId, int doctorId, string healthinsurance, DateTime start, DateTime end, int typeService)
        {
            PatientId = patientId;
            ServiceId = serviceId;
            DoctorId = doctorId;
            Healthinsurance = healthinsurance;
            Start = start;
            End = end;
            TypeService = typeService;
            Active = true;
        }

        public int PatientId { get; private set; }
        public int ServiceId { get; private set; }
        public int DoctorId { get; private set; }
        public string Healthinsurance { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
        public int TypeService { get; private set; }
        public bool Active { get; private set; }
        public Patient Patient { get; private set; }
        public Service Service { get; private set; }
        public Doctor Doctor { get; private set; }

        public void Update(int patientId, int serviceId, int doctorId, string healthinsurance, DateTime start, DateTime end, int typeService)
        {
            PatientId = patientId;
            ServiceId = serviceId;
            DoctorId = doctorId;
            Healthinsurance = healthinsurance;
            Start = start;
            End = end;
            TypeService = typeService;
        }

        public void Remove()
        {
            Active = false;
        }
    }
}
