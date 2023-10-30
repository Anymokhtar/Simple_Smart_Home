using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace Smart_Home
{
    class EquipementService : Idao<Equipement>
    {
        public String parametres = "SERVER=127.0.0.1; DATABASE=smart_home; UID=root; PASSWORD=";
        public void create(Equipement o)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"insert into equipement values (null, @nom,@status,@etat,@zone);";
                command.Parameters.AddWithValue("@nom", o.getnom());
                command.Parameters.AddWithValue("@status", o.getstatus());
                command.Parameters.AddWithValue("@etat", o.getetat());
                command.Parameters.AddWithValue("@zone", o.getidzone());

                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("create: error!");
            }
        }

        public void delete(String nom)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"delete from equipement where nom = @nom;";
                command.Parameters.AddWithValue("@nom", nom);
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("delete: error!");
            }
        }

        public List<Equipement> findAll()
        {
            List<Equipement> equipement = new List<Equipement>();
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select idEquip, nom,status, etat,zone from equipement ;";
                command.ExecuteNonQuery();
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        equipement.Add(new Equipement(reader["nom"].ToString(), reader["status"].ToString(), reader["etat"].ToString(), int.Parse(reader["zone"].ToString())));

                    }
                }
                connection.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("findAll: error!");
            }
            return equipement;
        }

        public Equipement FindbyId(int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"select * from equipement where idEquip = @id;";
                command.Parameters.AddWithValue("@id", id);
                command.ExecuteNonQuery();
                MySqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        return new Equipement(reader["nom"].ToString(), reader["status"].ToString(), reader["etat"].ToString(), int.Parse(reader["zone"].ToString()));
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



        public void update(Equipement o, int id)
        {
            try
            {
                MySqlConnection connection = new MySqlConnection(parametres);
                connection.Open();
                var command = connection.CreateCommand();
                command.CommandText = @"update equipement set nom = @nom, set status = @status, set etat=@etat , set zone=@zone where idZone = @id ;";
                command.Parameters.AddWithValue("@nom", o.getnom());
                command.Parameters.AddWithValue("@status", o.getstatus());
                command.Parameters.AddWithValue("@etat", o.getetat());
                command.Parameters.AddWithValue("@zone", o.getidzone());
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
