namespace Algo_Shortest_Paths_in_a_Network_VasuTiwari
{
    public class Edge
    {
        public string From_Vertex { get; set; }
        public string To_Vertex { get; set; }
        public float Weight { get; set; }
        public string EdgeStatus { get; set; }

        public Edge(string From_Vertex, string To_Vertex, float Weight, string EdgeStatus)
        {
            this.From_Vertex = From_Vertex;
            this.To_Vertex = To_Vertex;
            this.Weight = Weight;
            this.EdgeStatus = EdgeStatus;
        }
    }
}
