using System.Collections.Generic;

namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    class PriorityQueue
    {
        public Vertex From_Vertex { get; set; }

        public Vertex To_Vertex { get; set; }

        public float Min_Cost { get; set; }

        public Graph graph { get; set; }

        public List<PriorityQueue> PriorityQueue_List { get; set; }

        public PriorityQueue(Vertex From_Vertex, Vertex To_Vertex, float Min_Cost)
        {
            this.From_Vertex = From_Vertex;
            this.To_Vertex = To_Vertex;
            this.Min_Cost = Min_Cost;
        }

        public PriorityQueue(Vertex From_Vertex, Graph graph)
        {
            this.From_Vertex = From_Vertex;

            this.graph = graph;

            PriorityQueue_List = new List<PriorityQueue>();
        }

        public PriorityQueue(Vertex From_Vertex, Vertex To_Vertex, Graph graph)
        {
            this.From_Vertex = From_Vertex;

            this.graph = graph;

            this.To_Vertex = To_Vertex;

            PriorityQueue_List = new List<PriorityQueue>();
        }

        public void BuildQueue(float weight, string previous_vertex)
        {
            var to_vertex = "";
            var cost = (float)0.0;
            if (From_Vertex.VertexStatus == "UP" && !From_Vertex.VertexExplored)
            {
                foreach (var item in From_Vertex.Edges)
                {
                    var dumVertex = graph.Vertices.Find(x => x.VertexName == item.To_Vertex);
                    if (item.EdgeStatus == "UP" && item.To_Vertex != previous_vertex && !item.EdgeExplored && !dumVertex.VertexExplored)
                    {
                        cost = item.Weight + weight;
                        to_vertex = item.To_Vertex;
                        var tvertex = graph.Vertices.Find(x => x.VertexName == to_vertex);

                        var tpqueu = new PriorityQueue(From_Vertex, tvertex, cost);
                        PriorityQueue_List.Add(tpqueu);
                        item.EdgeExplored = true;
                    }
                }

                From_Vertex.VertexExplored = true;
            }
        }

        // BuildQueueInitial method used to initially build the Queue. All elements will be added to end of the list.
        public void BuildQueueInitial(float weight, string previous_vertex) // O(V*E)
        {
            var to_vertex = "";
            var cost = (float)0.0;
            if (From_Vertex.VertexStatus == "UP" && !From_Vertex.VertexExplored)
            {
                foreach (var item in From_Vertex.Edges) // O(E)
                {
                    // Only those edges which are up, not explored and not equal to previous vertex will be added.
                    if (item.EdgeStatus == "UP" && item.To_Vertex != previous_vertex & !item.EdgeExplored)
                    {
                        cost = item.Weight + weight;
                        to_vertex = item.To_Vertex;
                        var tvertex = graph.Vertices.Find(x => x.VertexName == to_vertex); // O(V)
                        var tpqueu = new PriorityQueue(From_Vertex, tvertex, cost);
                        PriorityQueue_List.Add(tpqueu);
                        item.EdgeExplored = true;
                    }
                }

                From_Vertex.VertexExplored = true;
            }
        }

        // Return_MinCost_Vertex returns minimum cost along with the previous vertex, the destination vertex and list of priority queue.
        public (Vertex, float, List<PriorityQueue>, Vertex) Return_MinCost_Vertex(string previous_vertex) // O(V*E) worst case
        {
            var dum_previous_vertex = new Vertex();
            var mincost = (float)0;
            Vertex tvertex = new Vertex();

            var findanycost = PriorityQueue_List.Find(x => x.To_Vertex.VertexStatus != "DOWN"); // O(V*E) at worst case. if we need to maintain all elements in the queue. But we are deleting elements from the queue after they are used.

            mincost = findanycost.Min_Cost;
            foreach (var item in PriorityQueue_List) // O(V*E) worst case
            {
                if (item.Min_Cost <= mincost && previous_vertex != item.To_Vertex.VertexName && item.To_Vertex.VertexStatus != "DOWN" && !item.To_Vertex.VertexExplored)
                {
                    tvertex = item.To_Vertex;
                    mincost = item.Min_Cost;
                    dum_previous_vertex = item.From_Vertex;
                }

            }

            tvertex.Parent_Vertex = dum_previous_vertex;

            var dumVertex = PriorityQueue_List.Find(x => x.To_Vertex == tvertex); // O(V*E) worst case 

            PriorityQueue_List.Remove(dumVertex); // removing the element from the priority queue after it is used.
            return (tvertex, mincost, PriorityQueue_List, dum_previous_vertex);
        }
    }
}
