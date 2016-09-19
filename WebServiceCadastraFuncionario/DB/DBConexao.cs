using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Web.Configuration;
using System.Data.SqlClient;

namespace WebServiceCadastraFuncionario.DB
{
    public class DBConexao : IDisposable
    {
        private static ConnectionStringSettings m_getString = null;

        private DBTransacao m_dbTrans = null;
        private SqlConnection m_conexao = null;

        //----------------------------------------------------------------------------------------------------------------
        public SqlConnection getConexao()
        {
            if (m_conexao == null)
            {
                if (m_getString == null)
                    m_getString = WebConfigurationManager.ConnectionStrings["MSSQL"] as ConnectionStringSettings;

                m_conexao = new SqlConnection(m_getString.ConnectionString);
                m_conexao.Open();
            }
            return (m_conexao);
        }

        //----------------------------------------------------------------------------------------------------------------
        public void setDBTransacao(DBTransacao dbTrans)
        {
            m_dbTrans = dbTrans;
        }

        //----------------------------------------------------------------------------------------------------------------
        public SqlTransaction getCurrentTransaction()
        {
            if (m_dbTrans == null)
                return (null);
            else
                return (m_dbTrans.getCurrentTransaction());
        }

        //----------------------------------------------------------------------------------------------------------------
        public SqlTransaction getOpenTransaction()
        {
            if (m_dbTrans == null)
                return (null);
            else
                return (m_dbTrans.getOpenTransaction(m_conexao));
        }

        //----------------------------------------------------------------------------------------------------------------
        public void Dispose()
        {
            if (m_conexao != null)
            {
                m_conexao.Dispose();
                m_conexao = null;
            }
        }
    }
}