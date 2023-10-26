using Domain.DTOs;
using Domain.Models;

namespace HttpClients.ClientInterfaces;

public interface IPostService
{
    Task CreateAsync(PostCreationDto dto);
    Task<IEnumerable<Post>> GetPosts(string? titleContains = null);
    Task<Post> GetPostById(int id);

}