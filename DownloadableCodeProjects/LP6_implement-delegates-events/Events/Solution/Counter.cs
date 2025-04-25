public class Counter
{
    public int Total { get; private set; }
    public int Threshold { get; set; }

    public Counter(int threshold)
    {
        Threshold = threshold;
        Total = 0;
    }

    public void Add(int value)
    {
        Total += value;
        Console.WriteLine($"Current Total: {Total}"); // Debugging output
        if (Total >= Threshold)
        {
            var args = new ThresholdReachedEventArgs
            {
                Threshold = Threshold,
                TimeReached = DateTime.Now
            };
            OnThresholdReached(args);
        }
    }

    public event EventHandler<ThresholdReachedEventArgs> ThresholdReached = delegate { };

    protected virtual void OnThresholdReached(ThresholdReachedEventArgs e)
    {
        ThresholdReached?.Invoke(this, e);
    }
}

public class ThresholdReachedEventArgs : EventArgs
{
    public int Threshold { get; set; }
    public DateTime TimeReached { get; set; }
}