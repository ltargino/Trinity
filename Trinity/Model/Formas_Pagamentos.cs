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

namespace Trinity.Model {
    class Formas_Pagamentos {
        public int COD_PAGAMENTO { get; set; }
        public string DESCRICACAO_PAGAMENTO { get; set; }

        public Formas_Pagamentos(int COD_PAGAMENTO, string DESCRICACAO_PAGAMENTO) {
            this.COD_PAGAMENTO = COD_PAGAMENTO;
            this.DESCRICACAO_PAGAMENTO = DESCRICACAO_PAGAMENTO;
        }

    }
}