using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    // Vertex Class to store a given vertex.
    public class Vertex : IComparable<Vertex>
    {
        #region Properties

        // VertexName to store the name of a given vertex
        public string VertexName { get; set; }

        // Parent_Vertex to store the Parent Vertex of a given vertex. Used when computing shortest path using Dijikstra's
        public Vertex Parent_Vertex { get; set; }

        // List of Edges for a given vertex.
        public List<Edge> Edges { get; set; }

        // Adj list of vertices for a given vertex
        public List<Vertex> adj;

        // VertexStatus to store the status of a vertex. Vertex can be UP or DOWN.
        public string VertexStatus { get; set; }

        // Visited to check whether a given vertex is visited or not. Used when computing reachability.
        public bool Visited { get; set; }

        // VertexExplored to check whether a given vertex is explored or not. Used when computing the shortest distance using Dijikstra's.
        public bool VertexExplored { get; set; }
        #endregion

        #region Constructor
        public Vertex()
        {
            VertexName = "";
            Edges = new List<Edge>();
            adj = new List<Vertex>();
            VertexStatus = "UP";
            Visited = false;
            VertexExplored = false;
        }

        public Vertex(string VertexName, List<Edge> Edges, string VertexStatus, bool Visited)
        {
            this.VertexName = VertexName;
            this.Edges = Edges;
            adj = new List<Vertex>();
            this.VertexStatus = VertexStatus;
            this.Visited = Visited;
            VertexExplored = false;
        }
        #endregion

        #region Public Methods

        // AddEdge to add new edge from a given vertex to a given vertex.
        public void AddEdge(Edge e1, Edge e2) // O(V)
        {
            // To add an edge from e1 -> e2
            if (adj.Any(x => x?.VertexName == e1?.From_Vertex)) // O(V)
            {
                var index = adj.FindIndex(x => x?.VertexName == e1?.From_Vertex);
                adj[index]?.Edges?.Add(e1);
            }

            // To add an edge from e2 -> e1. When adding directed edge, e2 is null.
            if (e2 != null)
            {
                if (adj.Any(x => x?.VertexName == e2?.From_Vertex)) // O(V)
                {
                    var index = adj.FindIndex(x => x?.VertexName == e2?.From_Vertex);
                    adj[index]?.Edges?.Add(e2);
                }
            }
        }

        // AddVertex to add a vertex.
        public void AddVertex(string source, string destination)
        {
            // Add the source vertex to the adj list.
            if (!adj.Any(x => x?.VertexName == source))
            {
                Vertex v = new Vertex(source, new List<Edge>(), "UP", false);
                adj?.Add(v);
            }

            if (destination != null)
            {
                // Add the destination vertex to the adj list. Used when building the graph, we have undirected edges so both vertices will be added.
                if (!adj.Any(x => x?.VertexName == destination))
                {
                    Vertex v = new Vertex(destination, new List<Edge>(), "UP", false);
                    adj?.Add(v);
                }
            }
        }

        // CompareTo function from IComparable class to sort the vertex in alphabetically order.
        public int CompareTo([AllowNull] Vertex other)
        {
            return VertexName.CompareTo(other.VertexName);
        }

        #endregion
    }
}
