using Assignment1.Data;
using Assignment1.Models;

namespace Assignment1.Services.Impls;

// dummy database 
public class UserService : IUserService
{
    private List<User> users = new();
    public Task<User?> GetUserAsync(string username)
    {
        if (users.Count()== 0)
        {
            createUser();
        }

        User find = users.Find(user => user.UserName.Equals(username));
        return Task.FromResult(find);
    }


    private void  createUser()
    {
        FileUserContext fl = new FileUserContext();
        users = fl.Users;
       // User us = new User("Sami", "1234");
        //users.Add(us);
    }
    
    public  Task<User?> AddUserAsync(string username,string password)
    {
        User us = new User(username,password); // Get user from database
        users.Add(us);
        
        FileUserContext fl = new FileUserContext();
        fl.addUser(us);
        
        
        User find = users.Find(user => user.UserName.Equals(username));
        return Task.FromResult(find);
       
    }
    
}