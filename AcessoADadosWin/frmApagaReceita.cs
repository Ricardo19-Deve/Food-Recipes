using System;
using DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcessoADadosWin
{
    public partial class frmApagaReceita : Form
    {
        bool flag;
        public frmApagaReceita()
        {
            InitializeComponent();
        }

        private void frmApagaReceita_Load(object sender, EventArgs e)
        {
           AtualizaCombobox();

        }
        private void AtualizaCombobox()
        {

            cboReceitaApagar.DataSource = TodasAsReceitas.ListaTodos();
            cboReceitaApagar.DisplayMember = Receita.Campos.Nome;
            cboReceitaApagar.ValueMember = Receita.Campos.ID;


            flag = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cboReceitaApagar.Text != string.Empty)
            {
                Receita apagarReceita = new Receita();
                apagarReceita.Id = (int)cboReceitaApagar.SelectedValue;

                apagarReceita.Nome = cboReceitaApagar.Text;


                if (apagarReceita.Eliminar())
                {
                    MessageBox.Show("Apagado com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }
    }
}
