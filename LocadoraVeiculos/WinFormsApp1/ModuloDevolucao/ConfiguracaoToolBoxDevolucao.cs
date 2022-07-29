using LocadoraVeiculosForm.Compartilhado;
using System;

namespace LocadoraVeiculosForm.ModuloDevolucao
{
    public class ConfiguracaoToolBoxDevolucao : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de devoluções";

        public override string TooltipInserir { get { return "Inserir uma nova devolução"; } }

        public override string TooltipEditar { get { return "Editar uma devolução existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma devolução existente"; } }
    }
}
