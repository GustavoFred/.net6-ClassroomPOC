using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class SalaAulaAluno
    {
        public int SalaAulaAlunoId { get; set; }
        public int SalaAulaId { get; set; }
        public int AlunoId { get; set; }

        public virtual Aluno Aluno { get; set; }
        public virtual SalaAula SalaAula { get; set; }

    }
}
