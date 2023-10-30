using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Smart_Home
{
    class ZoneService : Idao<Zone>
    {
        public String parametres = "SERVER=127.0.0.1; DATABASE=smart_home; UID=root; PASSWORD=";
        public void create(Zone o)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"insert into zone values (null, @nom);";
                command.Parameters.AddWithValue("@nom", o.getnom());

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("create: error!");
            }
        }

        public void delete(string nom)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"delete from zone where nom = @nom;";
                command.Parameters.AddWithValue("@nom", nom);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("delete: error!");
            }
        }



        public List<Zone> findAll()
        {

            List<Zone> zones = new List<Zone>();
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select idZone, nom from zone ;";
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        zones.Add(new Zone(reader["nom"].ToString()));
                        string test = reader["id"].ToString();
                    }
                }
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("findAll: error!");
            }
            return zones;
        }


        public Zone FindbyId(int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select * from zone where idZone = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new Zone(reader["nom"].ToString());
                    }
                }
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("findbyId: error!");
            }
            return null;
        }

        public void update(Zone o, int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"update zone set nom = @nom where idZone = @id ;";
                command.Parameters.AddWithValue("@nom", o.getnom());
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("update: error!");
            }
        }
    }
}
