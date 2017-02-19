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
using System.Net;
using System.IO;

namespace Trinity.Control
{
    [Activity(Label = "TimeLine")]
    public class TimeLine : Activity
    {
        private TextView texEmailFeed;
        private TextView texNomeUsuarioFeed;

        private ListView lsvFeed;

        Usuario usuarioLogado;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string jsonString_UsuarioLogado = Intent.GetStringExtra("usuario");

            usuarioLogado = JsonConvert.DeserializeObject<Usuario>(jsonString_UsuarioLogado);

            SetContentView(Resource.Layout.TimeLine);

            texEmailFeed = FindViewById<TextView>(Resource.Id.texEmailFeed);
            texNomeUsuarioFeed = FindViewById<TextView>(Resource.Id.texNomeUsuarioFeed);
            lsvFeed = FindViewById<ListView>(Resource.Id.lsvFeed);

            texEmailFeed.Text = texEmailFeed.Text.Replace("{email}", usuarioLogado.EMAIL);
            texNomeUsuarioFeed.Text = texNomeUsuarioFeed.Text.Replace("{NomeUsuario}", usuarioLogado.NOME);

            lsvFeed.Adapter = getAdapter();
        }

        private ArrayAdapter getAdapter()
        {
            ArrayAdapter arrayAdapter;

            arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, getFeedData());

            return arrayAdapter;
        }

        private string[] getFeedData() {
            List<string> itens = new List<string>();

            string urlBase = "http://webservices.commitsoft.com.br/";
            string servico = "Databasyquery.php";
            string type_query = "type_query=Feed";

            try
            {

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

                        List<Feed> feedData = JsonConvert.DeserializeObject<List<Feed>>(responseText);

                        foreach (Feed feed in feedData) {
                            itens.Add(feed.DATA_PUBLICACAO.ToString()+": "+feed.DESCRICAO_FEED);
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

                Toast.MakeText(this, "Não foi possível obter os dados.", ToastLength.Short).Show();
            }

            return itens.ToArray();
        }
    }
}