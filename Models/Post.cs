using System.Numerics;
public class Post{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    //public Author Author { get; set; }
    public int post_rating {  get; set; }
    //public ICollection<PostCategoryes> posts_category { get; set; }
    public Post(int id, string name, string description, int rating)
    {
        this.Id = id;
        this.Name = name;
        this.Description = description;
        this.post_rating = rating;
    }
}
