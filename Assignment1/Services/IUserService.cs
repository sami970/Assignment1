using Assignment1.Models;

namespace Assignment1.Services;

public interface IUserService
{
    public Task<User?> GetUserAsync(string username);
    public Task<User?> AddUserAsync(string username, string password);
}