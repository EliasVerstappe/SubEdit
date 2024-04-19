using System.IO;
using System.Text;

namespace SubEdit;

internal static class SRTSerializer
{
    public enum ReturnCode
    {
        Success = 0,
        FileDoesNotExist
    }

    public static ReturnCode Load(FileInfo file, SubTitleFile? output)
    {
        output = null;

        if (!file.Exists)
            return ReturnCode.FileDoesNotExist;

        var lines = File.ReadLines(file.FullName);

        SubRecord? worker = null;
        output = new SubTitleFile();
        bool textSection = false;

        foreach (var line in lines)
        {
            if (line.Contains(" --> "))
            {
                // Save the last chunck
                output.Add(worker);

                // Create a new record
                worker = new SubRecord();

                var times = line.Split(" --> ", StringSplitOptions.TrimEntries);

                if (TimeSpanSerializer.Deserialize(times[0], out var start))

                    worker.StartTime = (TimeSpan)start;
                if (TimeSpanSerializer.Deserialize(times[1], out var end))
                    worker.EndTime = (TimeSpan)end;

                textSection = true;
            }
            else if (textSection)
            {

            }
        }

        return ReturnCode.Success;
    }
}
