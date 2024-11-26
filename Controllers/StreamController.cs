using Microsoft.AspNetCore.Mvc;
using StreamingApi.Dtos;
using StreamingApi.Models;
using StreamingApi.Repositories;

namespace StreamingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StreamController : ControllerBase
{
    private readonly IPlaylistRepository _playlistRepository;
    public StreamController(IPlaylistRepository playlistRepository)
    {
        _playlistRepository = playlistRepository;
    }

    [HttpPost]
    [Route("obterPlaylists")]
    public IActionResult ObterTodasPlaylist([FromBody] Usuario usuario)
    {
        var playlists = _playlistRepository.ObterTodos(usuario);

        var response = new List<PlaylistResponseDto>();

        foreach (var playlist in playlists)
        {
            response.Add(new PlaylistResponseDto { NomePlaylist = playlist.Nome, Conteudo = new ConteudoResponseDto { Tipo = playlist.Conteudos[0].Tipo, Titulo = playlist.Conteudos[0].Titulo }, Id = playlist.Id });
        }

        if (playlists != null)
            return Ok(response);

        return NotFound("Sem playlist cadastrada!");
    }

    [HttpPost]
    [Route("cadastrarPlaylist")]
    public IActionResult CadastrarPlaylist([FromBody] Playlist playlist)
    {
        try
        {
            _playlistRepository.Adicionar(playlist);
            return Ok("Playlist cadastrada com sucesso!");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao cadastrar!");
            throw;
        }  
    }

    [HttpGet]
    [Route("obterPlaylistPorId/{id}")]
    public IActionResult ObterPlaylistPorId(int id)
    {
        var playlist = _playlistRepository.ObterPorId(id);

        if (playlist != null)
            return Ok(playlist);

        return NotFound("Nenhuma playlist encontrada!");
    }

    [HttpPut]
    [Route("atualizarPlaylist")]
    public IActionResult AtualizarPlaylist([FromBody] Playlist playlist)
    {
        try
        {
            _playlistRepository.Atualizar(playlist);
            return Ok("Playlist atualizada com sucesso!");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao atualizar!");
            throw;
        }
    }

    [HttpDelete]
    [Route("deletarPlaulist/{id}")]
    public ActionResult DeletarPlaylist(int id)
    {
        try
        {
            _playlistRepository.Deletar(id);
            return Ok("Playlist deletada com sucesso!");
        }
        catch (Exception)
        {
            return BadRequest("Erro ao deletar!");
            throw;
        }
    }
}
