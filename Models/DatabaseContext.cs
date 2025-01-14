using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Web;
using Npgsql;

public class DataBaseContext : DbContext
{
    public DbSet<Post> Posts { get; set;}
    public DbSet<Category> Categories { get; set;}
    public DbSet<Author> Authors { get; set;}
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Username=postgres;Password=master");
    }

}

