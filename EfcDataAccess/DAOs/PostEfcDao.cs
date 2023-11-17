using Application.DaoInterfaces;
using Domain.DTOs;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EfcDataAccess.DAOs;

public class PostEfcDao : IPostDao
{
    private readonly ForumContext context;

    public PostEfcDao(ForumContext context)
    {
        this.context = context;
    }
    public async Task<Post> CreateAsync(Post post)
    {
        EntityEntry<Post> newPost = await context.Posts.AddAsync(post);
        await context.SaveChangesAsync();
        return newPost.Entity;
    }

    public async Task<Post?> GetByIdAsync(int id)
    {
        Post? found = await context.Posts.Include(post => post.Owner).SingleOrDefaultAsync(post => post.Id == id);
        return found;
    }

    public async Task UpdateAsync(Post post)
    {
        context.Posts.Update(post);
        await context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Post>> GetAsync(SearchPostParametersDto searchParameters)
    {
        IQueryable<Post> query = context.Posts.Include(post => post.Owner).AsQueryable();
    
        if (!string.IsNullOrEmpty(searchParameters.Username))
        {
            // we know username is unique, so just fetch the first
            query = query.Where(post =>
                post.Owner.Username.ToLower().Equals(searchParameters.Username.ToLower()));
        }
    
        if (searchParameters.UserId != null)
        {
            query = query.Where(t => t.Owner.Id == searchParameters.UserId);
        }
    
        if (!string.IsNullOrEmpty(searchParameters.TitleContains))
        {
            query = query.Where(p =>
                p.Title.ToLower().Contains(searchParameters.TitleContains.ToLower()));
        }

        List<Post> result = await query.ToListAsync();
        return result;
    }
}