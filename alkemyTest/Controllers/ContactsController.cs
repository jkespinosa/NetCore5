using alkemyTest.dbContext;
using alkemyTest.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alkemyTest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ContactsController : ControllerBase
    {
        private ApplicationDbContext _context;

        public ContactsController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        [HttpGet]
        public async Task<List<Contact>> Get()
        {
             List<Contact>  lsc = null;

            try
            {
                lsc = await _context.Contacts.ToListAsync();
                //return lsc;
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
            }

            return lsc;

        }



        [HttpPost]
        public async Task<Contact> Create(Contact contact)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // update the ef core context in memory 
                    _context.Add(contact);

                    // sync the changes of ef code in memory with the database
                    await _context.SaveChangesAsync();

                    // return RedirectToAction("Index");
                    return contact;
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            // We return the object back to view
            return contact;
        }

   

        [HttpPut]
        public async Task<Contact> Edit(Contact contact)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    // Check if the contact exist based on the id
                    var exist = _context.Contacts.Where(x => x.Id == contact.Id).FirstOrDefault();

                    // if the contact is not null we update the information
                    if (exist != null)
                    {
                        exist.FirstName = contact.FirstName;
                        exist.LastName = contact.LastName;
                        exist.Mobile = contact.Mobile;
                        exist.Email = contact.Email;

                        // we save the changes into the db
                        await _context.SaveChangesAsync();

                        //return RedirectToAction("Index");
                        return contact;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return contact;
        }

    

        [HttpDelete]
        public async Task<Contact> Delete(Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var exist = _context.Contacts.Where(x => x.Id == contact.Id).FirstOrDefault();

                    if (exist != null)
                    {
                        _context.Remove(exist);
                        await _context.SaveChangesAsync();

                        return contact;
                    }
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }
            }

            //ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return contact;
        }
    }
}
