using LocadoraVeiculosForm.Compartilhado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocadoraVeiculosForm.ModuloCliente
{
    public class ConfiguracaoToolBoxCliente : ConfiguracaoToolboxBase
    {
        public override string TipoCadastro => "Cadastro de clientes";

        public override string TooltipInserir { get { return "Inserir um novo Cliente"; } }

        public override string TooltipEditar { get { return "Editar um Cliente existente"; } }

        public override string TooltipExcluir { get { return "Excluir um Cliente existente"; } }
    }
}
