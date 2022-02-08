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

var graph2 = new Dictionary<int, List<int>>
{
    {0, new List<int> { 8, 1, 5 } },
    {1, new List<int> { 0 } },
    {5, new List<int> { 0, 8 } },
    {8, new List<int> { 0, 5 } },
    {2, new List<int> { 3, 4 } },
    {3, new List<int>{ 2, 4 } },
    {4, new List<int>{ 3, 2 } }
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

#region Prepare Grid

var grid = new string[6, 5]
{
    {"W", "L", "W", "W", "W"},
    {"W", "L", "W", "W", "W"},
    {"W", "W", "W", "L", "W"},
    {"W", "W", "L", "L", "W"},
    {"L", "W", "W", "L", "L"},
    {"L", "L", "W", "W", "W"},
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
Console.WriteLine(GraphsOperations<string>.GetComponentsCount(graph));
Console.WriteLine(GraphsOperations<int>.GetComponentsCount(graph2));
Console.WriteLine(GraphsOperations<string>.GetLargestComponent(graph));
Console.WriteLine(GraphsOperations<int>.GetLargestComponent(graph2));
Console.WriteLine(GraphsOperations<string>.GetShortestPathRecursive(edges, "i", "l"));
Console.WriteLine(GraphsOperations<string>.GetShortestPath(edges, "i", "l"));
Console.WriteLine(GraphsOperations<string>.GetIslandsCount(grid, "L", "W"));
Console.WriteLine(GraphsOperations<string>.GetMinimumIsland(grid, "L", "W"));

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