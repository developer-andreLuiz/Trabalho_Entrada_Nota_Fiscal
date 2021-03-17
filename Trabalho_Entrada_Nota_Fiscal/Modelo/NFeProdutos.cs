using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFMercadoTitio.Modelo
{
    public class NFeProdutos
    {
        public object ID { get; set; }
        public object Item { get; set; }
        public object COD_FORNECEDOR { get; set; }
        public string cProd { get; set; }
        public object xProd { get; set; }
        public object cEAN { get; set; }
        public object QtdProdCompra { get; set; }
        public object vProd { get; set; }
        public object cEANTrib { get; set; }
        public object vDesc { get; set; }
        public object vOutro { get; set; }
        public object vFrete { get; set; }
        public object vSeg { get; set; }
        public object ICMS_vICMSST { get; set; }
        public object ICMS_vFCPST { get; set; }
        public object IPI_vIPI { get; set; }
        public object Codigo { get; set; }


        public object vUnCom { get; set; }
        public object uTrib { get; set; }
        public object qTrib { get; set; }
        public object vUnTrib { get; set; }

        public object ICMS_orig { get; set; }
        public object ICMS_CST { get; set; }
        public object ICMS_vBC { get; set; }
        public object ICMS_pICMS { get; set; }
        public object ICMS_vICMS { get; set; }
        public object ICMS_modBCST { get; set; }
        public object ICMS_vBCST { get; set; }

        public object IPI_vBC { get; set; }
        public object IPI_pIPI { get; set; }

        public object PIS_vBC { get; set; }
        public object PIS_pPIS { get; set; }
        public object PIS_vPIS { get; set; }

        public object COFINS_vBC { get; set; }
        public object COFINS_pCOFINS { get; set; }
        public object COFINS_vCOFINS { get; set; }



    }
}
