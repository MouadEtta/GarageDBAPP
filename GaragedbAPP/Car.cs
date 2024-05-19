using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Common.EntitySql;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GaragedbAPP
{
    public class Car
    {
        public string Targa { get; set; }
        public string Marca { get; set; }

        public string Tipo { get; set; }

        public string dataDiImmatricolazione { get; set; }

        public List<Car> getAll()
        {
            List<Car> cars = new List<Car>();
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=LAPTOP-2MF9GFD7;Initial Catalog=garage;Integrated Security=True;";
            cnn = new SqlConnection(connetionString);
            cnn.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            String sql, Output = "";
            sql = "Select targa,marca,tipo,data_di_immatricolazione from Automobili";
            command = new SqlCommand(sql, cnn);
            dataReader = command.ExecuteReader();
            while (dataReader.Read())
            {
                cars.Add(new Car()
                {
                    Targa = dataReader.GetValue(0).ToString(),
                    Marca = dataReader.GetValue(1).ToString(),
                    Tipo = dataReader.GetValue(2).ToString(),
                    dataDiImmatricolazione= dataReader.GetValue(3).ToString()
                });

            }
            dataReader.Close();
            command.Dispose();
            return cars;
        }
    }
}
