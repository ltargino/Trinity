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
using Trinity.Model;
using Newtonsoft.Json;

namespace Trinity.Control
{
    [Activity(Label = "ConfirmTroca")]
    public class ConfirmTrocas : Activity
    {

        private TextView etxConfirmTroca1;
        private TextView etxConfirmTroca2;
        private TextView etxConfirmTroca3;
        private TextView etxConfirmTroca4;

        Usuario usuarioLogado;
        private int voucherID;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            string jsonString_UsuarioLogado = Intent.GetStringExtra("usuario");
            usuarioLogado = JsonConvert.DeserializeObject<Usuario>(jsonString_UsuarioLogado);

            voucherID = Intent.GetIntExtra("voucherID", 0);

            SetContentView(Resource.Layout.ConfirmTroca);
            
            etxConfirmTroca1 = FindViewById<TextView>(Resource.Id.etxConfirmTroca1);
            etxConfirmTroca2 = FindViewById<TextView>(Resource.Id.etxConfirmTroca2); ;
            etxConfirmTroca3 = FindViewById<TextView>(Resource.Id.etxConfirmTroca3); ;
            etxConfirmTroca4 = FindViewById<TextView>(Resource.Id.etxConfirmTroca4); ;

            etxConfirmTroca2.Text = etxConfirmTroca2.Text.Replace("{codigo gerado}", voucherID.ToString());
            etxConfirmTroca3.Text = etxConfirmTroca3.Text.Replace("{E-MAIL}", usuarioLogado.EMAIL);
        }
    }
}