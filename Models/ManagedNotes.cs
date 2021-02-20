using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NotesManagementApp.Models
{
    public class ManagedNotes
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        public string Secret { get; set; }
    }
}
