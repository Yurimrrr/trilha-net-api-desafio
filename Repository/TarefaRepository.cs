
using Microsoft.EntityFrameworkCore;
using TrilhaApiDesafio.Context;
using TrilhaApiDesafio.Models;

namespace TrilhaApiDesafio.Repository
{
    public class TarefaRepository
    {
        private readonly OrganizadorContext _context;

        public TarefaRepository(OrganizadorContext context)
        {
            _context = context;
        }

        public void Create(Tarefa tarefa)
        {
            _context.Tarefas.Add(tarefa);
            _context.SaveChanges();
        }

        public IEnumerable<Tarefa> GetAll()
        {
            return _context
                .Tarefas
                .AsNoTracking()
                .OrderBy(x => x.Data);
        }

        public Tarefa GetById(int id)
        {
            return _context
                .Tarefas
                .AsNoTracking()
                .FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Tarefa> GetByTitulo(string titulo)
        {
            return _context
                .Tarefas
                .AsQueryable()
                .AsNoTracking()
                .Where(x => x.Titulo == titulo);
        }

        public void Update(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Tarefa tarefa)
        {
            _context.Entry(tarefa).State = EntityState.Deleted;
            _context.SaveChanges();
        }
    }
}