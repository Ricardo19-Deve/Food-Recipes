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
    public partial class frmInsereAtualizaEApagaDificuldade : Form
    {
        bool flag;
        public frmInsereAtualizaEApagaDificuldade()
        {
            InitializeComponent();
        }

        private void frmInsereAtualizaEApagaDificuldade_Load(object sender, EventArgs e)

        {

            AtualizaCombobox();
        }

        private void AtualizaCombobox()
        {

            cboDificuldadeApagar.DataSource = Dificuldades.ListaTodos();
            cboDificuldadeApagar.DisplayMember = Dificuldade.Campos.Nome;
            cboDificuldadeApagar.ValueMember = Dificuldade.Campos.ID;


            cboAtualizaDificuldade.DataSource = Dificuldades.ListaTodos();
            cboAtualizaDificuldade.DisplayMember = Dificuldade.Campos.Nome;
            cboAtualizaDificuldade.ValueMember = Dificuldade.Campos.ID;
            flag = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtNomeNovaDificuldade.Text != string.Empty)
            {
                Dificuldade novaDificuldade = new Dificuldade();
                novaDificuldade.Nome = txtNomeNovaDificuldade.Text;


                if (novaDificuldade.Inserir())
                {
                    MessageBox.Show("Inserido com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cboDificuldadeApagar.Text != string.Empty)
            {
                Dificuldade apagarDificuldade = new Dificuldade();
                apagarDificuldade.ID = (int)cboDificuldadeApagar.SelectedValue;

                apagarDificuldade.Nome = cboDificuldadeApagar.Text;


                if (apagarDificuldade.Eliminar())
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
            if (cboAtualizaDificuldade.Text != string.Empty && txtDificuldadeAtualizada.Text != string.Empty)
            {
                Dificuldade atualizarDificuldade = new Dificuldade((int)cboAtualizaDificuldade.SelectedValue);
                atualizarDificuldade.Nome = txtDificuldadeAtualizada.Text;
                atualizarDificuldade.Atualizar();
                AtualizaCombobox();

                if (atualizarDificuldade.Atualizar())
                {
                    MessageBox.Show("Atualizado com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }
    }
}
