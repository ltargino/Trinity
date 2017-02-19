using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace Trinity.Model
{
    class Lancamento
    {

        public int ID { get; set; }
        public int FK_ID_USUARIO { get; set; }
        public string CHAVE_SEGURANCA { get; set; }
        public DateTime DATA_LANCAMENTO { get; set; }
        public int PONTOS_USUARIO { get; set; }
        public double VALOR_COMPRA { get; set; }
        public string STATUS { get; set; }
        public string TIPO_PAGAMENTO { get; set; }
        public Lancamento(int FK_ID_USUARIO, string CHAVE_SEGURANCA, DateTime DATA_LANCAMENTO, int PONTOS_USUARIO, double VALOR_COMPRA, string STATUS, string TIPO_PAGAMENTO)
        {
            this.ID = ID;
            this.FK_ID_USUARIO = FK_ID_USUARIO;
            this.CHAVE_SEGURANCA = CHAVE_SEGURANCA;
            this.DATA_LANCAMENTO = DATA_LANCAMENTO;
            this.PONTOS_USUARIO = PONTOS_USUARIO;
            this.VALOR_COMPRA = VALOR_COMPRA;
            this.STATUS = STATUS;
            this.TIPO_PAGAMENTO = TIPO_PAGAMENTO;
        }

    }
}