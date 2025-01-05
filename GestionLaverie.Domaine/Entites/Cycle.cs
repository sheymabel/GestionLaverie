using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionLaverie.Domaine.Entities
{
    public class Cycle
    {

        public int IdCycle { get; set; }
        public string CycleType { get; set; }
        public int Cout { get; set; }
        public int Duree { get; set; }

        public Cycle(int idCycle, string cycleType, int cout, int duree)
        {
            IdCycle = idCycle;
            CycleType = cycleType;
            Cout = cout;
            Duree = duree;
        }
        public int IdMachine { get; set; }
        public Machine Machine { get; set; }

    }
}
