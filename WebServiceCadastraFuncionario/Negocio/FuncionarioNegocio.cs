using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebServiceCadastraFuncionario.DAO;
using WebServiceCadastraFuncionario.DB;

namespace WebServiceCadastraFuncionario.Negocio
{
    public class FuncionarioNegocio
    {
        public static void cadastrarFuncionarioWebService(DBConexao db, String nome, String codigoFunc,
                                                            String cpf, String identidade, String passaporte,
                                                                String numOutroDocumento, String descricaoOutroDocumento,
                                                                    int idPerfil, DateTime dataNascimento, DateTime dataAssuncaoCargo, 
                                                                        DateTime dataAdmissao, DateTime dataDemissao)
        {
            FuncionarioDAO.cadastrarFuncionarioWebService(db, nome, codigoFunc, cpf, identidade, passaporte,
                                                                numOutroDocumento, descricaoOutroDocumento, idPerfil,
                                                                    dataNascimento, dataAssuncaoCargo, dataAdmissao, dataDemissao);
        }
    }
}