using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VehicleDetails;

namespace DatabaseReader
{
    public class DbReader
    {
        private string connectionString;
        private SqlConnection? connection;
        private SqlCommand? command;
        private SqlDataReader? dataReader;

        public DbReader(string connectionString= "Server = DESKTOP-38F10AQ; Database = VehicleInfo; Integrated Security = true;")
        {
            this.connectionString = connectionString;
        }
        public void ConnectToDataSource()
        {
            connection = new SqlConnection(connectionString);
            connection?.Open();
        }

        public void Disconnect()
        {
            if (connection == null)
            {
                return;
            }
            connection.Close();
            connection.Dispose();
            connection = null;
        }

        public IEnumerable<Vehicle> GetData()
        {

            List<Vehicle> list = new();
            if (connection == null)
                return list;

            command = new SqlCommand("SELECT Model, Year, NumberDoors, Fuel FROM VehicleInfo", connection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read())
            {

                var currentVehicle = new Vehicle
                {
                    Model = dataReader.GetFieldValue<string>(0),
                    Year = dataReader.GetFieldValue<int>(1),
                    NumberDoors = dataReader.GetFieldValue<int>(2),
                    Fuel = dataReader.GetFieldValue<string>(3)
                };
                list.Add(currentVehicle);
            }


            return list;
        }
    }



}