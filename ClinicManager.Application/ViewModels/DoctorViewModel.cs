namespace ClinicManager.Application.ViewModels
{
    public class DoctorViewModel
    {
        public DoctorViewModel(string specialty, string cRMRegistration)
        {
            Specialty = specialty;
            CRMRegistration = cRMRegistration;
        }
        public string Specialty { get; private set; }
        public string CRMRegistration { get; private set; }
    }
}
