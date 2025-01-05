using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLaverie.Domaine.Entities
{
    public class Laverie
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public string Adress { get; set; }

        public Laverie(int id, string nom , string adress)
        {
            Id = id;
            Nom = nom;
            Adress = adress;
        }
        public List<Machine> Machines { get; set; } = new List<Machine>();

    }
}
