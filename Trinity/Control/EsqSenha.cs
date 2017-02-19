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
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Trinity.Model;
using Newtonsoft.Json;
using System.IO;

namespace Trinity.Control
{
    [Activity(Label = "EsqSenha")]
    public class EsqSenha : Activity {

        private EditText etxEmailRecuperarSenha;
        private Button btnEnviarRecuperarSenha;

        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.EsqSenha);

            etxEmailRecuperarSenha = FindViewById<EditText>(Resource.Id.etxEmailRecuperarSenha);
            btnEnviarRecuperarSenha = FindViewById<Button>(Resource.Id.btnEnviarRecuperarSenha);

            btnEnviarRecuperarSenha.Click += delegate {
                if (string.IsNullOrEmpty(etxEmailRecuperarSenha.Text)) {
                    Toast.MakeText(this, "Digite seu e-mail.", ToastLength.Short).Show();
                } else {

                    string urlBase = "http://webservices.commitsoft.com.br/";
                    string servico = "Databasyquery.php";
                    string type_query = "type_query=Usuario";
                    string emailUsuario = "emailUsuario=" + etxEmailRecuperarSenha.Text;

                    try {

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

                                enviarEmailRecuperacaoSenha(usuarioResposta.EMAIL, usuarioResposta.SENHA);

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
            };
        }

        private void enviarEmailRecuperacaoSenha(string destinatario, string senhaRecuperada) {

            //Define os dados do e-mail
            string nomeRemetente = "Seu Nome";
            string emailRemetente = "fr3toprg@gmail.com";
            string senha = "Windows5";

            //Host da porta SMTP
            string SMTP = "smtp.gmail.com";

            string emailDestinatario = destinatario;
            //string emailComCopia        = "email@comcopia.com.br";
            //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

            string assuntoMensagem = "Trinity - Recuperação de senha";
            string conteudoMensagem = "Sua senha para acessar sua conta Trinity é " + senhaRecuperada;

            //Cria objeto com dados do e-mail.
            MailMessage objEmail = new MailMessage();

            //objEmail.

            //Properties prop = new Properties();
            //prop.put("mail.smtp.host", "smtp.gmail.com");
            //prop.put("mail.smtp.auth", "true");
            //prop.put("mail.smtp.port", "465");
            //prop.put("mail.smtp.starttls.enable", "true");
            //prop.put("mail.smtp.socketFactory.port", "465");
            //prop.put("mail.smtp.socketFactory.fallback", "false");
            //prop.put("mail.smtp.socketFactory.class", "javax.net.ssl.SSLSocketFactory");



            //Define o Campo From e ReplyTo do e-mail.
            objEmail.From = new System.Net.Mail.MailAddress(nomeRemetente + "<" + emailRemetente + ">");

            //Define os destinatários do e-mail.
            objEmail.To.Add(emailDestinatario);

            //Enviar cópia para.
            //objEmail.CC.Add(emailComCopia);

            //Enviar cópia oculta para.
            //objEmail.Bcc.Add(emailComCopiaOculta);

            //Define a prioridade do e-mail.
            objEmail.Priority = System.Net.Mail.MailPriority.Normal;

            //Define o formato do e-mail HTML (caso não queira HTML alocar valor false)
            objEmail.IsBodyHtml = true;

            //Define título do e-mail.
            objEmail.Subject = assuntoMensagem;

            //Define o corpo do e-mail.
            objEmail.Body = conteudoMensagem;


            //Para evitar problemas de caracteres "estranhos", configuramos o charset para "ISO-8859-1"
            objEmail.SubjectEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");
            objEmail.BodyEncoding = System.Text.Encoding.GetEncoding("ISO-8859-1");


            // Caso queira enviar um arquivo anexo
            //Caminho do arquivo a ser enviado como anexo
            //string arquivo = Server.MapPath("arquivo.jpg");

            // Ou especifique o caminho manualmente
            //string arquivo = @"e:\home\LoginFTP\Web\arquivo.jpg";

            // Cria o anexo para o e-mail
            //Attachment anexo = new Attachment(arquivo, System.Net.Mime.MediaTypeNames.Application.Octet);

            // Anexa o arquivo a mensagem
            //objEmail.Attachments.Add(anexo);

            //Cria objeto com os dados do SMTP
            System.Net.Mail.SmtpClient objSmtp = new System.Net.Mail.SmtpClient();

            //Alocamos o endereço do host para enviar os e-mails  
            objSmtp.Credentials = new System.Net.NetworkCredential(emailRemetente, senha);
            objSmtp.Host = SMTP;
            objSmtp.Port = 587;
            objSmtp.EnableSsl = true;
            //Caso utilize conta de email do exchange da locaweb deve habilitar o SSL
            //objEmail.EnableSsl = true;

            //Enviamos o e-mail através do método .send()
            try
            {
                objSmtp.Send(objEmail);
                // Response.Write("E-mail enviado com sucesso !");
            }
            catch (Exception ex)
            {
                //Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }

        }

    }
}