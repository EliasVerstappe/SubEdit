using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SubEdit;

internal class SubTitleFile
{
    public List<SubRecord> Subtitles { get; set; } = new List<SubRecord>();

    public string Serialize()
    {
        var retval = string.Empty;

        Subtitles.Sort();

        int chunkCount = 0;

        foreach (var subtitle in Subtitles)
        {
            retval += ++chunkCount;
            retval += Environment.NewLine;
            retval += subtitle.ToString();
            retval += Environment.NewLine;
        }

        return retval;
    }

    public void Add(SubRecord? chunk)
    {
        if (chunk == null)
            return;

        Subtitles.Add(chunk);
    }
}
