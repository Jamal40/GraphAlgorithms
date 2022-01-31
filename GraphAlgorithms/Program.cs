#region Preparing Testing Graph

using GraphAlgorithms;

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

#region Testing

PrintCollection(GraphsOperations<string>.GetDepthFirstValues(graph, "a"));

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