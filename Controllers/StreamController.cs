﻿using Microsoft.AspNetCore.Mvc;
using StreamingApi.Models;
using StreamingApi.Repositories;

namespace StreamingApi.Controllers;

[ApiController]
[Route("[controller]")]
public class StreamController : ControllerBase
{
    private readonly IUsuarioRepository _usuarioRepository;


    public StreamController(IUsuarioRepository usuarioRepository)
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

    [HttpPut("atualizarUsuario")]
    public IActionResult Put([FromBody] Usuario usuario)
    {
        _usuarioRepository.Update(usuario);
        return Ok("Usuario atualizado com sucesso!");
    }

    [HttpDelete("deletarUsuario")]
    public IActionResult Delete([FromBody] Usuario usuario)
    {
        _usuarioRepository?.Delete(usuario);
        return Ok("Usuario deletado com sucesso!");
    }

}