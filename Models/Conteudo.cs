using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Conteudo : IdBase
{
    public string Titulo { get; set; } = string.Empty;
    public string Tipo { get; set; } = string.Empty;
    public Criador? Criador { get; set; } = null!;
    public virtual Playlist? Playlist { get; set; } = null!;
    public int? PlaylistId { get; set; }
}


