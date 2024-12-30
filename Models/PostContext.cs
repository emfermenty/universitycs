using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Web;
using Npgsql;

public class PostContext : DbContext
{
    public DbSet<Post> Posts { get; set;}
    public DbSet<Category> Categories { get; set;}
    public DbSet<Author> Authors { get; set;}
    public DbSet<PostCategory> PostCategories { get; set;}
    
}

