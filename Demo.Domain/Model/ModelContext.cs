using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Demo.Domain.Model
{
    public interface IModelContext
    {
        DbSet<Task> Tasks { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UsersTask> UsersTasks { get; set; }
    }

    public class ModelContext: DbContext
    {
        public DbSet<Task> Tasks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UsersTask> UsersTasks { get; set; }

        public ModelContext(DbContextOptions<ModelContext> options) : base(options) { }
    }
}
