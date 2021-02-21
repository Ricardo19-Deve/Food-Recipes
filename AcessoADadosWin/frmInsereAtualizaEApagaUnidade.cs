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
    public partial class frmInsereAtualizaEApagaUnidade : Form
    {
        bool flag;
        public frmInsereAtualizaEApagaUnidade()
        {
            InitializeComponent();
        }

        private void frmInsereAtualizaEApagaUnidade_Load(object sender, EventArgs e)
        {

            AtualizaCombobox();
        }  

            private void AtualizaCombobox()
            {

                cboUnidadeApagar.DataSource = Unidades.ListaTodos();
                cboUnidadeApagar.DisplayMember = Unidade.Campos.Nome;
                cboUnidadeApagar.ValueMember = Unidade.Campos.ID;


                cboAtualizaUnidade.DataSource = Unidades.ListaTodos();
                cboAtualizaUnidade.DisplayMember = Unidade.Campos.Nome;
                cboAtualizaUnidade.ValueMember = Unidade.Campos.ID;
                flag = true;
            }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtNomeNovaUnidade.Text != string.Empty)
            {
                Unidade novaUnidade = new Unidade();
                novaUnidade.Nome = txtNomeNovaUnidade.Text;


                if (novaUnidade.Inserir())
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
            if (cboUnidadeApagar.Text != string.Empty)
            {
                Unidade apagarUnidade = new Unidade();
                apagarUnidade.ID = (int)cboUnidadeApagar.SelectedValue;

                apagarUnidade.Nome = cboUnidadeApagar.Text;


                if (apagarUnidade.Eliminar())
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
            if (cboAtualizaUnidade.Text != string.Empty && txtUnidadeAtualizada.Text != string.Empty)
            {
                Unidade atualizarUnidade = new Unidade((int)cboAtualizaUnidade.SelectedValue);
                atualizarUnidade.Nome = txtUnidadeAtualizada.Text;
                atualizarUnidade.Atualizar();
                AtualizaCombobox();

                if (atualizarUnidade.Atualizar())
                {
                    MessageBox.Show("Inserido com sucesso");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("Houve um erro");
            }
        }
    }
    }

