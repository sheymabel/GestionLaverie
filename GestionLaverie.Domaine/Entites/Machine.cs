using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GestionLaverie.Domaine.Entities
{
    public class Machine
    {
        public int IdMachine { get; set; }
        public string Marque { get; set; }
        public string Modele { get; set; }
        public bool EstUsine { get; set; }  // Assurez-vous que EstUsine est de type bool
        public List<Cycle> Cycles { get; set; } = new List<Cycle>();

        // Modifiez le constructeur pour inclure EstUsine comme un booléen
        public Machine(int id, string marque, string modele, bool estUsine)
        {
            IdMachine = id;
            Marque = marque;
            Modele = modele;
            EstUsine = estUsine;
        }
    }
}


