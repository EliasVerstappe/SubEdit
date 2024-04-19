namespace SubEdit;

public class TimeSpanSerializer
{
    public static string Serialize(TimeSpan timeSpan) 
        => $"{timeSpan.Hours:D2}:{timeSpan.Minutes:D2}:{timeSpan.Seconds:D2},{timeSpan.Milliseconds:D3}";

    public static bool Deserialize(string timeSpanString, out TimeSpan? output)
    {
        output = null;

        string[] parts = timeSpanString.Split(':', ',', '.');

        if (parts.Length != 4)
            return false; // Format not recognised

        int hours = int.Parse(parts[0]);
        int minutes = int.Parse(parts[1]);
        int seconds = int.Parse(parts[2]);
        int milliseconds = int.Parse(parts[3]);

        output = new TimeSpan(hours, minutes, seconds) + TimeSpan.FromMilliseconds(milliseconds);
        
        return true;
    }
}
