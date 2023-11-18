using Application.DaoInterfaces;
using Application.LogicInterfaces;
using Domain.DTOs;
using Domain.Models;

namespace Application.Logic;

public class PostLogic : IPostLogic
{
    private readonly IPostDao postDao;
    private readonly IUserDao userDao;

    public PostLogic(IPostDao postDao, IUserDao userDao)
    {
        this.postDao = postDao;
        this.userDao = userDao;
    }

    public async Task<Post> CreateAsync(PostCreationDto dto)
    {
        User? user = await userDao.GetByIdAsync(dto.OwnerId);
        if (user == null)
        {
            throw new Exception($"User with id {dto.OwnerId} was not found! ");
        }

        ValidatePost(dto);
        Post post = new Post(user.Id, dto.Title, dto.Description);
        Post created = await postDao.CreateAsync(post);
        return created;
    }

    public Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        return postDao.GetAsync(searchParameters);
    }

    private void ValidatePost(PostCreationDto dto)
    {
        if (string.IsNullOrEmpty(dto.Title))
        {
            throw new Exception("Title cannot be empty! ");
        }
        else if (string.IsNullOrEmpty(dto.Description))
        {
            throw new Exception("Description cannot be empty! ");
        }
    }
    
    public Task<Post?> GetByIdAsync(int id)
    {
        return postDao.GetByIdAsync(id);
    }
}