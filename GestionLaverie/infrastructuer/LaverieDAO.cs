using GestionLaverie.Domaine.Entities;
using liveriAPI.Model.Domaine;
using MySql.Data.MySqlClient;

namespace liveriAPI.infrastructure
{
    public class LaverieDAO : ILaverieDAO
    {
        private readonly string _connectionString = "Server=localhost;Port=3306;Database=laverie;User=root;Password=;";

        public List<Laverie> GetLaveriesByProprietaireId(int proprietaireId)
        {
            var laveries = new List<Laverie>();
            string query = "SELECT Id, Nom, Adresse FROM laveries WHERE ProprietaireId = @ProprietaireId";

            using (MySqlConnection conn = new MySqlConnection(_connectionString))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ProprietaireId", proprietaireId);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            laveries.Add(new Laverie(
                                reader.GetInt32("Id"),
                                reader.GetString("Nom"),
                                reader.GetString("Adresse")
                            ));
                        }
                    }
                }
            }

            return laveries;
        }
    }
}
