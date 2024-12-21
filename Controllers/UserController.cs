using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Banking_system.DataBase;
using Banking_system.DataInstanse;
using Banking_system.DTOs;
using Banking_system.Services;
using Banking_system.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Banking_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;

        public UserController(ILogger<UserController> logger, ApplicationDbContext context, TokenService tokenService)
        {
            _tokenService= tokenService;
            _logger = logger;
            _context = context;
        }
        
        [HttpGet("login")]
        public async Task<ActionResult<UserToken>> LogIn(LogInDto logInUser)
        {
            var user= await _context.appUser.FirstOrDefaultAsync(x=> x.userName==logInUser.username);
            if(user==null)return BadRequest("Wrong User Name");
            if(!Checking.checkPassword(user,logInUser.password))return BadRequest("Wrong password");
            return new UserToken
            {
                userName = user.userName,
                token = _tokenService.CreatToken(user)
            }; ;
        }
        [HttpPost("register")]
        public async Task<ActionResult<AppUser>> UserRegisteration([FromBody]RegisterDto register)
        {
            if(await Checking.ExistedUser(register.userName, _context)) return BadRequest("This UserName is taken");
            
            var hash =new HMACSHA512();

            var user =new AppUser{
                id = 0,
                name=register.name,
                userName=register.userName,
                Phone=register.Phone,
                address=register.address,
                passwordHash=hash.ComputeHash(Encoding.UTF8.GetBytes(register.password)),
                passwordSalt=hash.Key
                    
            };
            await _context.appUser.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok(user);
        }
     
        

    }
}