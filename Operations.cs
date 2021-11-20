using System;
using System.Collections.Generic;
using System.IO;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Operations
    {
        public Graph FinalGraph { get; set; }
        public string ChooseOption()
        {
            Console.WriteLine("Please select from the below options");
            Console.WriteLine("1. Building the graph");
            Console.WriteLine("2. Add directed edge from headvertex to tailvertex");
            Console.WriteLine("3. Delete the edge from headvertex to tailvertex");
            Console.WriteLine("4. Mark the directed edge as “down” and therefore unavailable for use.");
            Console.WriteLine("5. Mark the directed edge as “up”, and available for use");
            Console.WriteLine("6. Mark the vertex as down");
            Console.WriteLine("7. Mark the vertex as up again");
            Console.WriteLine("8. Print the Graph");
            Console.WriteLine("100. To Exit");

            var option = Console.ReadLine();

            return option;
        }

        public void BuildGraph(string str)
        {
            try
            {
                Vertex finalVertex = new Vertex();

                string[] initializeFile = str.Split(" ");

                if (initializeFile[0] == "graph" && initializeFile[1] != ".txt")
                {

                    var existingFile = Directory.GetFiles("../../../", "*.txt", SearchOption.TopDirectoryOnly);

                    var fileName = initializeFile[1].Split(".");

                    File.Move(existingFile[0], "../../../" + fileName[0] + ".txt");

                    string[] lines = File.ReadAllLines("../../../" + fileName[0] + ".txt");

                    foreach (var item in lines)
                    {
                        string[] graph = item.Split(" ");

                        var source_vertex = graph[0];
                        var destination_vertex = graph[1];
                        var edge_weight = float.Parse(graph[2]);

                        Edge edge1 = new Edge(source_vertex, destination_vertex, edge_weight, "UP");

                        Edge edge2 = new Edge(destination_vertex, source_vertex, edge_weight, "UP");

                        LinkedList<Edge> edges1 = new LinkedList<Edge>();

                        LinkedList<Edge> edges2 = new LinkedList<Edge>();

                        edges1.AddFirst(edge1);

                        edges2.AddFirst(edge2);

                        finalVertex.AddVertex(source_vertex, destination_vertex);

                        finalVertex.AddEdge(edges1, edges2);
                    }

                    FinalGraph = new Graph(finalVertex.adj);
                }

                else
                {
                    throw new NotImplementedException();
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Graph not build properly");
                Environment.Exit(0);
            }
        }

        public void AddAnEdge(string tailvertex, string headvertex, float weight)
        {
            var flag = false;

            //var line = headvertex + " " + tailvertex + " " + weight;

            //var existingFile = Directory.GetFiles("../../../", "*.txt", SearchOption.TopDirectoryOnly);

            //List<string> lines = new List<string>(File.ReadAllLines(existingFile[0]));

            //for (int i = 0; i < lines.Count; i++)
            //{
            //    string[] linesRead = lines[i].Split(" ");

            //    if (linesRead[0] == headvertex && linesRead[1] == tailvertex)
            //    {
            //        lines[i] = line;
            //        flag = true;
            //    }
            //}

            //if (!flag)
            //    lines.Add(line);

            //File.WriteAllLines(existingFile[0], lines);

            foreach(var item in FinalGraph.Vertices)
            {
                foreach(var vertices in item.Edges)
                {
                    if(headvertex == vertices.From_Vertex && tailvertex == vertices.To_Vertex)
                    {
                        vertices.Weight = weight;
                        flag = true;
                    }
                }
            }

            if(!flag)
            {
                var vertex = new Vertex();

                var edges = new LinkedList<Edge>();

                var edge = new Edge(headvertex, tailvertex, weight, "UP");

                vertex.AddVertex(headvertex, tailvertex);

                edges.AddFirst(edge);

                vertex.AddEdge(edges, null);

                FinalGraph.Vertices.Add(vertex.adj[0]);
            }

        }

        public void DeleteAnEdge(string tailvertex, string headvertex)
        {
            foreach (var item in FinalGraph.Vertices)
            {
                foreach (var vertices in item.Edges)
                {
                    if (headvertex == vertices.From_Vertex && tailvertex == vertices.To_Vertex)
                    {
                        vertices.Weight = -1;
                    }
                }
            }
        }

        public void EdgeDown(string tailvertex, string headvertex)
        {
            foreach (var item in FinalGraph.Vertices)
            {
                foreach (var edge in item.Edges)
                {
                    if (headvertex == edge.From_Vertex && tailvertex == edge.To_Vertex)
                    {
                        edge.EdgeStatus = "DOWN";
                    }
                }
            }
        }

        public void EdgeUp(string tailvertex, string headvertex)
        {
            foreach (var item in FinalGraph.Vertices)
            {
                foreach (var edge in item.Edges)
                {
                    if (headvertex == edge.From_Vertex && tailvertex == edge.To_Vertex)
                    {
                        edge.EdgeStatus = "UP";
                    }
                }
            }
        }

        public void VertexDown(string vertex)
        {
            foreach (var item in FinalGraph.Vertices)
            {
                if (item.VertexName == vertex)
                    item.VertexStatus = "DOWN";
            }
        }

        public void VertexUp(string vertex)
        {
            foreach (var item in FinalGraph.Vertices)
            {
                if (item.VertexName == vertex)
                    item.VertexStatus = "UP";
            }
        }

        public void Print()
        {
            try
            {
                FinalGraph.PrintGraph(FinalGraph);
            }

            catch (Exception ex)
            {
                Console.WriteLine("Graph not build properly" + ex);
                Environment.Exit(0);
            }
        }
    }
}
