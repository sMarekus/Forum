namespace Domain.Models;

public class Post
{
    public int Id { get; set; }
    public User Owner { get; private set; }
    public int OwnerId { get; set; }
    public string Title { get; private set; }
    public string Description { get; private set; }

    public Post(int ownerId, string title, string description)
    {
        OwnerId = ownerId;
        Title = title;
        Description = description;
    }
    
    private Post(){}
}