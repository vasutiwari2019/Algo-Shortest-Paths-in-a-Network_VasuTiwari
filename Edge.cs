using System;
using System.Diagnostics.CodeAnalysis;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    // This project file belongs to Vasu Tiwari
    // Edge Class to store the Edge variables for a particular vertex.
    public class Edge : IComparable<Edge>
    {
        #region Properties

        // From_Vertex used to store the tail vertex
        public string From_Vertex { get; set; }

        // To_Vertex used to store the headvertex
        public string To_Vertex { get; set; }

        // Weight used to store the edge weight from tailvertex to headvertex
        public float Weight { get; set; }

        // EdgeStatus used to keep track whethere edge is visted. Used when computing Reachability
        public string EdgeStatus { get; set; }

        // EdgeExplored used to keep track whether edge is explored or not. Used when computing shortest distance using Dijikstras's
        public bool EdgeExplored { get; set; }

        #endregion

        #region Constructor
        public Edge(string From_Vertex, string To_Vertex, float Weight, string EdgeStatus)
        {
            this.From_Vertex = From_Vertex;
            this.To_Vertex = To_Vertex;
            this.Weight = Weight;
            this.EdgeStatus = EdgeStatus;
            EdgeExplored = false;
        }
        #endregion

        // CompareTo Function from IComparable class. Used when we need to sort the edges alphabetically
        public int CompareTo([AllowNull] Edge other)
        {
            return To_Vertex.CompareTo(other.To_Vertex);
        }
    }
}
