using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloCliente.ClienteEmpresa
{
    public class ConfiguracaoToolBoxEmpresa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de pessoas jurídicas";

        public override string TooltipInserir { get { return "Inserir uma nova pessoa jurídica"; } }

        public override string TooltipEditar { get { return "Editar uma pessoa jurídica existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma pessoa jurídica existente"; } }
    }
}
