using GestionLaverie.Domaine.Entities;

namespace liveriAPI.Model.Domaine
{
    public interface ICycleDAO
    {
        List<Cycle> GetCyclesByMachineId(int machineId);
    }
}
