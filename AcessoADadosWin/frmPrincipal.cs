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
    public partial class frmPrincipal : Form
    {
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void categoriasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsereAtualizaEApagaCategorias f = new frmInsereAtualizaEApagaCategorias();
            f.ShowDialog();
        }

        

        private void ingredienteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsereAtualizaEApagaIngredientes f = new frmInsereAtualizaEApagaIngredientes();
            f.ShowDialog();
        }

        private void unidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsereAtualizaEApagaUnidade f = new frmInsereAtualizaEApagaUnidade();
            f.ShowDialog();
        }

        private void classificaçãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsereAtualizaEApagaClassificacao f = new frmInsereAtualizaEApagaClassificacao();
            f.ShowDialog();
        }

        private void dificuldadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmInsereAtualizaEApagaDificuldade f = new frmInsereAtualizaEApagaDificuldade();
            f.ShowDialog();
        }

        private void insereReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmLinhaReceita f = new frmLinhaReceita();
            f.ShowDialog();
        }

        private void eliminaReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApagaReceita f = new frmApagaReceita();
            f.ShowDialog();
        }

        private void validaReceitasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmValidaReceitas f = new frmValidaReceitas();
            f.ShowDialog();
        }
    }
}
