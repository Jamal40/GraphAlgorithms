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

var graph3 = new int[][]
{
    new int [] { 1, 3 },
    new int [] { 0, 2 },
    new int [] { 1, 3 },
    new int [] { 0, 2 }
};

var graph4 = new int[][]
{
    new int [] { 1, 2, 3 },
    new int [] { 0, 2 },
    new int [] { 0, 1, 3 },
    new int [] { 0, 2 }
};

var graph5 = new int[][]
{
    new int [] {},
    new int [] { 3 },
    new int [] {},
    new int [] { 1 },
    new int [] {},
};

var graph6 = new int[][]
{
  new int [] {},
  new int [] {2, 4, 6},
  new int [] {1, 4, 8, 9},
  new int [] {7, 8},
  new int [] {1, 2, 8, 9},
  new int [] {6, 9},
  new int [] {1, 5, 7, 8, 9},
  new int [] {3, 6, 9},
  new int [] {2, 3, 4, 6, 9},
  new int [] {2, 4, 5, 6, 7, 8}
};

var graph7 = new int[][]
{
  new int[] {4},
  new int[] {},
  new int[] {4},
  new int[] {4},
  new int[] {0, 2, 3}
};

var graph8 = new int[][]
{
  new int[] {2, 4},
  new int[] {2, 3, 4},
  new int[] {0, 1},
  new int[] {1},
  new int[] {0, 1},
  new int[] {7},
  new int[] {9},
  new int[] {5},
  new int[] {},
  new int[] {6},
  new int[] {12, 14},
  new int[] {},
  new int[] {10},
  new int[] {},
  new int[] {10},
  new int[] {19},
  new int[] {18},
  new int[] {},
  new int[] {16},
  new int[] {15},
  new int[] {23},
  new int[] {23},
  new int[] {},
  new int[] {20, 21},
  new int[] {},
  new int[] {},
  new int[] {27},
  new int[] {26},
  new int[] {},
  new int[] {},
  new int[] {34},
  new int[] {33, 34},
  new int[] {},
  new int[] {31},
  new int[] {30, 31},
  new int[] {38, 39},
  new int[] {37, 38, 39},
  new int[] {36},
  new int[] {35, 36},
  new int[] {35, 36},
  new int[] {43},
  new int[] {},
  new int[] {},
  new int[] {40},
  new int[] {},
  new int[] {49},
  new int[] {47, 48, 49},
  new int[] {46, 48, 49},
  new int[] {46, 47, 49},
  new int[] {45, 46, 47, 48}
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

var grid2 = new int[3][]
{
    new int [] {9, 9, 4},
    new int [] {6, 6, 8},
    new int [] {2, 1, 1},
};

var grid3 = new int[3][]
{
    new int [] {3, 4, 5},
    new int [] {3, 2, 6},
    new int [] {2, 2, 1},
};

var grid4 = new int[1][]
{
    new int [] {1},
};

var grid5 = new int[1][]
{
    new int [] {1,2},
};

var grid6 = new int[3][]
{
  new int [] {7, 8, 9},
  new int [] {9, 7, 6},
  new int [] {7, 2, 3}
};

var grid7 = new int[7][]
{
  new int [] {0, 1, 2, 3, 4, 5, 6},
  new int [] {7, 8, 9, 10, 11, 12, 13},
  new int [] {14, 15, 16, 17, 18, 19, 20},
  new int [] {21, 22, 23, 24, 25, 26, 27},
  new int [] {28, 29, 30, 31, 32, 33, 34},
  new int [] {35, 36, 37, 38, 39, 40, 41},
  new int [] {42, 43, 44, 45, 46, 47, 48}
};

var grid8 = new int[15][]
{
  new int [] {0, 1, 2, 3, 4, 5, 6, 7, 8, 9},
  new int [] {19, 18, 17, 16, 15, 14, 13, 12, 11, 10},
  new int [] {20, 21, 22, 23, 24, 25, 26, 27, 28, 29},
  new int [] {39, 38, 37, 36, 35, 34, 33, 32, 31, 30},
  new int [] {40, 41, 42, 43, 44, 45, 46, 47, 48, 49},
  new int [] {59, 58, 57, 56, 55, 54, 53, 52, 51, 50},
  new int [] {60, 61, 62, 63, 64, 65, 66, 67, 68, 69},
  new int [] {79, 78, 77, 76, 75, 74, 73, 72, 71, 70},
  new int [] {80, 81, 82, 83, 84, 85, 86, 87, 88, 89},
  new int [] {99, 98, 97, 96, 95, 94, 93, 92, 91, 90},
  new int [] {100, 101, 102, 103, 104, 105, 106, 107, 108, 109},
  new int [] {119, 118, 117, 116, 115, 114, 113, 112, 111, 110},
  new int [] {120, 121, 122, 123, 124, 125, 126, 127, 128, 129},
  new int [] {139, 138, 137, 136, 135, 134, 133, 132, 131, 130},
  new int [] {0, 0, 0, 0, 0, 0, 0, 0, 0, 0}
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
Console.WriteLine(GraphsOperations<int>.IsBipartite(graph3)); // Should be true
Console.WriteLine(GraphsOperations<int>.IsBipartite(graph4)); // Should be false
Console.WriteLine(GraphsOperations<int>.IsBipartite(graph5)); // Should be true
Console.WriteLine(GraphsOperations<int>.IsBipartite(graph6)); // Should be false
Console.WriteLine(GraphsOperations<int>.IsBipartite(graph7)); // Should be true
Console.WriteLine(GraphsOperations<int>.IsBipartite(graph8)); // Should be false
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid4)); // Should be 1
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid5)); // Should be 2
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid6)); // Should be 6
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid2)); // Should be 4
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid3)); // Should be 4
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid7)); // Should be 4
Console.WriteLine(GraphsOperations<int>.GetLongestIncreasingPath(grid8)); // Should be 4
Console.WriteLine(GraphsOperations<string>.IsCyclic(graph)); // Should be False
Console.WriteLine(GraphsOperations<int>.IsCyclic(graph2)); // Should be True

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