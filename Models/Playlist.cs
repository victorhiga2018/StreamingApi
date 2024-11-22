using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Playlist : IdBase
{
    public string Nome { get; set; }
    public Usuario Usuario { get; set; }
    public List<Conteudo> Conteudos { get; set; }
}
