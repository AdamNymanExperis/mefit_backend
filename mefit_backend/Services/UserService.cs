using mefit_backend.Exceptions;
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
            var foundUser = await _context.Users.FindAsync(id);
            if (foundUser == null)
            {
                throw new UserNotFoundException(id);
            }

            _context.Users.Remove(foundUser);
            await _context.SaveChangesAsync();
        }

        public async Task<User> UpdateUser(User user)
        {
            var foundUser = await _context.Users.AnyAsync(x => x.Id == user.Id);
            if (!foundUser)
            {
                throw new UserNotFoundException(user.Id);
            }
            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return user;
        }

        public async Task<User> UpdateUserPassword(int id, string password)
        {
            var foundUser = await _context.Users.FindAsync(id);
            if (foundUser == null)
            {
                throw new UserNotFoundException(id);
            }

            foundUser.Password = password;

            _context.Entry(foundUser).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return foundUser;
        }
    }
}
