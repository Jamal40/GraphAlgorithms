using GraphAlgorithms;

#region Preparing Testing Graph

#region Prepare Graph

var graph = new Dictionary<string, List<string>>
{
    {"a", new List<string> {"b", "c"}},
    {"b", new List<string> {"d"}},
    {"c", new List<string> {"e"}},
    {"d", new List<string> {"f"}},
    {"e", new List<string>()},
    {"f", new List<string>()}
};

#endregion

#region Prepare Edges

var edges = new List<List<string>>
{
    new() {"i", "j"},
    new() {"k", "i"},
    new() {"m", "k"},
    new() {"k", "l"},
    new() {"o", "n"}
};

#endregion

#endregion

#region Testing

PrintCollection(GraphsOperations<string>.GetDepthFirstValues(graph, "a"));
PrintCollection(GraphsOperations<string>.GetDepthFirstValuesRecursive(graph, "a"));
PrintCollection(GraphsOperations<string>.GetBreadthFirstValues(graph, "a"));
Console.WriteLine(GraphsOperations<string>.HasPathDepthFirstRecursive(graph, "a", "b"));
Console.WriteLine(GraphsOperations<string>.HasPathBreadthFirst(graph, "a", "b"));
Console.WriteLine(GraphsOperations<string>.UndirectedHasPath(edges, "i", "j"));
Console.WriteLine(GraphsOperations<string>.UndirectedHasPath(edges, "i", "o"));

#endregion

#region helpers

static void PrintCollection<T>(ICollection<T> collection, string name = "")
{
    Console.WriteLine($"------------Start {name}------------");
    foreach (var item in collection)
    {
        Console.WriteLine(item);
    }

    Console.WriteLine($"------------End {name}------------");
}

#endregion