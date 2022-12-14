using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalaAula
    {
        public int SalaAulaId { get; set; }
        public int SalaId { get; set; }
        public int ProfessorId { get; set; }
        public virtual Sala Sala { get; set; }
        public virtual Professor Professor { get; set; }
        public virtual ICollection<SalaAulaAluno> AlunosList { get; set; }
    }
}
