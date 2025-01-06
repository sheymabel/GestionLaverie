using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLaverie.Domaine.Entities
{
    public class Cycle
    {
        public int Id { get; set; }
        public string Nom { get; set; } = string.Empty;
        public int Cout { get; set; }
        public int Duree { get; set; }  
        public Cycle(int cycleId) { }

        public Cycle(int id, string nom, int cout)
        {
            Id = id;
            Nom = nom;
            Cout = cout;
        }

        public Cycle(int id, string nom, int cout, int duree) : this(id, nom, cout)
        {
            id = Id;
            Duree = duree;  
        }

        public Cycle(int cycleId, int duree, int cout) : this(cycleId)
        {
        }
    }
}

