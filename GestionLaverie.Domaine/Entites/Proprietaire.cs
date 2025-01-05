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
        public List<Laverie> Laveries { get; set; } = new List<Laverie>();



    }
}
