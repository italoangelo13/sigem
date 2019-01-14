using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sigem_api.Modelos
{
    public class Usuarios
    {
        private int id;
        private string usuario;
        private string senha;
        private DateTime dataCadastro;
        private string user;
        private bool autenticado;
        private string mensagem;
        public int Id { get => id; set => id = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Senha { get => senha; set => senha = value; }
        public DateTime DataCadastro { get => dataCadastro; set => dataCadastro = value; }
        public string User { get => user; set => user = value; }
        public bool Autenticado { get => autenticado; set => autenticado = value; }
        public string Mensagem { get => mensagem; set => mensagem = value; }
    }
}