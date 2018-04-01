using System;

namespace Demo.Domain.User
{
    public class UserListInfo
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public double AveragePoints { get; set; }
    }
}
