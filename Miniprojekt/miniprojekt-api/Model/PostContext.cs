using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Model;
namespace Data
{
 public class PostContext : DbContext
    {
        public DbSet<Post> Post => Set<Post>();
        public DbSet<User> User => Set<User>();


        public PostContext (DbContextOptions<PostContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}