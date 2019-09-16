using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Reports;

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
                       
            groupService.ConnectUserToGroup(user, group);

            return Ok("User added to Group #" + group.Id);
        }

        [HttpGet("report")]
        public ActionResult Report(
            [FromServices] GroupService groupService,
            [FromServices] ReportService reportService,
            [FromServices] ExportService exportService
        )
        {
            var groups = groupService.GetGroups();

            var report = reportService.CreateGroupReport(groups);

            var text = exportService.ToText(report);

            return File(new System.Text.UTF8Encoding().GetBytes(text), "text/plain", "Report.txt");
        }



        // GET users
        [HttpGet("users")]
        public ActionResult<IEnumerable<string>> GetUsers([FromServices] UserService userService)
        {
            return Ok(userService.GetUsers());
        }

        // GET groups
        [HttpGet("groups")]
        public ActionResult<IEnumerable<string>> GetGroups([FromServices] GroupService groupService)
        {
            return Ok(groupService.GetGroups());
        }


    }
}
