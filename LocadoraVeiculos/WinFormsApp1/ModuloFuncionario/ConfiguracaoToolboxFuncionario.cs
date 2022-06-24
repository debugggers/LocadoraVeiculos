using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloFuncionario
{
    public class ConfiguracaoToolboxFuncionario : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Funcionários";

        public override string TooltipInserir { get { return "Inserir um novo Funcionário"; } }

        public override string TooltipEditar { get { return "Editar um Funcionário existente"; } }

        public override string TooltipExcluir { get { return "Excluir um Funcionário existente"; } }
    }
}
