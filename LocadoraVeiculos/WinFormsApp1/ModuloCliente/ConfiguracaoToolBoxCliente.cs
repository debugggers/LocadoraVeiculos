using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de pessoas físicas";

        public override string TooltipInserir { get { return "Inserir uma nova pessoas físicas"; } }

        public override string TooltipEditar { get { return "Editar uma pessoas físicas existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma pessoas físicas existente"; } }
    }
}
