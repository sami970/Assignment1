using System.Text.Json;
using Assignment1.Models;


namespace Assignment1.Data;

public class FileUserContext
{
    private string userFilePath = "users.json";

    private List<User>? users;

    public List<User> Users
    {
        get
        {
            if (users == null)
            {
                LoadData();
            }

            return users!;
        }
       
    }

    public FileUserContext()
    {
        if (!File.Exists(userFilePath))
        {
            Seed();
        }
    }

    private void Seed()
    {
        users = new List<User>();
        
        User us = new User("Sami", "1234");
        users.Add(us);

        SaveChanges();
    }

    public void SaveChanges()
    {
        string serialize = JsonSerializer.Serialize(Users);
        File.WriteAllText(userFilePath, serialize);
        users = null;
    }

    public void addUser(User user)
    {
        Users.Add(user);
        this.SaveChanges();
    }
    private void LoadData()
    {
        string content = File.ReadAllText(userFilePath);
        users = JsonSerializer.Deserialize<List<User>>(content);
    }
}