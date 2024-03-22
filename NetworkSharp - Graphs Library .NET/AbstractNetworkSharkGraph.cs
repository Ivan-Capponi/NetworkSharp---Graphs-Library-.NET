namespace NetworkSharp___Graphs_Library_.NET
{
    /// <summary>
    /// An abstract base class for graph data structures, supporting generic vertex and edge types.
    /// This class defines the fundamental operations and properties that all graphs should implement.
    /// </summary>
    /// <typeparam name="TVertex">The type of the vertices in the graph.</typeparam>
    /// <typeparam name="TEdge">The type of the edges in the graph.</typeparam>
    public abstract class AbstractNetworkSharkGraph<TVertex, TEdge> : INetworkSharpGraph<TVertex, TEdge>
    {
        // Abstract properties representing the vertices and edges of the graph.
        // Implementations must define how these collections are stored and accessed.
        public abstract IEnumerable<TVertex> Vertices { get; }
        public abstract IEnumerable<TEdge> Edges { get; }

        // Clears the graph of all vertices and edges.
        public abstract void Clear();

        // Returns the number of vertices and edges in the graph.
        public abstract int VertexCount { get; }
        public abstract int EdgeCount { get; }

        // Methods to get the degree of vertices (incoming and outgoing).
        public abstract int GetIncomingDegree(TVertex vertex);
        public abstract int GetOutgoingDegree(TVertex vertex);

        // Methods for adding and removing edges and vertices.
        public abstract TEdge AddEdge(TVertex source, TVertex destination, TEdge edge);
        public abstract TEdge RemoveEdge(TEdge edge);
        public abstract TVertex AddVertex(TVertex vertex);
        public abstract TVertex RemoveVertex(TVertex vertex);

        // Methods to check existence of vertices and edges, and adjacency between vertices.
        public abstract bool HasVertex(TVertex vertex);
        public abstract bool HasEdge(TEdge edge);
        public abstract bool AreAdjacent(TVertex vertex1, TVertex vertex2);

        // Methods to retrieve incoming and outgoing edges for a specific vertex.
        public abstract IEnumerable<TEdge> GetOutgoingEdges(TVertex vertex);
        public abstract IEnumerable<TEdge> GetIncomingEdges(TVertex vertex);
        // Retrieves the source and destination vertices of an edge.
        public abstract (TVertex source, TVertex? destination) GetEndpoints(TEdge edge);

        // Utility methods to check for null vertices and edges. Throws an ArgumentNullException if null is encountered.
        protected void InputVertexCheck(TVertex vertex)
        {
            if (vertex == null)
                throw new ArgumentNullException(nameof(vertex));
        }

        protected void InputEdgeCheck(TEdge edge)
        {
            if (edge == null)
                throw new ArgumentNullException(nameof(edge));
        }

        // Calculates the total degree (incoming + outgoing) of a vertex.
        public int GetDegree(TVertex vertex)
        {
            InputVertexCheck(vertex);
            return GetIncomingDegree(vertex) + GetOutgoingDegree(vertex);
        }

        // Retrieves all edges associated with a vertex (both incoming and outgoing).
        public IEnumerable<TEdge> GetEdges(TVertex vertex)
        {
            InputVertexCheck(vertex);
            return GetOutgoingEdges(vertex).Union(GetIncomingEdges(vertex));
        }

        // Gets the neighboring vertices of a given vertex based on outgoing edges.
        public IEnumerable<TVertex?> GetNeighbors(TVertex vertex)
        {
            InputVertexCheck(vertex);
            return GetOutgoingEdges(vertex).Select(e => GetOppositeVertex(vertex, e));
        }

        // Determines the vertex at the opposite end of an edge from the given vertex.
        public TVertex? GetOppositeVertex(TVertex vertex, TEdge edge)
        {
            InputVertexCheck(vertex);
            InputEdgeCheck(edge);
            var (source, destination) = GetEndpoints(edge);
            return source != null && source.Equals(vertex) ? destination : default;
        }
    }
}
