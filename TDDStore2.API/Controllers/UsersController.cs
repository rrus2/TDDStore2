using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDDStore2.DataAccess.Models;

namespace TDDStore2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UsersController(ApplicationDbContext context)
        {
            _context = context;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();
            return users;
        }
        // GET/id
        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationUser>> GetUsers(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            return user;
        }
        //PUT/id
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, ApplicationUser user)
        {
            if (id != user.Id)
                return BadRequest();
            if (user == null)
                return NotFound();
            _context.Entry(user).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
                    return NotFound();
                else
                    throw;
            }
            return NoContent();
        }
        // POST/user
        [HttpPost]
        public async Task<ActionResult<ApplicationUser>> CreateUser(ApplicationUser user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        //DELETE/id
        [HttpDelete]
        public async Task<ActionResult<ApplicationUser>> DeleteUser(string id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return NotFound();
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            return user;
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
    }
}