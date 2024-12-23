using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking_system.DataBase;
using Banking_system.DataInstanse;
using Banking_system.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Banking_system.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class TransactionRecordController : ControllerBase
    {

        private readonly ILogger<TransactionRecordController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly TokenService _tokenService;
        public TransactionRecordController(ILogger<TransactionRecordController>logger,ApplicationDbContext context, TokenService tokenService)
        {
            _tokenService = tokenService;
            _logger = logger;
            _context = context;
        }
        [HttpGet("AllTransaction,{username}")]
        public async Task<ActionResult> GetUserAllTransaction(string username)
        {
            var finduser =await _context.appUser.FirstOrDefaultAsync(x=>x.userName==username);
            if(finduser==null) return BadRequest();
         
            var transactions = _context.transaction.Where(t => t.senderId == finduser.id|| t.receiverId == finduser.id);
            
            return Ok(transactions);
        }
        [HttpGet("sendTransaction,{username}")]
        public async Task<ActionResult> GetUserSendTransaction(string username)
        {
            var finduser = await _context.appUser.FirstOrDefaultAsync(x => x.userName == username);
            if (finduser == null) return BadRequest();
            var transactions= _context.transaction.Where(t=>t.senderId==finduser.id);
            return Ok(transactions);
        }
        [HttpGet("receiveTransaction,{username}")]
        public async Task<ActionResult> GetUserreceiveTransaction(string username)
        {
            var finduser = await _context.appUser.FirstOrDefaultAsync(x => x.userName == username);
            if (finduser == null) return BadRequest();
            var transactions = _context.transaction.Where(t => t.receiverId == finduser.id);
            return Ok(transactions);
            
        }
    }
}