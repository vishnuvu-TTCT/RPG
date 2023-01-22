global using AutoMapper;
using RPG.Data;
using RPG.Dtos.Character;
using RPG.Models;

namespace RPG.Services.CharacterService
{
    public class CharacterService : ICharacterService
    {

        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public CharacterService(IMapper mapper, DataContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        private static List<Character> characters = new List<Character>
        {
            new Character(),
            new Character{Name = "Sam",}
        };
        public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto Newcharacter)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var character = _mapper.Map<Character>(Newcharacter);
            character.Id = characters.Max(x => x.Id) +1;
            characters.Add(character);
            serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> DeteleCharacter(int id)
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();

            try
            {
                var character = characters.First(c => c.Id == id);
                if (character is null)
                {
                    throw new Exception($"Character with ID '{id}' not found");
                }
                characters.Remove(character); 
                serviceResponse.Data = characters.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList(); ;
            }
            catch (Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message = ex.Message;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacter()
        {
            var serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
            var dbCharacter = await _context.Characters.ToListAsync();
            serviceResponse.Data = dbCharacter.Select(c => _mapper.Map<GetCharacterDto>(c)).ToList();
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();
            var character = characters.FirstOrDefault(c => c.Id == id);
            serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            return serviceResponse;
        }

        public async Task<ServiceResponse<GetCharacterDto>> UpdateCharacter(UpdateCharacterDto updatedCharacter)
        {
            var serviceResponse = new ServiceResponse<GetCharacterDto>();

            try
            {
                var character = characters.FirstOrDefault(c => c.Id == updatedCharacter.Id);
                if(character is null)
                {
                    throw new Exception($"Character with ID '{updatedCharacter.Id}' not found");
                }
                _mapper.Map(updatedCharacter, character);
                serviceResponse.Data = _mapper.Map<GetCharacterDto>(character);
            }
            catch(Exception ex)
            {
                serviceResponse.Success = false;
                serviceResponse.Message= ex.Message;
            }

            return serviceResponse ;
        }

    }
}
