using ClinicManager.Application.ViewModels;
using MediatR;

namespace ClinicManager.Application.Queries.GetByDocumentPatient
{
    public class GetByDocumentPatientQuery : IRequest<PatientViewModel>
    {

        public GetByDocumentPatientQuery(string document)
        {
            Document = document;
        }
        public string Document { get; set; }

    }
}
