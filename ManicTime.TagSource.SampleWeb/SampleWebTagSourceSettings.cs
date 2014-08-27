using Finkit.ManicTime.Common.TagSources;

namespace ManicTime.TagSource.SampleWeb
{
    /*
     * 
     * Settings will be stored within ManicTime. In here you would put things like Username, Password (please encrypt it first), 
     * Refresh rate, Url of the service.....
     * 
     * Anything you need to get the tags. You can get all the values from the SampleWebTagSourceSettingsViewModel, which is the UI
     * users sees when he creates a plugin within ManicTime.
     * 
     */
    public class SampleWebTagSourceSettings : ITagSourceSettings
    {
        public string Url { get; set; }
    }
}