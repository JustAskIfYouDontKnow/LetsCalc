using LetsCalc.Database.Models;

namespace LetsCalc.Database;

public interface IUserRepository
{
    public Task<UserModel?> GetOne(string login, string password);
}