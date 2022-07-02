using LocadoraVeiculos.Aplicacao.ModuloPlanoCobranca;
using LocadoraVeiculos.BancoDados.ModuloPlanoCobranca;
using LocadoraVeiculos.Dominio.ModuloPlanoCobranca;
using LocadoraVeiculosForm.Compartilhado;
using System.Collections.Generic;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    public class ControladorPlanoCobranca : ControladorBase
    {
        private RepositorioPlanoCobrancaEmBancoDados _repositorioPlanoCobranca;
        private ListagemPlanoCobrancaControl _listagemPlanoCobranca;
        private ServicoPlanoCobranca _servicoPlanoCobranca;

        public ControladorPlanoCobranca(RepositorioPlanoCobrancaEmBancoDados repositorioPlanoCobranca, ServicoPlanoCobranca servicoPlanoCobranca)
        {
            _repositorioPlanoCobranca = repositorioPlanoCobranca;
            _listagemPlanoCobranca = new ListagemPlanoCobrancaControl();
            _servicoPlanoCobranca = servicoPlanoCobranca;
        }
        public override void Inserir()
        {
            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(_servicoPlanoCobranca);
            tela.PlanoCobranca = new PlanoCobranca();

            tela.GravarRegistro = _servicoPlanoCobranca.Inserir;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosCobranca();
        }

        public override void Editar()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Edição de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            TelaCadastroPlanoCobrancaForm tela = new TelaCadastroPlanoCobrancaForm(_servicoPlanoCobranca);

            tela.PlanoCobranca = planoCobrancaSelecionado;

            tela.GravarRegistro = _servicoPlanoCobranca.Editar;

            DialogResult resultado = tela.ShowDialog();

            if (resultado == DialogResult.OK)
                CarregarPlanosCobranca();
        }

        public override void Excluir()
        {
            PlanoCobranca planoCobrancaSelecionado = ObtemPlanoCobrancaSelecionado();

            if (planoCobrancaSelecionado == null)
            {
                MessageBox.Show("Selecione um Plano de Cobrança primeiro",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            DialogResult resultado = MessageBox.Show("Deseja realmente excluir o Plano de Cobrança?",
                "Exclusão de Plano de Cobrança", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

            if (resultado == DialogResult.OK)
            {
                _repositorioPlanoCobranca.Excluir(planoCobrancaSelecionado);
                CarregarPlanosCobranca();
            }
        }

        public override UserControl ObtemListagem()
        {
            if (_listagemPlanoCobranca == null)
                _listagemPlanoCobranca = new ListagemPlanoCobrancaControl();

            CarregarPlanosCobranca();

            return _listagemPlanoCobranca;
        }

        public override ConfiguracaoToolboxBase ObtemConfiguracaoToolbox()
        {
            return new ConfiguracaoToolboxPlanoCobranca();
        }

        private PlanoCobranca ObtemPlanoCobrancaSelecionado()
        {
            var id = _listagemPlanoCobranca.ObtemIdPlanoCobrancaSelecionado();

            return _repositorioPlanoCobranca.SelecionarPorId(id);
        }

        private void CarregarPlanosCobranca()
        {
            List<PlanoCobranca> planosCobranca = _repositorioPlanoCobranca.SelecionarTodos();

            _listagemPlanoCobranca.AtualizarRegistros(planosCobranca);

            TelaMenuPrincipalForm.Instancia.AtualizarRodape($"Visualizando {planosCobranca.Count} Planos de Cobrança(s)");
        }
    }
}
