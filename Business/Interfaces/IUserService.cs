using Business.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        bool CreateUser(UserModel user);
        IEnumerable<UserModel> GetAll();
    }
}