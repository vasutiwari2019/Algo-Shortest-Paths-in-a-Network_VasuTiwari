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
                foreach (var item in g?.Vertices)
                {
                    if (item?.VertexStatus == "UP")
                    {
                        Console.WriteLine(item?.VertexName);
                    }

                    else if (item?.VertexStatus == "DOWN")
                    {
                        Console.WriteLine(item?.VertexName + " " + item?.VertexStatus);
                    }

                    foreach (var edges in item?.Edges)
                    {
                        if (edges?.Weight != -1 && edges?.EdgeStatus == "UP")
                            Console.WriteLine("  " + edges?.To_Vertex + " " + edges?.Weight);
                        else if (edges?.Weight != -1 && edges?.EdgeStatus == "DOWN")
                            Console.WriteLine("  " + edges?.To_Vertex + " " + edges?.Weight + " " + edges?.EdgeStatus);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Graph not build properly for PrintGraph" + ex);
                Environment.Exit(0);
            }
        }
    }
}
