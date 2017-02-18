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
using Java.Lang;
using static Android.Views.View;
using System.Net;
using System.IO;
using Trinity.Model;
using Newtonsoft.Json;

namespace Trinity.Control {
    [Activity(Label = "LoginScreem")]
    public class LoginScreem : Activity {
        private EditText emailLogin;
        private EditText senhaLogin;
        private Button btnLogin;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LoginScreem);

            emailLogin = FindViewById<EditText>(Resource.Id.emailLogin);
            senhaLogin = FindViewById<EditText>(Resource.Id.senhaLogin);

            btnLogin = FindViewById<Button>(Resource.Id.btnLogin);
            btnLogin.Click += delegate {
                login();
            };

        }

        private void login() {
            if ( string.IsNullOrEmpty(emailLogin.Text) ) {
                Toast.MakeText(this, "Informe o seu e-mail.", ToastLength.Short).Show();
            } else if (string.IsNullOrEmpty(senhaLogin.Text)) {
                Toast.MakeText(this, "Informe sua senha.", ToastLength.Short).Show();
            } else {
                string urlBase = "http://webservices.commitsoft.com.br/";
                string servico = "Databasyquery.php";
                string type_query = "type_query=Usuario";
                string emailUsuario = "emailUsuario=" + emailLogin.Text;

                try
                {

                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlBase + servico + "?" + type_query + "&" + emailUsuario);
                    request.Method = "GET";
                    request.ContentType = "application/json";

                    HttpWebResponse myWebResponse = (HttpWebResponse)request.GetResponse();

                    string responseText;

                    using (var response = request.GetResponse())
                    {
                        using (var reader = new StreamReader(response.GetResponseStream()))
                        {
                            responseText = reader.ReadToEnd();

                            Usuario usuarioResposta = JsonConvert.DeserializeObject<Usuario>(responseText);

                            if (validarSenha(usuarioResposta)) {
                                StartActivity(typeof(MainMenu));
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

                    Toast.MakeText(this, "Não foi possível efetuar o login.", ToastLength.Short).Show();
                }

            }

        }

        private bool validarSenha(Usuario usuarioResposta) {
            bool isvalid = false;

            isvalid = (senhaLogin.Text == usuarioResposta.SENHA);

            return isvalid;
        }
    }
}