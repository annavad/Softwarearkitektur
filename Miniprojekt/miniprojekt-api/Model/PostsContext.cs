using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
namespace Data
{
 public class PostsContext : DbContext
    {
        public DbSet<Posts> Post => Set<Posts>();
        public DbSet<Users> User => Set<Users>();


        public PostsContext (DbContextOptions<PostsContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}