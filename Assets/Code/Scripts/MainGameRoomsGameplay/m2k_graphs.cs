using System;
using System.Collections.Generic;

class Graph<T>
{
    // We use a Dictionary to store the edges in the graph
    private Dictionary<T, List<T>> map = new Dictionary<T, List<T>>();

    // This function adds a new vertex to the graph
    public void AddVertex(T s)
    {
        map[s] = new List<T>();
    }

    // This function adds the edge between source and destination
    public void AddEdge(T source, T destination, bool bidirectional)
    {
        if (!map.ContainsKey(source))
            AddVertex(source);

        if (!map.ContainsKey(destination))
            AddVertex(destination);

        map[source].Add(destination);
        if (bidirectional)
        {
            map[destination].Add(source);
        }
    }

    // This function gives the count of vertices
    public void GetVertexCount()
    {
        Console.WriteLine("The graph has " + map.Keys.Count + " vertex");
    }

    // This function gives the count of edges
    public void GetEdgesCount(bool bidirectional)
    {
        int count = 0;
        foreach (var v in map.Keys)
        {
            count += map[v].Count;
        }
        if (bidirectional)
        {
            count /= 2;
        }
        Console.WriteLine("The graph has " + count + " edges.");
    }

    // This function gives whether a vertex is present or not.
    public void HasVertex(T s)
    {
        if (map.ContainsKey(s))
        {
            Console.WriteLine("The graph contains " + s + " as a vertex.");
        }
        else
        {
            Console.WriteLine("The graph does not contain " + s + " as a vertex.");
        }
    }

    // This function gives whether an edge is present or not.
    public void HasEdge(T s, T d)
    {
        if (map.ContainsKey(s) && map[s].Contains(d))
        {
            Console.WriteLine("The graph has an edge between " + s + " and " + d + ".");
        }
        else
        {
            Console.WriteLine("The graph has no edge between " + s + " and " + d + ".");
        }
    }

    // This function prints the neighbours of a vertex
    public void Neighbours(T s)
    {
        if (!map.ContainsKey(s))
            return;

        Console.WriteLine("The neighbours of " + s + " are:");
        foreach (var w in map[s])
        {
            Console.Write(w + ", ");
        }
        Console.WriteLine();
    }

    // Prints the adjacency list of each vertex.
    public override string ToString()
    {
        var builder = new System.Text.StringBuilder();

        foreach (var v in map.Keys)
        {
            builder.Append(v.ToString() + ": ");
            foreach (var w in map[v])
            {
                builder.Append(w.ToString() + " ");
            }
            builder.AppendLine();
        }

        return builder.ToString();
    }
}

// Driver Code
public class MainClass
{
    public static void Main(string[] args)
    {
        // Object of graph is created.
        Graph<int> g = new Graph<int>();

        // Edges are added.
        // Since the graph is bidirectional,
        // so boolean bidirectional is passed as true.
        g.AddEdge(0, 1, true);
        g.AddEdge(0, 4, true);
        g.AddEdge(1, 2, true);
        g.AddEdge(1, 3, true);
        g.AddEdge(1, 4, true);
        g.AddEdge(2, 3, true);
        g.AddEdge(3, 4, true);

        // Printing the graph
        Console.WriteLine("Graph:\n" + g.ToString());

        // Gives the number of vertices in the graph.
        g.GetVertexCount();

        // Gives the number of edges in the graph.
        g.GetEdgesCount(true);

        // Tells whether the edge is present or not.
        g.HasEdge(3, 4);

        // Tells whether vertex is present or not.
        g.HasVertex(5);

        // Prints the neighbours of a vertex.
        g.Neighbours(1);
    }
}
