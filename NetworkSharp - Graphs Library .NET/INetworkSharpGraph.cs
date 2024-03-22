namespace NetworkSharp___Graphs_Library_.NET
{
    /// <summary>
    /// Defines the structure and operations for a graph data structure, supporting generic types for vertices and edges.
    /// This interface encapsulates fundamental graph operations such as adding and removing vertices and edges,
    /// as well as querying graph properties and relationships between elements.
    /// </summary>
    /// <typeparam name="TVertex">The type representing vertices within the graph.</typeparam>
    /// <typeparam name="TEdge">The type representing edges within the graph.</typeparam>
    public interface INetworkSharpGraph<TVertex, TEdge>
    {
        /// <summary>
        /// Gets a collection of all vertices in the graph.
        /// </summary>
        IEnumerable<TVertex> Vertices { get; }

        /// <summary>
        /// Gets a collection of all edges in the graph.
        /// </summary>
        IEnumerable<TEdge> Edges { get; }

        /// <summary>
        /// Determines whether the graph contains a specific vertex.
        /// </summary>
        /// <param name="vertex">The vertex to locate in the graph.</param>
        /// <returns>True if the graph contains the specified vertex; otherwise, false.</returns>
        bool HasVertex(TVertex vertex);

        /// <summary>
        /// Determines whether the graph contains a specific edge.
        /// </summary>
        /// <param name="edge">The edge to locate in the graph.</param>
        /// <returns>True if the graph contains the specified edge; otherwise, false.</returns>
        bool HasEdge(TEdge edge);

        /// <summary>
        /// Retrieves all edges connected to a specified vertex, including both incoming and outgoing edges.
        /// </summary>
        /// <param name="vertex">The vertex for which to retrieve connected edges.</param>
        /// <returns>A collection of edges connected to the specified vertex.</returns>
        IEnumerable<TEdge> GetEdges(TVertex vertex);

        /// <summary>
        /// Retrieves all edges outgoing from a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex from which outgoing edges will be retrieved.</param>
        /// <returns>A collection of outgoing edges from the specified vertex.</returns>
        IEnumerable<TEdge> GetOutgoingEdges(TVertex vertex);

        /// <summary>
        /// Retrieves all edges incoming to a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex to which incoming edges will be retrieved.</param>
        /// <returns>A collection of incoming edges to the specified vertex.</returns>
        IEnumerable<TEdge> GetIncomingEdges(TVertex vertex);

        /// <summary>
        /// Retrieves all vertices adjacent to a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex for which to retrieve adjacent vertices.</param>
        /// <returns>A collection of vertices adjacent to the specified vertex.</returns>
        IEnumerable<TVertex?> GetNeighbors(TVertex vertex);

        /// <summary>
        /// Calculates the total degree (the number of incoming and outgoing edges) of a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex for which to calculate the degree.</param>
        /// <returns>The total degree of the specified vertex.</returns>
        int GetDegree(TVertex vertex);

        /// <summary>
        /// Calculates the incoming degree (the number of incoming edges) of a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex for which to calculate the incoming degree.</param>
        /// <returns>The incoming degree of the specified vertex.</returns>
        int GetIncomingDegree(TVertex vertex);

        /// <summary>
        /// Calculates the outgoing degree (the number of outgoing edges) of a specified vertex.
        /// </summary>
        /// <param name="vertex">The vertex for which to calculate the outgoing degree.</param>
        /// <returns>The outgoing degree of the specified vertex.</returns>
        int GetOutgoingDegree(TVertex vertex);

        /// <summary>
        /// Determines whether two vertices are adjacent (directly connected by an edge).
        /// </summary>
        /// <param name="vertex1">The first vertex.</param>
        /// <param name="vertex2">The second vertex.</param>
        /// <returns>True if the vertices are adjacent; otherwise, false.</returns>
        bool AreAdjacent(TVertex vertex1, TVertex vertex2);

        /// <summary>
        /// Retrieves the source and destination vertices connected by an edge.
        /// </summary>
        /// <param name="edge">The edge for which to retrieve connected vertices.</param>
        /// <returns>A tuple containing the source and destination vertices of the specified edge.</returns>
        (TVertex source, TVertex? destination) GetEndpoints(TEdge edge);

        /// <summary>
        /// Identifies the vertex opposite to a given vertex on the specified edge.
        /// </summary>
        /// <param name="vertex">The reference vertex.</param>
        /// <param name="edge">The edge connecting the reference vertex to its opposite vertex.</param>
        /// <returns>The vertex opposite to the reference vertex along the specified edge, or null if the edge is not connected to the reference vertex.</returns>
        TVertex? GetOppositeVertex(TVertex vertex, TEdge edge);

        /// <summary>
        /// Adds a new vertex to the graph.
        /// </summary>
        /// <param name="vertex">The vertex to be added.</param>
        /// <returns>The added vertex, or null if the vertex was already present in the graph.</returns>
        TVertex AddVertex(TVertex vertex);

        /// <summary>
        /// Adds a new edge between two specified vertices in the graph.
        /// </summary>
        /// <param name="source">The source vertex from which the edge originates.</param>
        /// <param name="destination">The destination vertex at which the edge terminates.</param>
        /// <param name="edge">The edge to be added between the source and destination vertices.</param>
        /// <returns>The added edge, or null if an identical edge already exists.</returns>
        TEdge AddEdge(TVertex source, TVertex destination, TEdge edge);

        /// <summary>
        /// Removes a specified vertex from the graph.
        /// </summary>
        /// <param name="vertex">The vertex to be removed.</param>
        /// <returns>The removed vertex, or null if the vertex was not found in the graph.</returns>
        TVertex RemoveVertex(TVertex vertex);

        /// <summary>
        /// Removes a specified edge from the graph.
        /// </summary>
        /// <param name="edge">The edge to be removed.</param>
        /// <returns>The removed edge, or null if the edge was not found in the graph.</returns>
        TEdge RemoveEdge(TEdge edge);

        /// <summary>
        /// Gets the total number of vertices in the graph.
        /// </summary>
        int VertexCount { get; }

        /// <summary>
        /// Gets the total number of edges in the graph.
        /// </summary>
        int EdgeCount { get; }

        /// <summary>
        /// Removes all vertices and edges from the graph, effectively resetting it.
        /// </summary>
        void Clear();
    }
}