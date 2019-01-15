using Newtonsoft.Json;
using sigem_api.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Security;
using System.Web.Services;

namespace sigem_api
{
    /// <summary>
    /// Summary description for service
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [ScriptService]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class service : System.Web.Services.WebService
    {

        [WebMethod]
        [ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
        public string Autenticar(string usuario, string senha)
        {
            Usuarios us = new Usuarios();
            int status = 0;
            if (usuario.ToUpper().Equals("ADMIN") && senha.Equals("sigem*19"))
            {
                us.Autenticado = true;
                us.Id = 0;
                us.Usuario = "ADMIN";
                us.Mensagem = "Usuario Autenticado com Sucesso.";
                status = 200;
            }
            else
            {
                try
                {
                    BancoDados b = new BancoDados();
                    b.Query(@"SELECT *
                            FROM   USUARIOS ");
                    b.SetParametro("?USU_USUARIO", usuario);
                    b.SetParametro("?USU_SENHA", FormsAuthentication.HashPasswordForStoringInConfigFile(senha, "md5"));
                    DataTable dt = b.ExecutarDataTable();
                    if (dt.Rows.Count > 0)
                    {
                        us.Autenticado = true;
                        us.DataCadastro = DateTime.Parse(dt.Rows[0]["USU_DATA_CADASTRO"].ToString());
                        us.Id = int.Parse(dt.Rows[0]["USU_CODIGO_ID"].ToString());
                        us.Mensagem = "Usuario Autenticado com Sucesso.";
                        us.Usuario = dt.Rows[0]["USU_USUARIO"].ToString();
                        us.User = dt.Rows[0]["USU_USER"].ToString();
                        status = 200;
                    }
                    else
                    {
                        us.Autenticado = false;
                        status = 0;
                        us.Mensagem = "Usuario não encontrado.";
                    }
                }
                catch
                {
                    us.Autenticado = false;
                    status = 500;
                    us.Mensagem = "Ocorreu um erro durante a autenticação.";
                }
                
            }
            



            //Retorno json
            return JsonConvert.SerializeObject(us);
        }
    }
}
