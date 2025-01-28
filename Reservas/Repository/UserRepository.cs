using Capitulo4.Repository;
using Microsoft.EntityFrameworkCore;
using Reservas.Models;

namespace Reservas.Repository;

public class UserRepository : IRepository<User>
{
    private ReserveContext _context;

    public UserRepository(ReserveContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<User>> Get()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetById(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task Add(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public void Update(User user)
    {
        _context.Users.Attach(user);
        _context.Entry(user).State = EntityState.Modified;
    }

    public void Delete(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task Save()
    {
        await _context.SaveChangesAsync(); // actualiza la base de datos
    }

    public IEnumerable<User> Search(Func<User, bool> filter)
    {
        throw new NotImplementedException();
    }
}