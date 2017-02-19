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
using System.Net.Mail;

namespace Trinity.Control
{
    [Activity(Label = "Troca")]
    public class Troca : Activity
    {

        private ImageView imgTroca;
        private TextView txNomePremioTroca;
        private TextView txDescricaoPremioTroca;
        private EditText edtSenhaTroca;
        private Button btnConfirmarTroca;
        
        Usuario usuarioLogado;
        private int voucherID;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            string jsonString_UsuarioLogado = Intent.GetStringExtra("usuario");
            usuarioLogado = JsonConvert.DeserializeObject<Usuario>(jsonString_UsuarioLogado);

            string nomePremio = Intent.GetStringExtra("NomePremio");
            string descricaoPremio = Intent.GetStringExtra("DescricaoPremio");
            string stringImagem = Intent.GetStringExtra("Imagem");

            SetContentView(Resource.Layout.Troca);

            imgTroca = FindViewById<ImageView>(Resource.Id.imgTroca);
            txNomePremioTroca = FindViewById<TextView>(Resource.Id.txNomePremioTroca);
            txDescricaoPremioTroca = FindViewById<TextView>(Resource.Id.txDescricaoPremioTroca);
            edtSenhaTroca = FindViewById<EditText>(Resource.Id.edtSenhaTroca);
            btnConfirmarTroca = FindViewById<Button>(Resource.Id.btnConfirmarTroca);

            txNomePremioTroca.Text = txNomePremioTroca.Text.Replace("{NomePremio}", nomePremio);
            txDescricaoPremioTroca.Text = txDescricaoPremioTroca.Text.Replace("{DescricaoPremio}", descricaoPremio);

            switch (stringImagem)
            {
                case "Imagem1": 
                    {
                        imgTroca.SetImageResource(Resource.Drawable.Premio1);
                        break;
                    }
                case "Imagem2":
                    {
                        imgTroca.SetImageResource(Resource.Drawable.Premio7);
                        break;
                    }
                case "Imagem3":
                    {
                        imgTroca.SetImageResource(Resource.Drawable.Premio8);
                        break;
                    }
            };

            btnConfirmarTroca.Click += delegate
            {
                if (string.IsNullOrEmpty(edtSenhaTroca.Text))
                {
                    Toast.MakeText(this, "Informe sua senha.", ToastLength.Short).Show();
                } else {

                    if (usuarioLogado.SENHA != edtSenhaTroca.Text)
                    {
                        Toast.MakeText(this, "Senha incorreta.", ToastLength.Short).Show();
                    }
                    else
                    {
                        if (enviarVoucher(usuarioLogado.EMAIL))
                        {
                            Intent intent = new Intent();

                            intent.SetClass(this, typeof(ConfirmTrocas));
                            intent.PutExtra("usuario", JsonConvert.SerializeObject(usuarioLogado));
                            intent.PutExtra("voucherID", voucherID);

                            StartActivity(intent);
                        }
                    }
                }
            };
        }

        private bool enviarVoucher(string destinatario)
        {
            bool enviado = false;
            Random rand1 = new Random();
            voucherID = rand1.Next(5000, 20000);

            //Define os dados do e-mail
            string nomeRemetente = "Seu Nome";
            string emailRemetente = "fr3toprg@gmail.com";
            string senha = "Windows5";

            //Host da porta SMTP
            string SMTP = "smtp.gmail.com";

            string emailDestinatario = destinatario;
            //string emailComCopia        = "email@comcopia.com.br";
            //string emailComCopiaOculta  = "email@comcopiaoculta.com.br";

            string assuntoMensagem = "Trinity - Seu voucher chegou";
            string conteudoMensagem = "Parabéns por sua troca de pontos, use o voucher de número " + voucherID + ". Bom proveito!";

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
                enviado = true;
            }
            catch (Exception ex)
            {
                //Response.Write("Ocorreram problemas no envio do e-mail. Erro = " + ex.Message);
                enviado = false;
            }
            finally
            {
                //excluímos o objeto de e-mail da memória
                objEmail.Dispose();
                //anexo.Dispose();
            }

            return enviado;
        }

        
    }
}