﻿using System.Numerics;
public class Post{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Author Author { get; set; }
    public int post_rating {  get; set; }
    /*public void like(Post post)
    {
        post.post_rating++;
    }
    public void dislike(Post post)
    {
        post.post_rating--;
    }*/
}
