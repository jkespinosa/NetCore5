using alkemyTest.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace alkemyTest.Services.Contracts
{
    public interface ICharacterService
    {
        Task<List<CharacterModel>> GetCharacters();
        Task<Character> GetCharacterById(Guid id);
        Task<Character> AddCharacter(Character character);
        Task<bool> UpdateCharacter(Guid id, Character character);
        Task<bool> DeleteCharacter(Guid id);


    }
}
