using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PokedexApi.DTOs;
using PokedexApi.Interfaces;

namespace PokedexApi.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MestrePokemonController : ControllerBase
    {
        private readonly IMestrePokemonService _mestrePokemonService;
        private readonly IPokemonService _pokemonService;

        public MestrePokemonController(IMestrePokemonService mestrePokemonService, IPokemonService pokemonService)
        {
            _mestrePokemonService = mestrePokemonService;
            _pokemonService = pokemonService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById([FromRoute] int id)
        {
            try
            {
                var response = await _mestrePokemonService.GetItemAsync(id);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<ActionResult> GetList()
        {
            try
            {
                var response = await _mestrePokemonService.ListAsync();

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] InputMestreDTO dto)
        {
            try
            {
                var response = await _mestrePokemonService.CreateAsync(dto);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete([FromRoute] int id)
        {
            try
            {
                var response = await _mestrePokemonService.DeleteByIdAsync(id);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] InputMestreDTO dto)
        {
            try
            {
                var response = await _mestrePokemonService.UpdateAsync(dto);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("CapturaPokemon")]
        public async Task<ActionResult> CapturaPokemon([FromBody] InputCapturaPokemonDTO dto)
        {
            try
            {
                var response = await _mestrePokemonService.CapturaPokemon(dto.MestreId, dto.PokemonName);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}/Pokemons")]
        public async Task<ActionResult> PokemonsPorMestre([FromRoute] int id)
        {
            try
            {
                var response = await _pokemonService.GetPokemonsByMestreId(id);

                return Ok(response);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}