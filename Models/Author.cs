﻿public class Author{
    public int id { get; set; }
    public string name { get; set; }
    public int ratings { get; set; }
    public ICollection<Post> Posts { get; set; }
}