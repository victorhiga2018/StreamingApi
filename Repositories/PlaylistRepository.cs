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
        var result = ObterPorId(playlist.Id);

        if (result == null)
        {
            throw new Exception("Playlist não encontrada.");
        }

        result.Nome = playlist.Nome;

        _streamingContext.Entry(result).Collection(p => p.Conteudos).Load();

        result.Conteudos.Clear();
        foreach (var conteudo in playlist.Conteudos)
        {
            result.Conteudos.Add(conteudo);
        }

        _streamingContext.SaveChanges();
    }

    public void Deletar(int id)
    {
        var result = _streamingContext.Playlists.Where(x => x.Id == id);
        if (result.Any())
        {
            _streamingContext.Remove(result.First());
            _streamingContext.SaveChanges();
        }
    }

    public Playlist? ObterPorId(int id)
    {
        var playlist = _streamingContext.Playlists
            .Include(x => x.Conteudos)
            .Where(x => x.Id == id);
        if (playlist.Any())
            return playlist.First();

        return null;
    }

    public List<Playlist> ObterTodos(Usuario usuario)
    {
        var usuarioPlaylist = _usuarioRepository.ObterPorUsuario(usuario);
        var todasPlaylists = _streamingContext.Playlists
            .Include(x => x.Conteudos)
            .Where(x => x.UsuarioId == usuarioPlaylist.Id)
            .ToList();
        return todasPlaylists;
    }
}
