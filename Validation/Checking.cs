using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Banking_system.DataBase;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using Banking_system.DataInstanse;

namespace Banking_system.Validation
{
    public class Checking
    {

        public static async Task<bool> ExistedUser(String username,ApplicationDbContext _context)
        {
            var user = await _context.appUser.AnyAsync(x => x.userName == username);
            if (user == false) return false;
            return true;
        }
        public static bool checkPassword(AppUser user, string password)
        {
            var hash = new HMACSHA512(user.passwordSalt);
            var comPassword = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            if (comPassword.Length == user.passwordHash.Length)
            {
                for (int i = 0; i < comPassword.Length; i++)
                {
                    if (comPassword[i] != user.passwordHash[i])
                        return false;
                }
            }
            else
                return false;
            return true;

        }
    }
}