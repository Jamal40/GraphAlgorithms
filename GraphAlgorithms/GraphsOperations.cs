namespace GraphAlgorithms;

public class GraphsOperations<T>
{
    #region Directed Graph

    #region Get Depth First Values

    public static List<T> GetDepthFirstValues(Dictionary<T, List<T>> graph, T entry)
    {
        var resultList = new List<T>();
        var stack = new Stack<T>();
        stack.Push(entry);

        while (stack.Count > 0)
        {
            var currentEntry = stack.Pop();
            resultList.Add(currentEntry);

            var currentList = graph[currentEntry];
            currentList.ForEach(entry => stack.Push(entry));
        }

        return resultList;
    }

    public static List<T> GetDepthFirstValuesRecursive(Dictionary<T, List<T>> graph, T entry, List<T> resultList = null)
    {
        resultList ??= new();
        resultList.Add(entry);

        graph[entry].ForEach(entry => GetDepthFirstValuesRecursive(graph, entry, resultList));
        return resultList;
    }

    #endregion

    #region Get Breadth First Value

    public static List<T> GetBreadthFirstValues(Dictionary<T, List<T>> graph, T entry)
    {
        var resultList = new List<T>();
        var queue = new Queue<T>();
        queue.Enqueue(entry);

        while (queue.Count > 0)
        {
            var currentEntry = queue.Dequeue();
            resultList.Add(currentEntry);

            var currentList = graph[currentEntry];
            currentList.ForEach(entry => queue.Enqueue(entry));
        }

        return resultList;
    }

    #endregion

    #region Has Path

    public static bool HasPathDepthFirstRecursive(Dictionary<T, List<T>> graph, T source, T destination)
    {
        if (source.Equals(destination))
            return true;

        return graph[source].Any(entry => HasPathDepthFirstRecursive(graph, entry, destination));
    }

    public static bool HasPathBreadthFirst(Dictionary<T, List<T>> graph, T source, T destination)
    {
        var queue = new Queue<T>();
        queue.Enqueue(source);

        while (queue.Count > 0)
        {
            var currentEntry = queue.Dequeue();
            if (currentEntry.Equals(destination))
                return true;

            graph[currentEntry].ForEach(entry => queue.Enqueue(entry));
        }

        return false;
    }

    #endregion

    #region Get Components Count
    public static int GetComponentsCount(Dictionary<T, List<T>> graph)
    {
        int result = 0;
        var visitedNodes = new HashSet<T>();
        foreach (var node in graph.Keys)
        {
            if (visitedNodes.Contains(node))
                continue;

            ExploreGraph(node, graph, visitedNodes);
            result++;
        }
        return result;
    }

    private static void ExploreGraph(T node, Dictionary<T, List<T>> graph, HashSet<T> visitedNodes)
    {
        if (visitedNodes.Contains(node))
            return;
        visitedNodes.Add(node);
        graph[node].ForEach(entry => ExploreGraph(entry, graph, visitedNodes));
    }
    #endregion

    #region Get Largest Compnent
    public static int GetLargestComponent(Dictionary<T, List<T>> graph)
    {
        var visitedList = new HashSet<T>();
        var graphsCounts = new List<int>();
        foreach (var node in graph.Keys)
        {
            if (!visitedList.Contains(node))
                graphsCounts.Add(CountGraph(graph, node, visitedList));
        }
        return graphsCounts.Max();
    }

    private static int CountGraph(Dictionary<T, List<T>> graph, T node, ISet<T> visitedList)
    {
        if (visitedList.Contains(node))
            return 0;

        visitedList.Add(node);
        int count = 1;

        graph[node].ForEach(entry => { count += CountGraph(graph, entry, visitedList); });
        return count;
    }
    #endregion

    #endregion

    #region Undirected Graph

    #region HasPath

    public static bool UndirectedHasPath(List<List<T>> edges, T source, T destination)
    {
        var graph = GetAdjacencyListFromEdges(edges);
        return UndirectedHasPathHelper(graph, source, destination, new HashSet<T>());
    }

    private static bool UndirectedHasPathHelper(Dictionary<T, List<T>> graph, T source, T destination,
        HashSet<T> visited)
    {
        if (source.Equals(destination))
            return true;
        if (visited.Contains(source))
            return false;

        visited.Add(source);

        return graph[source].Any(entry => UndirectedHasPathHelper(graph, entry, destination, visited));
    }

    #endregion

    #region Get Shortest Path

    #region Reucursive (DepthFirst)

    public static int GetShortestPathRecursive(List<List<T>> edges, T source, T target)
    {
        var graph = GetAdjacencyListFromEdges(edges);

        int shortestPath = GetShortestPathFromGraphRecursive(graph, source, target);

        return shortestPath;
    }

    private static int GetShortestPathFromGraphRecursive(
        Dictionary<T, List<T>> graph,
        T node,
        T target,
        HashSet<T> visitedList = null,
        List<int> pathsLengths = null,
        int currentCoount = 0)
    {
        visitedList ??= new();
        pathsLengths ??= new();

        if (visitedList.Contains(node))
            return 0;

        visitedList.Add(node);

        if (node.Equals(target))
        {
            pathsLengths.Add(currentCoount);
            currentCoount = 0;
        }
        currentCoount++;

        graph[node].ForEach(entry =>
        {
            GetShortestPathFromGraphRecursive(graph, entry, target, visitedList, pathsLengths, currentCoount);
        });

        return pathsLengths.Any() ? pathsLengths.Min() : 0;
    }

    #endregion

    #region Iterative (BreadthFirst)

    public static int GetShortestPath(List<List<T>> edges, T source, T target)
    {
        var graph = GetAdjacencyListFromEdges(edges);
        var visitedList = new HashSet<T>();

        var queue = new Queue<(T node, int level)>();
        queue.Enqueue((source, 0));

        while (queue.Count > 0)
        {
            var current = queue.Dequeue();
            if (visitedList.Contains(current.node))
                continue;
            visitedList.Add(current.node);

            if (current.node.Equals(target))
                return current.level;

            graph[current.node].ForEach(node => queue.Enqueue((node, current.level + 1)));
        }
        return -1;
    }

    #endregion

    #endregion

    #region Count Islands
    public static int GetIslandsCount(T[,] grid, T landSymbol, T waterSymbol)
    {
        var visitedList = new HashSet<(int row, int col)>();
        int counter = 0;
        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j].Equals(waterSymbol))
                    continue;
                if (visitedList.Contains((i, j)))
                    continue;

                ExploreGrid(grid, i, j, landSymbol, waterSymbol, visitedList);
                counter++;
            }
        }
        return counter;
    }

    private static void ExploreGrid(T[,] grid, int i, int j, T landSymbol, T waterSymbol, ISet<(int row, int col)> visitedList)
    {
        try
        {
            if (grid[i, j].Equals(waterSymbol))
                return;
        }
        catch (IndexOutOfRangeException)
        {
            return;
        }

        if (visitedList.Contains((i, j)))
            return;
        visitedList.Add((i, j));

        ExploreGrid(grid, i + 1, j, landSymbol, waterSymbol, visitedList);
        ExploreGrid(grid, i - 1, j, landSymbol, waterSymbol, visitedList);
        ExploreGrid(grid, i, j + 1, landSymbol, waterSymbol, visitedList);
        ExploreGrid(grid, i, j - 1, landSymbol, waterSymbol, visitedList);
    }
    #endregion

    #region Minimum Island
    public static int GetMinimumIsland(T[,] grid, T landSymbol, T waterSymbol)
    {
        var visitedList = new HashSet<(int row, int col)>();
        var islandsSizes = new List<int>();

        for (int i = 0; i < grid.GetLength(0); i++)
        {
            for (int j = 0; j < grid.GetLength(1); j++)
            {
                if (grid[i, j].Equals(waterSymbol))
                    continue;
                if (visitedList.Contains((i, j)))
                    continue;
                islandsSizes.Add(GetIslandSize(grid, i, j, landSymbol, waterSymbol, visitedList));
            }
        }
        return islandsSizes.Min();
    }

    private static int GetIslandSize(T[,] grid, int i, int j, T landSymbol, T waterSymbol, HashSet<(int row, int col)> visitedList)
    {
        int count = 0;

        try
        {
            if (grid[i, j].Equals(waterSymbol))
                return count;
        }
        catch (IndexOutOfRangeException)
        {
            return count;
        }

        if (visitedList.Contains((i, j)))
            return count;
        visitedList.Add((i, j));

        count++;
        count += GetIslandSize(grid, i + 1, j, landSymbol, waterSymbol, visitedList);
        count += GetIslandSize(grid, i - 1, j, landSymbol, waterSymbol, visitedList);
        count += GetIslandSize(grid, i, j + 1, landSymbol, waterSymbol, visitedList);
        count += GetIslandSize(grid, i, j - 1, landSymbol, waterSymbol, visitedList);

        return count;
    }
    #endregion

    #region Helpers

    private static Dictionary<T, List<T>> GetAdjacencyListFromEdges(List<List<T>> edges)
    {
        var resultDictionary = new Dictionary<T, List<T>>();
        foreach (var edge in edges)
        {
            AddOrAppendEdge(resultDictionary, edge[0], edge[1]);
            AddOrAppendEdge(resultDictionary, edge[1], edge[0]);
        }

        return resultDictionary;
    }

    private static void AddOrAppendEdge(Dictionary<T, List<T>> resultDictionary, T key, T value)
    {
        if (value is null)
            return;
        if (resultDictionary.ContainsKey(key))
        {
            resultDictionary[key].Add(value);
        }
        else
        {
            resultDictionary[key] = new List<T> { value };
        }
    }

    #endregion

    #endregion
}