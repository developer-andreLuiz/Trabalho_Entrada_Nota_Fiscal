using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using NFMercadoTitio.Modelo;

namespace NFMercadoTitio.Formulario
{
    public partial class FrmNotasXml : Form
    {
        TNfeProc nota;
        ConexaoBD conexaoBD = new ConexaoBD();
        List<GridNota> lt = new List<GridNota>();
        string impressao = string.Empty;
        public FrmNotasXml()
        {
            InitializeComponent();
        }

       
        private void clearFolder(string FolderName)
        {
            DirectoryInfo dir = new DirectoryInfo(FolderName);

            foreach (FileInfo fi in dir.GetFiles())
            {
                fi.Delete();
            }

            foreach (DirectoryInfo di in dir.GetDirectories())
            {
                clearFolder(di.FullName);
                di.Delete();
            }
        }
        void NumeroNotas()
        {

            lblNumeroNotas.Text = "Notas: " + lt.Count.ToString();
        }
        bool retornoExiste(string idNotaLocal)
        {
            string arquivo = Global.instancia.caminhoPastaNotaRetorno + @"\" + idNotaLocal + "-Retorno.xml";
            if (File.Exists(arquivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        bool notaExiste(string idNotaLocal)
        {
            string arquivo = Global.instancia.caminhoPastaNota + @"\" + idNotaLocal + ".xml";
            if (File.Exists(arquivo))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void ApagarRetorno(string nomeArquivoLocal)
        {
            if (retornoExiste(nomeArquivoLocal))
            {
                string texto = Global.instancia.caminhoPastaNotaRetorno + @"\" + nomeArquivoLocal + "-Retorno.xml";
                File.Delete(texto);
            }

        }
        void ApagarNota(string nomeArquivoLocal)
        {
            if (notaExiste(nomeArquivoLocal))
            {
                string texto = Global.instancia.caminhoPastaNota + @"\" + nomeArquivoLocal + ".xml";
                File.Delete(texto);
            }
        }
        void AbrirNota(string nomeArquivoLocal)
        {
            try
            {
                if (notaExiste(nomeArquivoLocal))
                {
                    string texto = Global.instancia.caminhoPastaNota + @"\" + nomeArquivoLocal + ".xml";
                    System.Diagnostics.Process.Start(texto);
                }
            }
            catch { }

        }
        void CarregarNota(string idNotaLocal)
        {
            string arquivo = Global.instancia.caminhoPastaNota + "\\" + idNotaLocal + ".xml";
            nota = null;
            XmlSerializer ser = new XmlSerializer(typeof(TNfeProc));
            TextReader textReader = (TextReader)new StreamReader(arquivo);
            XmlTextReader reader = new XmlTextReader(textReader);
            reader.Read();
            nota = (TNfeProc)ser.Deserialize(reader);
        }
        void CarregarObjNota(NFeIdentificacaoNota nFeIdentificacaoNotaLocal, TNfeProc notaLocal, Fornecedores fornecedorLocal)
        {
            try
            {
                nFeIdentificacaoNotaLocal.ID = notaLocal.NFe.infNFe.Id;
                if (nFeIdentificacaoNotaLocal.ID == null)
                {
                    nFeIdentificacaoNotaLocal.ID = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.ID = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.COD_FORNECEDOR = fornecedorLocal.Codigo;
                if (nFeIdentificacaoNotaLocal.COD_FORNECEDOR == null)
                {
                    nFeIdentificacaoNotaLocal.COD_FORNECEDOR = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.COD_FORNECEDOR = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.nom_fornecedor = notaLocal.NFe.infNFe.emit.xNome;
                if (nFeIdentificacaoNotaLocal.nom_fornecedor == null)
                {
                    nFeIdentificacaoNotaLocal.nom_fornecedor = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.nom_fornecedor = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.cNF = notaLocal.NFe.infNFe.ide.cNF;
                if (nFeIdentificacaoNotaLocal.cNF == null)
                {
                    nFeIdentificacaoNotaLocal.cNF = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.cNF = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.nNF = notaLocal.NFe.infNFe.ide.nNF;
                if (nFeIdentificacaoNotaLocal.nNF == null)
                {
                    nFeIdentificacaoNotaLocal.nNF = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.nNF = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.dhsaient = notaLocal.NFe.infNFe.ide.dhSaiEnt;
                if (nFeIdentificacaoNotaLocal.dhsaient == null)
                {
                    nFeIdentificacaoNotaLocal.dhsaient = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.dhsaient = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.dhemi = notaLocal.NFe.infNFe.ide.dhEmi;
                if (nFeIdentificacaoNotaLocal.dhemi == null)
                {
                    nFeIdentificacaoNotaLocal.dhemi = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.dhemi = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vBC = notaLocal.NFe.infNFe.total.ICMSTot.vBC;
                if (nFeIdentificacaoNotaLocal.vBC == null)
                {
                    nFeIdentificacaoNotaLocal.vBC = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vBC = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vICMS = notaLocal.NFe.infNFe.total.ICMSTot.vICMS;
                if (nFeIdentificacaoNotaLocal.vICMS == null)
                {
                    nFeIdentificacaoNotaLocal.vICMS = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vICMS = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vBCST = notaLocal.NFe.infNFe.total.ICMSTot.vBCST;
                if (nFeIdentificacaoNotaLocal.vBCST == null)
                {
                    nFeIdentificacaoNotaLocal.vBCST = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vBCST = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vST = notaLocal.NFe.infNFe.total.ICMSTot.vST;
                if (nFeIdentificacaoNotaLocal.vST == null)
                {
                    nFeIdentificacaoNotaLocal.vST = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vST = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vProd = notaLocal.NFe.infNFe.total.ICMSTot.vProd;
                if (nFeIdentificacaoNotaLocal.vProd == null)
                {
                    nFeIdentificacaoNotaLocal.vProd = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vProd = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vIPI = notaLocal.NFe.infNFe.total.ICMSTot.vIPI;
                if (nFeIdentificacaoNotaLocal.vIPI == null)
                {
                    nFeIdentificacaoNotaLocal.vIPI = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vIPI = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vPIS = notaLocal.NFe.infNFe.total.ICMSTot.vPIS;
                if (nFeIdentificacaoNotaLocal.vPIS == null)
                {
                    nFeIdentificacaoNotaLocal.vPIS = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vPIS = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vCOFINS = notaLocal.NFe.infNFe.total.ICMSTot.vCOFINS;
                if (nFeIdentificacaoNotaLocal.vCOFINS == null)
                {
                    nFeIdentificacaoNotaLocal.vCOFINS = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vCOFINS = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vOutro = notaLocal.NFe.infNFe.total.ICMSTot.vOutro;
                if (nFeIdentificacaoNotaLocal.vOutro == null)
                {
                    nFeIdentificacaoNotaLocal.vOutro = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vOutro = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vNF = notaLocal.NFe.infNFe.total.ICMSTot.vNF;
                if (nFeIdentificacaoNotaLocal.vNF == null)
                {
                    nFeIdentificacaoNotaLocal.vNF = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vNF = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.vTotTrib = notaLocal.NFe.infNFe.total.ICMSTot.vTotTrib;
                if (nFeIdentificacaoNotaLocal.vTotTrib == null)
                {
                    nFeIdentificacaoNotaLocal.vTotTrib = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.vTotTrib = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.FAT_vOrig = nota.NFe.infNFe.cobr.fat.vOrig;
                if (nFeIdentificacaoNotaLocal.FAT_vOrig == null)
                {
                    nFeIdentificacaoNotaLocal.FAT_vOrig = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.FAT_vOrig = 0; }
            try
            {
                nFeIdentificacaoNotaLocal.FAT_vLiq = nota.NFe.infNFe.cobr.fat.vLiq;
                if (nFeIdentificacaoNotaLocal.FAT_vLiq == null)
                {
                    nFeIdentificacaoNotaLocal.FAT_vLiq = 0;
                }
            }
            catch { nFeIdentificacaoNotaLocal.FAT_vLiq = 0; }
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



        private void FrmNotasXml_Load(object sender, EventArgs e)
        {
            try
            {
                DirectoryInfo diretorio = new DirectoryInfo(@"C:\NotasFiscais\Notas");
                FileInfo[] Arquivos = diretorio.GetFiles("*.*");

                foreach (FileInfo fileinfo in Arquivos)
                {
                    lt.Add(new GridNota { ID_NOTA = fileinfo.Name.Replace(".xml", "") });
                }



                if (lt.Count > 0)
                {
                    dataGridView.DataSource = lt;
                    dataGridView.Columns[0].Width = 669;
                }
                NumeroNotas();
            }
            catch { }
            
        }
        private void btnApagarTudo_Click(object sender, EventArgs e)
        {
            try
            {
                lt.Clear();
                dataGridView.DataSource = null;
                NumeroNotas();
                clearFolder(Global.instancia.caminhoPastaNota);
                clearFolder(Global.instancia.caminhoPastaNotaRetorno);
            }
            catch { }
           

        }
        private void dataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Delete)
                {
                    if (lt.Count() > 0)
                    {
                        if (dataGridView.SelectedCells.Count > 0)
                        {
                            DataGridViewRow linhaAtual = dataGridView.CurrentRow;
                            string idDeletar = dataGridView.Rows[linhaAtual.Index].Cells[0].Value.ToString();
                            int indexLst = lt.FindIndex(x => x.ID_NOTA.Equals(idDeletar));
                            ApagarRetorno(idDeletar);
                            ApagarNota(idDeletar);
                            lt.RemoveAt(indexLst);
                            NumeroNotas();
                            dataGridView.DataSource = null;
                            if (lt.Count > 0)
                            {
                                dataGridView.DataSource = lt;
                                dataGridView.Columns[0].Width = 669;
                            }
                        }
                    }

                }
                if (e.KeyCode == Keys.Escape)
                {
                    if (lt.Count() > 0)
                    {
                        if (dataGridView.SelectedCells.Count > 0)
                        {
                            DataGridViewRow linhaAtual = dataGridView.CurrentRow;
                            string idDeletar = dataGridView.Rows[linhaAtual.Index].Cells[0].Value.ToString();
                            AbrirNota(idDeletar);

                        }
                    }

                }
            }
            catch { }
           
        }
        private void printDocument_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Times New Roman", 10, FontStyle.Regular);
                PointF pointF = new PointF(20, 20);
                SolidBrush cor = new SolidBrush(Color.Black);
                Pen lapis = new Pen(Color.Black, 3);
                e.Graphics.DrawString(impressao, font, cor, pointF);
            }
            catch { }
           
        }
        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                string notaID = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                impressao = string.Empty;
                bool notaCarregada = false;
                bool fornecedorCadastrado = false;
                bool produtosCadastrados = false;
                int codigoFornecedor = 0;
                Fornecedores fornecedor = new Fornecedores();
                nota = null;
                if (notaID.Count() == 44)
                {
                    CarregarNota(notaID);
                    if (string.IsNullOrEmpty(nota.NFe.infNFe.Id) == false)
                    {
                        notaCarregada = true;
                    }
                    //Nota Carregada

                    if (notaCarregada == true)
                    {
                        fornecedor = conexaoBD.fornecedor(nota.NFe.infNFe.emit.Item.ToString());
                        if (string.IsNullOrEmpty(fornecedor.Nome.ToString()) == true)
                        {
                            Fornec_codigo fornecedorCodigo = conexaoBD.fornecedorCodigo(nota.NFe.infNFe.emit.Item.ToString());
                            if (string.IsNullOrEmpty(fornecedorCodigo.nome.ToString()) == false)
                            {
                                fornecedorCadastrado = true;
                                fornecedor.Nome = fornecedorCodigo.nome;
                                fornecedor.Codigo = fornecedorCodigo.Codigo;
                                fornecedor.CNPJ_CPF = fornecedorCodigo.Cnpj;
                                codigoFornecedor = int.Parse(fornecedor.Codigo.ToString());
                            }
                            else
                            {
                                MessageBox.Show("Fornecedor não Cadastrado", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            fornecedorCadastrado = true;
                            codigoFornecedor = int.Parse(fornecedor.Codigo.ToString());
                        }

                    }
                    //Forncedor Verificado

                    if (fornecedorCadastrado == true)
                    {
                        NFeIdentificacaoNota nFeIdentificacaoNota = conexaoBD.nFeIdentificacaoNota("NFe" + notaID);
                        if (string.IsNullOrEmpty(nFeIdentificacaoNota.ID.ToString()) == true)
                        {
                            CarregarObjNota(nFeIdentificacaoNota, nota, fornecedor);
                            conexaoBD.InsertNFeIdentificacaoNota(nFeIdentificacaoNota);
                        }

                        List<ProdutoFalta> lstProdutoFalta = new List<ProdutoFalta>();

                        foreach (var a in nota.NFe.infNFe.det)
                        {
                            bool produtoCadastradoLoop = false;
                            Produtos produto = new Produtos();
                            Prod_Codigo produtoCodigo = new Prod_Codigo();
                            NFePesq_Prod nFePesq_Prod = new NFePesq_Prod();

                            //buscar Nfe pesquisa produto
                            if (produtoCadastradoLoop == false)
                            {
                                nFePesq_Prod = conexaoBD.nFePesq_Prod(a.prod.cProd, int.Parse(fornecedor.Codigo.ToString()));
                                if (string.IsNullOrEmpty(nFePesq_Prod.Referencia.ToString()) == false)
                                {
                                    if (nFePesq_Prod.Referencia.ToString().Equals(nFePesq_Prod.Codigo.ToString()) == false)
                                    {
                                        produtoCadastradoLoop = true;
                                    }
                                }
                            }
                            if (produtoCadastradoLoop == false)
                            {
                                nFePesq_Prod = conexaoBD.nFePesq_Prod(a.prod.cEAN, int.Parse(fornecedor.Codigo.ToString()));
                                if (string.IsNullOrEmpty(nFePesq_Prod.Referencia.ToString()) == false)
                                {
                                    if (nFePesq_Prod.Referencia.ToString().Equals(nFePesq_Prod.Codigo.ToString()) == false)
                                    {
                                        produtoCadastradoLoop = true;
                                    }
                                }
                            }
                            if (produtoCadastradoLoop == false)
                            {
                                nFePesq_Prod = conexaoBD.nFePesq_Prod(a.prod.cEANTrib, int.Parse(fornecedor.Codigo.ToString()));
                                if (string.IsNullOrEmpty(nFePesq_Prod.Referencia.ToString()) == false)
                                {
                                    if (nFePesq_Prod.Referencia.ToString().Equals(nFePesq_Prod.Codigo.ToString()) == false)
                                    {
                                        produtoCadastradoLoop = true;
                                    }
                                }
                            }

                            //busca na tabela produto 
                            if (produtoCadastradoLoop == false)
                            {
                                produto = conexaoBD.produtoRef(a.prod.cProd);
                                if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                                {
                                    if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                    {
                                        if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                        {
                                            produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                        }

                                    }
                                    if (produto.Referencia.ToString().Equals(produto.Codigo.ToString()) == false)
                                    {
                                        produtoCadastradoLoop = true;
                                    }

                                }
                            }
                            if (produtoCadastradoLoop == false)
                            {
                                produto = conexaoBD.produtoRef(a.prod.cEAN);
                                if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                                {
                                    if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                    {
                                        if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                        {
                                            produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                        }
                                    }
                                    if (produto.Referencia.ToString().Equals(produto.Codigo.ToString()) == false)
                                    {
                                        produtoCadastradoLoop = true;
                                    }
                                }
                            }
                            if (produtoCadastradoLoop == false)
                            {
                                produto = conexaoBD.produtoRef(a.prod.cEANTrib);
                                if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                                {
                                    if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                    {
                                        produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                        {
                                            produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                        }
                                    }
                                    if (produto.Referencia.ToString().Equals(produto.Codigo.ToString()) == false)
                                    {
                                        produtoCadastradoLoop = true;
                                    }
                                }
                            }

                            //busca na tabela produtoCodigo
                            if (produtoCadastradoLoop == false)
                            {
                                produtoCodigo = conexaoBD.produtoCodigo(a.prod.cProd);

                                if (string.IsNullOrEmpty(produtoCodigo.Codigo.ToString()) == false)
                                {
                                    produto = conexaoBD.produtoCod(produtoCodigo.Codigo.ToString());

                                    if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                                    {
                                        if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                        {
                                            if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                            {
                                                produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                            }
                                        }
                                        if (produto.Referencia.ToString().Equals(produto.Codigo.ToString()) == false)
                                        {
                                            produtoCadastradoLoop = true;
                                        }
                                    }
                                }
                            }
                            if (produtoCadastradoLoop == false)
                            {
                                produtoCodigo = conexaoBD.produtoCodigo(a.prod.cEAN);

                                if (string.IsNullOrEmpty(produtoCodigo.Codigo.ToString()) == false)
                                {
                                    produto = conexaoBD.produtoCod(produtoCodigo.Codigo.ToString());

                                    if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                                    {
                                        if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                        {
                                            if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                            {
                                                produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                            }
                                        }
                                        if (produto.Referencia.ToString().Equals(produto.Codigo.ToString()) == false)
                                        {
                                            produtoCadastradoLoop = true;
                                        }
                                    }
                                }
                            }
                            if (produtoCadastradoLoop == false)
                            {
                                produtoCodigo = conexaoBD.produtoCodigo(a.prod.cEANTrib);

                                if (string.IsNullOrEmpty(produtoCodigo.Codigo.ToString()) == false)
                                {
                                    produto = conexaoBD.produtoCod(produtoCodigo.Codigo.ToString());

                                    if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                                    {
                                        if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                        {
                                            if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                            {
                                                produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                            }
                                        }
                                        if (produto.Referencia.ToString().Equals(produto.Codigo.ToString()) == false)
                                        {
                                            produtoCadastradoLoop = true;
                                        }
                                    }
                                }
                            }

                            if (produtoCadastradoLoop == false)
                            {
                                lstProdutoFalta.Add(new ProdutoFalta() { cProd = a.prod.cProd, xProd = a.prod.xProd });
                            }
                        }

                        if (lstProdutoFalta.Count == 0)
                        {
                            produtosCadastrados = true;
                        }
                        else
                        {
                            if (MessageBox.Show("Deseja Imprimir Produtos que estão Faltando no Sistema", " Atenção! Produtos Faltando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {

                                impressao = "Produtos Faltando na Nota   " + notaID + "   " + Environment.NewLine + Environment.NewLine + Environment.NewLine;
                                foreach (var a in lstProdutoFalta)
                                {
                                    impressao = impressao + a.cProd + "    " + a.xProd + Environment.NewLine;
                                }
                                printDocument.Print();
                            }
                            if (MessageBox.Show("Deseja Cadastrar Produtos que estão Faltando no Sistema", " Atenção! Produtos Faltando", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                openChildForm(new FrmInserirNfePesquisa(lstProdutoFalta, codigoFornecedor, nota));
                            }


                        }
                    }
                    //Produto Verificado

                    if (produtosCadastrados)
                    {
                        openChildForm(new FrmInserirNfeProduto(nota, codigoFornecedor));
                    }

                }
            }
            catch { }
            
        }

        
    }
}
