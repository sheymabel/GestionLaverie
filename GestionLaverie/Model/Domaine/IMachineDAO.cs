using System.Collections.Generic;
using GestionLaverie.Domaine.Entities;

namespace liveriAPI.Model.Domaine
{
   
    public interface IMachineDAO
    {
        List<Machine> GetAllMachinesWithDetails();

        
        int AddMachine(Machine machine);

        bool DeleteMachine(int machineId);
        bool UpdateMachine(Machine machine);

        Machine? GetMachineById(int machineId);

        List<Machine> GetMachinesByLaverieId(int id);
    }
}
