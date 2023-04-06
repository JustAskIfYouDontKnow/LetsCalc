using LetsCalc.Database.Models;

namespace LetsCalc.Database;

public interface IUserData
{
    public Task<Dictionary<string, UserModel>> GetData();
}