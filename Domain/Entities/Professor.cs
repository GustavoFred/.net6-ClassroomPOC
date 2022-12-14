using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Professor
    {
        public int ProfessorId { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string PIN { get; set; }
    }
}
