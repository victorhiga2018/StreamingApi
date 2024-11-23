using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Playlist : IdBase
{
    public string Nome { get; set; } = string.Empty;
    public Usuario Usuario { get; set; }
    public List<Conteudo> Conteudos { get; set; } = new List<Conteudo>();
    public int UsuarioId { get; set; }
}
