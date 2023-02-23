using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using RPG.Dtos.Character;
using RPG.Models;
using System.Security.Claims;

namespace RPG.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[Controller]")]
    public class CharacterController : Controller
    {
      
        private readonly ICharacterService _characterService;

        public CharacterController(ICharacterService characterService)
        {
            _characterService = characterService;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> GetCharacters()
        {
            return Ok(await _characterService.GetAllCharacter());
        }

        [HttpGet("{id}")]

        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> GetCharacter(int id)
        {
            return Ok(await _characterService.GetCharacterById(id));
        }

        [HttpPost]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> AddCharacter(AddCharacterDto Newcharacter)
        {
            return Ok(await _characterService.AddCharacter(Newcharacter));
        }

        [HttpPut]

        public async Task<ActionResult<ServiceResponse<List<GetCharacterDto>>>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var response = await _characterService.UpdateCharacter(updatedCharacter);
            if(response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }


        [HttpDelete("{id}")]

        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> deleteCharacter(int id)
        {
            var response = await _characterService.DeteleCharacter(id);
            if (response.Data == null)
            {
                return NotFound(response);
            }
            return Ok(response);
        }

        [HttpPost("Skill")]
        public async Task<ActionResult<ServiceResponse<GetCharacterDto>>> AddCharacterSkills(AddCharacterSkillDto newCharacterSkills)
        {
            return Ok(await _characterService.AddCharacterSkill(newCharacterSkills));
        }
    }
}
