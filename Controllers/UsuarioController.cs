using Microsoft.AspNetCore.Mvc;
using StreamingApi.Models;
using StreamingApi.Repositories;

namespace StreamingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;


    public UsuarioController(IUsuarioRepository usuarioRepository)
    {
        _usuarioRepository = usuarioRepository;
    }

    [HttpGet("obterUsuarios")]
    public async Task<IActionResult> Get()
    {

        return Ok(await _usuarioRepository.GetAll());
    }

    [HttpPost("cadastrarUsuario")]
    public IActionResult Post([FromBody] Usuario usuario)
    {
        _usuarioRepository.Add(usuario);

        return Ok("Usuario cadastrado com sucesso!");
    }

    [HttpPost("loginUsuario")]
    public IActionResult Login([FromBody] Usuario usuario)
    {
        var isLogado = _usuarioRepository.VerificarLogin(usuario);

        if (isLogado != null)
          return Ok("Login realizado com sucesso!");

        return NotFound("Login não encontrado!");
    }

    [HttpPut("atualizarUsuario")]
    public IActionResult Put([FromBody] Usuario usuario)
    {
        _usuarioRepository.Update(usuario);
        return Ok("Usuario atualizado com sucesso!");
    }

    [HttpDelete("deletarUsuario/{id}")]
    public IActionResult Delete(int id)
    {
        _usuarioRepository?.Delete(id);
        return Ok("Usuario deletado com sucesso!");
    }

}
