using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFMercadoTitio
{
    class Global
    {
        public OleDbConnection conexao;
        public static Global instancia = new Global();
        public string caminhoPastaNota = @"C:\NotasFiscais\Notas";
        public string caminhoPastaNotaRetorno = @"C:\NotasFiscais\Retornos";

        public string conexaoString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source = C:\Banco_Dados\Soft.mdb;Jet OLEDB:Database Password = 'Soft';";
        //public string conexaoString = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source =  \\MAINSERVIDOR-PC\Arquivos Sistema Valendo\Banco_Dados\Soft.mdb;Jet OLEDB:Database Password = 'Soft';";

        public string codigoBarraProduto = string.Empty;
    }
}
