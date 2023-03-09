using mefit_backend.models.domain;

namespace mefit_backend.Services
{
    public interface IProfileService
    {
        public Task<Profile> GetProfileById(int id);
        public Task<Profile> CreateProfile(Profile profile);
        public Task<Profile> UpdateProfile(Profile profile);
        public Task DeleteProfile(int id);
    }
}
