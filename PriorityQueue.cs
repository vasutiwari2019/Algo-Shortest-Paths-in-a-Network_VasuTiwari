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

        public void BuildQueue(float weight, string previous_vertex)
        {
            var to_vertex = "";
            var cost = (float)0.0;
            if (From_Vertex.VertexStatus == "UP" && !From_Vertex.VertexExplored)
            {
                foreach (var item in From_Vertex.Edges)
                {
                    if (item.EdgeStatus == "UP" && item.To_Vertex != previous_vertex & !item.EdgeExplored)
                    {
                        cost = item.Weight + weight;
                        to_vertex = item.To_Vertex;
                        var tvertex = graph.Vertices.Find(x => x.VertexName == to_vertex);
                        if (!tvertex.VertexExplored)
                        {
                            var tpqueu = new PriorityQueue(From_Vertex, tvertex, cost);
                            PriorityQueue_List.Add(tpqueu);
                        }
                        item.EdgeExplored = true;
                    }
                }

                From_Vertex.VertexExplored = true;
            }
        }

        public void BuildQueueInitial(float weight, string previous_vertex)
        {
            var to_vertex = "";
            var cost = (float)0.0;
            if (From_Vertex.VertexStatus == "UP" && !From_Vertex.VertexExplored)
            {
                foreach (var item in From_Vertex.Edges)
                {
                    if (item.EdgeStatus == "UP" && item.To_Vertex != previous_vertex & !item.EdgeExplored)
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

        public (Vertex,float, List<PriorityQueue>, Vertex) Return_MinCost_Vertex(string previous_vertex)
        {
            var dum_previous_vertex = new Vertex();
            var mincost = (float)0;
            Vertex tvertex = new Vertex();

            var findanycost = PriorityQueue_List.Find(x => x.To_Vertex.VertexStatus != "DOWN");

            mincost = findanycost.Min_Cost;
            foreach (var item in PriorityQueue_List)
            {
                if (item.Min_Cost <= mincost && previous_vertex != item.To_Vertex.VertexName && item.To_Vertex.VertexStatus != "DOWN")
                {
                    tvertex = item.To_Vertex;
                    mincost = item.Min_Cost;
                    dum_previous_vertex = item.From_Vertex;
                }

            }

            tvertex.Parent_Vertex = dum_previous_vertex;

            var dumVertex = PriorityQueue_List.Find(x => x.To_Vertex == tvertex);
        
            PriorityQueue_List.Remove(dumVertex);
            return (tvertex, mincost, PriorityQueue_List, dum_previous_vertex);
        }
    }
}
