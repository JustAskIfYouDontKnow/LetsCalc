using LetsCalc.Database.Models;

namespace LetsCalc.Database;

public class UserRepository : IUserRepository
{
    private readonly IUserData _userData;


    public UserRepository(IUserData userData)
    {
        _userData = userData;
    }


    public async Task<UserModel?> GetOne(string login, string password)
    {
        var peoples = await _userData.GetData();

        if (peoples.TryGetValue(login.ToLower(), out var person) && person.Password == password)
        {
            return person;
        }

        return null;
    }
}