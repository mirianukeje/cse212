public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a value with a priority to the back of the queue
    /// </summary>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // make sure the queue isn't empty
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // start by assuming the first item has the highest priority
        var highPriorityIndex = 0;

        // check the rest of the list to find the highest priority
        for (int index = 1; index < _queue.Count; index++)
        {
            // only switch if we find a strictly higher priority
            // this keeps the original order for ties (FIFO)
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
                highPriorityIndex = index;
        }

        // grab the value
        var value = _queue[highPriorityIndex].Value;

        // remove it so it doesn’t get returned again
        _queue.RemoveAt(highPriorityIndex);

        return value;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    // DO NOT MODIFY THE CODE IN THIS METHOD
    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}