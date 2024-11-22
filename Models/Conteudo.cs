using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Conteudo : IdBase
{
    public string Titulo { get; set; }
    public string Tipo { get; set; }
    public required Criador Criador { get; set; }
}


