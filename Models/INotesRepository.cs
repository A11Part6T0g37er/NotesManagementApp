using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagementApp.Models
{
   
   public interface INotesRepository : IRepositoryBase<ManagedNotes>
    {
        Task<IEnumerable<ManagedNotes>> GetAllNotesAsync();
        Task<ManagedNotes> GetNoteByIdAsync(long noteId);
       
        void CreateNote(ManagedNotes note);
        void UpdateNote(ManagedNotes note);
        void DeleteNote(ManagedNotes note);
    }
}
