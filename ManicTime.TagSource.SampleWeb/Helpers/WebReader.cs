using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Finkit.ManicTime.Common.TagSources;

namespace ManicTime.TagSource.SampleWeb.Helpers
{
    public static class WebReader
    {
        public static async Task<TagSourceItem[]> GetItemsAsync(string url)
        {
            HttpResponseMessage message = await new HttpClient().GetAsync(url);
            message.EnsureSuccessStatusCode();
            string content = await message.Content.ReadAsStringAsync();
            return ContentParser.Parse(content).ToArray();
        }
    }
}
