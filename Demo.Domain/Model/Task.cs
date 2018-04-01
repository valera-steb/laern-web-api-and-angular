using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Model
{
    public class Task: DtoBase
    {
        public string Title { get; set; }

        public ICollection<UsersTask> UsersTasks { get; set; }
    }
}
