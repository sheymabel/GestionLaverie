using System;
using System.Collections.Generic;
using System.Threading;
using GestionLaverie.Domaine.Entities;

public class LaverieSimulator
{
    private List<Laverie> _laveries;

    public LaverieSimulator(List<Laverie> laveries)
    {
        _laveries = laveries ?? new List<Laverie>();
    }

    public void SimulateCycle()
    {
        Console.WriteLine("********** DÉBUT DE LA SIMULATION DE LAVERIES **********\n");

        foreach (var laverie in _laveries)
        {
            Console.WriteLine($"--- Laverie : {laverie.Nom} ---\n");

            foreach (var machine in laverie.Machines)
            {
                Console.WriteLine($"    Machine ID: {machine.IdMachine}");
                Console.WriteLine($"    Marque: {machine.Marque}");
                Console.WriteLine($"    Modèle: {machine.Modele}");
                Console.WriteLine($"    Type : {(machine.EstUsine ? "Industrielle" : "Résidentielle")}");

                if (machine.Cycles.Count == 0)
                {
                    Console.WriteLine("    Avertissement : Cette machine ne contient aucun cycle !");
                    continue;
                }

                foreach (var cycle in machine.Cycles) // Vérifiez que "Cycles" est défini dans votre classe `Machine`
                {
                    Console.WriteLine($"\n    Démarrage du cycle : {cycle.Nom} (ID: {cycle.Id})");
                    Console.WriteLine($"        Durée : {cycle.Duree} minutes");
                    Console.WriteLine($"        Coût : {cycle.Cout} unités");
                    SimulateDelay(cycle.Duree);
                    Console.WriteLine($"        Cycle terminé : {cycle.Nom} (ID: {cycle.Id})\n");
                }
            }

            Console.WriteLine($"--- Fin de la laverie : {laverie.Nom} ---\n");
        }

        Console.WriteLine("********** FIN DE LA SIMULATION **********");
    }

    private void SimulateDelay(int duree)
    {
        Console.WriteLine($"    [Simulation] Attendez {duree} minutes...");
        Thread.Sleep(duree * 1000);
    }
}