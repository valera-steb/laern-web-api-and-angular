using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.Domain.Model
{
    public class UsersTask: DtoBase
    {
        public Guid UserId { get; set; }
        public Guid TaskId { get; set; }

        public int Points { get; set; }
    }
}
