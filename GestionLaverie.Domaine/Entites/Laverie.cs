using System;
namespace GestionLaverie.Domaine.Entities
{
    
        public class Laverie
        {
            public int Id { get; set; }
            public string Nom { get; set; } = string.Empty;
            public string Adresse { get; set; } = string.Empty;
        public List<Machine> Machines { get; set; } = new List<Machine>();
        public Machine Machine { get; set; }

        public Laverie() { }

            public Laverie(int id, string nom, string adresse)
            {
                Id = id;
                Nom = nom;
                Adresse = adresse;
            }
        }

}
