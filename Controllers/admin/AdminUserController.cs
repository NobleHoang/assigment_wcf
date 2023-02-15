using AutoMapper;
using baseNetApi.config;
using baseNetApi.models.user;
using baseNetApi.service.interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace baseNetApi.Controllers.admin;

[Route("admin/api/user")]
[Authorize]
[ApiController]
public class AdminUserController : ControllerBase
{
    private IUserService _userService;
    private IMapper _mapper;
    private readonly AppSettings _appSettings;
    
    public AdminUserController(
        IUserService userService,
        IMapper mapper,
        IOptions<AppSettings> appSettings)
    {
        _userService = userService;
        _mapper = mapper;
    }
    
    [Authorize(Policy = "Admin")]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [Authorize(Policy = "Admin")]
    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var user = _userService.GetById(id);
        return Ok(user);
    }
    
    [Authorize(Policy = "Admin")]
    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _userService.Create(model);
        return Ok(new { message = "User created" });
    }
    
    [Authorize(Policy = "Admin")]
    [HttpPut("change-pass/{id}")]
    public IActionResult ChangPass(int id, ChangePasswordRequest model)
    {
        _userService.ChangPass(id, model);
        return Ok(new { message = "Change Password Success!" });
    }

    [Authorize(Policy = "Admin")]
    [HttpPut("update-info/{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _userService.UpdateInfo(id, model);
        return Ok(new { message = "User updated" });
    }

    [Authorize(Policy = "Admin")]
    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _userService.Delete(id);
        return Ok(new { message = "User deleted" });
    }
}