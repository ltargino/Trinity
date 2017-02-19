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
    class Saldo_Usuario
    {

        public int ID { get; set; }
        public int FK_ID_USUARIO { get; set; }
        public int SALDO_PONTOS { get; set; }

        public Saldo_Usuario(int ID, int FK_ID_USUARIO, int SALDO_PONTOS)
        {
            this.ID = ID;
            this.FK_ID_USUARIO = FK_ID_USUARIO;
            this.SALDO_PONTOS = SALDO_PONTOS;
        }

    }
}