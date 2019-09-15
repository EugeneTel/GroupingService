using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Api.Controllers
{
    [Route("/")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        // GET addUser?name=[name]&skill=[double]&remoteness=[int]
        [HttpGet("addUser")]
        public ActionResult<string> AddUser(
            [FromServices] UserService userService,
            [FromServices] GroupService groupService,
            [FromQuery] string name,
            [FromQuery] float skill,
            [FromQuery] int remoteness
        )
        {
            var user = userService.CreateUser(name, skill, remoteness);

            var group = groupService.GetGroupForUser(user);
                       
            userService.ConnectUserToGroup(user, group);

            return Ok("User added to Group #" + group.Id);
        }



        // GET api/users
        [HttpGet("users")]
        public ActionResult<IEnumerable<string>> Get([FromServices] UserService userService)
        {
            return Ok(userService.GetUsers());
        }

    }
}
