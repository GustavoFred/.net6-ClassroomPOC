using Domain.Entities;
using Infrastructure.Persistance.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProfessorRepository : IRepository<Professor>
    {
        public SchoolContext _context;

        public ProfessorRepository()
        {
            _context = new SchoolContext();
        }


        public async Task<IEnumerable<Professor>> GetAll()
        {
            return await _context.Professores.ToListAsync();
        }

        public async Task<Professor> GetById(int? ProfessorId)
        {
            //linqiu
            return await _context.Professores.FindAsync(ProfessorId);
        }

        public async Task<Professor> Add(Professor professor)
        {
            professor.ProfessorId = new int();
            _context.Add(professor);
            _context.SaveChanges();
            return await GetById(professor.ProfessorId);
        }

        public async Task<Professor> Update(int id, Professor professor)
        {
            var updatedProfessor = await GetById(id);
            updatedProfessor.Name = professor.Name;
            updatedProfessor.Subject = professor.Subject;
            updatedProfessor.PIN = professor.PIN;
            _context.Update(updatedProfessor);
            _context.SaveChanges();
            return await GetById(updatedProfessor.ProfessorId);
        }

        public async Task<Professor> Delete(int id)
        {
            var Professor = await GetById(id);


            _context.Remove(Professor);
            _context.SaveChanges();
            return await GetById(Professor.ProfessorId);

        }
    }
}
