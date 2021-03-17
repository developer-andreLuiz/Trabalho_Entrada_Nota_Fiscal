using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFMercadoTitio.Modelo
{
    public class ModeloListaProdutosNota
    {
        public string id { get; set; }
        public string item { get; set; }
        public int codFornecedor { get; set; }
        public string cprod { get; set; }
        public string xprod { get; set; }
        public string cean { get; set; }
        public string ceantrib { get; set; }
        public string voutro { get; set; }
        public string vdesc { get; set; }
        public string vfrete { get; set; }
        public string vprod { get; set; }
        public string vseg { get; set; }
        public object icms_vicmsst { get; set; }
        public object icms_vfcpst { get; set; }
        public object ipi_vipi { get; set; }
        public object ucom { get; set; }
        public object qcom { get; set; }

        // * = lista    ** = banco + lista
        public object vUnCom { get; set; }//*   
        public object uTrib { get; set; }//*
        public object qTrib { get; set; }//*
        public object vUnTrib { get; set; }//*

        public object ICMS_orig { get; set; }//*
        public object ICMS_CST { get; set; }//*
        public object ICMS_vBC { get; set; }//*
        public object ICMS_pICMS { get; set; }//*
        public object ICMS_vICMS { get; set; }//*
        public object ICMS_modBCST { get; set; }//
        public object ICMS_vBCST { get; set; }//*


        public object IPI_vBC { get; set; }//*
        public object IPI_pIPI { get; set; }//*

        public object PIS_vBC { get; set; }//*
        public object PIS_pPIS { get; set; }//*
        public object PIS_vPIS { get; set; }//*


        public object COFINS_vBC { get; set; }//*
        public object COFINS_pCOFINS { get; set; }//*
        public object COFINS_vCOFINS { get; set; }//*

    }
}
