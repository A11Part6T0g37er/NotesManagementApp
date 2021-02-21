﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagementApp.Models
{
    interface IRepository<T> : IDisposable where T : class
    
    {
        IEnumerable<T> GetNotesList(); // get All objects
        T GetNote(long id); // get exact note
        void Create(T item); // create new note
        void Update(long id); // update note by id
        void Delete(long id); //delete note by id
        void Save();  // save changes
    }
}
