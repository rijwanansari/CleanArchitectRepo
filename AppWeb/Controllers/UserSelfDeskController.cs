using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.UserSelfDesk;

namespace UserSelfDesk.AppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserSelfDeskController : ControllerBase
    {
        //private readonly IActiveDirectoryService _activeDirectoryService;
        //public UserSelfDeskController(IActiveDirectoryService activeDirectoryService)
        //{
        //    _activeDirectoryService = activeDirectoryService;
        //}
        //[HttpGet("GetActiveDirectorySetting")]
        //public async Task<IActionResult> GetActiveDirectorySetting()
        //{
        //    return Ok(await _activeDirectoryService.GetActiveDirectorySetting());
        //}

        //[HttpGet("GetUserDetailsByUserAccount")]
        //public async Task<IActionResult> GetUserDetailsByUserAccount(string userAccunt)
        //{
        //    return Ok(await _activeDirectoryService.GetUserDetailsByUserAccount(userAccunt));
        //}
    }
}
