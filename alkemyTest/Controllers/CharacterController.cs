using alkemyTest.dbContext;
using alkemyTest.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alkemyTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private ApplicationDbContext _context;
        public CharacterController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/<CharacterController>
        [HttpGet("Character")]
        [Authorize]
        public async Task<List<Character>> Get()
        {

            List<Character> lsc = null;

            try
            {
                lsc = await _context.Characters.ToListAsync();
                //return lsc;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
            }

            return lsc;

        }

        [HttpPost]
        public async Task<Character> Create(Character character)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // update the ef core context in memory 
                    _context.Add(character);

                    // sync the changes of ef code in memory with the database
                    await _context.SaveChangesAsync();

                    // return RedirectToAction("Index");
                    return character;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            // We return the object back to view
            return character;
        }

        // PUT api/<CharacterController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<CharacterController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

       
    }
}
