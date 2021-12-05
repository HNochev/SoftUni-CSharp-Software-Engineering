using _07.MilitaryElite.Contracts;
using _07.MilitaryElite.Enums;
using _07.MilitaryElite.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;

namespace _07.MilitaryElite
{
    public class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, ISoldier> soldiersById = new Dictionary<string, ISoldier>();

            while (true)
            {
                string[] input = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (input[0] == "End")
                {
                    break;
                }

                string type = input[0];

                string id = input[1];
                string firstName = input[2];
                string lastName = input[3];

                if (type == nameof(Private))
                {
                    decimal salary = decimal.Parse(input[4]);

                    soldiersById.Add(id, new Private(id, firstName, lastName, salary));
                }
                else if (type == nameof(LieutenantGeneral))
                {
                    decimal salary = decimal.Parse(input[4]);

                    ILieutenantGeneral lieutenantGeneral = new LieutenantGeneral(id, firstName, lastName, salary);

                    for (int i = 5; i < input.Length; i++)
                    {
                        string privateId = input[i];

                        if (!soldiersById.ContainsKey(privateId))
                        {
                            continue;
                        }

                        lieutenantGeneral.AddPrivate((Private)soldiersById[privateId]);
                    }

                    soldiersById[id] = lieutenantGeneral;
                }
                else if (type == nameof(Engineer))
                {
                    decimal salary = decimal.Parse(input[4]);

                    bool isCorpsValid = Enum.TryParse(input[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    IEngineer engineer = new Engineer(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < input.Length; i = i + 2)
                    {
                        string part = input[i];
                        int hoursWorked = int.Parse(input[i + 1]);

                        IRepair repair = new Repair(part, hoursWorked);

                        engineer.AddRepair(repair);
                    }

                    soldiersById[id] = engineer;
                }
                else if (type == nameof(Commando))
                {
                    decimal salary = decimal.Parse(input[4]);

                    bool isCorpsValid = Enum.TryParse(input[5], out Corps corps);

                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICommando commando = new Commando(id, firstName, lastName, salary, corps);

                    for (int i = 6; i < input.Length; i = i + 2)
                    {
                        string codeName = input[i];
                        string state = input[i + 1];

                        bool isMissionStateValid = Enum.TryParse(state, out MissionState missionState);

                        if (!isMissionStateValid)
                        {
                            continue;
                        }

                        IMission mission = new Mission(codeName, missionState);

                        commando.AddMission(mission);
                    }

                    soldiersById[id] = commando;
                }
                else if (type == nameof(Spy))
                {
                    int codeNumber = int.Parse(input[4]);

                    ISpy spy = new Spy(id, firstName, lastName, codeNumber);

                    soldiersById[id] = spy;
                }
            }

            foreach (var soldier in soldiersById)
            {
                Console.WriteLine(soldier.Value);
            }
        }
    }
}
