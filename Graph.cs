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
                    if (item.VertexUp)
                    {
                        Console.WriteLine(item.VertexName);
                        foreach (var edges in item.Edges)
                        {
                            if (edges.Weight != -1 && edges.edgeUp)
                                Console.WriteLine(" " + edges.To_Vertex + " " + edges.Weight);
                        }
                    }
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
