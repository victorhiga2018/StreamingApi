using Microsoft.EntityFrameworkCore;
using StreamingApi.Context;
using StreamingApi.Models;

namespace StreamingApi.Repositories;

public class PlaylistRepository : IPlaylistRepository
{
    private readonly StreamingContext _streamingContext;
    private readonly IUsuarioRepository _usuarioRepository;

    public PlaylistRepository(StreamingContext streamingContext, IUsuarioRepository usuarioRepository)
    {
        _streamingContext = streamingContext;
        _usuarioRepository = usuarioRepository;
    }
    public void Adicionar(Playlist playlist)
    {
        _streamingContext.Playlists.Add(playlist);
        _streamingContext.SaveChanges();
    }

    public void Atualizar(Playlist playlist)
    {
        _streamingContext.Playlists.Update(playlist);
        _streamingContext.SaveChanges();
    }

    public void Deletar(int id)
    {
        var result = _streamingContext.Playlists.FirstOrDefault(x => x.Id == id);
        if (result != null)
        {
            _streamingContext.Remove(result);
            _streamingContext.SaveChanges();
        }
    }

    public Playlist? ObterPorId(int id)
    {
        var playlist = _streamingContext.Playlists.FirstOrDefault(x => x.Id == id);
        if (playlist != null)
            return playlist;

        return null;
    }

    public IEnumerable<Playlist> ObterTodos(Usuario usuario)
    {
        var usuarioPlaylist = _usuarioRepository.ObterPorUsuario(usuario);
        var todasPlaylists = _streamingContext.Playlists.Where(x => x.UsuarioId == usuarioPlaylist.Id).ToList();
        return todasPlaylists;
    }
}
