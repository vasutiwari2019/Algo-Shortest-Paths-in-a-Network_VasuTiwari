using System.Collections.Generic;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Vertex
    {
        public string VertexName { get; set; }

        public LinkedList<Edge> Edges { get; set; }

        public Vertex(string VertexName, LinkedList<Edge> Edges)
        {
            this.VertexName = VertexName;
            this.Edges = Edges;
        }
    }
}
