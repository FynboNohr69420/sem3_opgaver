﻿// TaskContext.cs
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Model
{
    public class TaskContext : DbContext
    {
        public DbSet<TodoTask> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public string DbPath { get; }

        public TaskContext()
        {
            DbPath = "C:\\Users\\Bruger\\Desktop\\3. sem\\Softwarearkitektur\\sem3_opgaver\\Kasper\\Modul5\\ef-sjov\\bin\\TodoTask.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoTask>().ToTable("Tasks");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}