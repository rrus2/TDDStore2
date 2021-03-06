﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TDDStore2.DataAccess.Models;
using TDDStore2.DataAccess.VIewModels;

namespace TDDStore2.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        // GET
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ApplicationUser>>> GetUsers()
        {
            var users = await _context.Users.Include(x => x.Orders).ToListAsync();
            return Ok(users);
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
        public async Task<IActionResult> UpdateUser(string id, UserViewModel model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (id != user.Id)
                return BadRequest();
            if (user == null)
                return NotFound();
            user.Email = model.Email;
            user.Birthdate = model.Birthdate;
            user.UserName = model.Email;
            user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, model.RepeatPassword);
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
        public async Task<ActionResult<ApplicationUser>> CreateUser(UserViewModel model)
        {
            //await _context.Users.AddAsync(user);
            var user = new ApplicationUser { Email = model.Email, Birthdate = model.Birthdate, UserName = model.Email };
            await _userManager.CreateAsync(user, model.RepeatPassword);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }
        //DELETE/id
        [HttpDelete]
        public async Task<ActionResult<ApplicationUser>> DeleteUser(string id)
        {
            //var user = await _context.Users.FindAsync(id);
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null)
                return NotFound();
            //_context.Users.Remove(user);
            await _userManager.DeleteAsync(user);
            await _context.SaveChangesAsync();
            return Ok(user);
        }
        private bool UserExists(string id)
        {
            return _context.Users.Any(x => x.Id == id);
        }
    }
}