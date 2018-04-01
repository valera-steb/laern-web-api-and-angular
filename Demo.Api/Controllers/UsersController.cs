using System.Linq;
using Demo.Api.Model.Users;
using Demo.Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Api.Controllers
{
    [Route("api/[controller]")]
    public class UsersController: Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }


        [HttpGet]
        public object Get()
        {
            return _userService.GetUsersInfo();
        }


        [HttpPost]
        public object Post([FromBody] UserPostModel model)
        {
            if (!ModelState.IsValid)
                return new {error = ModelState.First()};

            return _userService.CreateUser(model.UserName);
        }
    }
}
