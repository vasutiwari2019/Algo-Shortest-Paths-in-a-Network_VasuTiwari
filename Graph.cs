using System;
using System.Collections.Generic;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    // Graph class to store all the connected vertices and corresponding edges
    public class Graph
    {
        #region Properties

        // Vertices used to store all the vertices for a Graph
        public List<Vertex> Vertices { get; set; }
        #endregion

        #region Constructor
        public Graph(List<Vertex> Vertices)
        {
            this.Vertices = Vertices;
        }
        #endregion

        #region Public Methods

        // PrintGraph method used to print all the vertices and it's corresponding edges.
        public void PrintGraph(Graph g) // O(V*E)                                                 
        {
            try
            {
                foreach (var item in g?.Vertices) // O(V)
                {
                    // Printing only those vertices which are UP.
                    if (item?.VertexStatus == "UP")
                    {
                        Console.WriteLine(item?.VertexName);
                    }

                    // Printing the down vertex along with it's status
                    else if (item?.VertexStatus == "DOWN")
                    {
                        Console.WriteLine(item?.VertexName + " " + item?.VertexStatus);
                    }

                    if (item.Edges.Count != 0)
                    {
                        foreach (var edges in item?.Edges) // O(E)
                        {
                            // Printing edge name and its weight only if it is UP
                            if (edges?.EdgeStatus == "UP")
                                Console.WriteLine("  " + edges?.To_Vertex + " " + edges?.Weight);

                            // Printing edge name it's weight and status, when edge is down.
                            else if (edges?.EdgeStatus == "DOWN")
                                Console.WriteLine("  " + edges?.To_Vertex + " " + edges?.Weight + " " + edges?.EdgeStatus);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Graph not build properly for PrintGraph" + ex);
                Environment.Exit(0);
            }
        }
        #endregion
    }
}
