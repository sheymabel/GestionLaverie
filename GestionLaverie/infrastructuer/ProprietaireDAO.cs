using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Domaine;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;

namespace liveriAPI.infrastructuer
{
    public class ProprietaireDAO : IProprietaireDAO
    {
        private readonly string _connectionString = "Server=localhost;Port=3307;Database=laverie;User=root;Password=;";

        public List<Proprietaire>? GetAllPropriétairesWithDetails()
        {
            var proprietaires = new List<Proprietaire>();

            string query = @"SELECT p.Id AS PropId, p.Nom AS PropName, 
       l.Id AS LaverieId, l.Nom AS LaverieName, l.Adresse AS LaverieAdresse, 
       m.Id AS MachineId, m.Marque, m.Modele, m.LaverieId, 
       c.Id AS CycleId, c.Duree, c.Cout  -- Ajout de la colonne Cout ici
FROM proprietaires p 
LEFT JOIN laveries l ON p.Id = l.ProprietaireId 
LEFT JOIN machines m ON l.Id = m.LaverieId 
LEFT JOIN cycles c ON m.Id = c.MachineId;
";

            try
            {
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
                                proprietaire = new Proprietaire(
                                    propId,
                                    reader.GetString("PropName")
                                );
                                proprietaires.Add(proprietaire);
                            }

                            AddLaverieToProprietaire(proprietaire, reader);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur lors de la récupération des données: {ex.Message}");
                return new List<Proprietaire>();
            }

            return proprietaires;
        }

        private void AddLaverieToProprietaire(Proprietaire proprietaire, MySqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("LaverieId")))
            {
                int laverieId = reader.GetInt32("LaverieId");
                var laverie = proprietaire.Laveries.Find(l => l.Id == laverieId);

                if (laverie == null)
                {
                    laverie = new Laverie(laverieId, reader.GetString("LaverieName"), reader.GetString("LaverieAdresse"));
                    proprietaire.Laveries.Add(laverie);
                }

                AddMachineToLaverie(laverie, reader);
            }
        }

        private void AddMachineToLaverie(Laverie laverie, MySqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("MachineId")))
            {
                int machineId = reader.GetInt32("MachineId");

                var machine = AddOrGetItem(laverie.Machines, machineId, m => m.IdMachine, () =>
                    new Machine(
                        machineId,
                        reader.GetString("Marque"),
                        reader.GetString("Modele")
                    )
                );

                AddCycleToMachine(machine, reader);
            }
        }

        private void AddCycleToMachine(Machine machine, MySqlDataReader reader)
        {
            if (!reader.IsDBNull(reader.GetOrdinal("CycleId")))
            {
                int cycleId = reader.GetInt32("CycleId");
                int duree = reader.GetInt32("Duree");

                if (!reader.IsDBNull(reader.GetOrdinal("Cout")))
                {
                    int cout = reader.GetInt32("Cout");
                    var cycle = new Cycle(cycleId, duree, cout);
                    machine.Cycles.Add(cycle);
                }
                else
                {
                    Console.WriteLine("La colonne 'Cout' est vide dans les résultats.");
                }
            }
        }


        private T AddOrGetItem<T, TKey>(List<T> items, TKey key, Func<T, TKey> keySelector, Func<T> createItem)
        {
            var item = items.FirstOrDefault(i => keySelector(i).Equals(key));

            if (item == null)
            {
                item = createItem();
                items.Add(item);
            }

            return item;
        }
    }
}
