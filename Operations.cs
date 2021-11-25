using System;
using System.Collections.Generic;
using System.IO;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    // This project file belongs to Vasu Tiwari
    // Main Driver class of the program. Contains functions for all the tasks.
    public class Operations
    {
        #region Properties

        // Used to store the graph variable
        public Graph FinalGraph { get; set; }
        #endregion

        #region Public Methods
        // Build Graph method used to build the initial configuration from the .txt file.
        public void BuildGraph(string str) // O(V*E)
        {
            try
            {
                Vertex finalVertex = new Vertex();

                string[] initializeFile = str?.Split(" ");

                // Logic for taking any .txt file in the current directory and renaming it to given file name.

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

                        finalVertex?.AddVertex(source_vertex, destination_vertex); // O(V)

                        finalVertex?.AddEdge(edge1, edge2); // O(V*E)
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

        // AddAnEdge method used to add an edge from the tailvertex to headvertex
        public void AddAnEdge(string tailvertex, string headvertex, float weight) // O(V+E)
        {
            if (FinalGraph.Vertices.Find(x => x.VertexName == tailvertex) != null) // O(V)
            {
                if (FinalGraph.Vertices.Find(x => x.VertexName == headvertex) != null) // O(V)
                {
                    var from_vertex = FinalGraph.Vertices.Find(x => x.VertexName == tailvertex); // O(V)

                    var tail_vertex = FinalGraph.Vertices.Find(x => x.VertexName == headvertex); // O(V)

                    var dumedge = new Edge(tailvertex, headvertex, weight, "UP");

                    var findEdge = from_vertex.Edges.Find(x => x.To_Vertex == tail_vertex.VertexName); // O(E)

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
                    dumVertex.AddVertex(headvertex, null); // O(V)
                    var edge = new Edge(tailvertex, headvertex, weight, "UP");
                    FinalGraph.Vertices.Add(dumVertex.adj[0]);
                    FinalGraph.Vertices.Find(x => x.VertexName == tailvertex).Edges.Add(edge); // O(V)
                }
            }
            else
            {
                var dumVertex = new Vertex();
                dumVertex.AddVertex(tailvertex, null); // O(V)
                FinalGraph.Vertices.Add(dumVertex.adj[0]);
                if (FinalGraph.Vertices.Find(x => x.VertexName == headvertex) != null) // O(V)
                {
                    var edge = new Edge(tailvertex, headvertex, weight, "UP");
                    FinalGraph.Vertices.Find(x => x.VertexName == tailvertex).Edges.Add(edge); // O(V)
                }
                else
                {
                    var dum2Vertex = new Vertex();
                    dum2Vertex.AddVertex(headvertex, null); // O(V)
                    FinalGraph.Vertices.Add(dum2Vertex.adj[0]);
                    var edge = new Edge(tailvertex, headvertex, weight, "UP");
                    FinalGraph.Vertices.Find(x => x.VertexName == tailvertex).Edges.Add(edge); // O(V)
                }
            }
        }

        // DeleteAnEdge method used to delete an edge from the tailvertex to headvertex.
        public void DeleteAnEdge(string tailvertex, string headvertex) // O(V+E)
        {
            try
            {
                // Finding the vertex in the list
                var vert = FinalGraph?.Vertices.Find(x => x.VertexName == tailvertex); // O(V)

                // Finding the edge in the vertex
                if (vert != null)
                {
                    var deledge = vert.Edges.Find(x => x.To_Vertex == headvertex); // O(E)

                    if (deledge != null)
                    {
                        // Deleting the edge
                        vert.Edges.Remove(deledge); // O(E)
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for DeleteAnEdge" + ex);
            }
        }

        // EdgeDown Method used to make the edge down.
        public void EdgeDown(string tailvertex, string headvertex) // O(V+E)
        {
            try
            {
                // Finding the vertex in the list
                var vert = FinalGraph?.Vertices.Find(x => x.VertexName == tailvertex); // O(V)

                if (vert != null)
                {
                    // Finding the edge in the vertex
                    var edgeToBeDown = vert.Edges.Find(x => x.To_Vertex == headvertex); // O(E)

                    if (edgeToBeDown != null)
                    {
                        // Marking the edgedown
                        edgeToBeDown.EdgeStatus = "DOWN";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for EdgeDown" + ex);
            }
        }

        // EdgeUp Method used to make the edge down.
        public void EdgeUp(string tailvertex, string headvertex) // O(V+E)
        {
            try
            {
                // Finding the vertex in the list
                var vert = FinalGraph?.Vertices.Find(x => x.VertexName == tailvertex); // O(V)

                if (vert != null)
                {
                    // Finding the edge in the vertex
                    var edgeToBeUP = vert.Edges.Find(x => x.To_Vertex == headvertex); // O(E)

                    if (edgeToBeUP != null)
                    {
                        // Marking the edgeup
                        edgeToBeUP.EdgeStatus = "UP";
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for EdgeUp" + ex);
            }
        }

        // VertexDown Method used to make the vertex down.
        public void VertexDown(string vertex) // O(V)
        {
            try
            {
                // Finding the vertex in the list
                foreach (var item in FinalGraph?.Vertices) // O(V)
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

        // VertexUp Method used to make the vertex up.
        public void VertexUp(string vertex) // O(V)
        {
            try
            {
                // Finding the vertex in the list
                foreach (var item in FinalGraph?.Vertices) // O(V)
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

        // Print Method to print the graph configuration
        public void Print() // O(V*E)
        {
            try
            {
                FinalGraph?.PrintGraph(FinalGraph); // O(V*E)
            }
            catch (Exception ex)
            {
                Console.WriteLine("Input not in order for Print" + ex);
            }
        }

        // Reachable Method to find all vertices which are reachable from given vertex.
        // Using DFS to explore all vertices which are reachable.
        // For doing DFS complexity will be O(V*(V+E)).
        public void Reachable() // O(V(V+E))
        {
            List<Vertex> listOfVertices = new List<Vertex>(FinalGraph.Vertices);
            foreach (var item in FinalGraph.Vertices) // O(V)
            {
                if (item.VertexStatus == "UP" && item.Edges.Count != 0)
                {
                    Console.WriteLine(item?.VertexName);

                    item.Visited = true;

                    ReachableEdge(item.Edges, listOfVertices); // O(V+E)

                    foreach (var vertices in FinalGraph.Vertices)
                    {
                        vertices.Visited = false;
                    }
                }
            }
        }

        // ReachableEdge Method used to find what all vertices are reachable from a list of edges.
        public void ReachableEdge(List<Edge> listOfEdges, List<Vertex> listOfVertices) // O(V+E)
        {
            foreach (var edges in listOfEdges) // O(E)
            {
                foreach (var vertices in listOfVertices) // O(V)
                {
                    if (edges.To_Vertex == vertices.VertexName && !vertices.Visited && vertices.VertexStatus != "DOWN" && edges.EdgeStatus != "DOWN")
                    {
                        Console.WriteLine("  " + edges.To_Vertex);

                        vertices.Visited = true;

                        ReachableEdge(vertices.Edges, listOfVertices);
                    }
                }
            }
        }

        // Path method used to find shortest path from a given source vertex to destination vertex using Dijikstra's algorithm.
        // Using custom made priority queue for storing the path information.
        public void Path(string from_vertex, string to_vertex) // O(V^2) worst case for dense graph. O(|V+E|logV) on average.   
        {
            bool nopath = false;
            var newcost = (float)0;
            var previous_vertex = new Vertex();

            var source_vertex = FinalGraph.Vertices.Find(x => x.VertexName == from_vertex); // O(V)

            var destination_vertex = new Vertex();

            var priorityQueue = new PriorityQueue(source_vertex, FinalGraph);

            priorityQueue.BuildQueueInitial((float)0.0, null); // O(V*E)

            while (destination_vertex.VertexName != to_vertex) // O(V) in worst case if not present.
            {
                if (priorityQueue.PriorityQueue_List.Count == 0)
                {
                    nopath = true;
                    break;
                }
                (destination_vertex, newcost, priorityQueue.PriorityQueue_List, previous_vertex) = priorityQueue.Return_MinCost_Vertex(previous_vertex.VertexName); // O(V*E) worst case

                var tempPriorityQueue = new PriorityQueue(destination_vertex, previous_vertex, FinalGraph);

                tempPriorityQueue.BuildQueue(newcost, previous_vertex.VertexName);

                foreach (var item in tempPriorityQueue.PriorityQueue_List)
                {
                    priorityQueue.PriorityQueue_List.Add(item);
                }
            }

            if (!nopath)
            {
                var printPath = new List<string>
                {
                    newcost.ToString("0.00")
                };

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

        // Used to sort the vertices and edges in alphabetically order
        public void Sort_Vertex_Edges() // (V*ElogE + VlogV)
        {
            FinalGraph.Vertices.Sort(); // O(VlogV)

            foreach (var vertex in FinalGraph.Vertices) // O(V)
            {
                vertex.Edges.Sort(); // O(ElogE)
            }
        }

        public void Sort_Vertex()
        {
            FinalGraph.Vertices.Sort();
        }
        #endregion
    }
}
