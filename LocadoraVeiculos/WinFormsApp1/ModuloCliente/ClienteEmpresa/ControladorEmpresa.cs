using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public class ControladorEmpresa
    {

        private RepositorioEmpresaBancoDados repositorio;
        private ListagemClientesControl listagem;

        public ControladorEmpresa(RepositorioEmpresaBancoDados repositorio)
        {

            this.repositorio = repositorio;
            listagem = new ListagemClientesControl();

        }

        public void Inserir()
        {

            TelaCadastroEmpresaForm tela = new TelaCadastroEmpresaForm();
            tela.Empresa = new Empresa();

            tela.GravarRegistro = repositorio.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEmpresas();
            }

        }

        public void Editar()
        {

            Empresa empresaSelecionada = ObtemEmpresaSelecionada();

            if (empresaSelecionada == null)
            {
                MessageBox.Show("Selecione uma empresa primeiro",
                "Edição de empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroEmpresaForm tela = new TelaCadastroEmpresaForm();

            tela.GravarRegistro = repositorio.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                CarregarEmpresas();
            }
        }

        public void Excluir()
        {

            Empresa empresaSelecionada = ObtemEmpresaSelecionada();

            if (empresaSelecionada == null)
            {
                MessageBox.Show("Selecione uma empresa primeiro",
                "Exclusão de empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir a empresa?",
                "Exclusão de empresa", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                repositorio.Excluir(empresaSelecionada);
                CarregarEmpresas();
            }

        }

        private void CarregarEmpresas()
        {
            List<Empresa> empresas = repositorio.SelecionarTodos();

            listagem.AtualizarRegistrosPessoaJuridica(empresas);
        }

        public UserControl ObtemListagem()
        {
            if (listagem == null)
                listagem = new ListagemClientesControl();

            CarregarEmpresas();

            return listagem;
        }

        private Empresa ObtemEmpresaSelecionada()
        {
            int id = listagem.SelecionarNumeroCliente();

            Empresa empresaSelecionada = repositorio.SelecionarPorId(id);

            return empresaSelecionada;
        }
    }
}
