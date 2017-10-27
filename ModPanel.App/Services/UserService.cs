using ModPanel.App.Data;
using ModPanel.App.Data.Models;
using ModPanel.App.Services.Contracts;
using System.Linq;

namespace ModPanel.App.Services
{
    public class UserService : IUserService
    {
        private readonly ModPanelDbContext db;

        public UserService(ModPanelDbContext db)
        {
            this.db = db;
        }

        public bool Create(string email, string password, PositionType position)
        {
            if (this.db.Users.Any(u => u.Email == email))
            {
                return false;
            }

            var isAdmin = !db.Users.Any();

            var user = new User
            {
                Email = email,
                Password = password,
                Position = position,
                IsAdmin = isAdmin
            };

            db.Add(user);
            db.SaveChanges();

            return true;
        }

        public bool UserExists(string email, string password)
            => this.db
                .Users
                .Any(u => u.Email == email && u.Password == password);
    }
}
