using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculosForm.ModuloTaxa
{
    public class ConfiguracaoToolBoxTaxa : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de taxas";

        public override string TooltipInserir { get { return "Inserir uma nova taxa"; } }

        public override string TooltipEditar { get { return "Editar uma taxa existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma taxa existente"; } }
    }
}
