namespace LetsCalc.Database.Models;

public class UserModel
{
    public int Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public string Password { get; set; }

    public Role Role { get; set; }

    public UserModel(int id, string firstName, string lastName, string password, Role role)
    {
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Password = password;
        Role = role;
    }

}


