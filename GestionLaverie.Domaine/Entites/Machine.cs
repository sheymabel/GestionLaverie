namespace GestionLaverie.Domaine.Entities
{
    public class Machine
    {
        public int IdMachine { get; set; }  
        public string Marque { get; set; }
        public string Modele { get; set; }
        public bool EstUsine { get; set; }

        public List<Cycle> Cycles { get; set; } = new List<Cycle>();
        public int MachineId { get; }
        public string V1 { get; }
        public string V2 { get; }

        public Machine(int idMachine, string marque, string modele, bool estUsine)
        {
            IdMachine = idMachine;
            Marque = marque;
            Modele = modele;
            EstUsine = estUsine;
        }

        public Machine(int machineId, string v1, string v2, int v3)
        {
        }

        public Machine(int machineId, string v1, string v2)
        {
            MachineId = machineId;
            V1 = v1;
            V2 = v2;
        }
    }
}
