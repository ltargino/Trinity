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
    class Mensagens {

        public int ID { get; set; }
        public DateTime DATA_HORA_MENSAGEM { get; set; }
        public string MENSAGEM { get; set; }
        public int FK_ID_USUARIO_ORIGEM { get; set; }
        public int FK_ID_USUARIO_DESTINO { get; set; }

        public Mensagens(int ID, DateTime DATA_HORA_MENSAGEM, string MENSAGEM, int FK_ID_USUARIO_ORIGEM, int FK_ID_USUARIO_DESTINO)
        {
            this.ID = ID;
            this.DATA_HORA_MENSAGEM = DATA_HORA_MENSAGEM;
            this.MENSAGEM = MENSAGEM;
            this.FK_ID_USUARIO_ORIGEM = FK_ID_USUARIO_ORIGEM;
            this.FK_ID_USUARIO_DESTINO = FK_ID_USUARIO_DESTINO;    
        }

    }
}