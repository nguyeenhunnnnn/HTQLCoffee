using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HTQLCoffee.Model
{
    public class DouongModel
    {
        public int PK_iDouongID { get; set; }
        public string sTenDouong { get; set; }
    }
    public class DoUongDAO
    {
        private readonly string _connectionString;

        public DoUongDAO(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<DouongModel> GetDouongs()
        {
            List<DouongModel> douongs = new List<DouongModel>();

            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                string query = "SELECT PK_iDouongID, sTenDouong FROM tblDouong";

                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    DouongModel douong = new DouongModel();
                    douong.PK_iDouongID = reader.GetInt32(0);
                    douong.sTenDouong = reader.GetString(1);

                    douongs.Add(douong);
                }

                reader.Close();
            }

            return douongs;
        }
    }
}
