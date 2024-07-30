using ClinicManager.Core.DTOs;

namespace ClinicManager.Core.Repositores
{
    public interface IJobRepository
    {
        List<CareDTO> GetConsultationNext12Hours();
    }
}
