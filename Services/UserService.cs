using AutoMapper;
using Task5Back.Entities;
using Task5Back.Helpers;

namespace Task5Back.Services
{
    public interface IUserService
    {
        Task CreateUser(string name);

        Task<User> GetUserByName(string name);

        string[] Search(string str);
    }

    public class UserService : IUserService
    {
        private readonly DataContext _context;

        private readonly IMapper _mapper;

        public UserService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task CreateUser(string name)
        {
            User user = await _context.Users.FindAsync(name);

            if (user == null)
            {
                _ = await _context.Users.AddAsync(_mapper.Map<User>(name));
                _ = _context.SaveChanges();
            }
        }

        public async Task<User> GetUserByName(string name)
        {
            return await _context.Users.FindAsync(name);
        }

        public string[] Search(string str)
        {
            return _context.Users.Where(u => u.Name.Contains(str)).Select(u => u.Name).ToArray();
        }
    }
}