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
        private SqlConnection sqlConnection = new SqlConnection("data source = 10.10.14.40; initial catalog = Mityushin_P1_18; persist security info=True;user id = p1_18_12; password=Abcd1234;MultipleActiveResultSets=True;App=EntityFramework");
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
            SqlCommand command = new SqlCommand("SELECT * FROM test2", database.getConnection());
            sqlDataAdapter.SelectCommand = command;
            sqlDataAdapter.Fill(dataTable);
            return dataTable;
        }
        public static List<Elem> GetListElem()
        {
            DataTable dataTable = RunQuery();
            List<Elem> elems = new List<Elem>();
            Elem elem;
            for (int i = 0; i < dataTable.Rows.Count; ++i)
            {
                elem = new Elem();
                elem.id = int.Parse(dataTable.Rows[i][0].ToString());
                elem.name = dataTable.Rows[i][1].ToString();
                elems.Add(elem);
            }
            return elems;
        }
    }
}
