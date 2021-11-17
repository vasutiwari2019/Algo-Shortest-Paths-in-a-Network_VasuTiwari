using System;
using System.Collections.Generic;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Graph
    {
        public List<Vertex> Vertices { get; set; }

        public Graph(List<Vertex> Vertices)
        {
            this.Vertices = Vertices;
        }

        public void PrintGraph(Graph g)
        {
            try
            {
                foreach (var item in g.Vertices)
                {
                    Console.WriteLine(item.VertexName);

                    foreach (var edges in item.Edges)
                    {
                        Console.WriteLine(edges.To_Vertex + " " + edges.Weight);
                    }

                    Console.WriteLine("\n");
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Graph not build properly" + ex);
                Environment.Exit(0);
            }
        }
    }
}
