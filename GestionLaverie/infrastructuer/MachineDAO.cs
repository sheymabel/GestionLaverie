using System.Collections.Generic;
using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Domaine;
using MySql.Data.MySqlClient;

namespace liveriAPI.infrastructure
{
    public class MachineDAO : IMachineDAO
    {
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=laverie;User=root;Password=;";

        public List<Machine> GetMachinesByLaverieId(int laverieId)
        {
            var machines = new List<Machine>();
            string query = "SELECT Id, Marque, Modele, EstUsine FROM machines WHERE LaverieId = @LaverieId";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@LaverieId", laverieId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            machines.Add(new Machine(
                                reader.GetInt32("Id"),
                                reader.GetString("Marque"),
                                reader.GetString("Modele"),
                                reader.GetBoolean("EstUsine")
                            ));
                        }
                    }
                }
            }

            return machines;
        }

        public List<Machine> GetAllMachinesWithDetails()
        {
            var machines = new List<Machine>();
            string query = "SELECT * FROM machines";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            machines.Add(new Machine(
                                reader.GetInt32("Id"),
                                reader.GetString("Marque"),
                                reader.GetString("Modele"),
                                reader.GetBoolean("EstUsine")
                            ));
                        }
                    }
                }
            }

            return machines;
        }

        public int AddMachine(Machine machine)
        {
            string query = "INSERT INTO machines (Marque, Modele, EstUsine, LaverieId) VALUES (@Marque, @Modele, @EstUsine, @LaverieId)";
            int newMachineId;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Marque", machine.Marque);
                    cmd.Parameters.AddWithValue("@Modele", machine.Modele);
                    

                    cmd.ExecuteNonQuery();
                    newMachineId = (int)cmd.LastInsertedId;
                }
            }

            return newMachineId;
        }

        public bool DeleteMachine(int machineId)
        {
            string query = "DELETE FROM machines WHERE Id = @Id";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", machineId);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public bool UpdateMachine(Machine machine)
        {
            string query = "UPDATE machines SET Marque = @Marque, Modele = @Modele, EstUsine = @EstUsine WHERE Id = @Id";
            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Marque", machine.Marque);
                    cmd.Parameters.AddWithValue("@Modele", machine.Modele);
                  

                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
            }
        }

        public Machine? GetMachineById(int machineId)
        {
            string query = "SELECT * FROM machines WHERE Id = @Id";
            Machine? machine = null;

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", machineId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            machine = new Machine(
                                reader.GetInt32("Id"),
                                reader.GetString("Marque"),
                                reader.GetString("Modele"),
                                reader.GetBoolean("EstUsine")
                            );
                        }
                    }
                }
            }


            return machine;
        }
    }
}
