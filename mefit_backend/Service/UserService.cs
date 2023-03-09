using mefit_backend.models;
using mefit_backend.models.domain;
using Microsoft.EntityFrameworkCore;

namespace mefit_backend.Service
{
    public class UserService : IUserService
    {
        private readonly MeFitDbContext _context;

        public UserService(MeFitDbContext context)
        {
            _context = context;
        }

        public async Task<User> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user == null)
            {
                throw new UserNotFoundException(id);
            }
            return user;
        }

        public async Task DeleteUser(int id)
        {
            var character = await _context.Users.FindAsync(id);
            if (character == null)
            {
                throw new UserNotFoundException(id);
            }

            _context.Users.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var foundCharacter = await _context.Users.AnyAsync(x => x.Id == user.Id);
            if (!foundCharacter)
            {
                throw new UserNotFoundException(user.Id);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }
    }
}
