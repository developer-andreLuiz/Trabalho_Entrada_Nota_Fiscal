using NFMercadoTitio.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFMercadoTitio.Formulario
{
    public partial class FrmInserirNfeProduto : Form
    {
        #region Variaveis Form
        TNfeProc nota;
        int codFornecedor = 0;
        ConexaoBD conexaoBD = new ConexaoBD();
        List<ModeloListaProdutosNota> lstProdutosPendentesInicio = new List<ModeloListaProdutosNota>();
        List<ModeloListaProdutosNota> lstProdutosPendentes = new List<ModeloListaProdutosNota>();
        List<NFeProdutos> lstGrid = new List<NFeProdutos>();
        object Codproduto = 0;
        bool encontradoNfeQuantidade = false;
        #endregion
        public FrmInserirNfeProduto(TNfeProc notaLocal, int codFornecedorLocal)
        {
            InitializeComponent();
            
            try
            {
                nota = notaLocal;
                codFornecedor = codFornecedorLocal;
                foreach (var t in nota.NFe.infNFe.det)
                {
                    bool cadastrado = conexaoBD.nFeProdutosBool(nota.NFe.infNFe.Id, codFornecedor.ToString(), t.prod.cProd);
                    if (cadastrado == false)
                    {
                        ModeloListaProdutosNota modeloListaProdutosNota = new ModeloListaProdutosNota();

                        #region Tratamento para buscar elementos para a lista
                        try
                        {
                            modeloListaProdutosNota.id = nota.NFe.infNFe.Id;
                            if (modeloListaProdutosNota.id == null)
                            {
                                modeloListaProdutosNota.id = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.id = "0"; }
                        try
                        {
                            modeloListaProdutosNota.item = t.nItem;
                            if (modeloListaProdutosNota.item == null)
                            {
                                modeloListaProdutosNota.item = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.item = "0"; }
                        try
                        {
                            modeloListaProdutosNota.codFornecedor = codFornecedor;
                        }
                        catch { modeloListaProdutosNota.codFornecedor = 0; }
                        try
                        {
                            modeloListaProdutosNota.cprod = t.prod.cProd;
                            if (modeloListaProdutosNota.cprod == null)
                            {
                                modeloListaProdutosNota.cprod = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.cprod = "0"; }
                        try
                        {
                            modeloListaProdutosNota.xprod = t.prod.xProd;
                            if (modeloListaProdutosNota.xprod == null)
                            {
                                modeloListaProdutosNota.xprod = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.xprod = "0"; }
                        try
                        {
                            modeloListaProdutosNota.cean = t.prod.cEAN;
                            if (modeloListaProdutosNota.cean == null)
                            {
                                modeloListaProdutosNota.cean = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.cean = "0"; }
                        try
                        {
                            modeloListaProdutosNota.ceantrib = t.prod.cEANTrib;
                            if (modeloListaProdutosNota.ceantrib == null)
                            {
                                modeloListaProdutosNota.ceantrib = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.ceantrib = "0"; }
                        try
                        {
                            modeloListaProdutosNota.voutro = t.prod.vOutro;
                            if (modeloListaProdutosNota.voutro == null)
                            {
                                modeloListaProdutosNota.voutro = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.voutro = "0"; }
                        try
                        {
                            modeloListaProdutosNota.vdesc = t.prod.vDesc;
                            if (modeloListaProdutosNota.vdesc == null)
                            {
                                modeloListaProdutosNota.vdesc = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.vdesc = "0"; }
                        try
                        {
                            modeloListaProdutosNota.vfrete = t.prod.vFrete;
                            if (modeloListaProdutosNota.vfrete == null)
                            {
                                modeloListaProdutosNota.vfrete = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.vfrete = "0"; }
                        try
                        {
                            modeloListaProdutosNota.vseg = t.prod.vSeg;
                            if (modeloListaProdutosNota.vseg == null)
                            {
                                modeloListaProdutosNota.vseg = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.vseg = "0"; }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vICMSST"))
                                {
                                    modeloListaProdutosNota.icms_vicmsst = p.GetValue(impostoICMS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.icms_vicmsst == null)
                            {
                                modeloListaProdutosNota.icms_vicmsst = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.icms_vicmsst = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];
                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vFCPST"))
                                {
                                    modeloListaProdutosNota.icms_vfcpst = p.GetValue(impostoICMS.Item);
                                }

                            }



                            if (modeloListaProdutosNota.icms_vfcpst == null)
                            {
                                modeloListaProdutosNota.icms_vfcpst = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.icms_vfcpst = "0";
                        }
                        try
                        {
                            TIpi ipi = (TIpi)t.imposto.Items[1];
                            Type objType = ipi.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vIPI"))
                                {
                                    modeloListaProdutosNota.ipi_vipi = p.GetValue(ipi.Item);
                                }
                            }
                            if (modeloListaProdutosNota.ipi_vipi == null)
                            {
                                modeloListaProdutosNota.ipi_vipi = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.ipi_vipi = "0"; }
                        try
                        {
                            modeloListaProdutosNota.ucom = t.prod.uCom;
                            if (modeloListaProdutosNota.ucom == null)
                            {
                                modeloListaProdutosNota.ucom = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.ucom = "0"; }
                        try
                        {
                            modeloListaProdutosNota.qcom = t.prod.qCom;
                            if (modeloListaProdutosNota.qcom == null)
                            {
                                modeloListaProdutosNota.qcom = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.qcom = "0"; }
                        try
                        {
                            modeloListaProdutosNota.vprod = t.prod.vProd;
                            if (modeloListaProdutosNota.vprod == null)
                            {
                                modeloListaProdutosNota.vprod = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.vprod = "0"; }
                        try
                        {
                            modeloListaProdutosNota.vUnCom = t.prod.vUnCom;
                            if (modeloListaProdutosNota.vUnCom == null)
                            {
                                modeloListaProdutosNota.vUnCom = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.vUnCom = "0"; }
                        try
                        {
                            modeloListaProdutosNota.uTrib = t.prod.uTrib;
                            if (modeloListaProdutosNota.uTrib == null)
                            {
                                modeloListaProdutosNota.uTrib = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.uTrib = "0"; }
                        try
                        {
                            modeloListaProdutosNota.uTrib = t.prod.uTrib;
                            if (modeloListaProdutosNota.uTrib == null)
                            {
                                modeloListaProdutosNota.uTrib = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.uTrib = "0"; }
                        try
                        {
                            modeloListaProdutosNota.qTrib = t.prod.qTrib;
                            if (modeloListaProdutosNota.qTrib == null)
                            {
                                modeloListaProdutosNota.qTrib = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.qTrib = "0"; }
                        try
                        {
                            modeloListaProdutosNota.vUnTrib = t.prod.vUnTrib;
                            if (modeloListaProdutosNota.vUnTrib == null)
                            {
                                modeloListaProdutosNota.vUnTrib = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.vUnTrib = "0"; }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("orig"))
                                {
                                    modeloListaProdutosNota.ICMS_orig = p.GetValue(impostoICMS.Item).ToString().Replace("Item", "");
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_orig == null)
                            {
                                modeloListaProdutosNota.ICMS_orig = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_orig = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("CST"))
                                {
                                    modeloListaProdutosNota.ICMS_CST = p.GetValue(impostoICMS.Item).ToString().Replace("Item", "");
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_CST == null)
                            {
                                modeloListaProdutosNota.ICMS_CST = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_CST = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vBC"))
                                {
                                    modeloListaProdutosNota.ICMS_vBC = p.GetValue(impostoICMS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_vBC == null)
                            {
                                modeloListaProdutosNota.ICMS_vBC = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_vBC = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("pICMS"))
                                {
                                    modeloListaProdutosNota.ICMS_pICMS = p.GetValue(impostoICMS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_pICMS == null)
                            {
                                modeloListaProdutosNota.ICMS_pICMS = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_pICMS = "0";
                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vICMS"))
                                {
                                    modeloListaProdutosNota.ICMS_vICMS = p.GetValue(impostoICMS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_vICMS == null)
                            {
                                modeloListaProdutosNota.ICMS_vICMS = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_vICMS = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("modBCST"))
                                {
                                    modeloListaProdutosNota.ICMS_modBCST = p.GetValue(impostoICMS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_modBCST == null)
                            {
                                modeloListaProdutosNota.ICMS_modBCST = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_modBCST = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoICMS impostoICMS = new TNFeInfNFeDetImpostoICMS();
                            impostoICMS = (TNFeInfNFeDetImpostoICMS)t.imposto.Items[0];

                            Type objType = impostoICMS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vBCST"))
                                {
                                    modeloListaProdutosNota.ICMS_vBCST = p.GetValue(impostoICMS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.ICMS_vBCST == null)
                            {
                                modeloListaProdutosNota.ICMS_vBCST = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.ICMS_vBCST = "0";

                        }
                        try
                        {
                            TIpi ipi = (TIpi)t.imposto.Items[1];

                            TIpiIPITrib ipiIPITrib = (TIpiIPITrib)ipi.Item;
                            int rep = 0;
                            foreach (var f in ipiIPITrib.ItemsElementName)
                            {
                                object nome = f;
                                if (nome.ToString().Equals("vBC"))
                                {
                                    modeloListaProdutosNota.IPI_vBC = ipiIPITrib.Items[rep];
                                    break;
                                }
                                rep++;
                            }
                            if (modeloListaProdutosNota.IPI_vBC == null)
                            {
                                modeloListaProdutosNota.IPI_vBC = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.IPI_vBC = "0"; }
                        try
                        {
                            TIpi ipi = (TIpi)t.imposto.Items[1];

                            TIpiIPITrib ipiIPITrib = (TIpiIPITrib)ipi.Item;
                            int rep = 0;
                            foreach (var f in ipiIPITrib.ItemsElementName)
                            {
                                object nome = f;
                                if (nome.ToString().Equals("pIPI"))
                                {
                                    modeloListaProdutosNota.IPI_pIPI = ipiIPITrib.Items[rep];
                                    break;
                                }
                                rep++;
                            }
                            if (modeloListaProdutosNota.IPI_pIPI == null)
                            {
                                modeloListaProdutosNota.IPI_pIPI = "0";
                            }
                        }
                        catch { modeloListaProdutosNota.IPI_pIPI = "0"; }
                        try
                        {
                            TNFeInfNFeDetImpostoPIS impostoPis = new TNFeInfNFeDetImpostoPIS();
                            impostoPis = (TNFeInfNFeDetImpostoPIS)t.imposto.PIS;
                            Type objType = impostoPis.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vBC"))
                                {
                                    modeloListaProdutosNota.PIS_vBC = p.GetValue(impostoPis.Item);
                                }
                            }
                            if (modeloListaProdutosNota.PIS_vBC == null)
                            {
                                modeloListaProdutosNota.PIS_vBC = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.PIS_vBC = "0";
                        }
                        try
                        {
                            TNFeInfNFeDetImpostoPIS impostoPis = new TNFeInfNFeDetImpostoPIS();
                            impostoPis = (TNFeInfNFeDetImpostoPIS)t.imposto.PIS;

                            Type objType = impostoPis.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("pPIS"))
                                {
                                    modeloListaProdutosNota.PIS_pPIS = p.GetValue(impostoPis.Item);
                                }

                            }
                            if (modeloListaProdutosNota.PIS_pPIS == null)
                            {
                                modeloListaProdutosNota.PIS_pPIS = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.PIS_pPIS = "0";

                        }
                        try
                        {
                            TNFeInfNFeDetImpostoPIS impostoPis = new TNFeInfNFeDetImpostoPIS();
                            impostoPis = (TNFeInfNFeDetImpostoPIS)t.imposto.PIS;

                            Type objType = impostoPis.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vPIS"))
                                {
                                    modeloListaProdutosNota.PIS_vPIS = p.GetValue(impostoPis.Item);
                                }

                            }
                            if (modeloListaProdutosNota.PIS_vPIS == null)
                            {
                                modeloListaProdutosNota.PIS_vPIS = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.PIS_vPIS = "0";
                        }
                        try
                        {
                            TNFeInfNFeDetImpostoCOFINS impostoCONFINS = new TNFeInfNFeDetImpostoCOFINS();
                            impostoCONFINS = (TNFeInfNFeDetImpostoCOFINS)t.imposto.COFINS;

                            Type objType = impostoCONFINS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vBC"))
                                {
                                    modeloListaProdutosNota.COFINS_vBC = p.GetValue(impostoCONFINS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.COFINS_vBC == null)
                            {
                                modeloListaProdutosNota.COFINS_vBC = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.COFINS_vBC = "0";
                        }
                        try
                        {
                            TNFeInfNFeDetImpostoCOFINS impostoCONFINS = new TNFeInfNFeDetImpostoCOFINS();
                            impostoCONFINS = (TNFeInfNFeDetImpostoCOFINS)t.imposto.COFINS;

                            Type objType = impostoCONFINS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("pCOFINS"))
                                {
                                    modeloListaProdutosNota.COFINS_pCOFINS = p.GetValue(impostoCONFINS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.COFINS_pCOFINS == null)
                            {
                                modeloListaProdutosNota.COFINS_pCOFINS = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.COFINS_pCOFINS = "0";
                        }
                        try
                        {
                            TNFeInfNFeDetImpostoCOFINS impostoCONFINS = new TNFeInfNFeDetImpostoCOFINS();
                            impostoCONFINS = (TNFeInfNFeDetImpostoCOFINS)t.imposto.COFINS;

                            Type objType = impostoCONFINS.Item.GetType();
                            PropertyInfo[] properties = objType.GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance | BindingFlags.Static);
                            foreach (PropertyInfo p in properties)
                            {
                                object x = p.Name;
                                if (p.Name.Equals("vCOFINS"))
                                {
                                    modeloListaProdutosNota.COFINS_vCOFINS = p.GetValue(impostoCONFINS.Item);
                                }

                            }
                            if (modeloListaProdutosNota.COFINS_vCOFINS == null)
                            {
                                modeloListaProdutosNota.COFINS_vCOFINS = "0";
                            }
                        }
                        catch
                        {
                            modeloListaProdutosNota.COFINS_vCOFINS = "0";
                        }
                        #endregion

                        lstProdutosPendentes.Add(modeloListaProdutosNota);
                        lstProdutosPendentesInicio.Add(modeloListaProdutosNota);
                    }
                }
                ExibirDados();
            }
            catch (Exception a) { MessageBox.Show(a.Message); }
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
        void ExibirDados()
        {
            if (lstProdutosPendentes.Count > 0)
            {
                bool produtoEncontrado = false;
                encontradoNfeQuantidade = false;
                Produtos produto = new Produtos();
                Prod_Codigo prod_Codigo = new Prod_Codigo();
                NFePesq_Prod nFePesq_Prod = new NFePesq_Prod();
                NFe_Quantidade nFe_Quantidade = new NFe_Quantidade();


                //buscar Nfe pesquisa produto
                if (produtoEncontrado == false)
                {
                    nFePesq_Prod = conexaoBD.nFePesq_Prod(lstProdutosPendentes[0].cprod, codFornecedor);
                    if (string.IsNullOrEmpty(nFePesq_Prod.Codigo.ToString()) == false)
                    {
                        if (nFePesq_Prod.Referencia.ToString().Equals(nFePesq_Prod.Codigo.ToString()) == false)
                        {
                            produto = conexaoBD.produtoCod(nFePesq_Prod.Codigo.ToString());

                            if (string.IsNullOrEmpty(produto.Referencia.ToString()) == true)
                            {
                                produto = conexaoBD.produtoRef(nFePesq_Prod.Codigo.ToString());
                            }
                            //produto carregado
                            if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                            {
                                if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                {
                                    if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                    {
                                        produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                    }
                                }
                                produtoEncontrado = true;
                            }
                        }
                    }
                }
                if (produtoEncontrado == false)
                {
                    nFePesq_Prod = conexaoBD.nFePesq_Prod(lstProdutosPendentes[0].cean, codFornecedor);
                    if (string.IsNullOrEmpty(nFePesq_Prod.Codigo.ToString()) == false)
                    {
                        if (nFePesq_Prod.Referencia.ToString().Equals(nFePesq_Prod.Codigo.ToString()) == false)
                        {
                            produto = conexaoBD.produtoCod(nFePesq_Prod.Codigo.ToString());

                            if (string.IsNullOrEmpty(produto.Referencia.ToString()) == true)
                            {
                                produto = conexaoBD.produtoRef(nFePesq_Prod.Codigo.ToString());
                            }
                            //produto carregado
                            if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                            {
                                if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                {
                                    if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                    {
                                        produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                    }
                                }
                                produtoEncontrado = true;
                            }
                        }
                    }
                }
                if (produtoEncontrado == false)
                {
                    nFePesq_Prod = conexaoBD.nFePesq_Prod(lstProdutosPendentes[0].ceantrib, codFornecedor);
                    if (string.IsNullOrEmpty(nFePesq_Prod.Codigo.ToString()) == false)
                    {
                        if (nFePesq_Prod.Referencia.ToString().Equals(nFePesq_Prod.Codigo.ToString()) == false)
                        {
                            produto = conexaoBD.produtoCod(nFePesq_Prod.Codigo.ToString());

                            if (string.IsNullOrEmpty(produto.Referencia.ToString()) == true)
                            {
                                produto = conexaoBD.produtoRef(nFePesq_Prod.Codigo.ToString());
                            }
                            //produto carregado
                            if (string.IsNullOrEmpty(produto.Referencia.ToString()) == false)
                            {
                                if (int.TryParse(produto.IgualaCx.ToString(), out int valorteste) == true)
                                {
                                    if (int.Parse(produto.IgualaCx.ToString()) > 0)
                                    {
                                        produto = conexaoBD.produtoCH(int.Parse(produto.IgualaCx.ToString()));
                                    }
                                }
                                produtoEncontrado = true;
                            }
                        }
                    }
                }

                //busca na tabela produto 
                if (produtoEncontrado == false)
                {
                    produto = conexaoBD.produtoRef(lstProdutosPendentes[0].cprod);
                    if (string.IsNullOrEmpty(produto.Codigo.ToString()) == false)
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
                            produtoEncontrado = true;
                        }
                    }
                }
                if (produtoEncontrado == false)
                {
                    produto = conexaoBD.produtoRef(lstProdutosPendentes[0].cean);
                    if (string.IsNullOrEmpty(produto.Codigo.ToString()) == false)
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
                            produtoEncontrado = true;
                        }
                    }
                }
                if (produtoEncontrado == false)
                {
                    produto = conexaoBD.produtoRef(lstProdutosPendentes[0].ceantrib);
                    if (string.IsNullOrEmpty(produto.Codigo.ToString()) == false)
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
                            produtoEncontrado = true;
                        }
                    }
                }


                //busca na tabela produtoCodigo
                if (produtoEncontrado == false)
                {
                    prod_Codigo = conexaoBD.produtoCodigo(lstProdutosPendentes[0].cprod);
                    if (string.IsNullOrEmpty(prod_Codigo.Codigo.ToString()) == false)
                    {
                        if (prod_Codigo.referencia.ToString().Equals(prod_Codigo.Codigo.ToString()) == false)
                        {
                            produto = conexaoBD.produtoCod(prod_Codigo.Codigo.ToString());

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
                                    produtoEncontrado = true;
                                }
                            }
                        }
                    }
                }
                if (produtoEncontrado == false)
                {
                    prod_Codigo = conexaoBD.produtoCodigo(lstProdutosPendentes[0].cean);
                    if (string.IsNullOrEmpty(prod_Codigo.Codigo.ToString()) == false)
                    {
                        if (prod_Codigo.referencia.ToString().Equals(prod_Codigo.Codigo.ToString()) == false)
                        {
                            produto = conexaoBD.produtoCod(prod_Codigo.Codigo.ToString());

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
                                    produtoEncontrado = true;
                                }
                            }
                        }
                    }
                }
                if (produtoEncontrado == false)
                {
                    prod_Codigo = conexaoBD.produtoCodigo(lstProdutosPendentes[0].ceantrib);
                    if (string.IsNullOrEmpty(prod_Codigo.Codigo.ToString()) == false)
                    {
                        if (prod_Codigo.referencia.ToString().Equals(prod_Codigo.Codigo.ToString()) == false)
                        {
                            produto = conexaoBD.produtoCod(prod_Codigo.Codigo.ToString());

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
                                    produtoEncontrado = true;
                                }
                            }
                        }
                    }
                }

                nFe_Quantidade = conexaoBD.nFe_Quantidade(produto.Codigo.ToString(), lstProdutosPendentes[0].codFornecedor.ToString(), lstProdutosPendentes[0].cprod);

                if (string.IsNullOrEmpty(nFe_Quantidade.Quantidade.ToString()) == true)
                {
                    encontradoNfeQuantidade = false;
                    nFe_Quantidade.Quantidade = 0;
                }
                else
                {
                    encontradoNfeQuantidade = true;
                }
                Codproduto = produto.Codigo;

                lblNomeBanco.Text = produto.Descricao.ToString();
                lblNomeNota.Text = lstProdutosPendentes[0].xprod;
                txtQuantidadeUnitariaCaixa.Text = nFe_Quantidade.Quantidade.ToString();
                try
                {
                    string quant = lstProdutosPendentes[0].qcom.ToString().Replace(".0000", "");
                    float quantf = float.Parse(quant.Replace(".", ""));
                    txtQuantidadeCaixa.Text = quant.ToString();
                }
                catch
                {
                    txtQuantidadeCaixa.Text = "0";
                }


                lblEmbalagembanco.Text = produto.embalagem.ToString();
                lblEmbalagemNota.Text = lstProdutosPendentes[0].ucom.ToString();
                bool semOperacao = false;
                bool Multiplicacao = false;
                bool Divisao = false;
                if (lblEmbalagemNota.Text.Substring(0, 2).ToUpper().Equals("UN"))
                {
                    semOperacao = true;
                }
                if (lblEmbalagemNota.Text.Substring(0, 2).ToUpper().Equals("KG"))
                {
                    Divisao = true;
                }
                if (semOperacao == false && Divisao == false)
                {
                    Multiplicacao = true;
                }
                if (semOperacao)
                {
                    lblConta.Text = "   ";
                    txtQuantidadeTotal.Text = txtQuantidadeCaixa.Text;
                }
                if (Multiplicacao)
                {
                    lblConta.Text = " X ";
                    float uni = float.Parse(txtQuantidadeUnitariaCaixa.Text);
                    float cx = float.Parse(txtQuantidadeCaixa.Text.Replace(".", ","));
                    float r = uni * cx;
                    txtQuantidadeTotal.Text = r.ToString();
                }
                if (Divisao)
                {
                    lblConta.Text = " / ";
                    float uni = float.Parse(txtQuantidadeUnitariaCaixa.Text);
                    float cx = float.Parse(txtQuantidadeCaixa.Text.Replace(".", ","));
                    float r = (cx * 1000) / uni;
                    txtQuantidadeTotal.Text = r.ToString();
                }
            }
            else
            {
                lblNomeBanco.Text = "nome do Produto Banco de Dados";
                lblNomeNota.Text = "nome do Produto  Xml";
                lblEmbalagembanco.Text = "PCT";
                lblEmbalagemNota.Text = "PCT";
                txtQuantidadeUnitariaCaixa.Text = string.Empty;
                txtQuantidadeCaixa.Text = string.Empty;
                txtQuantidadeTotal.Text = string.Empty;

                openChildForm(new FrmPaginaInicial(nota.NFe.infNFe.Id.Replace("NFe","")));
            }
        }

        private void FrmInserirNfeProduto_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                bool action = false;
                if (e.KeyChar == (char)Keys.Enter && txtQuantidadeUnitariaCaixa.Focused && action == false)
                {
                    action = true;
                    try
                    {
                        bool semOperacao = false;
                        bool Multiplicacao = false;
                        bool Divisao = false;

                        if (lblEmbalagemNota.Text.Substring(0, 2).ToUpper().Equals("UN"))
                        {
                            semOperacao = true;
                        }
                        if (lblEmbalagemNota.Text.Substring(0, 2).ToUpper().Equals("KG"))
                        {
                            Divisao = true;
                        }
                        if (semOperacao == false && Divisao == false)
                        {
                            Multiplicacao = true;
                        }

                        if (semOperacao)
                        {
                            lblConta.Text = "   ";
                            txtQuantidadeTotal.Text = txtQuantidadeCaixa.Text;
                        }
                        if (Multiplicacao)
                        {
                            lblConta.Text = " X ";
                            float uni = float.Parse(txtQuantidadeUnitariaCaixa.Text);
                            float cx = float.Parse(txtQuantidadeCaixa.Text.Replace(".", ","));
                            float r = uni * cx;
                            txtQuantidadeTotal.Text = r.ToString();
                        }
                        if (Divisao)
                        {
                            lblConta.Text = " / ";
                            float uni = float.Parse(txtQuantidadeUnitariaCaixa.Text);
                            float cx = float.Parse(txtQuantidadeCaixa.Text.Replace(".", ","));
                            float r = (cx * 1000) / uni;
                            txtQuantidadeTotal.Text = r.ToString();
                        }
                    }
                    catch { }
                    txtQuantidadeCaixa.Focus();
                }
                if (e.KeyChar == (char)Keys.Enter && txtQuantidadeCaixa.Focused && action == false)
                {
                    try
                    {
                        action = true;
                        bool semOperacao = false;
                        bool Multiplicacao = false;
                        bool Divisao = false;

                        if (lblEmbalagemNota.Text.Substring(0, 2).ToUpper().Equals("UN"))
                        {
                            semOperacao = true;
                        }
                        if (lblEmbalagemNota.Text.Substring(0, 2).ToUpper().Equals("KG"))
                        {
                            Divisao = true;
                        }
                        if (semOperacao == false && Divisao == false)
                        {
                            Multiplicacao = true;
                        }

                        if (semOperacao)
                        {
                            lblConta.Text = "   ";
                            txtQuantidadeTotal.Text = txtQuantidadeCaixa.Text;
                        }
                        if (Multiplicacao)
                        {
                            lblConta.Text = " X ";
                            float uni = float.Parse(txtQuantidadeUnitariaCaixa.Text);
                            float cx = float.Parse(txtQuantidadeCaixa.Text.Replace(".", ","));
                            float r = uni * cx;
                            txtQuantidadeTotal.Text = r.ToString();
                        }
                        if (Divisao)
                        {
                            lblConta.Text = " / ";
                            float uni = float.Parse(txtQuantidadeUnitariaCaixa.Text);
                            float cx = float.Parse(txtQuantidadeCaixa.Text.Replace(".", ","));
                            float r = (cx * 1000) / uni;
                            txtQuantidadeTotal.Text = r.ToString();
                        }
                    }
                    catch { }

                    txtQuantidadeTotal.Focus();
                }
                if (e.KeyChar == (char)Keys.Enter && txtQuantidadeTotal.Focused && action == false)
                {
                    if (lstProdutosPendentes.Count > 0)
                    {
                        action = true;
                        NFeProdutos nFeProdutos = new NFeProdutos();
                        NFe_Quantidade nFe_Quantidade = new NFe_Quantidade();
                        nFeProdutos.ID = lstProdutosPendentes[0].id;
                        nFeProdutos.Item = lstProdutosPendentes[0].item;
                        nFeProdutos.COD_FORNECEDOR = lstProdutosPendentes[0].codFornecedor;
                        nFeProdutos.cProd = lstProdutosPendentes[0].cprod;
                        nFeProdutos.xProd = lstProdutosPendentes[0].xprod;
                        nFeProdutos.cEAN = lstProdutosPendentes[0].cean;
                        nFeProdutos.QtdProdCompra = txtQuantidadeTotal.Text;
                        nFeProdutos.vProd = lstProdutosPendentes[0].vprod;
                        nFeProdutos.cEANTrib = lstProdutosPendentes[0].ceantrib;
                        nFeProdutos.vDesc = lstProdutosPendentes[0].vdesc;
                        nFeProdutos.vOutro = lstProdutosPendentes[0].voutro;
                        nFeProdutos.vFrete = lstProdutosPendentes[0].vfrete;
                        nFeProdutos.vSeg = lstProdutosPendentes[0].vseg;
                        nFeProdutos.ICMS_vICMSST = lstProdutosPendentes[0].icms_vicmsst;
                        nFeProdutos.ICMS_vFCPST = lstProdutosPendentes[0].icms_vfcpst;
                        nFeProdutos.IPI_vIPI = lstProdutosPendentes[0].ipi_vipi;
                        nFeProdutos.Codigo = Codproduto;

                        nFeProdutos.vUnCom = lstProdutosPendentes[0].vUnCom;
                        nFeProdutos.uTrib = lstProdutosPendentes[0].uTrib;
                        nFeProdutos.qTrib = lstProdutosPendentes[0].qTrib;
                        nFeProdutos.vUnTrib = lstProdutosPendentes[0].vUnTrib;

                        nFeProdutos.ICMS_orig = lstProdutosPendentes[0].ICMS_orig;
                        nFeProdutos.ICMS_CST = lstProdutosPendentes[0].ICMS_CST;
                        nFeProdutos.ICMS_vBC = lstProdutosPendentes[0].ICMS_vBC;
                        nFeProdutos.ICMS_pICMS = lstProdutosPendentes[0].ICMS_pICMS;
                        nFeProdutos.ICMS_vICMS = lstProdutosPendentes[0].ICMS_vICMS;
                        nFeProdutos.ICMS_modBCST = lstProdutosPendentes[0].ICMS_modBCST;
                        nFeProdutos.ICMS_vBCST = lstProdutosPendentes[0].ICMS_vBCST;


                        nFeProdutos.IPI_vBC = lstProdutosPendentes[0].IPI_vBC;
                        nFeProdutos.IPI_pIPI = lstProdutosPendentes[0].IPI_pIPI;

                        nFeProdutos.PIS_vBC = lstProdutosPendentes[0].PIS_vBC;
                        nFeProdutos.PIS_pPIS = lstProdutosPendentes[0].PIS_pPIS;
                        nFeProdutos.PIS_vPIS = lstProdutosPendentes[0].PIS_vPIS;



                        nFeProdutos.COFINS_vBC = lstProdutosPendentes[0].COFINS_vBC;
                        nFeProdutos.COFINS_pCOFINS = lstProdutosPendentes[0].COFINS_pCOFINS;
                        nFeProdutos.COFINS_vCOFINS = lstProdutosPendentes[0].COFINS_vCOFINS;

                        try
                        {
                            conexaoBD.InsertNFeProdutos(nFeProdutos);
                        }
                        catch(Exception a)
                        {
                            MessageBox.Show(a.Message);
                        }
                        

                        nFe_Quantidade.Referencia_N = nFeProdutos.cProd;
                        nFe_Quantidade.Cod_Produto = nFeProdutos.Codigo;
                        nFe_Quantidade.Cod_Forn = nFeProdutos.COD_FORNECEDOR;
                        nFe_Quantidade.Quantidade = txtQuantidadeUnitariaCaixa.Text;

                        if (encontradoNfeQuantidade)
                        {
                            conexaoBD.AlterarNFe_Quantidade(nFe_Quantidade);
                        }
                        else
                        {
                            conexaoBD.InsertNFe_Quantidade(nFe_Quantidade);
                        }
                        lstProdutosPendentes.RemoveAt(0);

                        lstGrid.Add(nFeProdutos);
                        dataGridView.DataSource = null;
                        dataGridView.DataSource = lstGrid;
                        if (dataGridView.Rows.Count > 0)
                        {
                            dataGridView.Columns[0].Visible = false;
                            dataGridView.Columns[1].Visible = false;
                            dataGridView.Columns[2].Visible = false;
                            dataGridView.Columns[3].Visible = false;
                            dataGridView.Columns[4].Width = 600;
                        }
                        //Todo Organizar grid nfeProdudo

                        ExibirDados();
                        txtQuantidadeUnitariaCaixa.Focus();
                    }
                    else
                    {
                        ExibirDados();
                    }
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
                    string idDelete = dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString();
                    string cProdDelete = dataGridView.Rows[e.RowIndex].Cells[3].Value.ToString();
                    conexaoBD.DeleteNFeProdutos(idDelete, cProdDelete);
                    int indexLst = lstGrid.FindIndex(x => x.cProd == cProdDelete);
                    lstGrid.RemoveAt(indexLst);
                    foreach (var a in lstProdutosPendentesInicio)
                    {
                        if (a.cprod.Equals(cProdDelete))
                        {
                            lstProdutosPendentes.Add(new ModeloListaProdutosNota()
                            {
                                id = a.id,
                                item = a.item,
                                codFornecedor = a.codFornecedor,
                                cprod = a.cprod,
                                xprod = a.xprod,
                                cean = a.cean,
                                ceantrib = a.ceantrib,
                                voutro = a.voutro,
                                vdesc = a.vdesc,
                                vfrete = a.vfrete,
                                vprod = a.vprod,
                                vseg = a.vseg,
                                icms_vicmsst = a.icms_vicmsst,
                                icms_vfcpst = a.icms_vfcpst,
                                ipi_vipi = a.ipi_vipi,
                                ucom = a.ucom,
                                qcom = a.qcom,

                                vUnCom = a.vUnCom,
                                uTrib = a.uTrib,
                                qTrib = a.qTrib,
                                vUnTrib = a.vUnTrib,

                                ICMS_orig = a.ICMS_orig,
                                ICMS_CST = a.ICMS_CST,
                                ICMS_vBC = a.ICMS_vBC,
                                ICMS_pICMS = a.ICMS_pICMS,
                                ICMS_vICMS = a.ICMS_vICMS,
                                ICMS_modBCST = a.ICMS_modBCST,
                                ICMS_vBCST = a.ICMS_vBCST,

                                IPI_vBC = a.IPI_vBC,
                                IPI_pIPI = a.IPI_pIPI,
                                PIS_vBC = a.PIS_vBC,
                                PIS_pPIS = a.PIS_pPIS,
                                PIS_vPIS = a.PIS_vPIS,

                                COFINS_vBC = a.COFINS_vBC,
                                COFINS_pCOFINS = a.COFINS_pCOFINS,
                                COFINS_vCOFINS = a.COFINS_vCOFINS


                            });
                            break;
                        }
                    }
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = lstGrid;
                    ExibirDados();
                    txtQuantidadeUnitariaCaixa.Focus();
                }
            }
            catch { }
           
        }

        private void FrmInserirNfeProduto_Load(object sender, EventArgs e)
        {
            try
            {
                txtQuantidadeUnitariaCaixa.Focus();
            }
            catch { }
            
        }
    }
}
