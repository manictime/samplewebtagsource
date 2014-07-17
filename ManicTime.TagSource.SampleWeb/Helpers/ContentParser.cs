using System;
using System.Collections.Generic;
using System.Linq;
using Finkit.ManicTime.Common.TagSources;

namespace ManicTime.TagSource.SampleWeb.Helpers
{
    public static class ContentParser
    {
        public static IEnumerable<TagSourceItem> Parse(string content)
        {
            if (string.IsNullOrEmpty(content))
                yield break;
            string[] lines = content.Split(new[] {"\r\n", "\r", "\n"}, StringSplitOptions.None);
            foreach (string line in lines)
            {
                string[] tagsAndNotes = line.Split(';').Select(l => l.Trim()).ToArray();
                yield return new TagSourceItem
                {
                    Tags = tagsAndNotes[0].Split(',').Select(t => t.Trim()).ToArray(),
                    Notes = tagsAndNotes.Length > 1 ? tagsAndNotes[1] : string.Empty
                };
            }
        }
    }
}
