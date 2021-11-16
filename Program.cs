using Algo_Shortest_Paths_in_a_Network_VasuTiwari;
using System;
using System.Collections.Generic;
using System.IO;

namespace Algo_Shortest_Paths_in_a_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Shortest Path Project,please run the command as in the read me file.");

            Operations operations = new Operations();

            var option = operations.ChooseOption();

            while (option != "100")
            {
                try
                {
                    switch (option)
                    {
                        case "1":
                            Console.WriteLine("Enter in format, graph <filename>.txt");
                            var inputCase1 = Console.ReadLine();
                            operations.BuildGraph(inputCase1);
                            break;

                        case "2":
                            Console.WriteLine("Enter in format, addedge tailvertex headvertex transmit time");
                            var inputCase2 = Console.ReadLine();
                            string[] input = inputCase2.Split(" ");
                            operations.AddAnEdge(input[1], input[2], float.Parse(input[3]));
                            break;
                        case "8":
                            Console.WriteLine("Enter in format, print");
                            var inputCase8 = Console.ReadLine();
                            if (inputCase8 == "print")
                            {
                                operations.PrintGraph();
                            }
                            else
                            {
                                throw new InvalidOperationException("print not entered");
                            }
                            break;
                    }

                    option = operations.ChooseOption();
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Input not in correct order");
                }
            }

            Console.WriteLine("Thanks for your time, have a good day !!!");
        }
    }
}
