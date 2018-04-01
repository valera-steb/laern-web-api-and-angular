using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Model
{
    public class User: DtoBase
    {
        public string UserName { get; set; }

        public ICollection<UsersTask> UsersTasks { get; set; }
    }
}
