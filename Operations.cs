using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

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

                    Edge edge1 = new Edge(source_vertex, destination_vertex, edge_weight);

                    Edge edge2 = new Edge(destination_vertex, source_vertex, edge_weight);

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

        public void AddAnEdge(string tailvertex, string headvertex, float weight)
        {
            var flag = false;

            var line = headvertex + " " + tailvertex + " " + weight;

            var existingFile = Directory.GetFiles("../../../", "*.txt", SearchOption.TopDirectoryOnly);

            List<string> lines = new List<string>(File.ReadAllLines(existingFile[0]));

            for (int i = 0; i < lines.Count; i++)
            {
                string[] linesRead = lines[i].Split(" ");

                if (linesRead[0] == headvertex && linesRead[1] == tailvertex)
                {
                    lines[i] = line;
                    flag = true;
                }
            }

            if (!flag)
                lines.Add(line);

            File.WriteAllLines(existingFile[0], lines);
        }

        public void PrintGraph()
        {
            FinalGraph.PrintGraph(FinalGraph);
        }
    }
}
