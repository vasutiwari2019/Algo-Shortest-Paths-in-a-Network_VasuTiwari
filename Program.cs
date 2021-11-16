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

            Console.WriteLine("Please select from the below options");
            Console.WriteLine("1. Building the graph");
            Console.WriteLine("2. Add directed edge from headvertex to tailvertex");
            Console.WriteLine("3. Delete the edge from headvertex to tailvertex");
            Console.WriteLine("4. Mark the directed edge as “down” and therefore unavailable for use.");
            Console.WriteLine("5. Mark the directed edge as “up”, and available for use");
            Console.WriteLine("6. Mark the vertex as down");
            Console.WriteLine("7. Mark the vertex as up again");

            try
            {
                var str = Console.ReadLine();

                BuilGraph(str);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in correct order");
            }
        }

        private static void BuilGraph(string str)
        {
            Vertex finalVertex = new Vertex();

            string[] initializeFile = str.Split(" ");

            if (initializeFile[0] == "graph" && initializeFile[1] != ".txt")
            {

                var existingFile = Directory.GetFiles("../../../", "*.txt", SearchOption.TopDirectoryOnly);

                var fileName = initializeFile[1].Split(".");

                File.Move(existingFile[0], "../../../" + fileName[0] + ".txt");

                string[] lines = File.ReadAllLines("../../../" + fileName[0] + ".txt");

                foreach (var item in lines)
                {
                    string[] graph = item.Split(" ");

                    var source_vertex = graph[0];
                    var destination_vertex = graph[1];
                    var edge_weight = float.Parse(graph[2]);

                    Edge edge1 = new Edge(source_vertex, destination_vertex, edge_weight);

                    Edge edge2 = new Edge(destination_vertex, source_vertex, edge_weight);

                    LinkedList<Edge> edges1 = new LinkedList<Edge>();

                    LinkedList<Edge> edges2 = new LinkedList<Edge>();

                    edges1.AddFirst(edge1);

                    edges2.AddFirst(edge2);

                    finalVertex.AddVertex(source_vertex, destination_vertex);

                    finalVertex.AddEdge(edges1, edges2);
                }

                Graph finalGraph = new Graph(finalVertex.adj);

                finalGraph.PrintGraph(finalGraph);
            }

            else
            {
                throw new NotImplementedException();
            }
        }
    }
}
