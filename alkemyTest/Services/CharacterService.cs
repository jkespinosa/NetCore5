using alkemyTest.dbContext;
using alkemyTest.Models;
using alkemyTest.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace alkemyTest.Services
{
    public class CharacterService : ICharacterService
    {
        public readonly ApplicationDbContext _dbContext;
        public CharacterService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<Character> GetCharacterById(Guid id)
        {
            return await _dbContext.Characters.Where(s => s.Id == id).FirstOrDefaultAsync();

        }

        public async Task<List<CharacterModel>> GetCharacters()
        {

           return await _dbContext.Characters.Select(n=> new CharacterModel { Img= n.Img , FirstName = n.FirstName, LastName= n.LastName}).ToListAsync();

        }

        public async Task<Character> AddCharacter(Character character)
        {

            _dbContext.Add(character);

            await _dbContext.SaveChangesAsync();

            return character;

        }

        public async Task<bool> UpdateCharacter(Guid id, Character model)
        {

            var exist = _dbContext.Characters.Where(x => x.Id == model.Id).FirstOrDefault();
            try
            {
                if (exist != null)
                {
                    exist.FirstName = model.FirstName;
                    exist.LastName = model.LastName;
                    exist.Age = model.Age;
                    exist.History = model.History;
                    exist.Weight = model.Weight;

                    await _dbContext.SaveChangesAsync();

                    return true;

                }
            }
            catch
            {
                return false;
            }

            return false;

        }

        public async Task<bool> DeleteCharacter(Guid id)
        {

            try
            {
                var exist = _dbContext.Characters.Where(x => x.Id == id).FirstOrDefault();

                if (exist != null)
                {
                    _dbContext.Remove(exist);
                    await _dbContext.SaveChangesAsync();

                    return true;
                }
            }
            catch
            {
                return false;

                //   throw new NotImplementedException();
            }

            return false;

        }

    }
}