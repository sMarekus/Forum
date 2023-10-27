using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IUserService
{
    Task<User> Create(UserCreationDto dto);

    Task<IEnumerable<User>> GetUser(string? usernameContains = null);
}