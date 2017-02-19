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

namespace Trinity.Control {
    [Activity(Label = "MainMenu")]
    public class MainMenu : Activity
    {
        public TextView txvOlaUsuarioMainMenu;

        public Button btnTimeLineMainMenu;
        public Button btnLancarPagamentoMainMenu;
        public Button btnPremiosMainMenu;

        Usuario usuarioLogado;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MainMenu);

            string jsonString_UsuarioLogado = Intent.GetStringExtra("usuario");

            usuarioLogado = JsonConvert.DeserializeObject<Usuario>(jsonString_UsuarioLogado);

            txvOlaUsuarioMainMenu = FindViewById<TextView>(Resource.Id.txvOlaUsuarioMainMenu);

            txvOlaUsuarioMainMenu.Text = txvOlaUsuarioMainMenu.Text.Replace("{usuario}",usuarioLogado.NOME);

            btnTimeLineMainMenu = FindViewById<Button>(Resource.Id.btnTimeLineMainMenu);
            btnLancarPagamentoMainMenu = FindViewById<Button>(Resource.Id.btnLancarPagamentoMainMenu);
            btnPremiosMainMenu = FindViewById<Button>(Resource.Id.btnPremiosMainMenu);

            btnTimeLineMainMenu.Click += delegate {
                Intent intent = new Intent();

                intent.SetClass(this, typeof(TimeLine));
                intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));

                StartActivity(intent);
            };

            btnLancarPagamentoMainMenu.Click += delegate {
                Intent intent = new Intent();

                intent.SetClass(this, typeof(LancHistoPontos));
                intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));

                StartActivity(intent);
            };

            btnPremiosMainMenu.Click += delegate {
                Intent intent = new Intent();

                intent.SetClass(this, typeof(Premio));
                intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));

                StartActivity(intent);
            };
        }
    }
}