namespace SubEdit;

internal class SubRecord : IComparable<SubRecord>
{
    public TimeSpan StartTime { get; set; }
    public TimeSpan EndTime { get; set; }
    public List<string> Lines { get; set; } = [];

    public int CompareTo(SubRecord? other)
    {
        if (other == null) 
            return 1;

        if (other.StartTime < StartTime) 
            return -1;

        if (other.StartTime == StartTime) 
            return 0;

        if (other.StartTime > StartTime) 
            return 1;

        return 1;
    }

    public override string ToString()
    {
        var retval = $"{TimeSpanSerializer.Serialize(StartTime)} --> {TimeSpanSerializer.Serialize(EndTime)}{Environment.NewLine}";

        foreach (var line in Lines)
            retval += $"{line}{Environment.NewLine}";

        return retval;
    }
}