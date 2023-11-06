
using AutoMapper;
using Core.Services;
using Models.DB;
using Models.DTO;


namespace Core.Handlers
{
    public class NotesHandler
    {
        private readonly IMapper _mapper;
        private readonly INotesService _notesService;

        public NotesHandler(INotesService notesService, IMapper mapper)
        {
            _mapper = mapper;
            _notesService = notesService;
        }

        public async Task<NoteDTO> GetNoteById(int id)
        {
            var note = await _notesService.GetNoteById(id);
            if (note == null)
            {
                return null;
            }
            return _mapper.Map<NoteDTO>(note);
        }

        public async Task<IEnumerable<NoteDTO>> GetAllNotes()
        {
            var notes = await _notesService.GetAllNotes();
            return notes.Select(note => _mapper.Map<NoteDTO>(note));
        }

        public async Task<NoteDTO> CreateOrUpdateNote(NoteDTO note)
        {
            var toReturn = _mapper.Map<NOTES>(note);
            if (note.Id != 0)
            {
                var noteFromDb = await _notesService.GetNoteById(note.Id);
                if (noteFromDb == null)
                {
                    throw new Exception("Note not found");
                }
                note.LastUpdate = DateTime.Now;
                toReturn = _mapper.Map(note, noteFromDb);
               // await _notesService.UpdateNote(toReturn);
            }
            else
            {
                toReturn.InsertDate = DateTime.Now; //Questo andrebbe fatto lato db con un default value, cosi come last update
                toReturn = await _notesService.CreateNote(toReturn);
            }
            //_notesService.
            await _notesService.Save();
            return _mapper.Map<NoteDTO>(toReturn);
        }

        public async Task DeleteNote(int id)
        {
            var noteToDelete = await _notesService.GetNoteById(id);
            if (noteToDelete == null)
                throw new Exception("Note not found");
            noteToDelete.FlgDeleted = true;
            noteToDelete.LastUpdate = DateTime.Now;
            await _notesService.Save();
        }




    }
}
