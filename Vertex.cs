﻿using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Vertex : IComparable<Vertex>
    {
        public string VertexName { get; set; }

        public LinkedList<Edge> Edges { get; set; }

        public List<Vertex> adj;
        public string VertexStatus { get; set; }

        public bool Visited { get; set; }

        public Vertex()
        {
            VertexName = "";
            Edges = new LinkedList<Edge>();
            adj = new List<Vertex>();
            VertexStatus = "UP";
            Visited = false;
        }

        public Vertex(string VertexName, LinkedList<Edge> Edges, string VertexStatus, bool Visited)
        {
            this.VertexName = VertexName;
            this.Edges = Edges;
            adj = new List<Vertex>();
            this.VertexStatus = VertexStatus;
            this.Visited = Visited;
        }

        public void AddEdge(LinkedList<Edge> e1, LinkedList<Edge> e2)
        {
            if (adj.Any(x => x?.VertexName == e1?.Last()?.From_Vertex))
            {
                var index = adj.FindIndex(x => x?.VertexName == e1?.Last()?.From_Vertex);
                adj[index]?.Edges?.AddFirst(e1?.Last?.Value);
            }

            if (e2 != null)
            {
                if (adj.Any(x => x?.VertexName == e2?.Last()?.From_Vertex))
                {
                    var index = adj.FindIndex(x => x?.VertexName == e2?.Last()?.From_Vertex);
                    adj[index]?.Edges?.AddFirst(e2?.Last?.Value);
                }
            }
        }

        public void AddVertex(string source, string destination)
        {
            if(!adj.Any(x => x?.VertexName == source))
            {
                Vertex v = new Vertex(source, new LinkedList<Edge>(), "UP", false);
                adj?.Add(v);
            }

            if(!adj.Any(x => x?.VertexName == destination))
            {
                Vertex v = new Vertex(destination, new LinkedList<Edge>(), "UP", false);
                adj?.Add(v);
            }
        }

        public int CompareTo([AllowNull] Vertex other)
        {
            return VertexName.CompareTo(other.VertexName);            
        }
    }
}
