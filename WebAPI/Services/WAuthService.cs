using System.ComponentModel.DataAnnotations;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace WebAPI.Services;

public class WAuthService : IWAuthService
{
    private readonly IUserLogic userLogic;

    public WAuthService(IUserLogic userLogic)
    {
        this.userLogic = userLogic;
    }

    public async Task<User> GetUser(string username, string password)
    {
        SearchUserParametersDto parameters = new(username);
        IEnumerable<User> users = await userLogic.GetAsync(parameters);
        User? user = users.FirstOrDefault(u => u.Username.Equals(username, StringComparison.OrdinalIgnoreCase));
        if (user != null)
        {
            return user;
        }
        else
        {
            throw new Exception("List of users empty.");
        }
        
    }
    
    public async Task<User> ValidateUser(User user)
    {
        SearchUserParametersDto parameters = new(user.Username);
        IEnumerable<User> users = await userLogic.GetAsync(parameters);
        User? existingUser = users.FirstOrDefault(u => 
            u.Username.Equals(user.Username, StringComparison.OrdinalIgnoreCase));
        Console.WriteLine($"Username: {existingUser.Username}, Password: {existingUser.Password}");
        
        if (existingUser == null)
        {
            throw new Exception("User not found");
        }

        if (!existingUser.Password.Equals(user.Password))
        {
            throw new Exception("Password mismatch");
        }

        return existingUser;
    }
    

    public Task RegisterUser(User user)
    {
        if (string.IsNullOrEmpty(user.Username))
        {
            throw new ValidationException("Username cannot be null");
        }

        if (string.IsNullOrEmpty(user.Password))
        {
            throw new ValidationException("Password cannot be null");
        }

        UserCreationDto dto = new UserCreationDto(user.Username, user.Password);

        userLogic.CreateAsync(dto);
        
        return Task.CompletedTask;
    }
}