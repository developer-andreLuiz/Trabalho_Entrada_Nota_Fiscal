using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NFMercadoTitio
{
    static class Program
    {
        /// <summary>
        /// Ponto de entrada principal para o aplicativo.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Pasta();
            AberturaBanco();
            Application.Run(new FrmMain());
        }
        static void Pasta()
        {
            try
            {
                if (!Directory.Exists(Global.instancia.caminhoPastaNota))
                {
                    Directory.CreateDirectory(Global.instancia.caminhoPastaNota);
                }
                if (!Directory.Exists(Global.instancia.caminhoPastaNotaRetorno))
                {
                    Directory.CreateDirectory(Global.instancia.caminhoPastaNotaRetorno);
                }
            }
            catch { }
        }
        static void AberturaBanco()
        {
            try
            {
                Global.instancia.conexao = new OleDbConnection(Global.instancia.conexaoString);
            }
            catch { }
           
        }
    }
}
