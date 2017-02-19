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
    [Activity(Label = "LancHistoPontos")]
    public class LancHistoPontos : Activity
    {

        public RadioGroup rdgFormaPagamentoPontos;

        public RadioButton rdbAVista;
        public RadioButton rdbCCVISA;
        public RadioButton rdbMASTERCARD;
        public RadioButton rdbELO;
        public RadioButton rdbBoleto;

        public EditText etxChaveNFCE;

        public Button btnEnviarLancamento;

        Usuario usuarioLogado;

        public ListView lsvHistorico;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.LancHistoPontos);

            string jsonString_UsuarioLogado = Intent.GetStringExtra("usuario");

            usuarioLogado = JsonConvert.DeserializeObject<Usuario>(jsonString_UsuarioLogado);

            rdgFormaPagamentoPontos = FindViewById<RadioGroup>(Resource.Id.rdgFormaPagamentoPontos);

            rdbAVista = FindViewById<RadioButton>(Resource.Id.rdbAVista);
            rdbCCVISA = FindViewById<RadioButton>(Resource.Id.rdbCCVISA);
            rdbMASTERCARD = FindViewById<RadioButton>(Resource.Id.rdbMASTERCARD);
            rdbELO = FindViewById<RadioButton>(Resource.Id.rdbELO);
            rdbBoleto = FindViewById<RadioButton>(Resource.Id.rdbBoleto);

            etxChaveNFCE = FindViewById<EditText>(Resource.Id.etxChaveNFCE);

            btnEnviarLancamento = FindViewById<Button>(Resource.Id.btnEnviarLancamento);

            lsvHistorico = FindViewById<ListView>(Resource.Id.lsvHistorico);
            lsvHistorico.Adapter = getAdapter();

            btnEnviarLancamento.Click += delegate
            {
                string tipo_pagamento = string.Empty;

                if (rdbAVista.Selected)
                {
                    tipo_pagamento = "A Vista";
                }
                else if (rdbCCVISA.Selected)
                {
                    tipo_pagamento = "Cartão de Credito - VISA";
                }
                else if (rdbMASTERCARD.Selected)
                {
                    tipo_pagamento = "Cartão de Credito - MASTERCARD";
                }
                else if (rdbELO.Selected)
                {
                    tipo_pagamento = "Cartão de Credito - ELO";
                }
                else if (rdbBoleto.Selected)
                {
                    tipo_pagamento = "Boleto";
                }

                Lancamento lancamento = new Lancamento(usuarioLogado.ID, etxChaveNFCE.Text, DateTime.Now, 0, 0, "EA", tipo_pagamento);
                string json_lancamento = JsonConvert.SerializeObject(lancamento);

                string urlBase = "http://webservices.commitsoft.com.br/";
                string servico = "LancarPagamento.php";
                string type_query = "json_Lancamento=" + json_lancamento;

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

                            if (responseText.Equals("1"))
                            {
                                Toast.MakeText(this, "Lancamento realizado com sucesso", ToastLength.Short).Show();
                                base.OnBackPressed();
                            }
                            else
                            {
                                Toast.MakeText(this, "Não foi possível efetuar o lancamento.", ToastLength.Short).Show();
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

                    Toast.MakeText(this, "Não foi possível efetuar o lancamento.", ToastLength.Short).Show();
                }

            };
        }

        private string[] getFeedData()
        {
            List<string> itens = new List<string>();

            string urlBase = "http://webservices.commitsoft.com.br/";
            string servico = "Databasyquery.php";
            string type_query = "type_query=Lancamentos";
            string idUsuario = "idUsuario="+ usuarioLogado.ID;

            try
            {

                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(urlBase + servico + "?" + type_query + "&" + idUsuario);
                request.Method = "GET";
                request.ContentType = "application/json";

                HttpWebResponse myWebResponse = (HttpWebResponse)request.GetResponse();

                string responseText;

                using (var response = request.GetResponse())
                {
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseText = reader.ReadToEnd();

                        List<Lancamento> feedData = JsonConvert.DeserializeObject<List<Lancamento>>(responseText);

                        foreach (Lancamento lancamento in feedData)
                        {
                            itens.Add(lancamento.DATA_LANCAMENTO.ToString() + ": " + lancamento.VALOR_COMPRA);
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


        private ArrayAdapter getAdapter()
        {
            ArrayAdapter arrayAdapter;

            arrayAdapter = new ArrayAdapter(this, Android.Resource.Layout.SimpleListItem1, getFeedData());

            return arrayAdapter;
        }
    }

}