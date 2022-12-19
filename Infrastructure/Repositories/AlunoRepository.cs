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
    public class AlunoRepository : IRepository<Aluno>
    {
        public SchoolContext _context;

        public AlunoRepository()
        {
            _context = new SchoolContext();
        }


        public async Task<IEnumerable<Aluno>> GetAll()
        {
            return await _context.Alunos.ToListAsync();
        }

        public async Task<Aluno> GetById(int? AlunoId)
        {
            //linqiu
            return await _context.Alunos.FindAsync(AlunoId);
        }

        public async Task<Aluno> Add(Aluno aluno)
        {
            aluno.AlunoId = new int();
            _context.Add(aluno);
            _context.SaveChanges();
            return await GetById(aluno.AlunoId);
        }

        public async Task<Aluno> Update(int id, Aluno aluno)
        {
            var updatedAluno = await GetById(id);
            updatedAluno.Name = aluno.Name;
            updatedAluno.Age = aluno.Age;
            updatedAluno.RA = aluno.RA;
            updatedAluno.Course = aluno.Course;
            _context.Update(updatedAluno);
            _context.SaveChanges();
            return await GetById(updatedAluno.AlunoId);
        }

        public async Task<Aluno> Delete(int id)
        {
            var aluno = await GetById(id);


            _context.Remove(aluno);
            _context.SaveChanges();
            return await GetById(aluno.AlunoId);

        }
    }
}
