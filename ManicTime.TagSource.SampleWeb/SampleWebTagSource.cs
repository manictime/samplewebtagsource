using Finkit.ManicTime.Common.TagSources;

namespace ManicTime.TagSource.SampleWeb
{
    /*
     * 
     * Responsible for creating an instance of a plugin. For example GitHub plugin could have multiple instances, one for each username. This means
     * that within ManicTime you would create more than one connection to GitHub.
     * 
     * Different settings are sent to each instance (username, password)
     * 
     * BasicTagSource is a simple implementation of ITagSource, for all the features you can implement ITagSource.
     * 
     */

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
