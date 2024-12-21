using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Banking_system.DataInstanse;
using Banking_system.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Banking_system.DataBase;
using Microsoft.EntityFrameworkCore;
using Banking_system.Validation;
using Microsoft.AspNetCore.Authorization;

namespace Banking_system.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CashController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly ApplicationDbContext _context;

        public CashController(ILogger<UserController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpPut("sendCash")]
        public async Task<ActionResult<AppUser>> SendCash(SendCashDto requestToSendCash)
        {
            var sender = await _context.appUser.FirstOrDefaultAsync(x => x.userName == requestToSendCash.senderUsername);
            var receiver = await _context.appUser.FirstOrDefaultAsync(x => x.userName == requestToSendCash.receiverUserName);
            if (sender == null || receiver == null)
            {
                return BadRequest("error in user name");
            }
            if (!Checking.checkPassword(sender, requestToSendCash.password)) return BadRequest("Wrong password");

            if (receiver.Phone != requestToSendCash.receiverPhone)
            {
                return BadRequest("wrong phone number or username");
            }
            if (requestToSendCash.cash <= 0)
            {
                return BadRequest("you should send valid number of cash");
            }
            if (sender.balanc < requestToSendCash.cash)
            {
                return BadRequest("no enough balance in your account");
            }
            var senderBalance = sender.balanc;
            var receiverBalance = receiver.balanc;
            try
            {
                sender.balanc -= requestToSendCash.cash;
                receiver.balanc += requestToSendCash.cash;
                await _context.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
            

            return Ok(sender);
        }

    }
}