using DAL;
using System;
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
    public partial class frmInsereAtualizaEApagaIngredientes : Form
    {
        bool flag;
        public frmInsereAtualizaEApagaIngredientes()
        {
            InitializeComponent();
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtNomeNovoIngrediente.Text != string.Empty)
            {
                Ingrediente novoIngrediente = new Ingrediente();
                novoIngrediente.Nome = txtNomeNovoIngrediente.Text;


                if (novoIngrediente.Inserir())
                {
                    MessageBox.Show("Inserido com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }

        private void frmInsereAtualizaEApaga_Load(object sender, EventArgs e)
        {
            AtualizaCombobox();
        }

        private void AtualizaCombobox()
        {

            cboIngredienteApagar.DataSource = Ingredientes.ListaTodos();
            cboIngredienteApagar.DisplayMember = Ingrediente.Campos.Nome;
            cboIngredienteApagar.ValueMember = Ingrediente.Campos.ID;


            cboAtualizaIngrediente.DataSource = Ingredientes.ListaTodos();
            cboAtualizaIngrediente.DisplayMember = Ingrediente.Campos.Nome;
            cboAtualizaIngrediente.ValueMember = Ingrediente.Campos.ID;
            flag = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cboIngredienteApagar.Text != string.Empty)
            {
                Ingrediente apagarIngrediente = new Ingrediente();
                apagarIngrediente.ID = (int)cboIngredienteApagar.SelectedValue;

                apagarIngrediente.Nome = cboIngredienteApagar.Text;


                if (apagarIngrediente.Eliminar())
                {
                    MessageBox.Show("Apagado com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }

        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (cboAtualizaIngrediente.Text != string.Empty && txtIngredienteAtualizada.Text != string.Empty)
            {
                Ingrediente atualizarIngrediente = new Ingrediente((int)cboAtualizaIngrediente.SelectedValue);
                atualizarIngrediente.Nome = txtIngredienteAtualizada.Text;
                atualizarIngrediente.Atualizar();
                AtualizaCombobox();

                if (atualizarIngrediente.Atualizar())
                {
                    MessageBox.Show("Atualizada com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }
    }
    
}
