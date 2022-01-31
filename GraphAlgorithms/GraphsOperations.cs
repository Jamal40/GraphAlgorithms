namespace GraphAlgorithms;

public class GraphsOperations<T>
{
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

    #endregion
}