using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.Json;
using Model;

public class boardContext : DbContext
{
        public DbSet<Board> board { get; set; }
        public string DbPath { get; }

        public boardContext()
        {
            DbPath = "bin/board.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Todos>().ToTable("Tasks");
        }
    }
