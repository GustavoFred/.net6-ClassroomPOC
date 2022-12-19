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
    public class SalaRepository : IRepository<Sala>
    {
        public SchoolContext _context;

        public SalaRepository()
        {
            this._context = new SchoolContext();
        }


        public async Task<IEnumerable<Sala>> GetAll()
        {
            return await _context.Salas.ToListAsync();
        }

        public async Task<Sala> GetById(int? SalaId)
        {
            //linqiu
            return await _context.Salas.FindAsync(SalaId);
        }

        public async Task<Sala> Add(Sala sala)
        {
            sala.SalaId = new int();
            _context.Add(sala);
            _context.SaveChanges();
            return await GetById(sala.SalaId);
        }

        public async Task<Sala> Update(int id, Sala sala)
        {
            var updatedSala = await GetById(id);
            updatedSala.NumberOfSeats = sala.NumberOfSeats;
            updatedSala.Subject = sala.Subject;
            _context.Update(updatedSala);
            _context.SaveChanges();
            return await GetById(updatedSala.SalaId);
        }

        public async Task<Sala> Delete(int id)
        {
            var Sala = await GetById(id);


            _context.Remove(Sala);
            _context.SaveChanges();
            return await GetById(Sala.SalaId);

        }
    }
}
