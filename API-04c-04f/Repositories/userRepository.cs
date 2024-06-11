using Exo.WebApi.Contexts;
using Exo.WebApi.Models;
using System.Collections.Generic;
using System.Linq;
namespace Exo.WebApi.Repositories
{
    public class UserRepository
    {
        private readonly ExoContext _context;
        public UserRepository(ExoContext context)
        {
            _context = context;
        }
        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Email ==
             email && u.Password == password);
        }

        public List<User> List()
        {
            return _context.Users.ToList();
        }
        public void Register(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }
        public User SearchById(int id)
        {
            return _context.Users.Find(id);
        }
        public void Update(int id, User user)
        {
            User findedUser = _context.Users.Find(id);
            if (findedUser != null)
            {
                findedUser.Email = user.Email;
                findedUser.Password = user.Password;
            }
            _context.Users.Update(findedUser);
            _context.SaveChanges();
        }
        public void Delete(int id)
        {
            User findedUser = _context.Users.Find(id);
            _context.Users.Remove(findedUser);
            _context.SaveChanges();
        }
    }
}