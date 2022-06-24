using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public class ConfiguracaoToolBoxEmpresa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Empresas";

        public override string TooltipInserir { get { return "Inserir uma nova Empresa"; } }

        public override string TooltipEditar { get { return "Editar uma Empresa existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma Empresa existente"; } }
    }
}
