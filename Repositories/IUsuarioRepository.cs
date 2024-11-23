using StreamingApi.Models;

namespace StreamingApi.Repositories;

public interface IUsuarioRepository
{
    void Add(Usuario usuario);
    void Update(Usuario usuario);
    Task<IEnumerable<Usuario>> GetAll();
    Task Delete(int id);
    Task<Usuario>? VerificarLogin(Usuario usuario);
    Usuario ObterPorUsuario(Usuario usuario);
}
