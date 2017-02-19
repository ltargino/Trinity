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
using System.IO;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;
using System.Net;

namespace Trinity.Control
{
    [Activity(Label = "Cadastro")]
    public class Cadastro : Activity {

        public EditText etxNomeCadastro;
        public EditText etxDataNascimentoCadatro;
        public EditText etxCPFCadastro;
        public EditText etxTelefoneCadastro;
        public EditText etxEmailCadastro;
        public EditText etxSenhaCadastro;

        public Button etxConfirmSenhaCadastro;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Cadastro);

            etxNomeCadastro = FindViewById<EditText>(Resource.Id.etxNomeCadastro);
            etxDataNascimentoCadatro = FindViewById<EditText>(Resource.Id.etxDataNascimentoCadatro);
            etxCPFCadastro = FindViewById<EditText>(Resource.Id.etxCPFCadastro);
            etxTelefoneCadastro = FindViewById<EditText>(Resource.Id.etxTelefoneCadastro);
            etxEmailCadastro = FindViewById<EditText>(Resource.Id.etxEmailCadastro);
            etxSenhaCadastro = FindViewById<EditText>(Resource.Id.etxSenhaCadastro);

            etxConfirmSenhaCadastro = FindViewById<Button>(Resource.Id.btnConfirmarCadastro);

            etxConfirmSenhaCadastro.Click += delegate {
                confirmarCadastro();
            };
        }

        private void confirmarCadastro() {
            Usuario usuarioCadastro = new Usuario(0, etxCPFCadastro.Text, etxNomeCadastro.Text, DateTime.Parse(etxDataNascimentoCadatro.Text), etxTelefoneCadastro.Text, etxEmailCadastro.Text, etxSenhaCadastro.Text);
            string json_usuarioCadastro = JsonConvert.SerializeObject(usuarioCadastro);

            string urlBase = "http://webservices.commitsoft.com.br/";
            string servico = "Cadastrar.php";
            string type_query = "json_usuarioCadastro="+json_usuarioCadastro;

            try {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlBase + servico + "?" + type_query);
                request.Method = "GET";
                request.ContentType = "application/json";

                HttpWebResponse myWebResponse = (HttpWebResponse)request.GetResponse();

                string responseText;

                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();

                        if (responseText.Equals("1")) {
                            Toast.MakeText(this, "Cadastro realizado com sucesso", ToastLength.Short).Show();
                            base.OnBackPressed();
                        } else {
                            Toast.MakeText(this, "Não foi possível cadastrar.", ToastLength.Short).Show();
                        }

                    }
                }
            }
            catch (System.Exception e)
            {
                //string responseText;
                //using (var reader = new StreamReader(e.Response.GetResponseStream())) {
                //    responseText = reader.ReadToEnd();
                //    Console.WriteLine(responseText);
                //}

                Toast.MakeText(this, "Não foi possível cadastrar.", ToastLength.Short).Show();
            }


        }
    }
}