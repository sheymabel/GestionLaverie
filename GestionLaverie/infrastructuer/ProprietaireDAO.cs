using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Domaine;
using MySql.Data.MySqlClient;

namespace liveriAPI.infrastructuer
{
    public class ProprietaireDAO : IProprietaireDAO
    {
        private readonly string _connectionString = "Server=localhost;Port=3307;Database=laverie;User=root;Password=;";

        public List<Proprietaire>? GetAllPropriétairesWithDetails()
        {
            var proprietaires = new List<Proprietaire>();

            string query = "SELECT p.Id AS PropId, p.Nom AS PropName, " +
               "l.Id AS LaverieId, l.Nom AS LaverieName, l.Adresse, " +
               "m.Id AS MachineId, m.Marque, m.Modele, m.EstUsine, " +
               "c.Id AS CycleId, c.Duree FROM proprietaires p " +
               "LEFT JOIN laveries l ON p.Id = l.ProprietaireId " +
               "LEFT JOIN machines m ON l.Id = m.LaverieId " +
               "LEFT JOIN cycles c ON m.Id = c.MachineId";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int propId = reader.GetInt32("PropId");
                        var proprietaire = proprietaires.Find(p => p.Id == propId);

                        if (proprietaire == null)
                        {
                            proprietaire = new Proprietaire(propId, reader.GetString("PropName"));
                            proprietaires.Add(proprietaire);
                        }

                        if (!reader.IsDBNull(reader.GetOrdinal("LaverieId")))
                        {
                            int laverieId = reader.GetInt32("LaverieId");
                            var laverie = proprietaire.Laveries.Find(l => l.Id == laverieId);

                            if (laverie == null)
                            {
                                laverie = new Laverie(laverieId, reader.GetString("LaverieName"), reader.GetString("Adresse"));
                                proprietaire.Laveries.Add(laverie);
                            }

                            if (!reader.IsDBNull(reader.GetOrdinal("MachineId")))
                            {
                                int machineId = reader.GetInt32("MachineId");
                                var machine = laverie.Machines.Find(m => m.IdMachine == machineId);

                                if (machine == null)
                                {
                                    string marque = reader.IsDBNull(reader.GetOrdinal("Marque")) ? string.Empty : reader.GetString("Marque");
                                    string modele = reader.IsDBNull(reader.GetOrdinal("Modele")) ? string.Empty : reader.GetString("Modele");
                                    bool estUsine = reader.IsDBNull(reader.GetOrdinal("EstUsine")) ? false : reader.GetBoolean("EstUsine");

                                    machine = new Machine(machineId, marque, modele, estUsine);
                                    laverie.Machines.Add(machine);
                                }

                                if (!reader.IsDBNull(reader.GetOrdinal("CycleId")))
                                {
                                    var cycle = new Cycle(reader.GetInt32("CycleId"), "undefined", reader.GetInt32("Cout"), reader.GetInt32("Duree"));
                                    machine.Cycles.Add(cycle);
                                }
                            }
                        }
                    }
                }
            }

            return proprietaires;
        }
    }
}
