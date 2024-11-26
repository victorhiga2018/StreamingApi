namespace StreamingApi.Dtos;

public class PlaylistResponseDto
{
    public int Id { get; set; }
    public string NomePlaylist { get; set; }
    public ConteudoResponseDto Conteudo { get; set; }
}

