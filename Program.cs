using Algo_Shortest_Paths_in_a_Network_VasuTiwari;
using System;

namespace Algo_Shortest_Paths_in_a_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to My Shortest Path Project,please run the command as in the read me file.");

            Operations operations = new Operations();

            var option = operations.ChooseOption();

            while (option != null)
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
                            string[] inputFor2 = inputCase2.Split(" ");
                            operations.AddAnEdge(inputFor2[1], inputFor2[2], float.Parse(inputFor2[3]));
                            break;

                        case "3":
                            Console.WriteLine("Enter in format,deleteedge tailvertex headvertex");
                            var inputCase3 = Console.ReadLine();
                            string[] inputFor3 = inputCase3.Split(" ");
                            operations.DeleteAnEdge(inputFor3[1], inputFor3[2]);
                            break;

                        case "4":
                            Console.WriteLine("Enter in format,edgedown tailvertex headvertex");
                            var inputCase4 = Console.ReadLine();
                            string[] inputFor4 = inputCase4.Split(" ");
                            operations.EdgeDown(inputFor4[1], inputFor4[2]);
                            break;

                        case "5":
                            Console.WriteLine("Enter in format,edgeup tailvertex headvertex");
                            var inputCase5 = Console.ReadLine();
                            string[] inputFor5 = inputCase5.Split(" ");
                            operations.EdgeUp(inputFor5[1], inputFor5[2]);
                            break;

                        case "6":
                            Console.WriteLine("Enter in format,vertexdown vertex");
                            var inputCase6 = Console.ReadLine();
                            string[] inputFor6 = inputCase6.Split(" ");
                            operations.VertexDown(inputFor6[1]);
                            break;

                        case "7":
                            Console.WriteLine("Enter in format,vertexup vertex");
                            var inputCase7 = Console.ReadLine();
                            string[] inputFor7 = inputCase7.Split(" ");
                            operations.VertexUp(inputFor7[1]);
                            break;

                        case "8":
                            Console.WriteLine("Enter in format, print, Please note before calling print, you should first build the graph");
                            var inputCase8 = Console.ReadLine();
                            if (inputCase8 == "print")
                            {
                                operations.Print();
                            }
                            else
                            {
                                throw new InvalidOperationException("print not entered");
                            }
                            break;

                        case "100":
                            Console.WriteLine("Enter quit to exit");
                            var inputCase100 = Console.ReadLine();
                            if (inputCase100 == "quit")
                            {
                                Console.WriteLine("Thanks for your time, have a good day !!!");
                                Environment.Exit(0);
                            }

                            else
                            {
                                throw new InvalidOperationException("exit not entered");
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
        }
    }
}
