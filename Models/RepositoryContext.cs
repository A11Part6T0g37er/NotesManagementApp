using Microsoft.EntityFrameworkCore;
using System;

namespace NotesManagementApp.Models
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
        {
        }
        public RepositoryContext() { }
        public DbSet<ManagedNotes> Notes { get; set; }
    }
}