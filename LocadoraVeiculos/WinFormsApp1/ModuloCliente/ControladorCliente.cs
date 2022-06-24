using LocadoraVeiculos.BancoDados.ModuloCliente;
using LocadoraVeiculos.Dominio.ModuloCliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ControladorCliente
    {

        private RepositorioClienteEmBancoDados repositorio;
        private ListagemClientesControl listagem;

        public ControladorCliente(RepositorioClienteEmBancoDados repositorio)
        {

            this.repositorio = repositorio;
            listagem = new ListagemClientesControl();

        }

        public void Inserir()
        {

            TelaCadastroClienteForm tela = new TelaCadastroClienteForm();
            tela.Cliente = new Cliente();

            tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

        }

        //public void Editar()
        //{

        //    Cliente clienteSelecionado = ObtemClienteSelecionado();

        //    if (clienteSelecionado == null)
        //    {
        //        MessageBox.Show("Selecione um cliente primeiro",
        //        "Edição de Clientes", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        //        return;
        //    }

        //    TelaCadastroClienteForm tela = new TelaCadastroClienteForm();

        //    tela.GravarRegistro = repositorio.Editar;

        //    DialogResult resultado = tela.ShowDialog();

        //}

        //private Cliente ObtemClienteSelecionado()
        //{
        //    var numero = listagem.ObtemNumeroClienteSelecionado();

        //    return repositorio.SelecionarPorId(numero);
        //}

    }
}
