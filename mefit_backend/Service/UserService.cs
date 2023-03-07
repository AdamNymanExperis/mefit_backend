using mefit_backend.models;

namespace mefit_backend.Service
{
    public class UserService : IUserService
    {
        private readonly MeFitDbContext _context;

        public UserService(MeFitDbContext context)
        {
            _context = context;
        }


    }
}
