using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LeagueClient.Models.Context;

namespace LeagueClient.Controllers.API.V1
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ChampionsController : ControllerBase
    {
        private readonly LeagueClientContext _context;

        public ChampionsController(LeagueClientContext context)
        {
            _context = context;
        }

        // GET: api/v1/Champions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Champion>>> GetChampions()
        {
          if (_context.Champions == null)
          {
              return NotFound();
          }
            return await _context.Champions.ToListAsync();
        }

        // GET: api/v1/Champions/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Champion>> GetChampion(int id)
        {
          if (_context.Champions == null)
          {
              return NotFound();
          }
            var champion = await _context.Champions.FindAsync(id);

            if (champion == null)
            {
                return NotFound();
            }

            return champion;
        }

        // PUT: api/v1/Champions/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutChampion(int id, Champion champion)
        {
            if (id != champion.ChampionId)
            {
                return BadRequest();
            }

            _context.Entry(champion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ChampionExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/v1/Champions
        [HttpPost]
        public async Task<ActionResult<Champion>> PostChampion(Champion champion)
        {
          if (_context.Champions == null)
          {
              return Problem("Entity set 'LeagueClientContext.Champions'  is null.");
          }
            _context.Champions.Add(champion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChampion", new { id = champion.ChampionId }, champion);
        }

        // DELETE: api/v1/Champions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteChampion(int id)
        {
            if (_context.Champions == null)
            {
                return NotFound();
            }
            var champion = await _context.Champions.FindAsync(id);
            if (champion == null)
            {
                return NotFound();
            }

            _context.Champions.Remove(champion);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ChampionExists(int id)
        {
            return (_context.Champions?.Any(e => e.ChampionId == id)).GetValueOrDefault();
        }
    }
}
