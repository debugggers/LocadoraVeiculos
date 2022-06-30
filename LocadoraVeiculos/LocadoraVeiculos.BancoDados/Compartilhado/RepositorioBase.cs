﻿using FluentValidation;
using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.Compartilhado;
using LocadoraVeiculos.Dominio.Compartilhado;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ControleMedicamentos.Infra.BancoDados.Compartilhado
{
    public abstract class RepositorioBase<T, TMapeador>
        where T : EntidadeBase<T>
        where TMapeador : MapeadorBase<T>, new()
    {
        protected string EnderecoBanco = EnderecoBancoConst.EnderecoBanco;
     
        public void SetEnderecoBanco(string enderecoBanco)
        {
            EnderecoBanco = enderecoBanco;
        }

        protected abstract string sqlInserir { get; }

        protected abstract string sqlEditar { get; }

        protected abstract string sqlExcluir { get; }

        protected abstract string sqlSelecionarPorId { get; }

        protected abstract string sqlSelecionarTodos { get; }

        public virtual void Inserir(T registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoInsercao = new SqlCommand(sqlInserir, conexaoComBanco);

            var mapeador = new TMapeador();

            mapeador.ConfigurarParametros(registro, comandoInsercao);

            conexaoComBanco.Open();
            var id = comandoInsercao.ExecuteScalar();
            registro.Id = Convert.ToInt32(id);

            conexaoComBanco.Close();
        }

        public virtual void Editar(T registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoEdicao = new SqlCommand(sqlEditar, conexaoComBanco);

            var mapeador = new TMapeador();

            mapeador.ConfigurarParametros(registro, comandoEdicao);

            conexaoComBanco.Open();
            comandoEdicao.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        public void Excluir(T registro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoExclusao = new SqlCommand(sqlExcluir, conexaoComBanco);

            comandoExclusao.Parameters.AddWithValue("ID", registro.Id);

            conexaoComBanco.Open();
            comandoExclusao.ExecuteNonQuery();
            conexaoComBanco.Close();
        }

        public T SelecionarPorId(int id)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorId, conexaoComBanco);

            comandoSelecao.Parameters.AddWithValue("ID", id);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var mapeador = new TMapeador();

            T registro = null;
            if (leitorRegistro.Read())
                registro = mapeador.ConverterRegistro(leitorRegistro);

            conexaoComBanco.Close();

            return registro;
        }

        public List<T> SelecionarTodos()
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarTodos, conexaoComBanco);
            conexaoComBanco.Open();

            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var mapeador = new TMapeador();

            List<T> registros = new List<T>();

            while (leitorRegistro.Read())
                registros.Add(mapeador.ConverterRegistro(leitorRegistro));

            conexaoComBanco.Close();

            return registros;
        }

        public virtual T SelecionarPorParametro(string sqlSelecionarPorParametro, SqlParameter parametro)
        {
            SqlConnection conexaoComBanco = new SqlConnection(EnderecoBanco);

            SqlCommand comandoSelecao = new SqlCommand(sqlSelecionarPorParametro, conexaoComBanco);

            comandoSelecao.Parameters.Add(parametro);

            conexaoComBanco.Open();
            SqlDataReader leitorRegistro = comandoSelecao.ExecuteReader();

            var mapeador = new TMapeador();
            T registro = null;
            if (leitorRegistro.Read())
                registro = mapeador.ConverterRegistro(leitorRegistro);

            conexaoComBanco.Close();

            return registro;
        }
    }
}
