using ModPanel.App.Data;
using ModPanel.App.Data.Models;
using ModPanel.App.Services.Contracts;
using System.Linq;
using ModPanel.App.Models.Admin;
using System.Collections.Generic;

namespace ModPanel.App.Services
{
    public class UserService : IUserService
    {
        //private readonly ModPanelDbContext db;
        //
        //public UserService(ModPanelDbContext db)
        //{
        //    this.db = db;
        //}

        public bool Create(string email, string password, PositionType position)
        {
            using (var db = new ModPanelDbContext())
            {
                if (db.Users.Any(u => u.Email == email))
                {
                    return false;
                }

                var isAdmin = !db.Users.Any();

                var user = new User
                {
                    Email = email,
                    Password = password,
                    Position = position,
                    IsAdmin = isAdmin,
                    IsApproved = isAdmin
                    
                };

                db.Add(user);
                db.SaveChanges();

                return true;
            }        
        }

        public bool UserExists(string email, string password)
        {
            using (var db = new ModPanelDbContext())
            {
                return db
                .Users
                .Any(u => u.Email == email && u.Password == password);
            }
        }

        public bool UserIsApproved(string email)
        {
            using (var db = new ModPanelDbContext())
            {
                return db
                .Users
                .Any(u => u.Email == email && u.IsApproved);
            }
        }

        public IEnumerable<UsersListingAdminModel> AllUsers()
        {
            using (var db = new ModPanelDbContext())
            {
                return db
                    .Users
                    .Select(u => new UsersListingAdminModel
                    {
                        Id = u.Id,
                        Email = u.Email,
                        Position = u.Position,
                        Posts = 0,
                        IsUserApproved = u.IsApproved
                    })
                    .ToList();
            }
        }
    }
}
