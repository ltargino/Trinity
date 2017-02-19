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

namespace Trinity.Model {
    [Serializable]
    class Usuario {
        public int ID { get; set; }
        public string CPF { get; set; }
        public string NOME { get; set; }
        public DateTime DATA_NASCIMENTO { get; set; }
        public string TELEFONE { get; set; }
        public string EMAIL { get; set; }
        public string SENHA { get; set; }

        public Usuario(int ID, string CPF, string Nome, DateTime Data_Nascimento, string Telefone, string Email, string Senha) {
            this.ID = ID;
            this.CPF = CPF;
            this.NOME = Nome;
            this.DATA_NASCIMENTO = Data_Nascimento;
            this.TELEFONE = Telefone;
            this.EMAIL = Email;
            this.SENHA = Senha;
        }

    }
}