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
    public partial class frmInsereAtualizaEApagaCategorias : Form
    {
        bool flag;
        public frmInsereAtualizaEApagaCategorias()
        {
            InitializeComponent();
        }
       
        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cboCategoriasApagar.Text != string.Empty)
            {
                Categoria apagarCategoria = new Categoria();
                apagarCategoria.ID = (int)cboCategoriasApagar.SelectedValue;

                apagarCategoria.Nome = cboCategoriasApagar.Text;


                if (apagarCategoria.Eliminar())
                {
                    MessageBox.Show("Apagado com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("houve um erro");
            }
        }

        private void frmAtualizaCategoria_Load(object sender, EventArgs e)
        {
            AtualizaCombobox();
        }

        private void AtualizaCombobox()
        {

            cboCategoriasApagar.DataSource = Categorias.ListaTodos();
            cboCategoriasApagar.DisplayMember = Categoria.Campos.Nome;
            cboCategoriasApagar.ValueMember = Categoria.Campos.ID;


            cboAtualizaCategoria.DataSource = Categorias.ListaTodos();
            cboAtualizaCategoria.DisplayMember = Categoria.Campos.Nome;
            cboAtualizaCategoria.ValueMember = Categoria.Campos.ID;
            flag = true;
        }

        private void cboCategoriasApagar_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnGravar_Click_1(object sender, EventArgs e)
        {
            if (txtNomeNovaCategoria.Text != string.Empty)
            {
                Categoria novaCategoria = new Categoria();
                novaCategoria.Nome = txtNomeNovaCategoria.Text;


                if (novaCategoria.Inserir())
                {
                    MessageBox.Show("Inserido com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("houve um erro");
            }
        }
        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }
        private void btnAtualizar_Click(object sender, EventArgs e)
        {
            if (cboAtualizaCategoria.Text != string.Empty && txtCategoriaAtualizada.Text != string.Empty)
            {
                Categoria atualizarCategoria = new Categoria((int)cboAtualizaCategoria.SelectedValue);
                atualizarCategoria.Nome = txtCategoriaAtualizada.Text;
                atualizarCategoria.Atualizar();
                AtualizaCombobox();

                if (atualizarCategoria.Atualizar())
                {
                    MessageBox.Show("Inserido com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("houve um erro");
            }
        }
    }
}
