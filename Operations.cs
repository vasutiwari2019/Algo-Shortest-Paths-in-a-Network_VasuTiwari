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

                        var edge1 = new Edge(source_vertex, destination_vertex, edge_weight, "UP");

                        var edge2 = new Edge(destination_vertex, source_vertex, edge_weight, "UP");

                        finalVertex?.AddVertex(source_vertex, destination_vertex);

                        finalVertex?.AddEdge(edge1, edge2);
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

            var tedge = new Edge(tailvertex, headvertex, weight, "UP");

            var myvar = false;

            try
            {
                foreach (var item in FinalGraph?.Vertices)
                {
                    foreach (var edge in item?.Edges)
                    {
                        if (tailvertex == edge?.From_Vertex)
                        {
                            if (headvertex == edge?.To_Vertex)
                            {
                                edge.Weight = weight;
                                flag = true;
                            }

                            myvar = true;
                        }
                    }
                }

                if (myvar && !flag)
                {
                    var tdum = FinalGraph?.Vertices.Find(x => x.VertexName == tailvertex);
                    tdum.Edges.Add(tedge);

                    if (FinalGraph?.Vertices.Find(x => x.VertexName == headvertex) == null)
                    {
                        tdum.AddVertex(headvertex, tailvertex);

                        FinalGraph?.Vertices?.Add(tdum.adj[0]);
                    }
                }

                else if (!myvar && !flag)
                {
                    var vertex = new Vertex();

                    var edge = new Edge(tailvertex, headvertex, weight, "UP");

                    vertex?.AddVertex(tailvertex, headvertex);

                    vertex?.AddEdge(edge, null);

                    foreach (var item in vertex?.adj)
                    {
                        FinalGraph?.Vertices?.Add(item);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for AddAnEdge" + ex);
            }

        }

        public void AddAnEdgeNew(string tailvertex, string headvertex, float weight)
        {
            if (FinalGraph.Vertices.Find(x => x.VertexName == tailvertex) != null)
            {
                if (FinalGraph.Vertices.Find(x => x.VertexName == headvertex) != null)
                {
                    var from_vertex = FinalGraph.Vertices.Find(x => x.VertexName == tailvertex);

                    var tail_vertex = FinalGraph.Vertices.Find(x => x.VertexName == headvertex);

                    var dumedge = new Edge(tailvertex, headvertex, weight, "UP");

                    var findEdge = from_vertex.Edges.Find(x => x.To_Vertex == tail_vertex.VertexName);

                    if (findEdge != null)
                    {
                        findEdge.Weight = weight;
                    }

                    else
                    {
                        from_vertex.Edges.Add(dumedge);
                    }
                }

                else
                {
                    var dumVertex = new Vertex();
                    dumVertex.AddVertex(headvertex, null);
                    var edge = new Edge(tailvertex, headvertex, weight, "UP");
                    FinalGraph.Vertices.Add(dumVertex.adj[0]);
                    FinalGraph.Vertices.Find(x => x.VertexName == tailvertex).Edges.Add(edge);
                }
            }

            else
            {
                var dumVertex = new Vertex();
                dumVertex.AddVertex(tailvertex, null);
                FinalGraph.Vertices.Add(dumVertex.adj[0]);
                if (FinalGraph.Vertices.Find(x => x.VertexName == headvertex) != null)
                {
                    var edge = new Edge(tailvertex, headvertex, weight, "UP");
                    FinalGraph.Vertices.Find(x => x.VertexName == tailvertex).Edges.Add(edge);
                }

                else
                {
                    var dum2Vertex = new Vertex();
                    dum2Vertex.AddVertex(headvertex, null);
                    FinalGraph.Vertices.Add(dum2Vertex.adj[0]);
                    var edge = new Edge(tailvertex, headvertex, weight, "UP");
                    FinalGraph.Vertices.Find(x => x.VertexName == tailvertex).Edges.Add(edge);
                }
            }
        }

        public void DeleteAnEdge(string tailvertex, string headvertex)
        {
            try
            {
                var vert = FinalGraph?.Vertices.Find(x => x.VertexName == tailvertex);

                var deledge = vert.Edges.Find(x => x.To_Vertex == headvertex);

                vert.Edges.Remove(deledge);
                //foreach (var item in FinalGraph?.Vertices)
                //{
                //    foreach (var vertices in item.Edges)
                //    {
                //        if (headvertex == vertices?.To_Vertex && tailvertex == vertices?.From_Vertex)
                //        {
                //            vertices.Weight = -1;
                //        }
                //    }
                //}
            }

            catch (Exception ex)
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

        public void ReachableEdge(List<Edge> listOfEdges, List<Vertex> listOfVertices)
        {
            foreach (var edges in listOfEdges)
            {
                foreach (var vertices in listOfVertices)
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

        public void Path(string from_vertex, string to_vertex)
        {
            bool nopath = false;
            var cost = (float)0;
            var newcost = (float)0;
            var previous_vertex = new Vertex();

            var source_vertex = FinalGraph.Vertices.Find(x => x.VertexName == from_vertex);

            var destination_vertex = new Vertex();

            var priorityQueue = new PriorityQueue(source_vertex, FinalGraph);

            priorityQueue.BuildQueueInitial((float)0.0, null);

            while (destination_vertex.VertexName != to_vertex)
            {
                if (priorityQueue.PriorityQueue_List.Count == 0)
                {
                    nopath = true;
                    break;
                }
                (destination_vertex, newcost, priorityQueue.PriorityQueue_List, previous_vertex) = priorityQueue.Return_MinCost_Vertex(previous_vertex.VertexName);

                var tempPriorityQueue = new PriorityQueue(destination_vertex, previous_vertex, FinalGraph);

                tempPriorityQueue.BuildQueue(newcost, previous_vertex.VertexName);

                foreach (var item in tempPriorityQueue.PriorityQueue_List)
                {
                    priorityQueue.PriorityQueue_List.Add(item);
                }

            }

            if (!nopath)
            {
                List<string> printPath = new List<string>();

                printPath.Add(newcost.ToString("0.00"));

                while (destination_vertex.Parent_Vertex != null)
                {
                    printPath.Add(destination_vertex.VertexName);

                    destination_vertex = destination_vertex.Parent_Vertex;
                }

                printPath.Add(destination_vertex.VertexName);

                for (int i = printPath.Count - 1; i >= 0; i--)
                {
                    Console.Write(printPath[i] + " ");
                }

                Console.Write("\n");


                // Making all explored edges and vertices unexplored
                foreach (var vertex in FinalGraph.Vertices)
                {
                    vertex.VertexExplored = false;
                    vertex.Parent_Vertex = new Vertex();
                    foreach (var edge in vertex.Edges)
                        edge.EdgeExplored = false;
                }
            }
        }

        public void Sort_Vertex_Edges()
        {
            FinalGraph.Vertices.Sort();

            foreach (var vertex in FinalGraph.Vertices)
            {
                vertex.Edges.Sort();
            }
        }
    }
}
