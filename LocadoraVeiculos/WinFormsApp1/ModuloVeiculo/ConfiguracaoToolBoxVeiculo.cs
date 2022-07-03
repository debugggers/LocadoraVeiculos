using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloVeiculo
{
    public class ConfiguracaoToolBoxVeiculo : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de veiculos";

        public override string TooltipInserir { get { return "Inserir um novo veiculo"; } }

        public override string TooltipEditar { get { return "Editar um veiculo existente"; } }

        public override string TooltipExcluir { get { return "Excluir um veiculo existente"; } }
    }
}
