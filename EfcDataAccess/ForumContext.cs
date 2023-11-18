﻿using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace EfcDataAccess;

public class ForumContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source = ../EfcDataAccess/Forum.db");
        optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);            
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>().HasKey(post => post.Id);
        modelBuilder.Entity<User>().HasKey(user => user.Id);
        modelBuilder.Entity<Post>().Property(p => p.Title).IsRequired();
        modelBuilder.Entity<Post>().Property(p => p.Description).IsRequired();
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Owner);
    }
}