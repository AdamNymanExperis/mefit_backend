using mefit_backend.Exceptions;
using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Services
{
    public class ProfileService : IProfileService
    {
        private readonly MeFitDbContext _context;

        public ProfileService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<Profile> CreateProfile(Profile profile)
        {
            _context.Profiles.Add(profile);
            await _context.SaveChangesAsync();

            return profile;
        }

        public async Task DeleteProfile(int id)
        {
            var profile = await _context.Profiles.FindAsync(id);
            if (profile == null)
            {
                throw new ProfileNotFoundException(id);
            }
            _context.Profiles.Remove(profile);
            await _context.SaveChangesAsync();
        }

        public async Task<Profile> GetProfileById(int id)
        {
            var profile = await _context.Profiles.Include(x=> x.Goals).Include(x => x.Impairments).FirstOrDefaultAsync(x => x.Id == id);
            if (profile == null)
            {
                throw new ProfileNotFoundException(id);
            }
            return profile;
        }

        public async Task UpdateImpairmentsInProfile(int[] impairmentIds, int profileId)
        {
            var checkProfile = await _context.Profiles.FindAsync(profileId);
            if (checkProfile == null)
                throw new ProfileNotFoundException(profileId);

            List<Impairment> impairments = impairmentIds
                .ToList()
                .Select(x => _context.Impairments
                .Where(s => s.Id == x).First())
                .ToList();
          
            Profile profile = await _context.Profiles
                .Where(x => x.Id == profileId)
                .FirstAsync();
          
            profile.Impairments = impairments;
            _context.Entry(profile).State = EntityState.Modified;
     
            await _context.SaveChangesAsync();
        }

        public async Task<Profile> UpdateProfile(Profile profile)
        {
            var foundProfile = await _context.Profiles.AnyAsync(x => x.Id == profile.Id);
            if (!foundProfile)
            {
                throw new ProfileNotFoundException(profile.Id);
            }
            _context.Entry(profile).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return profile;
        }


    }
}
