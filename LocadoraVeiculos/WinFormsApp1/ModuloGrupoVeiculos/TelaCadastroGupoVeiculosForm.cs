using FluentValidation.Results;
using LocadoraVeiculos.Dominio.ModuloGrupoVeiculos;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LocadoraVeiculosForm.ModuloGrupoVeiculos
{
    public partial class TelaCadastroGupoVeiculosForm : Form
    {
        public Func<GrupoVeiculos, ValidationResult> GrupoVeiculos { get; internal set; }
        public Func<GrupoVeiculos, ValidationResult> GravarRegistro { get; internal set; }

        public TelaCadastroGupoVeiculosForm()
        {
            InitializeComponent();
        }

        private void TelaCadastroGupoVeiculosForm_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
