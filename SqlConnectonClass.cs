using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace MyFirstApi
{
    public class SqlConnectionClass
    {
        public List<AppointmentSlot> data = new List<AppointmentSlot>();
        const string connectionString = @"Server=5Z8RNV2\SQLEXPRESS;Database=patientsdb;Trusted_Connection=true;";
        SqlConnection connection = new SqlConnection(connectionString);
        SqlCommand command;

        public SqlDataReader DbConnection(string sql)
        {

            connection.Open();
            Console.WriteLine("Connected to DB");

            using (command = new SqlCommand(sql, connection))
            {
                return command.ExecuteReader();
            };

            
        }

        public SqlDataAdapter AddToTable(DataHandler data)
        {
            connection = new SqlConnection(connectionString);
            string sql;
            sql = $"UPDATE Patients SET Firstname = '{data.FirstName}', Lastname = '{data.LastName}', Reason = '{data.Reason}', Notes = '{data.Notes}' WHERE Time = '{data.Time}'";
            connection.Open();

            command = new SqlCommand(sql, connection);

            //adapter.InsertCommand = new SqlCommand(sql, connection);
            command.ExecuteNonQuery();

            command.Dispose();
            connection.Close();
            return null;
        }

        public void DatabaseSelection()
        {
           
        }

        public List<AppointmentSlot> Read()
        {

            var reader = DbConnection("Select * from Patients"); //Patients30 Patients45

            data = new List<AppointmentSlot>();
            while (reader.Read())
            {
                data.Add(Read(reader));
            }
            return data;
        }

        public AppointmentSlot Read(SqlDataReader reader)
        {
            return new AppointmentSlot
            {
                PatientID = reader.GetInt32(0),
                Time = reader.GetString(1), // - contains inbuilt function?
                FirstName = reader.GetString(2),
                LastName = reader.GetString(3),
                Reason = reader.GetString(4),
                Notes = reader.GetString(5)
            };
        }
    }
}