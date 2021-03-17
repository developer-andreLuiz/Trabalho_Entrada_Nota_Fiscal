using NFMercadoTitio.Modelo;
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
    public partial class FrmInserirNfePesquisa : Form
    {
        List<ProdutoFalta> lstFaltando = new List<ProdutoFalta>();
        List<ModeloGridPesquisa> lstNfePesq_Prod = new List<ModeloGridPesquisa>();
        TNfeProc nota;
        ConexaoBD conexaoBD = new ConexaoBD();
        int codigoFornecedor = 0;
        public FrmInserirNfePesquisa(List<ProdutoFalta> lstFaltadoRef, int codFornecedorRef, TNfeProc notaLocal)
        {
            InitializeComponent();
            try
            {
                lstFaltando = lstFaltadoRef;
                codigoFornecedor = codFornecedorRef;
                nota = notaLocal;
                conexaoBD.LstProdutos(dataGridViewProdutos);
            }
            catch { }
            

        }
        void ExibirXCProd()
        {
            int tamanhoXprod = lstFaltando[0].xProd.Count();
            int tamanhoCprod = lstFaltando[0].cProd.Count();
            if (tamanhoXprod >= 45)
            {
                lblxProd.Text = lstFaltando[0].xProd.Substring(0, 45);
            }
            else
            {
                lblxProd.Text = lstFaltando[0].xProd;
            }
            if (tamanhoCprod >= 7)
            {
                lblcProd.Text = lstFaltando[0].cProd.Substring(0, 7);
            }
            else
            {
                lblcProd.Text = lstFaltando[0].cProd;
            }
        }
        private Form activeForm = null;
        private void openChildForm(Form ChildForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = ChildForm;
            ChildForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            this.Controls.Add(ChildForm);
            this.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
        }
        void Processo()
        {
            NFePesq_Prod nFePesq_Prod = new NFePesq_Prod();
            bool produtoCadastrado = false;
            if (lstFaltando.Count > 0)
            {
                ExibirXCProd();
                if (String.IsNullOrEmpty(txtCodigoBarra.Text)==false)
                {
                    Produtos produtos = produtos = conexaoBD.produtoRef(txtCodigoBarra.Text);

                    if (string.IsNullOrEmpty(produtos.Referencia.ToString()) == true)
                    {
                        Prod_Codigo prod_Codigo = conexaoBD.produtoCodigo(txtCodigoBarra.Text);
                        if (string.IsNullOrEmpty(prod_Codigo.referencia.ToString()) ==true)
                        {
                            txtCodigoBarra.Text = string.Empty;
                            MessageBox.Show("Produto Não Cadastrado", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else
                        {
                            produtoCadastrado = true;
                            produtos.Descricao = prod_Codigo.descriçao;
                            produtos.Codigo = prod_Codigo.Codigo;
                        }
                    }
                    else
                    {
                        produtoCadastrado = true;
                    }
                    if (produtoCadastrado == true)
                    {
                        nFePesq_Prod.Codigo = produtos.Codigo;
                        nFePesq_Prod.descriçao = lstFaltando[0].xProd;
                        nFePesq_Prod.Referencia = lstFaltando[0].cProd;
                        nFePesq_Prod.Cod_Forn = codigoFornecedor;

                        lstNfePesq_Prod.Add(new ModeloGridPesquisa() { codigo = int.Parse(produtos.Codigo.ToString()), cProd = lstFaltando[0].cProd, NomeBanco = produtos.Descricao.ToString(), NomeNota = lstFaltando[0].xProd });
                        
                        dataGridViewPesquisa.DataSource = null;
                        dataGridViewPesquisa.DataSource = lstNfePesq_Prod;
                        if (lstNfePesq_Prod.Count>0)
                        {
                            dataGridViewPesquisa.Columns[0].Width = 50;
                            dataGridViewPesquisa.Columns[1].Width = 300;
                            dataGridViewPesquisa.Columns[2].Width = 50;
                            dataGridViewPesquisa.Columns[3].Width = 300;
                        }
                        

                        conexaoBD.InserirNFePesq_Prod(nFePesq_Prod);
                        txtCodigoBarra.Text = string.Empty;
                        lstFaltando.RemoveAt(0);
                        Processo();
                    }
                }
            }
            else
            {
                //TODO revisao ir form FrmInserirNfeProduto
                openChildForm(new FrmInserirNfeProduto(nota, codigoFornecedor));

            }
        }

        private void txtNomeProduto_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtNomeProduto.Text) == false)
                {
                    conexaoBD.LstProdutosFiltro(dataGridViewProdutos, txtNomeProduto.Text);
                }
                else
                {
                    conexaoBD.LstProdutos(dataGridViewProdutos);
                }
            }
            catch { }
           
        }
        private void FrmInserirNfePesquisa_Load(object sender, EventArgs e)
        {
            try
            {
                ExibirXCProd();
            }
            catch { }
           
        }
        private void dataGridViewProdutos_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtCodigoBarra.Text = dataGridViewProdutos.Rows[e.RowIndex].Cells[1].Value.ToString();
                txtCodigoBarra.Focus();
                txtNomeProduto.Text = string.Empty;
                Processo();
            }
            catch { }
        }

        private void dataGridViewPesquisa_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Deseja Refazer este Registro", " Atenção! Apagando Registro", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    string xProdLocal = dataGridViewPesquisa.Rows[e.RowIndex].Cells[3].Value.ToString();
                    string cProdLocal = dataGridViewPesquisa.Rows[e.RowIndex].Cells[2].Value.ToString();


                    int indexLst = lstNfePesq_Prod.FindIndex(x => x.cProd == cProdLocal);
                    lstNfePesq_Prod.RemoveAt(indexLst);

                    conexaoBD.DeleteProdutoNFePesq_Prod(cProdLocal);

                    lstFaltando.Add(new ProdutoFalta() { cProd = cProdLocal, xProd = xProdLocal });

                    dataGridViewPesquisa.DataSource = null;
                    dataGridViewPesquisa.DataSource = lstNfePesq_Prod;
                    ExibirXCProd();

                    if (lstNfePesq_Prod.Count > 0)
                    {
                        dataGridViewPesquisa.Columns[0].Width = 50;
                        dataGridViewPesquisa.Columns[1].Width = 300;
                        dataGridViewPesquisa.Columns[2].Width = 50;
                        dataGridViewPesquisa.Columns[3].Width = 300;
                    }
                    txtCodigoBarra.Focus();
                }
            }
            catch { }
            
        }

        private void FrmInserirNfePesquisa_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter && txtCodigoBarra.Focused)
                {
                    Processo();
                }
            }
            catch { }
           
        }
    }
}
