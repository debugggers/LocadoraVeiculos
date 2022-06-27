using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    public class ConfiguracaoToolBoxGrupoVeiculos : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro Grupo veiculos";

        public override string TooltipInserir { get { return "Inserir uma nova taxa"; } }

        public override string TooltipEditar { get { return "Editar uma taxa existente"; } }

        public override string TooltipExcluir { get { return "Excluir uma taxa existente"; } }
    }
}
