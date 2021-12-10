using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Shop.DataModels.CustomModels;
using Shop.Logic.Services;

namespace Shop.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class AdminController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;
        private readonly IAdminService _adminService;

        public AdminController(IWebHostEnvironment env, IAdminService adminService)
        {
            _env = env;
            _adminService = adminService;
        }

        [HttpPost]
        [Route("AdminLogin")]
        public IActionResult AdminLogin(LoginModel loginModel)
        {
            var data = _adminService.AdminLogin(loginModel);
            return Ok(data);
        }
    }
}