
using Business.Entites;
using Business.Helpers;
using Business.Models;

namespace Business.Factories;

public static class UserEntityFactory
{
    public static UserEntity Create(UserModel user)
    {
        return new UserEntity
        {
            Id = GenerateUniqeId.GenerateId(),
            FirstName = user.FirstName,
            LastName = user.LastName,
            Email = user.Email,
            Phone = user.Phone,
            Adress = user.Adress,
            PostalCode = user.PostalCode,
            City = user.City,
            CreatedDate = DateTime.Now
        };
    }
}
  