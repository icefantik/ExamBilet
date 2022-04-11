using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamBilet
{
    class Database
    {
        private SqlConnection sqlConnection = new SqlConnection(@"Data Source=DESKTOP-PNAU4VT;Initial Catalog=PrepExam;Integrated Security=true");
        public void openConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Closed)
            {
                sqlConnection.Open();
            }
        }
        public void closeConnection()
        {
            if (sqlConnection.State == System.Data.ConnectionState.Open)
            {
                sqlConnection.Close();
            }
        }
        public SqlConnection getConnection()
        {
            return sqlConnection;
        }
        public static DataTable RunQuery()
        {
            Database database = new Database();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
            DataTable dataTable = new DataTable();
            SqlCommand command = new SqlCommand("SELECT * FROM UserViewStudent", database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
    }
}
