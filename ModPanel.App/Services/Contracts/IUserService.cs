using ModPanel.App.Data.Models;

namespace ModPanel.App.Services.Contracts
{
    public interface IUserService
    {
        bool Create(string email, string password, PositionType position);

        bool UserExists(string email, string password);
    }
}
