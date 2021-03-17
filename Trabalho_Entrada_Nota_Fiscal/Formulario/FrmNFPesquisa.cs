using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFMercadoTitio.Formulario
{
    public partial class FrmNFPesquisa : Form
    {
        ConexaoBD conexaoBD = new ConexaoBD();
        public FrmNFPesquisa()
        {
            InitializeComponent();
            conexaoBD.LstFornecedores(dataGridViewFornecedor);
        }

        private void txtNomeFormecedor_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeFormecedor.Text) == false)
            {
                conexaoBD.LstFornecedoresFiltro(dataGridViewFornecedor, txtNomeFormecedor.Text);
            }
            else
            {
                conexaoBD.LstFornecedores(dataGridViewFornecedor);
            }
        }
        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(lblCodigoFornecedor.Text) == false)
            {
                if (string.IsNullOrEmpty(txtNomeProduto.Text) == false)
                {
                    conexaoBD.LstNFePesq_ProdFornecedorFiltro(dataGridViewProduto, int.Parse(lblCodigoFornecedor.Text), txtNomeProduto.Text);
                }
                else
                {
                    conexaoBD.LstNFePesq_ProdFornecedor(dataGridViewProduto, int.Parse(lblCodigoFornecedor.Text));
                }

            }
        }
        private void dataGridViewFornecedor_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                lblCodigoFornecedor.Text = dataGridViewFornecedor.Rows[e.RowIndex].Cells[0].Value.ToString();
                if (string.IsNullOrEmpty(lblCodigoFornecedor.Text) == false)
                {
                    if (string.IsNullOrEmpty(txtNomeProduto.Text) == false)
                    {
                        conexaoBD.LstNFePesq_ProdFornecedorFiltro(dataGridViewProduto, int.Parse(lblCodigoFornecedor.Text), txtNomeProduto.Text);
                    }
                    else
                    {
                        conexaoBD.LstNFePesq_ProdFornecedor(dataGridViewProduto, int.Parse(lblCodigoFornecedor.Text));
                    }
                }
            }
            catch { }
           
        }
        private void dataGridViewProduto_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(lblCodigoFornecedor.Text) == false)
                {
                    if (MessageBox.Show("Deseja deletar este Registro ?", " Atenção! Apagando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {

                        conexaoBD.DeleteProdutoNFePesq_ProdCodigo(dataGridViewProduto.Rows[e.RowIndex].Cells[0].Value.ToString(), int.Parse(lblCodigoFornecedor.Text));

                        if (string.IsNullOrEmpty(txtNomeProduto.Text) == false)
                        {
                            conexaoBD.LstNFePesq_ProdFornecedorFiltro(dataGridViewProduto, int.Parse(lblCodigoFornecedor.Text), txtNomeProduto.Text);
                        }
                        else
                        {
                            conexaoBD.LstNFePesq_ProdFornecedor(dataGridViewProduto, int.Parse(lblCodigoFornecedor.Text));
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Busque o Fornecedor antes de deletar", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch { }
        }
    }
}
