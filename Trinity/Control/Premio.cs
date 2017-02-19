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
using Newtonsoft.Json;
using Trinity.Model;
using Android.Graphics;
using Android.Graphics.Drawables;

namespace Trinity.Control
{
    [Activity(Label = "Premio")]
    public class Premio : Activity
    {

        public Button btnTrocarItem1;
        public Button btnTrocarItem2;
        public Button btnTrocarItem3;

        Usuario usuarioLogado;

        private ImageView imageView1;
        private ImageView imageView2;
        private ImageView imageView3;

        private TextView textView1;
        private TextView textView2;
        private TextView textView3;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string jsonString_UsuarioLogado = Intent.GetStringExtra("usuario");

            usuarioLogado = JsonConvert.DeserializeObject<Usuario>(jsonString_UsuarioLogado);

            SetContentView(Resource.Layout.Premio);

            btnTrocarItem1 = FindViewById<Button>(Resource.Id.btnTrocarItem1);
            btnTrocarItem2 = FindViewById<Button>(Resource.Id.btnTrocarItem2);
            btnTrocarItem3 = FindViewById<Button>(Resource.Id.btnTrocarItem3);

            imageView1 = FindViewById<ImageView>(Resource.Id.imageView1);
            imageView2 = FindViewById<ImageView>(Resource.Id.imageView2);
            imageView3 = FindViewById<ImageView>(Resource.Id.imageView3);

            textView1 = FindViewById<TextView>(Resource.Id.textView1);
            textView2 = FindViewById<TextView>(Resource.Id.textView2);
            textView3 = FindViewById<TextView>(Resource.Id.textView3);

            btnTrocarItem1.Click += delegate {
                Intent intent = new Intent();

                intent.SetClass(this, typeof(Troca));
                intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));
                intent.PutExtra("NomePremio", textView1.Text);
                intent.PutExtra("DescricaoPremio", string.Empty);
                intent.PutExtra("Imagem", "Imagem1");

                StartActivity(intent);
            };

            btnTrocarItem2.Click += delegate {
                Intent intent = new Intent();

                intent.SetClass(this, typeof(Troca));
                intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));
                intent.PutExtra("NomePremio", textView2.Text);
                intent.PutExtra("DescricaoPremio", string.Empty);
                intent.PutExtra("Imagem", "Imagem2");

                StartActivity(intent);
            };

            btnTrocarItem3.Click += delegate {
                Intent intent = new Intent();

                intent.SetClass(this, typeof(Troca));
                intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));
                intent.PutExtra("NomePremio", textView3.Text);
                intent.PutExtra("DescricaoPremio", string.Empty);
                intent.PutExtra("Imagem", "Imagem3");

                StartActivity(intent);
            };
        }
    }
}