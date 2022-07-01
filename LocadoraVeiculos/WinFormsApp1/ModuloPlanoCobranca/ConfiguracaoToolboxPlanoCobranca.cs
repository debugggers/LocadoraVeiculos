using LocadoraVeiculosForm.Compartilhado;

namespace LocadoraVeiculosForm.ModuloPlanoCobranca
{
    public class ConfiguracaoToolboxPlanoCobranca : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de Plano de Cobrança";

        public override string TooltipInserir { get { return "Inserir um novo Plano de Cobrança"; } }

        public override string TooltipEditar { get { return "Editar um Plano de Cobrança existente"; } }

        public override string TooltipExcluir { get { return "Excluir um Plano de Cobrança existente"; } }
    }
}
