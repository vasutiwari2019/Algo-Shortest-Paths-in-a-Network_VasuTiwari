using Algo_Shortest_Paths_in_a_Network_VasuTiwari;
using System;

namespace Algo_Shortest_Paths_in_a_Network
{
    class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();

            Console.WriteLine("Welcome to My Shortest Path Project,please run the command as in the read me file.");

            while (true)
            {
                var input = Console.ReadLine();

                string[] inputCase = input.Split(" ");

                try
                {
                    switch (inputCase[0])
                    {
                        case "graph":
                            operations.BuildGraph(input);
                            operations.Sort_Vertex_Edges();
                            break;

                        case "addedge":
                            operations.AddAnEdgeNew(inputCase[1], inputCase[2], float.Parse(inputCase[3]));
                            operations.Sort_Vertex_Edges();
                            break;

                        case "deleteedge":
                            operations.DeleteAnEdge(inputCase[1], inputCase[2]);
                            operations.Sort_Vertex_Edges();
                            break;

                        case "edgedown":
                            operations.EdgeDown(inputCase[1], inputCase[2]);
                            operations.Sort_Vertex_Edges();
                            break;

                        case "edgeup":
                            operations.EdgeUp(inputCase[1], inputCase[2]);
                            operations.Sort_Vertex_Edges();
                            break;

                        case "vertexdown":
                            operations.VertexDown(inputCase[1]);
                            operations.Sort_Vertex_Edges();
                            break;

                        case "vertexup":
                            operations.VertexUp(inputCase[1]);
                            operations.Sort_Vertex_Edges();
                            break;

                        case "print":
                            operations.Sort_Vertex_Edges();
                            operations.Print();
                            break;

                        case "reachable":
                            operations.Sort_Vertex_Edges();
                            operations.Reachable();
                            break;

                        case "path":
                            operations.Sort_Vertex_Edges();
                            operations.Path(inputCase[1], inputCase[2]);
                            break;

                        case "quit":
                            Environment.Exit(0);
                            break;
                    }
                }

                catch (Exception ex)
                {
                    Console.WriteLine("Input not in correct order");
                }
            }
        }
    }
}
