using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloLocacao
{
    public class ConfiguracaoToolboxLocacao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Locações";

        public override string TooltipInserir { get { return "Inserir uma nova Locação"; } }

        public override string TooltipEditar { get { return "Editar uma Locação existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma Locação existente"; } }
    }
}
