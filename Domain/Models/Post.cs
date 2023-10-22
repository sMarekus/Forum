namespace Domain.Models;

public class Post
{
    public int id { get; set; }
    public User owner { get; }
    public string title { get; }
    public string description { get; }

    public Post(User owner, string title, string description)
    {
        this.owner = owner;
        this.title = title;
        this.description = description;
    }
}