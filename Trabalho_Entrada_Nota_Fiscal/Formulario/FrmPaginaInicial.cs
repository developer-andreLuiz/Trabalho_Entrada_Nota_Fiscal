using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFMercadoTitio
{
    public partial class FrmPaginaInicial : Form
    {
        ConexaoBD conexaoBD = new ConexaoBD();
        public FrmPaginaInicial(string notaLocal)
        {
            InitializeComponent();
            try
            {
                if (notaLocal.Count() == 44)
                {
                    txtNumeroNotaFiscal.Text = notaLocal;
                    conexaoBD.LstnFeProdutos(dataGridView, "NFe" + txtNumeroNotaFiscal.Text);
                }
            }
            catch { }
           
        }

        private void FrmPaginaInicial_Load(object sender, EventArgs e)
        {
            try
            {
                txtNumeroNotaFiscal.Focus();
            }
            catch { }
            
        }

        private void txtNumeroNotaFiscal_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter && txtNumeroNotaFiscal.Focused && txtNumeroNotaFiscal.Text.Count() == 44)
                {
                    conexaoBD.LstnFeProdutos(dataGridView, "NFe" + txtNumeroNotaFiscal.Text);
                }
            }
            catch { }
           
        }

        private void dataGridView_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Refazer este Registro", " Atenção! Apagando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string idDelete = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string codigoDelete = dataGridView.Rows[e.RowIndex].Cells[1].Value.ToString();
                    conexaoBD.DeleteNFeProdutosCodigo(idDelete, codigoDelete);
                    conexaoBD.LstnFeProdutos(dataGridView, "NFe" + txtNumeroNotaFiscal.Text);

                }
            }
            catch { }
           
        }

        private void btnApagarNota_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtNumeroNotaFiscal.Text.Count() == 44)
                {
                    if (MessageBox.Show("Deseja Apagar esta Nota", " Atenção! Apagando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        conexaoBD.DeleteNFeIdentificacaoID("NFe" + txtNumeroNotaFiscal.Text);
                        conexaoBD.DeleteNFeProdutosID("NFe" + txtNumeroNotaFiscal.Text);
                        conexaoBD.LstnFeProdutos(dataGridView, "NFe" + txtNumeroNotaFiscal.Text);
                        txtNumeroNotaFiscal.Text = string.Empty;
                    }
                }
            }
            catch { }
            
        }
    }
}
