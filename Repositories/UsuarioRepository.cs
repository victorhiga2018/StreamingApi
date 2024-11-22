using Microsoft.EntityFrameworkCore;
using StreamingApi.Context;
using StreamingApi.Models;

namespace StreamingApi.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    private readonly StreamingContext _context;

    public UsuarioRepository(StreamingContext context)
    {
        _context = context;
    }

    public void Add(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void Delete(Usuario usuario)
    {
        _context.Usuarios.Find(usuario);
        _context.Usuarios.ExecuteDeleteAsync();
    }

    public async Task<IEnumerable<Usuario>> GetAll()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public void Update(Usuario usuario)
    {
        _context.Usuarios.Find(usuario);
        _context.Usuarios.Update(usuario);
    }
}
