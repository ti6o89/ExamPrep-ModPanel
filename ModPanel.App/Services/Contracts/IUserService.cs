using ModPanel.App.Data.Models;
using ModPanel.App.Models.Admin;
using System.Collections.Generic;

namespace ModPanel.App.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string password, PositionType position);

        bool UserExists(string email, string password);

        bool UserIsApproved(string email);

        IEnumerable<UsersListingAdminModel> AllUsers();
    }
}
