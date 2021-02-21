using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagementApp.Models
{
   
    public class NotesRepository : RepositoryBase<ManagedNotes>, INotesRepository
    {
        protected new RepositoryContext RepositoryContext { get; set; }
        public NotesRepository(RepositoryContext repositoryContext): base (repositoryContext)
         {
             RepositoryContext = repositoryContext;
        }
        public async Task<IEnumerable<ManagedNotes>> GetAllNotesAsync()
        {
            return await FindAll()
               .OrderBy(ow => ow.Name)
               .ToListAsync();
        }

        public async Task<ManagedNotes> GetNoteByIdAsync(long noteId)
        {
            return await FindByCondition(owner => owner.Id.Equals(noteId))
                .FirstOrDefaultAsync();
        }

       

        public void CreateNote(ManagedNotes note)
        {
           RepositoryContext.Notes.Add(note);
            SaveChangesAsync();
        }

        public void UpdateNote(ManagedNotes note)
        {
            RepositoryContext.Entry(note).State = EntityState.Modified;
            SaveChangesAsync();
        }

        public void DeleteNote(ManagedNotes note)
        {
            RepositoryContext.Notes.Remove(note);
            SaveChangesAsync();
        }


        public async Task SaveChangesAsync()
        {
            await RepositoryContext.SaveChangesAsync();
        }

    }
}
