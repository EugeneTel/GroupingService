using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // addUser?name=Mike&skill=0.5&remoteness=50

        [HttpGet("addUser")]
        public ActionResult<string> AddUser(
            [FromServices] UserService userService,
            [FromServices] GroupService groupService,
            [FromQuery] string name,
            [FromQuery] float skill,
            [FromQuery] int remoteness
        )
        {
            var newUser = userService.CreateUser(name);

            var groupForUser = groupService.GetGroupForUser(newUser);

            userService.ConnectUserToGroup(newUser, groupForUser);

            return Ok("User was added " + newUser.Name);
        }



        // GET api/users
        [HttpGet("users")]
        public ActionResult<IEnumerable<string>> Get([FromServices] UserService userService)
        {
            return Ok(userService.GetUsers());
        }

    }
}
