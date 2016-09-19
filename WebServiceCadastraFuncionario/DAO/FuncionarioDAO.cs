using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using WebServiceCadastraFuncionario.DB;
using WebServiceCadastraFuncionario.Properties;

namespace WebServiceCadastraFuncionario.DAO
{
    public class FuncionarioDAO : DAOPadrao
    {
        public static void cadastrarFuncionarioWebService(DBConexao db, String nome, String codigoFunc,
                                                            String cpf, String identidade, String passaporte,
                                                                String numOutroDocumento, String descricaoOutroDocumento,
                                                                    int idPerfil, DateTime dataNascimento, DateTime dataAssuncaoCargo, 
                                                                        DateTime dataAdmissao, DateTime dataDemissao)
        {
            
            using (SqlCommand comando = new SqlCommand(SQL.PROCEDURE_CADASTRA_FUNCIPROCEDURE_CADASTRA_FUNCIONARIO, db.getConexao()))
            {
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.AddWithValue("@nomePessoa", nome);
                comando.Parameters.AddWithValue("@dataNascimento", dataNascimento);
                comando.Parameters.AddWithValue("@idPerfil", idPerfil);
                comando.Parameters.AddWithValue("@dataAssuncaoCargo", dataAssuncaoCargo);
                comando.Parameters.AddWithValue("@codigoFuncionario", codigoFunc);
                comando.Parameters.AddWithValue("@dataAdmissao", dataAdmissao);
                comando.Parameters.AddWithValue("@dataDemissao", dataDemissao);
                comando.Parameters.AddWithValue("@cpf", cpf);
                comando.Parameters.AddWithValue("@identidade", identidade);
                comando.Parameters.AddWithValue("@passaporte", passaporte);
                comando.Parameters.AddWithValue("@descricaoOutroDocumento", descricaoOutroDocumento);
                comando.Parameters.AddWithValue("@numeroOutroDocumento", numOutroDocumento);
                
                using (SqlDataAdapter da = new SqlDataAdapter())
                {
                    da.SelectCommand = comando;

                    DataSet ds = new DataSet();
                    da.Fill(ds, "result_table");

                    DataTable dtResultado = ds.Tables["result_table"];

                    if (dtResultado != null && dtResultado.Rows.Count > 0 &&
                            dtResultado.Rows[0]["resultado"] != DBNull.Value &&
                                Convert.ToInt32(dtResultado.Rows[0]["resultado"]) == 1)
                        return;

                    throw new Exception(Mensagens.ERR_CADASTRAR_FUNCIONARIO);
                }
            }
        }
    }
}