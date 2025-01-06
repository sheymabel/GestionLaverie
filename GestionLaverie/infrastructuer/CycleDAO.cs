using MySql.Data.MySqlClient;
using GestionLaverie.Domaine.Entities;
using System.Collections.Generic;
using liveriAPI.Model.Domaine;

namespace liveriAPI.infrastructuer
{
    public class CycleDAO : ICycleDAO
    {
        private readonly string _connectionString = "Server=localhost;Port=3307;Database=laverie;User=root;Password=;";

        public List<Cycle> GetCyclesByMachineId(int machineId)
        {
            var cycles = new List<Cycle>();

            string query = "SELECT Id, Nom, Cout, Duree FROM cycles WHERE MachineId = @MachineId";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@MachineId", machineId);

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var cycle = new Cycle(
                                reader.GetInt32("Id"),
                                reader.GetString("Nom"),
                                reader.GetInt32("Cout"),
                                reader.GetInt32("Duree")
                            );
                            cycles.Add(cycle);
                        }
                    }
                }
            }

            return cycles;
        }
    }

}
