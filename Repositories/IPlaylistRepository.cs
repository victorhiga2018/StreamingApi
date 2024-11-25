﻿using StreamingApi.Models;

namespace StreamingApi.Repositories;

public interface IPlaylistRepository
{
    List<Playlist> ObterTodos(Usuario usuario);
    Playlist? ObterPorId(int id);
    void Adicionar(Playlist playlist);
    void Atualizar(Playlist playlist);
    void Deletar(int id);
}
