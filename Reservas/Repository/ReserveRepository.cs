using Capitulo4.Repository;
using Microsoft.EntityFrameworkCore;
using Reservas.Models;

namespace Reservas.Repository;

public class ReserveRepository : IRepository<Reserve>
{    
    private ReserveContext _context;

    public ReserveRepository(ReserveContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Reserve>> Get()
    {
        return await _context.Reserves.ToListAsync();
    }

    public async Task<Reserve> GetById(int id)
    {
        return await _context.Reserves.FindAsync(id);
    }

    public async Task Add(Reserve reserve)
    {
        await _context.Reserves.AddAsync(reserve);
    }

    public void Update(Reserve reserve)
    {
        _context.Reserves.Attach(reserve);
        _context.Entry(reserve).State = EntityState.Modified;
    }

    public void Delete(Reserve reserve)
    {
        _context.Reserves.Remove(reserve);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync(); // actualiza la base de datos
    }

    public IEnumerable<Reserve> Search(Func<Reserve, bool> filter)
    {
        throw new NotImplementedException();
    }
}