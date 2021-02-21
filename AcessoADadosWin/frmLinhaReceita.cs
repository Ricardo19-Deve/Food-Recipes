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
    public partial class frmLinhaReceita : Form
    {
        bool flag;
        Receita novaReceita;

        public frmLinhaReceita()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            AtualizaCombobox();
            novaReceita = new Receita();
            


        }

        private void AtualizaCombobox()
        {

            cboUnidade.DataSource = Unidades.ListaTodos();
            cboUnidade.DisplayMember = Unidade.Campos.Nome;
            cboUnidade.ValueMember = Unidade.Campos.ID;


            cboIngrediente.DataSource = Ingredientes.ListaTodos();
            cboIngrediente.DisplayMember = Ingrediente.Campos.Nome;
            cboIngrediente.ValueMember = Ingrediente.Campos.ID;

            cboCategoria.DataSource = Categorias.ListaTodos();
            cboCategoria.DisplayMember = Categoria.Campos.Nome;
            cboCategoria.ValueMember = Categoria.Campos.ID;

            cboDificuldade.DataSource = Dificuldades.ListaTodos();
            cboDificuldade.DisplayMember = Dificuldade.Campos.Nome;
            cboDificuldade.ValueMember = Dificuldade.Campos.ID;


            flag = true;

        }

        private void btnInserir_Click(object sender, EventArgs e)
        {
            if (txtNomeReceita.Text != string.Empty)
            {
                

                novaReceita.IdUser = txtUserID.Text.ToString();
                novaReceita.Nome = txtNomeReceita.Text;
                novaReceita.Categoria = new Categoria((int)cboCategoria.SelectedValue);
                novaReceita.Dificuldade = new Dificuldade((int)cboDificuldade.SelectedValue);
                novaReceita.Confeccao = rtbConfeccao.Text;
                novaReceita.Duracao = DateTime.ParseExact(mtbDuracao.Text, "HH:mm", null);

                if (novaReceita.Inserir())
                {
                    MessageBox.Show("Inserida receita com sucesso!");
                    AtualizaCombobox();
                }
                else
                    MessageBox.Show("houve um erro");
            }
                        
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            if (txtQuantidade.Text != string.Empty)
            {
                LinhaIngrediente novaLinha = new LinhaIngrediente();
                novaLinha.Quantidade = int.Parse(txtQuantidade.Text);

                novaLinha.Unidade = new Unidade((int)cboUnidade.SelectedValue);
                novaLinha.Ingrediente = new Ingrediente((int)cboIngrediente.SelectedValue);
               
                novaReceita.LinhasIngrediente.Add((novaLinha));        
                
                
            }
        }
    }
}
