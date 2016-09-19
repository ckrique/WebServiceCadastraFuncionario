using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using WebServiceCadastraFuncionario.DB;
using WebServiceCadastraFuncionario.Properties;
using WebServiceCadastraFuncionario.Negocio;

namespace WebServiceCadastraFuncionario
{
    /// <summary>
    /// Summary description for WebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/", Name="CadastroFuncionario")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public string cadastrarFuncionario(String nome, String codigoFunc,
                                                String cpf, String identidade, String passaporte,
                                                    String numOutroDocumento, String descricaoOutroDocumento,
                                                        String perfil, String dataNascimento, String dataAssuncaoCargo,
                                                            String dataAdmissao, String dataDemissao)
        {            
            int idPerfil;
            DateTime dtNascimento, dtAssuncaoCargo, dtAdmissao, dtDemissao;

            try
            {
                if (String.IsNullOrEmpty(nome))
                    throw new Exception(Mensagens.ERR_PARAMETRO);

                if (String.IsNullOrEmpty(codigoFunc))
                    throw new Exception(Mensagens.ERR_PARAMETRO);

                if (String.IsNullOrEmpty(perfil))
                    throw new Exception(Mensagens.ERR_PARAMETRO);
                else 
                    idPerfil = Convert.ToInt32(perfil);


                dtNascimento = Convert.ToDateTime(dataNascimento);
                dtAdmissao = Convert.ToDateTime(dataAdmissao);
                dtAssuncaoCargo = Convert.ToDateTime(dataAssuncaoCargo);

                if (String.IsNullOrEmpty(dataDemissao))
                    dtDemissao = Convert.ToDateTime("01/01/1900");
                else
                    dtDemissao = Convert.ToDateTime(dataDemissao);
                   
                

            }
            catch(Exception ex)
            {
                return Mensagens.ERR_PARAMETRO;
            }
                                    
            try
            {
                using (DBConexao db = new DBConexao())
                {
                    FuncionarioNegocio.cadastrarFuncionarioWebService(db, nome, codigoFunc, cpf, identidade, passaporte,
                                                                        numOutroDocumento, descricaoOutroDocumento, idPerfil,
                                                                            dtNascimento, dtAssuncaoCargo, dtAdmissao, dtDemissao);

                    return Mensagens.SUCESSO_CADASTRADO_FUNCIONARIO;
                }
            }
            catch(Exception ex)
            {
                return (ex.Message);
            }
            
        }
    }
}
