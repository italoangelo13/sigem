using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace sigem_api.Modelos
{
    public class Usuarios
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }
        private string usuario;

        public string Usuario
        {
            get { return usuario; }
            set { usuario = value; }
        }
        private string senha;

        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }
        private DateTime dataCadastro;

        public DateTime DataCadastro
        {
            get { return dataCadastro; }
            set { dataCadastro = value; }
        }
        private string user;

        public string User
        {
            get { return user; }
            set { user = value; }
        }
        private bool autenticado;

        public bool Autenticado
        {
            get { return autenticado; }
            set { autenticado = value; }
        }
        private string mensagem;

        public string Mensagem
        {
            get { return mensagem; }
            set { mensagem = value; }
        }
    }
}