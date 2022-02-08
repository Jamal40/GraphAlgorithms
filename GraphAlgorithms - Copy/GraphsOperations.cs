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
            resultDictionary[key] = new List<T> {value};
        }
    }

    #endregion

    #endregion
}