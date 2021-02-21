using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace NotesManagementApp.Models
{
    public class NotesContext : DbContext
    {
        public NotesContext( DbContextOptions<NotesContext> options) : base(options)
        {
        }
        public NotesContext() { }
        public DbSet<ManagedNotes> Notes { get; set; }
    }
}
