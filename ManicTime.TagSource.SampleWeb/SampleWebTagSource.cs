using Finkit.ManicTime.Common.TagSources;

namespace ManicTime.TagSource.SampleWeb
{
    public class SampleWebTagSource : BasicTagSource
    {
        public SampleWebTagSource(ITagSourceCache tagSourceCache) : base(tagSourceCache)
        {
        }

        protected override BasicTagSourceInstance CreateServerTagSourceInstance(ITagSourceSettings settings, string cacheTimestamp)
        {
            return new SampleWebTagSourceInstance((SampleWebTagSourceSettings)settings, cacheTimestamp);
        }
    }
}
