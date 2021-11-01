using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;

namespace _03.ThePianist
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> pieces = new Dictionary<string, List<string>>();

            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] piece = Console.ReadLine()
                    .Split("|", StringSplitOptions.RemoveEmptyEntries);

                pieces.Add(piece[0], new List<string>());
                pieces[piece[0]].Add(piece[1]);
                pieces[piece[0]].Add(piece[2]);
            }

            string[] command = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);

            while (command[0] != "Stop")
            {
                switch (command[0])
                {
                    case "Add":
                        {
                            string piece = command[1];
                            string composer = command[2];
                            string key = command[3];

                            if(pieces.ContainsKey(piece))
                            {
                                Console.WriteLine($"{piece} is already in the collection!");
                            }
                            else
                            {
                                Console.WriteLine($"{piece} by {composer} in {key} added to the collection!");
                                pieces.Add(piece, new List<string>());
                                pieces[piece].Add(composer);
                                pieces[piece].Add(key);
                            }
                            break;
                        }
                    case "Remove":
                        {
                            string piece = command[1];

                            if(pieces.ContainsKey(piece))
                            {
                                Console.WriteLine($"Successfully removed {piece}!");
                                pieces.Remove(piece);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                            }
                            break;
                        }
                    case "ChangeKey":
                        {
                            string piece = command[1];
                            string key = command[2];

                            if(pieces.ContainsKey(piece))
                            {
                                Console.WriteLine($"Changed the key of {piece} to {key}!");
                                pieces[piece][1] = key;
                            }
                            else
                            {
                                Console.WriteLine($"Invalid operation! {piece} does not exist in the collection.");
                            }
                            break;
                        }
                    default:
                        break;
                }

                command = Console.ReadLine()
                .Split("|", StringSplitOptions.RemoveEmptyEntries);
            }
            foreach (var item in pieces.OrderBy(x=>x.Key).ThenBy(x=>x.Value[0]))
            {
                Console.WriteLine($"{item.Key} -> Composer: {item.Value[0]}, Key: {item.Value[1]}");
            }
        }
    }
}
