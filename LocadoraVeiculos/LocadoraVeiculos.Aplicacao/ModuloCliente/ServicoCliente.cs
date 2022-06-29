using FluentValidation.Results;
using LocadoraVeiculos.BancoDados.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculos.Aplicacao.ModuloCliente
{
    public class ServicoCliente
    {

        private RepositorioClienteEmBancoDados repositorioCliente;

        public ServicoCliente(RepositorioClienteEmBancoDados repositorioCliente)
        {
            this.repositorioCliente = repositorioCliente;
        }


    }
}
