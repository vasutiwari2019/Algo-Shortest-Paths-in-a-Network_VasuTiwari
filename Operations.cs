using System;
using System.Collections.Generic;
using System.IO;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Operations
    {
        public Graph FinalGraph { get; set; }

        public void BuildGraph(string str)
        {
            try
            {
                Vertex finalVertex = new Vertex();

                string[] initializeFile = str?.Split(" ");

                if (initializeFile[0] == "graph" && initializeFile[1] != ".txt")
                {

                    var existingFile = Directory.GetFiles("../../../", "*.txt", SearchOption.TopDirectoryOnly);

                    var fileName = initializeFile[1]?.Split(".");

                    File.Move(existingFile[0], "../../../" + fileName[0] + ".txt");

                    string[] lines = File.ReadAllLines("../../../" + fileName[0] + ".txt");

                    foreach (var item in lines)
                    {
                        string[] graph = item?.Split(" ");

                        var source_vertex = graph[0];
                        var destination_vertex = graph[1];
                        var edge_weight = float.Parse(graph[2]);

                        Edge edge1 = new Edge(source_vertex, destination_vertex, edge_weight, "UP");

                        Edge edge2 = new Edge(destination_vertex, source_vertex, edge_weight, "UP");

                        LinkedList<Edge> edges1 = new LinkedList<Edge>();

                        LinkedList<Edge> edges2 = new LinkedList<Edge>();

                        edges1?.AddFirst(edge1);

                        edges2?.AddFirst(edge2);

                        finalVertex?.AddVertex(source_vertex, destination_vertex);

                        finalVertex?.AddEdge(edges1, edges2);
                    }

                    FinalGraph = new Graph(finalVertex?.adj);
                }

                else
                {
                    throw new NotImplementedException();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for BuildGraph" + ex);
                Environment.Exit(0);
            }
        }

        public void AddAnEdge(string tailvertex, string headvertex, float weight)
        {
            var flag = false;
            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    foreach (var edge in item?.Edges)
                    {
                        if (headvertex == edge?.To_Vertex && tailvertex == edge?.From_Vertex)
                        {
                            edge.Weight = weight;
                            flag = true;
                        }
                    }
                }

                if (!flag)
                {
                    var vertex = new Vertex();

                    var edges = new LinkedList<Edge>();

                    var edge = new Edge(tailvertex, headvertex, weight, "UP");

                    vertex?.AddVertex(tailvertex, headvertex);

                    edges?.AddFirst(edge);

                    vertex?.AddEdge(edges, null);
                    foreach (var item in vertex?.adj)
                    {
                        FinalGraph?.Vertices?.Add(item);
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine("Input not in order for AddAnEdge" + ex);
            }

        }

        public void DeleteAnEdge(string tailvertex, string headvertex)
        {
            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    foreach (var vertices in item.Edges)
                    {
                        if (headvertex == vertices?.To_Vertex && tailvertex == vertices?.From_Vertex)
                        {
                            vertices.Weight = -1;
                        }
                    }
                }
            }

            catch(Exception ex)
            {
                Console.WriteLine("Input not in order for DeleteAnEdge" + ex);
            }
        }

        public void EdgeDown(string tailvertex, string headvertex)
        {
            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    foreach (var edge in item?.Edges)
                    {
                        if (headvertex == edge?.To_Vertex && tailvertex == edge?.From_Vertex)
                        {
                            edge.EdgeStatus = "DOWN";
                        }
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for EdgeDown" + ex);
            }
        }

        public void EdgeUp(string tailvertex, string headvertex)
        {
            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    foreach (var edge in item?.Edges)
                    {
                        if (headvertex == edge?.To_Vertex && tailvertex == edge?.From_Vertex)
                        {
                            edge.EdgeStatus = "UP";
                        }
                    }
                }
            }

            catch (Exception ex) 
            { 
                Console.WriteLine("Input not in order for EdgeUp" + ex); 
            }
        }

        public void VertexDown(string vertex)
        {
            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    if (item?.VertexName == vertex)
                        item.VertexStatus = "DOWN";
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for VertexDown" + ex);
            }
        }

        public void VertexUp(string vertex)
        {
            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    if (item?.VertexName == vertex)
                        item.VertexStatus = "UP";
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for VertexUp" + ex);
            }
        }

        public void Print()
        {
            try
            {
                FinalGraph?.PrintGraph(FinalGraph);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for Print" + ex);
            }
        }

        public void Reachable()
        {
            List<Vertex> listOfVertices = new List<Vertex>(FinalGraph.Vertices);
            foreach (var item in FinalGraph.Vertices)
            {
                if (item.VertexStatus == "UP" && item.Edges.Count != 0)
                {
                    Console.WriteLine(item?.VertexName);

                    item.Visited = true;

                    ReachableEdge(item.Edges, listOfVertices);

                    foreach (var vertices in FinalGraph.Vertices)
                    {
                        vertices.Visited = false;
                    }
                }
            }
        }

        public void ReachableEdge(LinkedList<Edge> listOfEdges, List<Vertex> listOfVertices)
        {
            foreach(var edges in listOfEdges)
            {
                foreach(var vertices in listOfVertices)
                {
                    if (edges.To_Vertex == vertices.VertexName && vertices.Visited != true && vertices.VertexStatus != "DOWN" && edges.EdgeStatus != "DOWN")
                    {
                        Console.WriteLine("  " + edges.To_Vertex);

                        vertices.Visited = true;

                        ReachableEdge(vertices.Edges, listOfVertices);
                    }
                }
            }
        }
        
    }
}
