using NFMercadoTitio.Modelo;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFMercadoTitio
{
    public class ConexaoBD
    {
        #region Fornecedores
        public Fornecedores fornecedor(string cnpj)
        {
            Fornecedores fornecedorReturn = new Fornecedores();
            fornecedorReturn.Codigo = string.Empty;
            fornecedorReturn.Nome = string.Empty;
            fornecedorReturn.Endereco = string.Empty;
            fornecedorReturn.Bairro = string.Empty;
            fornecedorReturn.Cidade = string.Empty;
            fornecedorReturn.Uf = string.Empty;
            fornecedorReturn.Cep = string.Empty;
            fornecedorReturn.Telefone1 = string.Empty;
            fornecedorReturn.Telefone2 = string.Empty;
            fornecedorReturn.Representante = string.Empty;
            fornecedorReturn.CNPJ_CPF = string.Empty;
            fornecedorReturn.Observacao = string.Empty;
            fornecedorReturn.iestadual = string.Empty;
            fornecedorReturn.nota = string.Empty;
            fornecedorReturn.Fornec_Unit = string.Empty;

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from Fornecedores where CNPJ_CPF = '" + cnpj + "';";
            OleDbDataReader reader = comando.ExecuteReader();
           
            while (reader.Read())
            {
                if (reader["Codigo"] != null)
                {
                    fornecedorReturn.Codigo = reader["Codigo"];
                    fornecedorReturn.Nome = reader["Nome"];
                    fornecedorReturn.Endereco = reader["Endereco"];
                    fornecedorReturn.Bairro = reader["Bairro"];
                    fornecedorReturn.Cidade = reader["Cidade"];
                    fornecedorReturn.Uf = reader["Uf"];
                    fornecedorReturn.Cep = reader["Cep"];
                    fornecedorReturn.Telefone1 = reader["Telefone1"];
                    fornecedorReturn.Telefone2 = reader["Telefone2"];
                    fornecedorReturn.Representante = reader["Representante"];
                    fornecedorReturn.CNPJ_CPF = reader["CNPJ_CPF"];
                    fornecedorReturn.Observacao = reader["Observacao"];
                    fornecedorReturn.iestadual = reader["iestadual"];
                    fornecedorReturn.nota = reader["nota"];
                    fornecedorReturn.Fornec_Unit = reader["Fornec_Unit"];
                }
            }
            return fornecedorReturn;
        }
        public Fornec_codigo fornecedorCodigo(string cnpf)
        {
            Fornec_codigo fornecedorReturn = new Fornec_codigo();
            fornecedorReturn.Codigo = string.Empty;
            fornecedorReturn.Cnpj = string.Empty;
            fornecedorReturn.nome = string.Empty;
            fornecedorReturn.Fornec_Unit = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from Fornec_codigo where Cnpj = '" + cnpf + "';";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Codigo"] != null)
                {
                    fornecedorReturn.Codigo = reader["Codigo"];
                    fornecedorReturn.Cnpj = reader["Cnpj"];
                    fornecedorReturn.nome = reader["nome"];
                    fornecedorReturn.Fornec_Unit = reader["Fornec_Unit"];
                }
            }
            return fornecedorReturn;
        }
        public void LstFornecedores(DataGridView dataGridView)
        {
            string comandoString = "select Codigo, Nome from Fornecedores order by Nome asc";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);

            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;
            if (dataGridView.Rows.Count>0)
            {
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 600;
            }
            

        }
        public void LstFornecedoresFiltro(DataGridView dataGridView, string textLocal)
        {
            string comandoString = "select Codigo, Nome from Fornecedores where Nome like '%" + textLocal + "%' order by Nome asc";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);
            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;

            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 600;
            }
        }
        #endregion

        #region NFeIdentificacaoNota
        public NFeIdentificacaoNota nFeIdentificacaoNota(string id)
        {
            NFeIdentificacaoNota notaReturn = new NFeIdentificacaoNota();
            notaReturn.ID = string.Empty;
            notaReturn.COD_FORNECEDOR = string.Empty;
            notaReturn.nom_fornecedor = string.Empty;
            notaReturn.cNF = string.Empty;
            notaReturn.nNF = string.Empty;
            notaReturn.dhsaient = string.Empty;
            notaReturn.dhemi = string.Empty;
            notaReturn.vBC = string.Empty;
            notaReturn.vICMS = string.Empty;
            notaReturn.vBCST = string.Empty;
            notaReturn.vST = string.Empty;
            notaReturn.vProd = string.Empty;
            notaReturn.vIPI = string.Empty;
            notaReturn.vPIS = string.Empty;
            notaReturn.vCOFINS = string.Empty;
            notaReturn.vOutro = string.Empty;
            notaReturn.vNF = string.Empty;
            notaReturn.vTotTrib = string.Empty;
            notaReturn.FAT_vOrig = string.Empty;
            notaReturn.FAT_vLiq = string.Empty;

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from NFeIdentificacaoNota where ID = '" + id + "';";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["ID"] != null)
                {
                    notaReturn.ID = reader["ID"];
                    notaReturn.COD_FORNECEDOR = reader["COD_FORNECEDOR"];
                    notaReturn.nom_fornecedor = reader["nom_fornecedor"];
                    notaReturn.cNF = reader["cNF"];
                    notaReturn.nNF = reader["nNF"];
                    notaReturn.dhsaient = reader["dhsaient"];
                    notaReturn.dhemi = reader["dhemi"];
                    notaReturn.vBC = reader["vBC"];
                    notaReturn.vICMS = reader["vICMS"];
                    notaReturn.vBCST = reader["vBCST"];
                    notaReturn.vST = reader["vST"];
                    notaReturn.vProd = reader["vProd"];
                    notaReturn.vIPI = reader["vIPI"];
                    notaReturn.vPIS = reader["vPIS"];
                    notaReturn.vCOFINS = reader["vCOFINS"];
                    notaReturn.vOutro = reader["vOutro"];
                    notaReturn.vNF = reader["vNF"];
                    notaReturn.vTotTrib = reader["vTotTrib"];
                    notaReturn.FAT_vOrig = reader["FAT_vOrig"];
                    notaReturn.FAT_vLiq = reader["FAT_vLiq"];
                }
            }
            return notaReturn;
        }
        public void InsertNFeIdentificacaoNota(NFeIdentificacaoNota nFeLocal)
        {
            string comandoString = "insert into NFeIdentificacaoNota (ID, COD_FORNECEDOR, nom_fornecedor, cNF, nNF, dhsaient, dhemi, vBC, vICMS, vBCST, vST, vProd, vIPI, vPIS, vCOFINS, vOutro, vNF, vTotTrib, FAT_vOrig, FAT_vLiq) values (@ID, @COD_FORNECEDOR, @nom_fornecedor, @cNF, @nNF, @dhsaient, @dhemi, @vBC, @vICMS, @vBCST, @vST, @vProd, @vIPI, @vPIS, @vCOFINS, @vOutro, @vNF, @vTotTrib, @FAT_vOrig, @FAT_vLiq);";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            comando.Parameters.AddWithValue("ID", nFeLocal.ID);
            comando.Parameters.AddWithValue("COD_FORNECEDOR", nFeLocal.COD_FORNECEDOR);
            int tamanho = nFeLocal.nom_fornecedor.ToString().Count();
            if (tamanho < 45)
            {
                comando.Parameters.AddWithValue("nom_fornecedor", nFeLocal.nom_fornecedor.ToString().Substring(0, tamanho));
            }
            else
            {
                comando.Parameters.AddWithValue("nom_fornecedor", nFeLocal.nom_fornecedor.ToString().Substring(0, 45));
            }

            comando.Parameters.AddWithValue("cNF", nFeLocal.cNF);
            comando.Parameters.AddWithValue("nNF", nFeLocal.nNF);
            comando.Parameters.AddWithValue("dhsaient", nFeLocal.dhsaient);
            comando.Parameters.AddWithValue("dhemi", nFeLocal.dhemi);
            comando.Parameters.AddWithValue("vBC", nFeLocal.vBC);
            comando.Parameters.AddWithValue("vICMS", nFeLocal.vICMS);
            comando.Parameters.AddWithValue("vBCST", nFeLocal.vBCST);
            comando.Parameters.AddWithValue("vST", nFeLocal.vST);
            comando.Parameters.AddWithValue("vProd", nFeLocal.vProd);
            comando.Parameters.AddWithValue("vIPI", nFeLocal.vIPI);
            comando.Parameters.AddWithValue("vPIS", nFeLocal.vPIS);
            comando.Parameters.AddWithValue("vCOFINS", nFeLocal.vCOFINS);
            comando.Parameters.AddWithValue("vOutro", nFeLocal.vOutro);
            comando.Parameters.AddWithValue("vNF", nFeLocal.vNF);
            comando.Parameters.AddWithValue("vTotTrib", nFeLocal.vTotTrib);
            comando.Parameters.AddWithValue("FAT_vOrig", nFeLocal.FAT_vOrig);
            comando.Parameters.AddWithValue("FAT_vLiq", nFeLocal.FAT_vLiq);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();

        }

        public void DeleteNFeIdentificacaoID(string idLocal)
        {

            string comandoString = "DELETE FROM NFeIdentificacaoNota  where ID = '" + idLocal + "'";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }
        #endregion

        #region NFePesq_Prod
        public NFePesq_Prod nFePesq_Prod(string referencia, int codFornecedorLocal)
        {
            NFePesq_Prod nFePesq_ProdReturn = new NFePesq_Prod();
            nFePesq_ProdReturn.Controle = string.Empty;
            nFePesq_ProdReturn.Codigo = string.Empty;
            nFePesq_ProdReturn.descriçao = string.Empty;
            nFePesq_ProdReturn.Referencia = string.Empty;
            nFePesq_ProdReturn.Cod_Forn = string.Empty;
            nFePesq_ProdReturn.corrigido = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from NFePesq_Prod where Referencia = '" + referencia + "' and Cod_Forn = " + codFornecedorLocal;
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Referencia"] != null)
                {
                    nFePesq_ProdReturn.Controle = reader["Controle"];
                    nFePesq_ProdReturn.Codigo = reader["Codigo"];
                    nFePesq_ProdReturn.descriçao = reader["descriçao"];
                    nFePesq_ProdReturn.Referencia = reader["Referencia"];
                    nFePesq_ProdReturn.Cod_Forn = reader["Cod_Forn"];
                    nFePesq_ProdReturn.corrigido = reader["corrigido"];

                }
            }
            return nFePesq_ProdReturn;
        }
        public void InserirNFePesq_Prod(NFePesq_Prod nFePesq_Prod)
        {
            try
            {
                string comandoString = "insert into NFePesq_Prod (Codigo, descriçao, Referencia, Cod_Forn) values (@Codigo, @descriçao, @Referencia, @Cod_Forn);";
                OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
                comando.Parameters.AddWithValue("Codigo", nFePesq_Prod.Codigo);
                comando.Parameters.AddWithValue("descriçao", nFePesq_Prod.descriçao);
                comando.Parameters.AddWithValue("Referencia", nFePesq_Prod.Referencia);
                comando.Parameters.AddWithValue("Cod_Forn", nFePesq_Prod.Cod_Forn);
                if (Global.instancia.conexao.State == ConnectionState.Closed)
                {
                    Global.instancia.conexao.Open();
                }
                comando.ExecuteNonQuery();
            }
            catch (Exception a)
            {

                MessageBox.Show(a.Message);
            }
           
           
        }
        public void DeleteProdutoNFePesq_Prod(string cProd)
        {

            string comandoString = "DELETE FROM NFePesq_Prod where Referencia = '" + cProd + "';";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }
        public void LstNFePesq_ProdFornecedor(DataGridView dataGridView, int codFornecedorLocal)
        {
            string comandoString = "select Codigo, descriçao from NFePesq_Prod where Cod_Forn = " + codFornecedorLocal + " order by descriçao asc";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);
            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 600;
            }
        }
        public void LstNFePesq_ProdFornecedorFiltro(DataGridView dataGridView, int codFornecedorLocal, string textLocal)
        {
            string comandoString = "select Codigo, descriçao from NFePesq_Prod where Cod_Forn = " + codFornecedorLocal + " and descriçao like '%" + textLocal + "%' order by descriçao asc";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);
            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Columns[0].Width = 50;
                dataGridView.Columns[1].Width = 600;
            }
        }
        public void DeleteProdutoNFePesq_ProdCodigo(string codigoLocal, int codigoFornecedorLocal)
        {
            string comandoString = "DELETE FROM NFePesq_Prod where Codigo = '" + codigoLocal + "' and Cod_Forn = " + codigoFornecedorLocal;
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }
        #endregion

        #region Produto
        public Produtos produtoRef(string referencia)
        {
            Produtos produtoReturn = new Produtos();
            produtoReturn.Referencia = string.Empty;
            produtoReturn.iguala1 = string.Empty;
            produtoReturn.Descricao = string.Empty;
            produtoReturn.embalagem = string.Empty;
            produtoReturn.quantidade = string.Empty;
            produtoReturn.CustoUnitario = string.Empty;
            produtoReturn.Margem = string.Empty;
            produtoReturn.ValorVenda = string.Empty;
            produtoReturn.margOnline = string.Empty;
            produtoReturn.valvenda_online = string.Empty;
            produtoReturn.ItensPedido = string.Empty;
            produtoReturn.Codigo = string.Empty;
            produtoReturn.Quant = string.Empty;
            produtoReturn.Numero = string.Empty;
            produtoReturn.Unidade = string.Empty;
            produtoReturn.nome = string.Empty;
            produtoReturn.grama = string.Empty;
            produtoReturn.anulado = string.Empty;
            produtoReturn.colocar = string.Empty;
            produtoReturn.Multiplicar = string.Empty;
            produtoReturn.ValorCesta = string.Empty;
            produtoReturn.MargCesta = string.Empty;
            produtoReturn.Quant_cesta = string.Empty;
            produtoReturn.NumCest = string.Empty;
            produtoReturn.Num = string.Empty;
            produtoReturn.iguala = string.Empty;
            produtoReturn.ValorPromocao = string.Empty;
            produtoReturn.MargPromocao = string.Empty;
            produtoReturn.margAvista = string.Empty;
            produtoReturn.margCartao = string.Empty;
            produtoReturn.margCheque = string.Empty;
            produtoReturn.avista = string.Empty;
            produtoReturn.cartao = string.Empty;
            produtoReturn.cheque = string.Empty;
            produtoReturn.Vender = string.Empty;
            produtoReturn.CD_Balanco = string.Empty;
            produtoReturn.SubCategoria = string.Empty;
            produtoReturn.Categoria = string.Empty;
            produtoReturn.UltimaEntrada = string.Empty;
            produtoReturn.Peso = string.Empty;
            produtoReturn.valCartao = string.Empty;
            produtoReturn.QuantCx = string.Empty;
            produtoReturn.IgualaCx = string.Empty;
            produtoReturn.ChCaixa = string.Empty;
            produtoReturn.Validade = string.Empty;
            produtoReturn.Controle = string.Empty;
            produtoReturn.QuantForn = string.Empty;
            produtoReturn.QuantKg = string.Empty;
            produtoReturn.Cx_Fechada = string.Empty;
            produtoReturn.Tot_meses = string.Empty;
            produtoReturn.Quant_fardo = string.Empty;
            produtoReturn.Quant_desc = string.Empty;
            produtoReturn.liberar_decer = string.Empty;
            produtoReturn.Quant_Avista = string.Empty;
            produtoReturn.validade_Indeterminada = string.Empty;
            produtoReturn.data = string.Empty;
            produtoReturn.hora = string.Empty;
            produtoReturn.vale_Alimentaçao = string.Empty;
            produtoReturn.USUARIO = string.Empty;
            produtoReturn.Acrescimo_alimentaçao = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from Produtos where Referencia = '" + referencia + "';";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Referencia"] != null)
                {
                    produtoReturn.Referencia = reader["Referencia"];
                    produtoReturn.iguala1 = reader["iguala1"];
                    produtoReturn.Descricao = reader["Descricao"];
                    produtoReturn.embalagem = reader["embalagem"];
                    produtoReturn.quantidade = reader["quantidade"];
                    produtoReturn.CustoUnitario = reader["CustoUnitario"];
                    produtoReturn.Margem = reader["Margem"];
                    produtoReturn.ValorVenda = reader["ValorVenda"];
                    produtoReturn.margOnline = reader["margOnline"];
                    produtoReturn.valvenda_online = reader["valvenda_online"];
                    produtoReturn.ItensPedido = reader["ItensPedido"];
                    produtoReturn.Codigo = reader["Codigo"];
                    produtoReturn.Quant = reader["Quant"];
                    produtoReturn.Numero = reader["Numero"];
                    produtoReturn.Unidade = reader["Unidade"];
                    produtoReturn.nome = reader["nome"];
                    produtoReturn.grama = reader["grama"];
                    produtoReturn.anulado = reader["anulado"];
                    produtoReturn.colocar = reader["colocar"];
                    produtoReturn.Multiplicar = reader["Multiplicar"];
                    produtoReturn.ValorCesta = reader["ValorCesta"];
                    produtoReturn.MargCesta = reader["MargCesta"];
                    produtoReturn.Quant_cesta = reader["Quant_cesta"];
                    produtoReturn.NumCest = reader["NumCest"];
                    produtoReturn.Num = reader["Num"];
                    produtoReturn.iguala = reader["iguala"];
                    produtoReturn.ValorPromocao = reader["ValorPromocao"];
                    produtoReturn.MargPromocao = reader["MargPromocao"];
                    produtoReturn.margAvista = reader["margAvista"];
                    produtoReturn.margCartao = reader["margCartao"];
                    produtoReturn.margCheque = reader["margCheque"];
                    produtoReturn.avista = reader["avista"];
                    produtoReturn.cartao = reader["cartao"];
                    produtoReturn.cheque = reader["cheque"];
                    produtoReturn.Vender = reader["Vender"];
                    produtoReturn.CD_Balanco = reader["CD_Balanco"];
                    produtoReturn.SubCategoria = reader["SubCategoria"];
                    produtoReturn.Categoria = reader["Categoria"];
                    produtoReturn.UltimaEntrada = reader["UltimaEntrada"];
                    produtoReturn.Peso = reader["Peso"];
                    produtoReturn.valCartao = reader["valCartao"];
                    produtoReturn.QuantCx = reader["QuantCx"];
                    produtoReturn.IgualaCx = reader["IgualaCx"];
                    produtoReturn.ChCaixa = reader["ChCaixa"];
                    produtoReturn.Validade = reader["Validade"];
                    produtoReturn.Controle = reader["Controle"];
                    produtoReturn.QuantForn = reader["QuantForn"];
                    produtoReturn.QuantKg = reader["QuantKg"];
                    produtoReturn.Cx_Fechada = reader["Cx_Fechada"];
                    produtoReturn.Tot_meses = reader["Tot_meses"];
                    produtoReturn.Quant_fardo = reader["Quant_fardo"];
                    produtoReturn.Quant_desc = reader["Quant_desc"];
                    produtoReturn.liberar_decer = reader["liberar_decer"];
                    produtoReturn.Quant_Avista = reader["Quant_Avista"];
                    produtoReturn.validade_Indeterminada = reader["validade_Indeterminada"];
                    produtoReturn.data = reader["data"];
                    produtoReturn.hora = reader["hora"];
                    produtoReturn.vale_Alimentaçao = reader["vale_Alimentaçao"];
                    produtoReturn.USUARIO = reader["USUARIO"];
                    produtoReturn.Acrescimo_alimentaçao = reader["Acrescimo_alimentaçao"];
                }
            }
            return produtoReturn;
        }
        public Produtos produtoCH(int igualaCXLocal)
        {
            Produtos produtoReturn = new Produtos();
            produtoReturn.Referencia = string.Empty;
            produtoReturn.iguala1 = string.Empty;
            produtoReturn.Descricao = string.Empty;
            produtoReturn.embalagem = string.Empty;
            produtoReturn.quantidade = string.Empty;
            produtoReturn.CustoUnitario = string.Empty;
            produtoReturn.Margem = string.Empty;
            produtoReturn.ValorVenda = string.Empty;
            produtoReturn.margOnline = string.Empty;
            produtoReturn.valvenda_online = string.Empty;
            produtoReturn.ItensPedido = string.Empty;
            produtoReturn.Codigo = string.Empty;
            produtoReturn.Quant = string.Empty;
            produtoReturn.Numero = string.Empty;
            produtoReturn.Unidade = string.Empty;
            produtoReturn.nome = string.Empty;
            produtoReturn.grama = string.Empty;
            produtoReturn.anulado = string.Empty;
            produtoReturn.colocar = string.Empty;
            produtoReturn.Multiplicar = string.Empty;
            produtoReturn.ValorCesta = string.Empty;
            produtoReturn.MargCesta = string.Empty;
            produtoReturn.Quant_cesta = string.Empty;
            produtoReturn.NumCest = string.Empty;
            produtoReturn.Num = string.Empty;
            produtoReturn.iguala = string.Empty;
            produtoReturn.ValorPromocao = string.Empty;
            produtoReturn.MargPromocao = string.Empty;
            produtoReturn.margAvista = string.Empty;
            produtoReturn.margCartao = string.Empty;
            produtoReturn.margCheque = string.Empty;
            produtoReturn.avista = string.Empty;
            produtoReturn.cartao = string.Empty;
            produtoReturn.cheque = string.Empty;
            produtoReturn.Vender = string.Empty;
            produtoReturn.CD_Balanco = string.Empty;
            produtoReturn.SubCategoria = string.Empty;
            produtoReturn.Categoria = string.Empty;
            produtoReturn.UltimaEntrada = string.Empty;
            produtoReturn.Peso = string.Empty;
            produtoReturn.valCartao = string.Empty;
            produtoReturn.QuantCx = string.Empty;
            produtoReturn.IgualaCx = string.Empty;
            produtoReturn.ChCaixa = string.Empty;
            produtoReturn.Validade = string.Empty;
            produtoReturn.Controle = string.Empty;
            produtoReturn.QuantForn = string.Empty;
            produtoReturn.QuantKg = string.Empty;
            produtoReturn.Cx_Fechada = string.Empty;
            produtoReturn.Tot_meses = string.Empty;
            produtoReturn.Quant_fardo = string.Empty;
            produtoReturn.Quant_desc = string.Empty;
            produtoReturn.liberar_decer = string.Empty;
            produtoReturn.Quant_Avista = string.Empty;
            produtoReturn.validade_Indeterminada = string.Empty;
            produtoReturn.data = string.Empty;
            produtoReturn.hora = string.Empty;
            produtoReturn.vale_Alimentaçao = string.Empty;
            produtoReturn.USUARIO = string.Empty;
            produtoReturn.Acrescimo_alimentaçao = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from Produtos where IgualaCx = " + igualaCXLocal + " and ChCaixa = false";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Referencia"] != null)
                {
                    produtoReturn.Referencia = reader["Referencia"];
                    produtoReturn.iguala1 = reader["iguala1"];
                    produtoReturn.Descricao = reader["Descricao"];
                    produtoReturn.embalagem = reader["embalagem"];
                    produtoReturn.quantidade = reader["quantidade"];
                    produtoReturn.CustoUnitario = reader["CustoUnitario"];
                    produtoReturn.Margem = reader["Margem"];
                    produtoReturn.ValorVenda = reader["ValorVenda"];
                    produtoReturn.margOnline = reader["margOnline"];
                    produtoReturn.valvenda_online = reader["valvenda_online"];
                    produtoReturn.ItensPedido = reader["ItensPedido"];
                    produtoReturn.Codigo = reader["Codigo"];
                    produtoReturn.Quant = reader["Quant"];
                    produtoReturn.Numero = reader["Numero"];
                    produtoReturn.Unidade = reader["Unidade"];
                    produtoReturn.nome = reader["nome"];
                    produtoReturn.grama = reader["grama"];
                    produtoReturn.anulado = reader["anulado"];
                    produtoReturn.colocar = reader["colocar"];
                    produtoReturn.Multiplicar = reader["Multiplicar"];
                    produtoReturn.ValorCesta = reader["ValorCesta"];
                    produtoReturn.MargCesta = reader["MargCesta"];
                    produtoReturn.Quant_cesta = reader["Quant_cesta"];
                    produtoReturn.NumCest = reader["NumCest"];
                    produtoReturn.Num = reader["Num"];
                    produtoReturn.iguala = reader["iguala"];
                    produtoReturn.ValorPromocao = reader["ValorPromocao"];
                    produtoReturn.MargPromocao = reader["MargPromocao"];
                    produtoReturn.margAvista = reader["margAvista"];
                    produtoReturn.margCartao = reader["margCartao"];
                    produtoReturn.margCheque = reader["margCheque"];
                    produtoReturn.avista = reader["avista"];
                    produtoReturn.cartao = reader["cartao"];
                    produtoReturn.cheque = reader["cheque"];
                    produtoReturn.Vender = reader["Vender"];
                    produtoReturn.CD_Balanco = reader["CD_Balanco"];
                    produtoReturn.SubCategoria = reader["SubCategoria"];
                    produtoReturn.Categoria = reader["Categoria"];
                    produtoReturn.UltimaEntrada = reader["UltimaEntrada"];
                    produtoReturn.Peso = reader["Peso"];
                    produtoReturn.valCartao = reader["valCartao"];
                    produtoReturn.QuantCx = reader["QuantCx"];
                    produtoReturn.IgualaCx = reader["IgualaCx"];
                    produtoReturn.ChCaixa = reader["ChCaixa"];
                    produtoReturn.Validade = reader["Validade"];
                    produtoReturn.Controle = reader["Controle"];
                    produtoReturn.QuantForn = reader["QuantForn"];
                    produtoReturn.QuantKg = reader["QuantKg"];
                    produtoReturn.Cx_Fechada = reader["Cx_Fechada"];
                    produtoReturn.Tot_meses = reader["Tot_meses"];
                    produtoReturn.Quant_fardo = reader["Quant_fardo"];
                    produtoReturn.Quant_desc = reader["Quant_desc"];
                    produtoReturn.liberar_decer = reader["liberar_decer"];
                    produtoReturn.Quant_Avista = reader["Quant_Avista"];
                    produtoReturn.validade_Indeterminada = reader["validade_Indeterminada"];
                    produtoReturn.data = reader["data"];
                    produtoReturn.hora = reader["hora"];
                    produtoReturn.vale_Alimentaçao = reader["vale_Alimentaçao"];
                    produtoReturn.USUARIO = reader["USUARIO"];
                    produtoReturn.Acrescimo_alimentaçao = reader["Acrescimo_alimentaçao"];
                }
            }
            return produtoReturn;
        }
        public Produtos produtoCod(string codigoLocal)
        {
            Produtos produtoReturn = new Produtos();
            produtoReturn.Referencia = string.Empty;
            produtoReturn.iguala1 = string.Empty;
            produtoReturn.Descricao = string.Empty;
            produtoReturn.embalagem = string.Empty;
            produtoReturn.quantidade = string.Empty;
            produtoReturn.CustoUnitario = string.Empty;
            produtoReturn.Margem = string.Empty;
            produtoReturn.ValorVenda = string.Empty;
            produtoReturn.margOnline = string.Empty;
            produtoReturn.valvenda_online = string.Empty;
            produtoReturn.ItensPedido = string.Empty;
            produtoReturn.Codigo = string.Empty;
            produtoReturn.Quant = string.Empty;
            produtoReturn.Numero = string.Empty;
            produtoReturn.Unidade = string.Empty;
            produtoReturn.nome = string.Empty;
            produtoReturn.grama = string.Empty;
            produtoReturn.anulado = string.Empty;
            produtoReturn.colocar = string.Empty;
            produtoReturn.Multiplicar = string.Empty;
            produtoReturn.ValorCesta = string.Empty;
            produtoReturn.MargCesta = string.Empty;
            produtoReturn.Quant_cesta = string.Empty;
            produtoReturn.NumCest = string.Empty;
            produtoReturn.Num = string.Empty;
            produtoReturn.iguala = string.Empty;
            produtoReturn.ValorPromocao = string.Empty;
            produtoReturn.MargPromocao = string.Empty;
            produtoReturn.margAvista = string.Empty;
            produtoReturn.margCartao = string.Empty;
            produtoReturn.margCheque = string.Empty;
            produtoReturn.avista = string.Empty;
            produtoReturn.cartao = string.Empty;
            produtoReturn.cheque = string.Empty;
            produtoReturn.Vender = string.Empty;
            produtoReturn.CD_Balanco = string.Empty;
            produtoReturn.SubCategoria = string.Empty;
            produtoReturn.Categoria = string.Empty;
            produtoReturn.UltimaEntrada = string.Empty;
            produtoReturn.Peso = string.Empty;
            produtoReturn.valCartao = string.Empty;
            produtoReturn.QuantCx = string.Empty;
            produtoReturn.IgualaCx = string.Empty;
            produtoReturn.ChCaixa = string.Empty;
            produtoReturn.Validade = string.Empty;
            produtoReturn.Controle = string.Empty;
            produtoReturn.QuantForn = string.Empty;
            produtoReturn.QuantKg = string.Empty;
            produtoReturn.Cx_Fechada = string.Empty;
            produtoReturn.Tot_meses = string.Empty;
            produtoReturn.Quant_fardo = string.Empty;
            produtoReturn.Quant_desc = string.Empty;
            produtoReturn.liberar_decer = string.Empty;
            produtoReturn.Quant_Avista = string.Empty;
            produtoReturn.validade_Indeterminada = string.Empty;
            produtoReturn.data = string.Empty;
            produtoReturn.hora = string.Empty;
            produtoReturn.vale_Alimentaçao = string.Empty;
            produtoReturn.USUARIO = string.Empty;
            produtoReturn.Acrescimo_alimentaçao = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from Produtos where Codigo = '" + codigoLocal + "';";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Codigo"] != null)
                {
                    produtoReturn.Referencia = reader["Referencia"];
                    produtoReturn.iguala1 = reader["iguala1"];
                    produtoReturn.Descricao = reader["Descricao"];
                    produtoReturn.embalagem = reader["embalagem"];
                    produtoReturn.quantidade = reader["quantidade"];
                    produtoReturn.CustoUnitario = reader["CustoUnitario"];
                    produtoReturn.Margem = reader["Margem"];
                    produtoReturn.ValorVenda = reader["ValorVenda"];
                    produtoReturn.margOnline = reader["margOnline"];
                    produtoReturn.valvenda_online = reader["valvenda_online"];
                    produtoReturn.ItensPedido = reader["ItensPedido"];
                    produtoReturn.Codigo = reader["Codigo"];
                    produtoReturn.Quant = reader["Quant"];
                    produtoReturn.Numero = reader["Numero"];
                    produtoReturn.Unidade = reader["Unidade"];
                    produtoReturn.nome = reader["nome"];
                    produtoReturn.grama = reader["grama"];
                    produtoReturn.anulado = reader["anulado"];
                    produtoReturn.colocar = reader["colocar"];
                    produtoReturn.Multiplicar = reader["Multiplicar"];
                    produtoReturn.ValorCesta = reader["ValorCesta"];
                    produtoReturn.MargCesta = reader["MargCesta"];
                    produtoReturn.Quant_cesta = reader["Quant_cesta"];
                    produtoReturn.NumCest = reader["NumCest"];
                    produtoReturn.Num = reader["Num"];
                    produtoReturn.iguala = reader["iguala"];
                    produtoReturn.ValorPromocao = reader["ValorPromocao"];
                    produtoReturn.MargPromocao = reader["MargPromocao"];
                    produtoReturn.margAvista = reader["margAvista"];
                    produtoReturn.margCartao = reader["margCartao"];
                    produtoReturn.margCheque = reader["margCheque"];
                    produtoReturn.avista = reader["avista"];
                    produtoReturn.cartao = reader["cartao"];
                    produtoReturn.cheque = reader["cheque"];
                    produtoReturn.Vender = reader["Vender"];
                    produtoReturn.CD_Balanco = reader["CD_Balanco"];
                    produtoReturn.SubCategoria = reader["SubCategoria"];
                    produtoReturn.Categoria = reader["Categoria"];
                    produtoReturn.UltimaEntrada = reader["UltimaEntrada"];
                    produtoReturn.Peso = reader["Peso"];
                    produtoReturn.valCartao = reader["valCartao"];
                    produtoReturn.QuantCx = reader["QuantCx"];
                    produtoReturn.IgualaCx = reader["IgualaCx"];
                    produtoReturn.ChCaixa = reader["ChCaixa"];
                    produtoReturn.Validade = reader["Validade"];
                    produtoReturn.Controle = reader["Controle"];
                    produtoReturn.QuantForn = reader["QuantForn"];
                    produtoReturn.QuantKg = reader["QuantKg"];
                    produtoReturn.Cx_Fechada = reader["Cx_Fechada"];
                    produtoReturn.Tot_meses = reader["Tot_meses"];
                    produtoReturn.Quant_fardo = reader["Quant_fardo"];
                    produtoReturn.Quant_desc = reader["Quant_desc"];
                    produtoReturn.liberar_decer = reader["liberar_decer"];
                    produtoReturn.Quant_Avista = reader["Quant_Avista"];
                    produtoReturn.validade_Indeterminada = reader["validade_Indeterminada"];
                    produtoReturn.data = reader["data"];
                    produtoReturn.hora = reader["hora"];
                    produtoReturn.vale_Alimentaçao = reader["vale_Alimentaçao"];
                    produtoReturn.USUARIO = reader["USUARIO"];
                    produtoReturn.Acrescimo_alimentaçao = reader["Acrescimo_alimentaçao"];
                }
            }
            return produtoReturn;
        }
        public void LstProdutos(DataGridView dataGridView)
        {
            string comandoString = "select Descricao, Referencia from Produtos order by Descricao asc";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);
            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;
            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Columns[0].Width = 650;
                dataGridView.Columns[1].Width = 150;
            }

        }
        public void LstProdutosFiltro(DataGridView dataGridView, string textLocal)
        {
            string comandoString = "select Descricao, Referencia from Produtos where Descricao like '%" + textLocal + "%' order by Descricao asc";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);

            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;

            if (dataGridView.Rows.Count > 0)
            {
                dataGridView.Columns[0].Width = 650;
                dataGridView.Columns[1].Width = 150;
            }

        }
        #endregion

        #region Prod_Codigo
        public Prod_Codigo produtoCodigo(string referencia)
        {
            Prod_Codigo produtoCodigoReturn = new Prod_Codigo();
            produtoCodigoReturn.Controle = string.Empty;
            produtoCodigoReturn.Codigo = string.Empty;
            produtoCodigoReturn.referencia = string.Empty;
            produtoCodigoReturn.descriçao = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from Prod_Codigo where referencia = '" + referencia + "';";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["referencia"] != null)
                {
                    produtoCodigoReturn.Controle = reader["Controle"];
                    produtoCodigoReturn.Codigo = reader["Codigo"];
                    produtoCodigoReturn.referencia = reader["referencia"];
                    produtoCodigoReturn.descriçao = reader["descriçao"];

                }
            }
            return produtoCodigoReturn;
        }
        #endregion
      
        #region NFe_Quantidade
        public NFe_Quantidade nFe_Quantidade(string codigoLocal, string codigoFornecedorLocal, string cProdLocal)
        {
            NFe_Quantidade nFe_QuantidadeReturn = new NFe_Quantidade();
            nFe_QuantidadeReturn.Referencia_N = string.Empty;
            nFe_QuantidadeReturn.Cod_Produto = string.Empty;
            nFe_QuantidadeReturn.Cod_Forn = string.Empty;
            nFe_QuantidadeReturn.Quantidade = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from NFe_Quantidade where Cod_Produto = '" + codigoLocal + "' and Cod_Forn = " + codigoFornecedorLocal + " and Referencia_N = '" + cProdLocal + "' ; ";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["Quantidade"] != null)
                {
                    nFe_QuantidadeReturn.Referencia_N = reader["Referencia_N"];
                    nFe_QuantidadeReturn.Cod_Produto = reader["Cod_Produto"];
                    nFe_QuantidadeReturn.Cod_Forn = reader["Cod_Forn"];
                    nFe_QuantidadeReturn.Quantidade = reader["Quantidade"];
                }
            }
            return nFe_QuantidadeReturn;
        }
        public void AlterarNFe_Quantidade(NFe_Quantidade nFe_Quantidade)
        {
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            string comandoString = "update NFe_Quantidade set  Quantidade = " + nFe_Quantidade.Quantidade + " where Cod_Produto = '" + nFe_Quantidade.Cod_Produto + "' and Cod_Forn = " + nFe_Quantidade.Cod_Forn + " and Referencia_N = '" + nFe_Quantidade.Referencia_N + "' ; ";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            comando.ExecuteNonQuery();
        }
        public void InsertNFe_Quantidade(NFe_Quantidade nFe_Quantidade)
        {
            string comandoString = "insert into NFe_Quantidade (Referencia_N, Cod_Produto, Cod_Forn, Quantidade) values (@Referencia_N, @Cod_Produto, @Cod_Forn, @Quantidade);";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            comando.Parameters.AddWithValue("Referencia_N", nFe_Quantidade.Referencia_N);
            comando.Parameters.AddWithValue("Cod_Produto", nFe_Quantidade.Cod_Produto);
            comando.Parameters.AddWithValue("Cod_Forn", nFe_Quantidade.Cod_Forn);
            comando.Parameters.AddWithValue("Quantidade", nFe_Quantidade.Quantidade);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }
        public void DeleteNFeProdutos(string idLocal, string cProdLocal)
        {
            string comandoString = "DELETE FROM NFeProdutos  where ID = '" + idLocal + "' and cProd = '" + cProdLocal + "' ; ";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }
        public bool nFeProdutosBool(string idLocal, string codFornecedorLocal, string cProdLocal)
        {
            NFeProdutos nFeProdutosReturn = new NFeProdutos();
            nFeProdutosReturn.ID = string.Empty;
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbCommand comando = Global.instancia.conexao.CreateCommand();
            comando.CommandText = "select * from NFeProdutos where ID = '" + idLocal + "' and COD_FORNECEDOR = " + codFornecedorLocal + " and cProd = '" + cProdLocal + "' ; ";
            OleDbDataReader reader = comando.ExecuteReader();
            while (reader.Read())
            {
                if (reader["ID"] != null)
                {
                    nFeProdutosReturn.ID = reader["ID"];
                }
            }

            if (string.IsNullOrEmpty(nFeProdutosReturn.ID.ToString()) == false)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        #endregion

        #region NFeProdutos
        public void InsertNFeProdutos(NFeProdutos nFeProdutosLocal)
        {
            string comandoString = "insert into NFeProdutos (ID, Item, COD_FORNECEDOR, cProd, xProd, cEAN, QtdProdCompra, vProd, cEANTrib, vDesc, vOutro, vFrete, vSeg, ICMS_vICMSST, ICMS_vFCPST, IPI_vIPI, vUnCom, uTrib, qTrib, vUnTrib, ICMS_orig, ICMS_CST, ICMS_vBC, ICMS_pICMS, ICMS_vICMS, ICMS_modBCST, ICMS_vBCST, IPI_vBC, IPI_pIPI, PIS_vBC, PIS_pPIS, PIS_vPIS, COFINS_vBC, COFINS_pCOFINS, COFINS_vCOFINS, Codigo) values (@ID, @Item, @COD_FORNECEDOR, @cProd, @xProd, @cEAN, @QtdProdCompra, @vProd, @cEANTrib, @vDesc, @vOutro, @vFrete, @vSeg, @ICMS_vICMSST, @ICMS_vFCPST, @IPI_vIPI, @vUnCom, @uTrib, @qTrib, @vUnTrib, @ICMS_orig, @ICMS_CST, @ICMS_vBC, @ICMS_pICMS, @ICMS_vICMS, @ICMS_modBCST, @ICMS_vBCST, @IPI_vBC, @IPI_pIPI, @PIS_vBC, @PIS_pPIS, @PIS_vPIS, @COFINS_vBC, @COFINS_pCOFINS, @COFINS_vCOFINS, @Codigo);";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            comando.Parameters.AddWithValue("ID", nFeProdutosLocal.ID);
            comando.Parameters.AddWithValue("Item", nFeProdutosLocal.Item);
            comando.Parameters.AddWithValue("COD_FORNECEDOR", nFeProdutosLocal.COD_FORNECEDOR);
            comando.Parameters.AddWithValue("cProd", nFeProdutosLocal.cProd);
            comando.Parameters.AddWithValue("xProd", nFeProdutosLocal.xProd);
            comando.Parameters.AddWithValue("cEAN", nFeProdutosLocal.cEAN);
            comando.Parameters.AddWithValue("QtdProdCompra", nFeProdutosLocal.QtdProdCompra);
            comando.Parameters.AddWithValue("vProd", nFeProdutosLocal.vProd);
            comando.Parameters.AddWithValue("cEANTrib", nFeProdutosLocal.cEANTrib);
            comando.Parameters.AddWithValue("vDesc", nFeProdutosLocal.vDesc);
            comando.Parameters.AddWithValue("vOutro", nFeProdutosLocal.vOutro);
            comando.Parameters.AddWithValue("vFrete", nFeProdutosLocal.vFrete);
            comando.Parameters.AddWithValue("vSeg", nFeProdutosLocal.vSeg);
            comando.Parameters.AddWithValue("ICMS_vICMSST", nFeProdutosLocal.ICMS_vICMSST);
            comando.Parameters.AddWithValue("ICMS_vFCPST", nFeProdutosLocal.ICMS_vFCPST);
            comando.Parameters.AddWithValue("IPI_vIPI", nFeProdutosLocal.IPI_vIPI);


            comando.Parameters.AddWithValue("vUnCom", nFeProdutosLocal.vUnCom);
            comando.Parameters.AddWithValue("uTrib", nFeProdutosLocal.uTrib);
            comando.Parameters.AddWithValue("qTrib", nFeProdutosLocal.qTrib);
            comando.Parameters.AddWithValue("vUnTrib", nFeProdutosLocal.vUnTrib);

            comando.Parameters.AddWithValue("ICMS_orig", nFeProdutosLocal.ICMS_orig);
            comando.Parameters.AddWithValue("ICMS_CST", nFeProdutosLocal.ICMS_CST);
            comando.Parameters.AddWithValue("ICMS_vBC", nFeProdutosLocal.ICMS_vBC);
            comando.Parameters.AddWithValue("ICMS_pICMS", nFeProdutosLocal.ICMS_pICMS);
            comando.Parameters.AddWithValue("ICMS_vICMS", nFeProdutosLocal.ICMS_vICMS);
            comando.Parameters.AddWithValue("ICMS_modBCST", nFeProdutosLocal.ICMS_modBCST);
            comando.Parameters.AddWithValue("ICMS_vBCST", nFeProdutosLocal.ICMS_vBCST);

            comando.Parameters.AddWithValue("IPI_vBC", nFeProdutosLocal.IPI_vBC);
            comando.Parameters.AddWithValue("IPI_pIPI", nFeProdutosLocal.IPI_pIPI);

            comando.Parameters.AddWithValue("PIS_vBC", nFeProdutosLocal.PIS_vBC);
            comando.Parameters.AddWithValue("PIS_pPIS", nFeProdutosLocal.PIS_pPIS);
            comando.Parameters.AddWithValue("PIS_vPIS", nFeProdutosLocal.PIS_vPIS);

            comando.Parameters.AddWithValue("COFINS_vBC", nFeProdutosLocal.COFINS_vBC);
            comando.Parameters.AddWithValue("COFINS_pCOFINS", nFeProdutosLocal.COFINS_pCOFINS);
            comando.Parameters.AddWithValue("COFINS_vCOFINS", nFeProdutosLocal.COFINS_vCOFINS);


            comando.Parameters.AddWithValue("Codigo", nFeProdutosLocal.Codigo);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();

        }
        public void LstnFeProdutos(DataGridView dataGridView, string idlocal)
        {
            string comandoString = "select NFeProdutos.xProd, NFeProdutos.Codigo, Produtos.Descricao, NFeProdutos.ID, NFeProdutos.COD_FORNECEDOR from NFeProdutos inner join Produtos on NFeProdutos.Codigo = Produtos.Codigo where ID = '" + idlocal + "'";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);

            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(comando);

            DataTable dtLista = new DataTable();

            dataAdapter.Fill(dtLista);
            dataGridView.DataSource = null;
            dataGridView.DataSource = dtLista;
            if (dataGridView.Rows.Count>0)
            {
                dataGridView.Columns[0].Width = 250;
                dataGridView.Columns[1].Width = 50;
                dataGridView.Columns[2].Width = 250;
                dataGridView.Columns[3].Width = 300;
                dataGridView.Columns[4].Width = 50;
            }
           
           

        }
        public void DeleteNFeProdutosCodigo(string idLocal, string codigoLocal)
        {

            string comandoString = "DELETE FROM NFeProdutos  where ID = '" + idLocal + "' and Codigo = '" + codigoLocal + "' ; ";
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }
        public void DeleteNFeProdutosID(string idLocal)
        {

            string comandoString = "DELETE FROM NFeProdutos  where ID = '" + idLocal + "'" ;
            OleDbCommand comando = new OleDbCommand(comandoString, Global.instancia.conexao);
            if (Global.instancia.conexao.State == ConnectionState.Closed)
            {
                Global.instancia.conexao.Open();
            }
            comando.ExecuteNonQuery();
        }


        #endregion












    }
}
