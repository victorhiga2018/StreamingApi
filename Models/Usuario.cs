using StreamingApi.Models.Shared;

namespace StreamingApi.Models;

public class Usuario : IdBase
{
    public string Nome { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public List<Playlist>? Playlists { get; set; }
}
