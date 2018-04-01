using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace Demo.Domain.Model.Migrations
{
    public partial class InitData : Migration
    {
        /// <summary>
        /// Плохой пример добавления данных в базу, но по EF не позволяет пользоваться контекстом в миграциях
        /// </summary>
        /// <param name="migrationBuilder"></param>
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var builder = new DbContextOptionsBuilder<ModelContext>();
            builder.UseSqlite("Data Source=./DemoContext.db");


            using (var _context = new ModelContext(builder.Options))
            {
                var task1 = new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task 1"
                };
                var task2 = new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task 2"
                };

                var task3 = new Task
                {
                    Id = Guid.NewGuid(),
                    Title = "Task 3"
                };

                _context.Tasks.AddRange(task1, task2, task3);
                _context.SaveChanges();


                var usersTask1_1 = new UsersTask
                {
                    Id = Guid.NewGuid(),
                    Points = 10,
                    TaskId = task1.Id
                };

                var usersTask1_2 = new UsersTask
                {
                    Id = Guid.NewGuid(),
                    Points = 20,
                    TaskId = task2.Id
                };

                var usersTask2_2 = new UsersTask
                {
                    Id = Guid.NewGuid(),
                    Points = 22,
                    TaskId = task2.Id
                };

                var usersTask2_3 = new UsersTask
                {
                    Id = Guid.NewGuid(),
                    Points = 33,
                    TaskId = task3.Id
                };

                _context.Users.AddRange(
                    new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "User1",
                        UsersTasks = new List<UsersTask> {usersTask1_1, usersTask1_2}
                    },

                    new User
                    {
                        Id = Guid.NewGuid(),
                        UserName = "User2",
                        UsersTasks = new List<UsersTask> {usersTask2_2, usersTask2_3}
                    }
                );
                _context.SaveChanges();
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("TRUNCATE TABLE [Tasks]");
            migrationBuilder.Sql("TRUNCATE TABLE [Users]");
            migrationBuilder.Sql("TRUNCATE TABLE [UsersTasks]");
        }
    }
}
