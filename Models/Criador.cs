using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Criador : IdBase
{
    public string Nome { get; set; }
    List<Conteudo> Conteudos { get; set; }
}
