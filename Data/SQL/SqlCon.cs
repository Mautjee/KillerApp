using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace KillerApp.Data.SQL
{
    public class SqlCon
    {
        private string _sql_server = "maurosqlserver.database.windows.net,1433";
        private string _sql_user = "mauro@maurosqlserver";
        private string _sql_pass = "Geheim123";
        private string _sql_DB = "mauro_sql";
        public string connectionstring()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = _sql_server;
            builder.UserID = _sql_user;
            builder.Password = _sql_pass;
            builder.InitialCatalog = _sql_DB;
            return builder.ConnectionString;
        }

    }
}
