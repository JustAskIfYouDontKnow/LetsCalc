using LetsCalc.Database.Models;

namespace LetsCalc.Database;

public class UserData : IUserData
{
    private static readonly Dictionary<string, UserModel> Users = new()
    {
        { "admin", new UserModel(1,"John", "Doe", "12345", Role.Admin) },
        { "my_acc", new UserModel(2,"John", "John", "12345", Role.User) },
        { "testuser", new UserModel(3,"Jane", "Doe", "lastpass", Role.User) },
    };


    public Task<Dictionary<string, UserModel>> GetData()
    {
        return Task.FromResult(Users);
    }
}