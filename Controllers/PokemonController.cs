using Microsoft.AspNetCore.Mvc;
using PokedexApi.Integrations.PokeApi;
using PokedexApi.Interfaces;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonService _pokemonService;

        public PokemonController(IPokemonService pokemonService)
        {
            _pokemonService = pokemonService;
        }

        [HttpGet("{name}")]
        public async Task<ActionResult> GetById([FromRoute] string name)
        {
            try
            {
                var response = await _pokemonService.GetItemAsync(name);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("Random")]
        public async Task<ActionResult> GetRandom([FromQuery] int qtd = 10)
        {
            try
            {
                var response = await _pokemonService.GetRandomPokemons(qtd);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}