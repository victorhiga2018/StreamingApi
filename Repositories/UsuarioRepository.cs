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

    public async Task Delete(int id)
    {
        var usuario = _context.Usuarios.Where(x => x.Id == id).First();
        _context.Remove(usuario);
        _context.SaveChanges();
    }

    public async Task<IEnumerable<Usuario>> GetAll()
    {
        return await _context.Usuarios.ToListAsync();
    }

    public Task<Usuario>? VerificarLogin(Usuario usuario)
    {
        var login = _context.Usuarios.Where(x => x.Email == usuario.Email && x.Nome == usuario.Nome).ToList();
        if (login.Any())
            return Task.FromResult(login.First());

        return null;
    }

    public void Update(Usuario usuario)
    {
        _context.Usuarios.Find(usuario);
        _context.Usuarios.Update(usuario);
    }

    public Usuario ObterPorUsuario(Usuario usuario)
    {
        var result = _context.Usuarios.Where(x => x.Nome == usuario.Nome && x.Email == usuario.Email).First();
        return result;
    }
}
