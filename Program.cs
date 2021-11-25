using Algo_Shortest_Paths_in_a_Network_VasuTiwari;
using System;

namespace Algo_Shortest_Paths_in_a_Network
{
    // This project file belongs to Vasu Tiwari
    // Main class from execution begins
    public static class Program
    {
        static void Main(string[] args)
        {
            Operations operations = new Operations();

            Console.WriteLine("Welcome to My Shortest Path Project,please run the command as in the read me file.");

            // Taking input from the use until quit.

            while (true)
            {
                var input = Console.ReadLine();

                string[] inputCase = input.Split(" ");

                try
                {
                    switch (inputCase[0])
                    {
                        // Case 1 used for building the graph from the file given.
                        case "graph":
                            operations.BuildGraph(input); // O(V*E)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 2 used for adding an adge to the graph.
                        case "addedge":
                            operations.AddAnEdge(inputCase[1], inputCase[2], float.Parse(inputCase[3])); // O(V+E)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 3 used to delete an existing edge from the graph.
                        case "deleteedge":
                            operations.DeleteAnEdge(inputCase[1], inputCase[2]); // O(V+E)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 4 used to make an edge down.
                        case "edgedown":
                            operations.EdgeDown(inputCase[1], inputCase[2]); // O(V+E)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 5 used to make the edge up if it is down.
                        case "edgeup":
                            operations.EdgeUp(inputCase[1], inputCase[2]); // O(V+E)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 6 used to make the vertex down.
                        case "vertexdown":
                            operations.VertexDown(inputCase[1]); // O(V)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 7 used to make the vertex up.
                        case "vertexup":
                            operations.VertexUp(inputCase[1]); // O(V)
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            break;

                        // Case 8 used to print the current configuration of the graph.
                        case "print":
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            operations.Print(); // O(V*E)
                            break;

                        // Case 9 used to print all the reachable vertices.
                        case "reachable": // O(VlogV + V*(V+E))
                            operations.Sort_Vertex(); // O(VlogV)
                            operations.Reachable(); // O(V*(V+E))
                            break;

                        // Case 10 used to print the path from source vertex to destination vertex.
                        case "path":
                            operations.Sort_Vertex_Edges(); // O(V*ElogE + VlogV)
                            operations.Path(inputCase[1], inputCase[2]);
                            break;

                        // Case 11 used to exit from the program.
                        case "quit":
                            Environment.Exit(0);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Input not in correct order" +ex);
                }
            }
        }
    }
}
