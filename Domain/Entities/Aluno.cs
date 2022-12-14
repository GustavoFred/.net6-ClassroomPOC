using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string RA { get; set; }
        public string Course { get; set; }

    }
}
