using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Criador : IdBase
{
    public string Nome { get; set; } = string.Empty;
    public virtual ICollection<Conteudo>? Conteudos { get; set; } = null!;
    public virtual Conteudo? Conteudo { get; set; } = null;
    public int? ConteudoId { get; set; }
}
