using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLaverie.Domaine.Entities
{
    public class Proprietaire
    {
         public int Id { get; set; }
        public string NomProprietaire { get; set; }



        public Proprietaire(int id, string nomProprietaire)
        {
            Id = id;
            NomProprietaire = nomProprietaire;
        }

        public Proprietaire(int id, string nomProprietaire, string v1, string v2, string v3, string v4) : this(id, nomProprietaire)
        {
        }

        public List<Laverie> Laveries { get; set; } = new List<Laverie>();
        public string? Prenom { get; set; }
    }
}
