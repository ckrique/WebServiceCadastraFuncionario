using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace WebServiceCadastraFuncionario.DB
{
    public class DBTransacao : IDisposable
    {
        private DBConexao m_dbConn = null;
        private SqlTransaction m_sqlTr = null;

        //----------------------------------------------------------------------
        public DBTransacao(DBConexao dbConn)
        {
            m_dbConn = dbConn;
            m_dbConn.setDBTransacao(this);
        }

        //----------------------------------------------------------------------
        public SqlTransaction getCurrentTransaction()
        {
            return (m_sqlTr);
        }

        //----------------------------------------------------------------------
        public SqlTransaction getOpenTransaction(SqlConnection conn)
        {
            if (m_sqlTr == null)
                m_sqlTr = conn.BeginTransaction();

            return (m_sqlTr);
        }

        //----------------------------------------------------------------------
        public void Commit()
        {
            if (m_sqlTr != null)
                m_sqlTr.Commit();
        }

        //----------------------------------------------------------------------
        public void Rollback()
        {
            if (m_sqlTr != null)
            {
                try
                {
                    m_sqlTr.Rollback();
                }
                catch
                {
                }
            }
        }

        //----------------------------------------------------------------------
        #region IDisposable Members
        //----------------------------------------------------------------------
        public void Dispose()
        {
            if (m_sqlTr != null)
            {
                try
                {
                    m_sqlTr.Dispose();
                }
                catch
                {
                }
                m_sqlTr = null;
            }
            m_dbConn.setDBTransacao(null);
        }
        #endregion
    }
}