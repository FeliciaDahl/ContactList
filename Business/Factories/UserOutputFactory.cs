
using Business.Entites;
using Business.Models;

namespace Business.Factories;

public static class UserOutputFactory
{
    public static UserModel Create(UserEntity userEntity)
    {
        return new UserModel
        {
            FirstName = userEntity.FirstName,
            LastName = userEntity.LastName,
            Email = userEntity.Email,
            Phone = userEntity.Phone,
            Adress = userEntity.Adress,
            PostalCode = userEntity.PostalCode,
            City = userEntity.City
        };

    }
}
