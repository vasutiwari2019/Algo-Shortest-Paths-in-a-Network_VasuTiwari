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

        public void BuildQueue()
        {
            var to_vertex = "";
            var cost = (float)0.0;
            foreach(var item in From_Vertex.Edges)
            {
                if (item.EdgeStatus == "UP")
                {
                    cost = item.Weight;
                    to_vertex = item.To_Vertex;
                    var tvertex = graph.Vertices.Find(x => x.VertexName == to_vertex);
                    var tpqueu = new PriorityQueue(From_Vertex, tvertex, cost);
                    PriorityQueue_List.Add(tpqueu);
                }
            }
        }

        public (Vertex,float, List<PriorityQueue>) Return_MinCost_Vertex(float newcost)
        {
            var mincost = (float)0;
            Vertex tvertex = new Vertex();
            mincost = PriorityQueue_List[0].Min_Cost;
            foreach (var item in PriorityQueue_List)
            {
                if(item.Min_Cost <= mincost)
                {
                    tvertex = item.To_Vertex;
                    mincost = item.Min_Cost;
                }
            }

            var dumVertex = PriorityQueue_List.Find(x => x.To_Vertex == tvertex);

            PriorityQueue_List.Remove(dumVertex);
            return (tvertex, mincost + newcost, PriorityQueue_List);
        }
    }
}
