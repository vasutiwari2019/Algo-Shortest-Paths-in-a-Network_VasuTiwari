using System.Collections.Generic;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    class Graph
    {
        public List<Vertex> Vertices { get; set; }

        public Graph(List<Vertex> Vertices)
        {
            this.Vertices = Vertices;
        }
    }
}
