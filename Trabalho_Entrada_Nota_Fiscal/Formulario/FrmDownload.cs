using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using NFMercadoTitio.Modelo;
using Recepcao = NFMercadoTitio.NfeRecepcao;
using Download = NFMercadoTitio.NFeDistribuicaoDFe;
using System.Security.Cryptography.Xml;
using System.Reflection;
using System.Collections;
using System.Xml.Serialization;

namespace NFMercadoTitio.Formulario
{
    public partial class FrmDownload : Form
    {
        List<GridNota> lt = new List<GridNota>();
        public FrmDownload()
        {
            InitializeComponent();
        }
        private void FrmDownload_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter && txtNota.Focused && txtNota.Text.Count() == 44)
                {
                    bool notaInserida = false;
                    foreach (var a in lt)
                    {
                        if (txtNota.Text.Equals(a.ID_NOTA) == true)
                        {
                            notaInserida = true;
                            break;
                        }
                    }
                    if (notaInserida == false)
                    {
                        lt.Add(new GridNota { ID_NOTA = txtNota.Text });
                        NumeroNotas();
                        dataGridView.DataSource = null;
                        if (lt.Count > 0)
                        {
                            dataGridView.DataSource = lt;
                            dataGridView.Columns[0].Width = 669;
                        }
                    }
                    txtNota.Text = string.Empty;
                }
            }
            catch { }
            
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
        void AbrirRetorno(string nomeArquivoLocal)
        {
            try
            {
                if (retornoExiste(nomeArquivoLocal))
                {
                    string texto = Global.instancia.caminhoPastaNotaRetorno + @"\" + nomeArquivoLocal + "-Retorno.xml";
                    System.Diagnostics.Process.Start(texto);
                }
                
            }
            catch { }

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
        private XmlDocument ConverterStringToXml(string texto)
        {
            var xml = new XmlDocument();
            xml.LoadXml(texto);
            return xml;
        }
        public string descompactar(byte[] conteudo)
        {
            using (var memory = new MemoryStream(conteudo))
            using (var compression = new GZipStream(memory, CompressionMode.Decompress))
            using (var reader = new StreamReader(compression))
            {
                return reader.ReadToEnd();
            }
        }

        void NumeroNotas()
        {
            
            lblNumeroNotas.Text = "Notas: "+lt.Count.ToString();
        }

        ///********Função AG SILVA********///
        void CienciaNotaAG(string idNotaLocal)
        {
            var NFe_Rec = new Recepcao.RecepcaoEventoSoapClient();
            string cnpjCiencia = string.Empty;
            NFe_Rec.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "673e2004293b7498");
            cnpjCiencia = "10786763000163";


            var notas = new string[] { idNotaLocal }; // este array não deve passar de 20 elementos, máximo permitido por lote de manifestação
            var sbXml = new StringBuilder();
            sbXml.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                 <envEvento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">
                 <idLote>1</idLote>");
            foreach (var nota in notas)
            {
                sbXml.Append(@" <evento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">
                <infEvento Id=""ID210210" + nota + @"01"">
                <cOrgao>91</cOrgao>
                <tpAmb>1</tpAmb>
                <CNPJ>" + cnpjCiencia + @"</CNPJ>
                <chNFe>" + nota + @"</chNFe>
                 <dhEvento>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + @"-03:00</dhEvento>
                <tpEvento>210210</tpEvento>
                <nSeqEvento>1</nSeqEvento>
                <verEvento>1.00</verEvento>
                <detEvento versao=""1.00"">
                <descEvento>Ciencia da Operacao</descEvento>
                </detEvento>
                </infEvento>
                </evento>");
            }
            sbXml.Append("</envEvento>");
            var xml = new XmlDocument();
            xml.LoadXml(sbXml.ToString());
            var i = 0;
            foreach (var nota in notas)
            {
                var docXML = new SignedXml(xml);
                docXML.SigningKey = NFe_Rec.ClientCredentials.ClientCertificate.Certificate.PrivateKey;
                var refer = new Reference();
                refer.Uri = "#ID210210" + nota + "01";
                refer.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                refer.AddTransform(new XmlDsigC14NTransform());
                docXML.AddReference(refer);

                var ki = new KeyInfo();
                ki.AddClause(new KeyInfoX509Data(NFe_Rec.ClientCredentials.ClientCertificate.Certificate));
                docXML.KeyInfo = ki;

                docXML.ComputeSignature();
                i++;
                xml.ChildNodes[1].ChildNodes[i].AppendChild(xml.ImportNode(docXML.GetXml(), true));
            }
            var NFe_Cab = new Recepcao.nfeCabecMsg();
            NFe_Cab.cUF = "33"; //RJ => De acordo com a Tabela de Código de UF do IBGE
            NFe_Cab.versaoDados = "1.00";
            var resp = NFe_Rec.nfeRecepcaoEvento(NFe_Cab, xml);
            var fileResp = Global.instancia.caminhoPastaNotaRetorno + "\\" + idNotaLocal + "-Retorno.xml";
            //var fileReq = caminhoPastaNotaRetorno + "\\" + txtNumeroNotaFiscal.Text + "-tempRequ.xml";
            //File.WriteAllText(fileReq, xml.OuterXml);
            File.WriteAllText(fileResp, resp.OuterXml);
        }
        void DownloadNotaAG(string idNotaLocal)
        {
            var texto = string.Empty;
            texto = @"<distDFeInt xmlns=""http://www.portalfiscal.inf.br/nfe"" versao = ""1.01""> <tpAmb>1</tpAmb><cUFAutor>33</cUFAutor> <CNPJ>10786763000163</CNPJ><consChNFe><chNFe>" + idNotaLocal + "</chNFe></consChNFe></distDFeInt>";
            var xmlDownload = ConverterStringToXml(texto);
            BaixarXmlAG(xmlDownload, idNotaLocal);
        }
        private void BaixarXmlAG(XmlDocument xml, string idNotaLocalBaixarXml)
        {
            var NFe_Sc = new Download.NFeDistribuicaoDFeSoapClient();
            NFe_Sc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "673e2004293b7498");
            XElement x = XElement.Parse(xml.InnerXml);
            var arquivo = NFe_Sc.nfeDistDFeInteresse(x).ToString();

            var xmlNota = ConverterStringToXml(arquivo);
            var conteuZip = xmlNota.GetElementsByTagName("docZip")[0].InnerText;
            byte[] dados = Convert.FromBase64String(conteuZip);

            var xmlRetorno = descompactar(dados);
            var path = Global.instancia.caminhoPastaNota + "\\" + idNotaLocalBaixarXml + ".xml";
            File.AppendAllText(path, xmlRetorno);
        }
        retEnvEvento LeituraRetorno(string caminho)
        {
            XmlSerializer ser = new XmlSerializer(typeof(retEnvEvento));
            TextReader textReader = (TextReader)new StreamReader(caminho);
            XmlTextReader reader = new XmlTextReader(textReader);
            reader.Read();
            retEnvEvento retorno = (retEnvEvento)ser.Deserialize(reader);
            reader.Dispose();
            return retorno;

        }


        ///********Função TITIO********///
        void CienciaNotaTITIO(string idNotaLocal)
        {
            var NFe_Rec = new Recepcao.RecepcaoEventoSoapClient();
            string cnpjCiencia = string.Empty;
            NFe_Rec.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "0388b9c062154c7b");
            cnpjCiencia = "24952156000130";


            var notas = new string[] { idNotaLocal }; // este array não deve passar de 20 elementos, máximo permitido por lote de manifestação
            var sbXml = new StringBuilder();
            sbXml.Append(@"<?xml version=""1.0"" encoding=""UTF-8""?>
                 <envEvento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">
                 <idLote>1</idLote>");
            foreach (var nota in notas)
            {
                sbXml.Append(@" <evento xmlns=""http://www.portalfiscal.inf.br/nfe"" versao=""1.00"">
                <infEvento Id=""ID210210" + nota + @"01"">
                <cOrgao>91</cOrgao>
                <tpAmb>1</tpAmb>
                <CNPJ>" + cnpjCiencia + @"</CNPJ>
                <chNFe>" + nota + @"</chNFe>
                 <dhEvento>" + DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss") + @"-03:00</dhEvento>
                <tpEvento>210210</tpEvento>
                <nSeqEvento>1</nSeqEvento>
                <verEvento>1.00</verEvento>
                <detEvento versao=""1.00"">
                <descEvento>Ciencia da Operacao</descEvento>
                </detEvento>
                </infEvento>
                </evento>");
            }
            sbXml.Append("</envEvento>");
            var xml = new XmlDocument();
            xml.LoadXml(sbXml.ToString());
            var i = 0;
            foreach (var nota in notas)
            {
                var docXML = new SignedXml(xml);
                docXML.SigningKey = NFe_Rec.ClientCredentials.ClientCertificate.Certificate.PrivateKey;
                var refer = new Reference();
                refer.Uri = "#ID210210" + nota + "01";
                refer.AddTransform(new XmlDsigEnvelopedSignatureTransform());
                refer.AddTransform(new XmlDsigC14NTransform());
                docXML.AddReference(refer);

                var ki = new KeyInfo();
                ki.AddClause(new KeyInfoX509Data(NFe_Rec.ClientCredentials.ClientCertificate.Certificate));
                docXML.KeyInfo = ki;

                docXML.ComputeSignature();
                i++;
                xml.ChildNodes[1].ChildNodes[i].AppendChild(xml.ImportNode(docXML.GetXml(), true));
            }
            var NFe_Cab = new Recepcao.nfeCabecMsg();
            NFe_Cab.cUF = "33"; //RJ => De acordo com a Tabela de Código de UF do IBGE
            NFe_Cab.versaoDados = "1.00";
            var resp = NFe_Rec.nfeRecepcaoEvento(NFe_Cab, xml);
            var fileResp = Global.instancia.caminhoPastaNotaRetorno + "\\" + idNotaLocal + "-Retorno.xml";
            //var fileReq = caminhoPastaNotaRetorno + "\\" + txtNumeroNotaFiscal.Text + "-tempRequ.xml";
            //File.WriteAllText(fileReq, xml.OuterXml);
            File.WriteAllText(fileResp, resp.OuterXml);
        }
        void DownloadNotaTITIO(string idNotaLocal)
        {
            var texto = string.Empty;
            texto = @"<distDFeInt xmlns=""http://www.portalfiscal.inf.br/nfe"" versao = ""1.01""> <tpAmb>1</tpAmb><cUFAutor>33</cUFAutor> <CNPJ>24952156000130</CNPJ><consChNFe><chNFe>" + idNotaLocal + "</chNFe></consChNFe></distDFeInt>";
            var xmlDownload = ConverterStringToXml(texto);
            BaixarXmlTITIO(xmlDownload, idNotaLocal);
        }
        private void BaixarXmlTITIO(XmlDocument xml, string idNotaLocalBaixarXml)
        {
            var NFe_Sc = new Download.NFeDistribuicaoDFeSoapClient();
            NFe_Sc.ClientCredentials.ClientCertificate.SetCertificate(StoreLocation.CurrentUser, StoreName.My, X509FindType.FindBySerialNumber, "0388b9c062154c7b");
            XElement x = XElement.Parse(xml.InnerXml);
            var arquivo = NFe_Sc.nfeDistDFeInteresse(x).ToString();

            var xmlNota = ConverterStringToXml(arquivo);
            var conteuZip = xmlNota.GetElementsByTagName("docZip")[0].InnerText;
            byte[] dados = Convert.FromBase64String(conteuZip);

            var xmlRetorno = descompactar(dados);
            var path = Global.instancia.caminhoPastaNota + "\\" + idNotaLocalBaixarXml + ".xml";
            File.AppendAllText(path, xmlRetorno);
        }
        void BaixarNotasLista()
        {
            int rep = 0;
            int NotasBaixadas = 0;
            
            List<GridNota> ltErros = new List<GridNota>();
            if (lt.Count() > 0)
            {
                lblStatus.Text = "Baixando Nota...";
                progressBar.Maximum = lt.Count();
                string respostaErro = "Rejeicao: O autor do evento diverge do destinatario da NF-e";
                foreach (var a in lt)
                {
                    retEnvEvento retorno = new retEnvEvento();
                    ApagarRetorno(a.ID_NOTA);
                    ApagarNota(a.ID_NOTA);
                    retorno = null;
                    try{ CienciaNotaTITIO(a.ID_NOTA); } catch { }

                    
                    if (retornoExiste(a.ID_NOTA)==true)
                    {
                        retorno = LeituraRetorno(Global.instancia.caminhoPastaNotaRetorno + @"\" + a.ID_NOTA + "-Retorno.xml");
                    }

                    if (retorno.retEvento.infEvento.xMotivo.ToUpper().Equals(respostaErro.ToUpper())==false)
                    {
                        try { DownloadNotaTITIO(a.ID_NOTA); } catch { }
                    }
                    else
                    {
                        ApagarRetorno(a.ID_NOTA);
                        try { CienciaNotaAG(a.ID_NOTA); } catch { }
                        if (retornoExiste(a.ID_NOTA) == true)
                        {
                            retorno = LeituraRetorno(Global.instancia.caminhoPastaNotaRetorno + @"\" + a.ID_NOTA + "-Retorno.xml");
                        }
                        if (retorno.retEvento.infEvento.xMotivo.ToUpper().Equals(respostaErro.ToUpper()) == false)
                        {
                            try { DownloadNotaAG(a.ID_NOTA); } catch { }
                        }
                    }

                    if (notaExiste(a.ID_NOTA) == false)
                    {
                        ltErros.Add(new GridNota { ID_NOTA = a.ID_NOTA });
                    }
                    NotasBaixadas++;
                    progressBar.Value = NotasBaixadas;
                }
                lblStatus.Text = "Download Concluido";
                progressBar.Value = 0;
             
                if (ltErros.Count>0)
                {
                    lt.Clear();
                    lt = ltErros;
                    dataGridView.DataSource = null;
                    if (lt.Count() > 0)
                    {
                        dataGridView.DataSource = lt;
                        dataGridView.Columns[0].Width = 669;
                    }

                }
                else
                {
                    lt.Clear();
                    dataGridView.DataSource = null;
                    if (lt.Count() > 0)
                    {
                        dataGridView.DataSource = lt;
                        dataGridView.Columns[0].Width = 669;
                    }
                }
               
            }
            NumeroNotas();
        }
       

       
        
        
        
        private void btnDownloadNota_Click(object sender, EventArgs e)
        {
            try
            {
                BaixarNotasLista();
            }
            catch { }
            
        }
        private void dataGridView_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                if (lt.Count > 0)
                {
                    AbrirRetorno(dataGridView.Rows[e.RowIndex].Cells[0].Value.ToString());
                }
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
                            int indexLst = lt.FindIndex(x => x.ID_NOTA.Equals(dataGridView.Rows[linhaAtual.Index].Cells[0].Value.ToString()));
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
            }
            catch { }
           
           
        }
    }
}
