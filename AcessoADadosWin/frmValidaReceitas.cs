using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using System.Data.SqlClient;


namespace AcessoADadosWin
{
    public partial class frmValidaReceitas : Form
    {
        
        public frmValidaReceitas()
        {
            InitializeComponent();
        }

        private void frmValidaReceitas_Load(object sender, EventArgs e)
        {

            List<Receita> listaTodasReceitas = TodasAsReceitas.ListaTodos();

            ((ListBox)chlReceitasValidar).DataSource = listaTodasReceitas;
            ((ListBox)chlReceitasValidar).DisplayMember = Receita.Campos.Nome;
            ((ListBox)chlReceitasValidar).ValueMember = Receita.Campos.ID;

            for (int i = 0; i < chlReceitasValidar.Items.Count; i++)
            {
                if (((Receita)chlReceitasValidar.Items[i]).Validado)
                {
                    chlReceitasValidar.SetItemChecked(i, true);
                }
            }

        }

        private void btnValidar_Click(object sender, EventArgs e)
        {

            for (int i = 0; i < chlReceitasValidar.Items.Count; i++)
            {
                ((Receita)chlReceitasValidar.Items[i]).Validado = chlReceitasValidar.GetItemChecked(i);
                ((Receita)chlReceitasValidar.Items[i]).Update();
            }

        }

        private void ckbTodosNenhum_CheckedChanged(object sender, EventArgs e)
        {
            if (ckbTodosNenhum.Checked)
            {
                SelecionaTodos(true);
            }
            else
            {
                SelecionaTodos(false);
            }
            void SelecionaTodos(bool CheckThem)
            {
                for (int i = 0; i <= (chlReceitasValidar.Items.Count - 1); i++)
                {
                    if (CheckThem)
                    {
                        chlReceitasValidar.SetItemCheckState(i, CheckState.Checked);
                    }
                    else
                    {
                        chlReceitasValidar.SetItemCheckState(i, CheckState.Unchecked);
                    }
                }
            }
        }
    }
}

