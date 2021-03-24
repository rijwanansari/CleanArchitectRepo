using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using UserSelfDesk.Applcaiton.Master;
using UserSelfDesk.Applcaiton.Master.Dto;

namespace UserSelfDesk.AppWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MasterController : ControllerBase
    {
        private readonly IMasterService masterService;
        public MasterController(IMasterService masterService)
        {
            this.masterService = masterService;
        }
        [HttpGet("GetAllAppSetting")]
        public async Task<IActionResult> GetAllAppSetting()
        {
            return Ok(await masterService.GetAllAppSetting());
        }
        [HttpPost("UpsertAppSetting")]
        public async Task<IActionResult> UpsertAppSetting(AppSettingViewModel appSettingViewModel)
        {
            return Ok(await masterService.UpsertAppSetting(appSettingViewModel));
        }
    }
}
