namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Edge
    {
        public string TO_Vertex { get; set; }
        public float Weight { get; set; }

        public Edge(string TO_Vertex, float Weight)
        {
            this.TO_Vertex = TO_Vertex;
            this.Weight = Weight;
        }
    }
}
