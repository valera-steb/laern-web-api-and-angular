using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Domain.Model;

namespace Demo.Domain.User
{
    public interface IUserService
    {
        IList<UserListInfo> GetUsersInfo();
        Model.User CreateUser(string userName);
    }

    public class UserService : IUserService
    {
        private readonly ModelContext _context;

        public UserService(ModelContext context)
        {
            _context = context;
        }


        public IList<UserListInfo> GetUsersInfo()
        {
            return _context.Users.Select(x => new UserListInfo
            {
                UserId = x.Id,
                UserName = x.UserName,
                AveragePoints = x.UsersTasks.Any()
                    ? x.UsersTasks.Sum(p => p.Points) / x.UsersTasks.Count
                    : 0
            })
                .ToList();
        }


        public Model.User CreateUser(string userName)
        {
            var user = new Model.User
            {
                Id = Guid.NewGuid(),
                UserName = userName
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            return user;
        }
    }
}
