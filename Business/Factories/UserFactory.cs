
using Business.Models;

namespace Business.Factories;

public static class UserFactory
{
    public static UserModel Create()
    {
        return new UserModel();
    }

}
