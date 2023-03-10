using mefit_backend.models.domain;
using mefit_backend.models.DTO;

namespace mefit_backend.Services
{
    public interface IImpairmentService
    {
        public Task<IEnumerable<Impairment>> GetImpairments();
        public Task<Impairment> GetImpairmentById(int id);

        public Task<Impairment> CreateImpairment(Impairment impairment);
        public Task<Impairment> UpdateImpairment(Impairment impairment);
        public Task DeleteImpairment(int id);
    }
}
