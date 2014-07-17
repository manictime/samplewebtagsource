using Finkit.ManicTime.Common.TagSources;
using ManicTime.TagSource.SampleWeb.Helpers;

namespace ManicTime.TagSource.SampleWeb
{
    public class SampleWebTagSourceInstance : BasicTagSourceInstance
    {
        private SampleWebTagSourceSettings _settings;

        public SampleWebTagSourceInstance(SampleWebTagSourceSettings settings, string cacheTimestamp)
        {
            _settings = settings;
        }

        protected override void Update()
        {
            TagSourceItem[] items = WebReader.GetItemsAsync(_settings.Url).Result;
            TagSourceCache.Update(InstanceId, items, null, true);
        }

        public override void UpdateSettings(ITagSourceSettings settings)
        {
            _settings = (SampleWebTagSourceSettings)settings;
        }
    }
}