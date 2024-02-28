using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
 public class PostsContext : DbContext
    {
        public DbSet<Post> Posts => Set<Post>();
        public DbSet<User> Users => Set<User>();


        public BookContext (DbContextOptions<PostsContext> options)
            : base(options)
        {
            // Den her er tom. Men ": base(options)" sikre at constructor
            // på DbContext super-klassen bliver kaldt.
        }
    }
}