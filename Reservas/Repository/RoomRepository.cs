using Capitulo4.Repository;
using Microsoft.EntityFrameworkCore;
using Reservas.Models;

namespace Reservas.Repository;

public class RoomRepository : IRepository<Room>
{
    private ReserveContext _context;

    public RoomRepository(ReserveContext context)
    {
        _context = context;
    }
    
    public async Task<IEnumerable<Room>> Get()
    {
        return await _context.Rooms.ToListAsync();
    }

    public async Task<Room> GetById(int id)
    {
        return await _context.Rooms.FindAsync(id);
    }

    public async Task Add(Room room)
    {
        await _context.Rooms.AddAsync(room);
    }

    public void Update(Room room)
    {
        _context.Rooms.Attach(room);
        _context.Entry(room).State = EntityState.Modified;
    }

    public void Delete(Room room)
    {
        _context.Rooms.Remove(room);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync(); // actualiza la base de datos
    }

    public IEnumerable<Room> Search(Func<Room, bool> filter)
    {
        throw new NotImplementedException();
    }
}