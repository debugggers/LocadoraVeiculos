﻿using System;
using System.Collections.Generic;

namespace LocadoraVeiculos.Dominio.Compartilhado
{
    public interface IRepositorio<T> where T: EntidadeBase<T>
    {

        void Inserir(T novoRegistro);

        void Editar(T registro);

        void Excluir(T registro);

        List<T> SelecionarTodos();

        T SelecionarPorId(Guid id);

    }
}
