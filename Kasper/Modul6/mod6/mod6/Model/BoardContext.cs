using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class TaskContext : DbContext
    {
        public DbSet<Todo> Todos { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public string DbPath { get; }

        public TaskContext()
        {
            DbPath = "C:\\Users\\Bruger\\Desktop\\3. sem\\Softwarearkitektur\\sem3_opgaver\\Kasper\\Modul6\\mod6\\mod6\\bin\\TodoTask.db";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite($"Data Source={DbPath}");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Board>().ToTable("Boards");
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Todo>().ToTable("Todos");
        }
    }
}
