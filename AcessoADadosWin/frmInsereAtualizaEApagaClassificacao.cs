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
    public partial class frmInsereAtualizaEApagaClassificacao : Form
    {
        bool flag;
        public frmInsereAtualizaEApagaClassificacao()
        {
            InitializeComponent();
        }

        private void frmInsereAtualizaEApagaClassificacao_Load(object sender, EventArgs e)
        {

            AtualizaCombobox();
        }

        private void AtualizaCombobox()
        {

            cboClassificacaoApagar.DataSource = Classificacoes.ListaTodos();
            cboClassificacaoApagar.DisplayMember = Classificacao.Campos.Nome;
            cboClassificacaoApagar.ValueMember = Classificacao.Campos.ID;


            cboAtualizaClassificacao.DataSource = Classificacoes.ListaTodos();
            cboAtualizaClassificacao.DisplayMember = Classificacao.Campos.Nome;
            cboAtualizaClassificacao.ValueMember = Classificacao.Campos.ID;
            flag = true;
        }

        private void btnGravar_Click(object sender, EventArgs e)
        {
            if (txtNomeNovaClassificacao.Text != string.Empty)
            {
                Classificacao novaClassificacao = new Classificacao();
                novaClassificacao.Nome = txtNomeNovaClassificacao.Text;


                if (novaClassificacao.Inserir())
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
            if (cboClassificacaoApagar.Text != string.Empty)
            {
                Classificacao apagarClassificacao = new Classificacao();
                apagarClassificacao.ID = (int)cboClassificacaoApagar.SelectedValue;

                apagarClassificacao.Nome = cboClassificacaoApagar.Text;


                if (apagarClassificacao.Eliminar())
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
            if (cboAtualizaClassificacao.Text != string.Empty && txtClassificacaoAtualizada.Text != string.Empty)
            {
                Classificacao atualizarClassificacao = new Classificacao((int)cboAtualizaClassificacao.SelectedValue);
                atualizarClassificacao.Nome = txtClassificacaoAtualizada.Text;
                atualizarClassificacao.Atualizar();
                AtualizaCombobox();

                if (atualizarClassificacao.Atualizar())
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
