using LocadoraVeiculos.Aplicacao.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.BancoDados.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculos.Dominio.ModuloCliente.ClienteEmpresa;
using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public class ControladorEmpresa : ControladorBase
    {

        private ServicoEmpresa _servicoEmpresa;
        private ListagemEmpresasControl _listagem;

        public ControladorEmpresa(ServicoEmpresa servicoEmpresa)
        {
            _servicoEmpresa = servicoEmpresa;
            _listagem = new ListagemEmpresasControl();
        }

        private void CarregarEmpresas()
        {
            var resultado = _servicoEmpresa.SelecionarTodos();

            if (resultado.IsSuccess)
            {
                List<Empresa> empresas = resultado.Value;

                _listagem.AtualizarRegistrosPessoaJuridica(empresas);

                TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {empresas.Count} empresa(s)");
            }
            else
            {
                MessageBox.Show(resultado.Errors[0].Message, "Carregar listagem",
                 MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public override void Inserir()
        {
            var tela = new TelaCadastroEmpresaForm();
            tela.Empresa = new Empresa();
            tela.GravarRegistro = _servicoEmpresa.Inserir;
            DialogResult resultado = tela.ShowDialog();
            if (resultado == DialogResult.OK)
            {
                CarregarEmpresas();
            }
        }

        public override void Editar()
        {
            var id = _listagem.SelecionarIdEmpresa();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma empresa primeiro",
                    "Edição de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultado = _servicoEmpresa.SelecionarPorId(id);

            if (resultado.IsFailed)
            {
                MessageBox.Show(resultado.Errors[0].Message,
                    "Edição de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var empresaSelecionada = resultado.Value;

            var tela = new TelaCadastroEmpresaForm();

            tela.Empresa = empresaSelecionada;

            tela.GravarRegistro = _servicoEmpresa.Editar;

            if (tela.ShowDialog() == DialogResult.OK)
                CarregarEmpresas();
        }

        public override void Excluir()
        {
            var id = _listagem.SelecionarIdEmpresa();

            if (id == Guid.Empty)
            {
                MessageBox.Show("Selecione uma empresa primeiro",
                    "Exclusão de Empresa", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            var resultadoSelecao = _servicoEmpresa.SelecionarPorId(id);

            if (resultadoSelecao.IsFailed)
            {
                MessageBox.Show(resultadoSelecao.Errors[0].Message,
                    "Exclusão de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var empresaSelecionada = resultadoSelecao.Value;

            if (MessageBox.Show("Deseja realmente excluir a empresa?", "Exclusão de Empresa",
                 MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                var resultadoExclusao = _servicoEmpresa.Excluir(empresaSelecionada);

                if (resultadoExclusao.IsSuccess)
                    CarregarEmpresas();
                else
                    MessageBox.Show(resultadoExclusao.Errors[0].Message,
                        "Exclusão de Empresas", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public override UserControl ObtemListagem()
        {
            if (_listagem == null)
                _listagem = new ListagemEmpresasControl();

            CarregarEmpresas();

            return _listagem;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolBoxEmpresa();
        }

        public override void GerarPdf()
        {
            throw new NotImplementedException();
        }
    }
}
