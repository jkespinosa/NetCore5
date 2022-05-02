using alkemyTest.Models;
using alkemyTest.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace alkemyTest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public class CharacterController : ControllerBase
    {
        private readonly ICharacterService _characterService;
        public CharacterController(ICharacterService patient)
        {
            _characterService = patient;
        }


        [HttpGet]
         [Authorize]
        public async Task<IActionResult> Get()
        {
            try
            {
                var characters = await _characterService.GetCharacters();

                return Ok(characters);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPost]
          [Authorize]
        public async Task<Character> Create(Character character)
        {
            if (ModelState.IsValid)
            {
                return await _characterService.AddCharacter(character);
            }

            ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            return character;
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> Put(Guid id, Character model)
        {
            // validate that our model meets the requirement
            if (ModelState.IsValid)
            {
                try
                {
                    if (id != model.Id)
                    {
                        ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");
                        return NotFound();
                    }
                    else
                    {
                        var addNew = await _characterService.UpdateCharacter(id, model);

                        if (addNew == true)
                            return Ok(model);
                        else
                            ModelState.AddModelError(string.Empty, $"Something went wrong ");
                    }
                }

                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
                }


                ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");

            }
            return NotFound();

        }
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id, Character model)
        {

            try
            {
                if (id != model.Id)
                {
                    ModelState.AddModelError(string.Empty, $"Something went wrong, invalid model");
                    return NotFound();
                }
                else
                {

                    var Del = await _characterService.DeleteCharacter(id);

                    if (Del == true)
                        return Ok(model);
                    else
                        ModelState.AddModelError(string.Empty, $"Something went wrong ");

                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, $"Something went wrong {ex.Message}");
            }
            return NotFound();


        }

    }
}
