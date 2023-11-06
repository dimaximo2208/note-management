

using Models.DB;
using Models.DTO;

namespace Core.Services
{
    public interface INotesService
    {
        Task<NOTES> GetNoteById(int id);
        Task<List<NOTES>> GetAllNotes();
        Task<NOTES> CreateNote(NOTES request);
        //Task<NOTES> UpdateNote(NOTES request);
        Task Save();
        Task DeleteNote(NOTES request);

    }
}
