var counter = new Counter(10);

// Subscribe to the ThresholdReached event
counter.ThresholdReached += Counter_ThresholdReached;

// Increment the counter interactively
Console.WriteLine("Press 'a' to add 1 to the counter or 'q' to quit.");
while (true)
{
    var key = Console.ReadKey(true).KeyChar;
    if (key == 'a')
    {
        counter.Add(1);
    }
    else if (key == 'q')
    {
        break;
    }
}

// Unsubscribe from the ThresholdReached event
counter.ThresholdReached -= Counter_ThresholdReached;

static void Counter_ThresholdReached(object? sender, ThresholdReachedEventArgs e)
{
    Console.WriteLine($"Threshold of {e.Threshold} reached at {e.TimeReached}.");
}