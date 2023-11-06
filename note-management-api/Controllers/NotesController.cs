using Core.Handlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.DTO;
using System.Net;
using System.Reflection.Metadata;

namespace note_management_api.Controllers
{
    [ApiController]
    [Route("api/notes")]
    public class NotesController : ControllerBase
    {
        private readonly NotesHandler _notesHandler;

        public NotesController(NotesHandler notesHandler)
        {
            _notesHandler = notesHandler;
        }

        /// <summary>
        /// Returns a single note starting from the id
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<NoteDTO>> GetNoteById(int id)
        {
            try
            {
                var note = await _notesHandler.GetNoteById(id);
                return note != null ? Ok(note) : NotFound();
            }
            catch (Exception ex)
            {
                return this.NotFound($"Error {ex.Message}");
            }

        }

        /// <summary>
        /// Returns all notes
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<NoteDTO>>> GetAllNotes()
        {
            try
            {
                var notes = await _notesHandler.GetAllNotes();
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return this.NotFound($"Error {ex.Message}");
            }

        }

        /// <summary>
        /// Create or update a note
        /// </summary>
        [HttpPost("createOrUpdate")]
        public async Task<ActionResult<NoteDTO>> CreateOrUpdateNote(NoteDTO note)
        {
            try
            {
                var notes = await _notesHandler.CreateOrUpdateNote(note);
                return Ok(notes);
            }
            catch (Exception ex)
            {
                return this.NotFound($"Error {ex.Message}");
            }

        }

        /// <summary>
        /// Delete note
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNote(int id)
        {
            try
            {
                await _notesHandler.DeleteNote(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return this.NotFound($"Error {ex.Message}");
            }

        }
    }
}
