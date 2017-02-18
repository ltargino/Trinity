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
    class Feed
    {
        public int COD_PUBLICACAO { get; set; }
        public DateTime DATA_PUBLICACAO { get; set; }
        public string DESCRICAO_FEED { get; set; }
        public int FK_ID_USUARIO { get; set; }

        public Feed(int COD_PUBLICACAO, DateTime DATA_PUBLICACAO, string DESCRICAO_FEED, int FK_ID_USUARIO)
        {
            this.COD_PUBLICACAO = COD_PUBLICACAO;
            this.DATA_PUBLICACAO = DATA_PUBLICACAO;
            this.DESCRICAO_FEED = DESCRICAO_FEED;
            this.FK_ID_USUARIO = FK_ID_USUARIO;

        }
    }
}