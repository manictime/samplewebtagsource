using System;
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
            /* 
             * Update will be called every 10 minutes by default. You can change it with
             * UpdateRefreshInterval(TimeSpan.FromMinutes(settings.RefreshRateInMinutes));
             */
        }

        protected override void Update()
        {
            /*
             * 
             * Add your implementation of what happens on update. 
             * 
             * This is the main function of the plugin, it is responsible to get tags from your service
             * 
             * After you get your tags from the service call TagSourceCache.Update
             * 
             */

            TagSourceItem[] items = WebReader.GetItemsAsync(_settings.Url).Result;

            TagSourceCache.Update(InstanceId, items, null, true);
        }

        public override void UpdateSettings(ITagSourceSettings settings)
        {
            /* 
             * triggered when settings change. You can change any private vars used by Update at this point.
             * After this function exits, Update will be called, so do not call it here.
             */
            _settings = (SampleWebTagSourceSettings)settings;
        }
    }
}