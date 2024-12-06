
using Business.Entites;
using Business.Factories;
using Business.Interfaces;
using Business.Models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
namespace Business.Services;

public class UserService(IFileService fileService) : IUserService
{
    private readonly IFileService _fileService = fileService;

    private List<UserEntity> _users = [];

    public bool CreateUser(UserModel user)
    {
        try
        {
            var userEntity = UserEntityFactory.Create(user);
            _users.Add(userEntity);
            _fileService.SaveListToFile(_users);

            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
            return false;
        }
    }

    public IEnumerable<UserModel> GetAll()
    {
        _users = _fileService.LoadListFromFile();

        var list = new List<UserModel>();

        foreach (var user in _users)
            list.Add(UserOutputFactory.Create(user));

        
        return list;
    }

   
}
