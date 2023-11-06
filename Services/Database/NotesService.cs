using Core.Services;
using Microsoft.EntityFrameworkCore;
using Models.DB;
using Models.DTO;
using Services.Database.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Database
{
    public class NotesService : INotesService
    {
        private readonly AppDbContext _appDbContext;

        public NotesService(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<NOTES> GetNoteById(int id)
        {
            return await _appDbContext.NOTES.Where(note => note.Id == id && (note.FlgDeleted == false || note.FlgDeleted == null)).FirstOrDefaultAsync();
        }

        public async Task<List<NOTES>> GetAllNotes()
        {
            return await _appDbContext.NOTES.Where(note => note.FlgDeleted == false || note.FlgDeleted == null).ToListAsync();
        }

        public async Task<NOTES> CreateNote(NOTES note)
        {
            await _appDbContext.NOTES.AddAsync(note);
            await _appDbContext.SaveChangesAsync();
            return note;
        }
        public async Task Save()
        {
            await _appDbContext.SaveChangesAsync();
        }

        public async Task DeleteNote(NOTES note)
        {
            _appDbContext.Remove(note);
            await _appDbContext.SaveChangesAsync();
        }
    }
}
