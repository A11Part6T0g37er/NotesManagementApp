using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NotesManagementApp.Models;

namespace NotesManagementApp.Controllers
{
    [Route("api/ManagedNotes")]
    [ApiController]
    public class ManagedNotesController : ControllerBase
    {
        private readonly IRepository<ManagedNotes> _context;

        public ManagedNotesController(NotesContext context)
        {
            _context = new NotesRepository(context);
        }

        // GET: api/ManagedNotes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ManagedNotesDTO>>> GetNotes()
        {
            return await _context.GetNotesList().Select(x => NotesToDTO(x)).ToListAsync();
        }

        // GET: api/ManagedNotes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ManagedNotesDTO>> GetManagedNotes(long id)
        {
            var managedNotes = await _context.Notes.FindAsync(id);

            if (managedNotes == null)
            {
                return NotFound();
            }

            return NotesToDTO(managedNotes);
        }

        // PUT: api/ManagedNotes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutManagedNotes(long id, ManagedNotesDTO managedNotesDTO)
        {
            if (id != managedNotesDTO.Id)
            {
                return BadRequest();
            }

            var managedNotes = await _context.Notes.FindAsync(id);

            if (managedNotes == null)
            {
                return NotFound();

            }

            managedNotes.IsComplete = managedNotesDTO.IsComplete;
            managedNotes.Name = managedNotesDTO.Name;
           
            _context.Entry(managedNotes).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ManagedNotesExists(id))
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

        // POST: api/ManagedNotes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ManagedNotesDTO>> PostManagedNotes(ManagedNotesDTO managedNotesDTO)
        {
            var managedNotes = new ManagedNotes
            {
                IsComplete = managedNotesDTO.IsComplete,
                Name = managedNotesDTO.Name
            };
            _context.Notes.Add(managedNotes);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetManagedNotes), new { id = managedNotesDTO.Id }, managedNotesDTO);
            //return CreatedAtAction("GetManagedNotes", new { id = managedNotes.Id }, managedNotes);
        }

        // DELETE: api/ManagedNotes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteManagedNotes(long id)
        {
            var managedNotes = await _context.Notes.FindAsync(id);
            if (managedNotes == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(managedNotes);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ManagedNotesExists(long id) => _context.Notes.Any(e => e.Id == id);
        
        private static ManagedNotesDTO NotesToDTO(ManagedNotes todoItem) =>
            new ManagedNotesDTO
            {
                Id = todoItem.Id,
                Name = todoItem.Name,
                IsComplete = todoItem.IsComplete
            };
    }
}
