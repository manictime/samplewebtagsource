using System;
using System.Threading.Tasks;
using System.Windows;
using Finkit.ManicTime.Common.TagSources;
using ManicTime.TagSource.SampleWeb.Helpers;

namespace ManicTime.TagSource.SampleWeb
{
    /*
     * Works with SampleWebTagSourceSettingsView view.
     * */

    public class SampleWebTagSourceSettingsViewModel : TagSourceSettingsViewModel
    {
        private string _url;
        public string Url
        {
            get { return _url; }
            set
            {
                if (_url == value)
                    return;
                _url = value;
                OnPropertyChanged("Url");
            }
        }

        public override bool ShowStartingTags
        {
            get { return true; }
        }

        public override void Initialize(ITagSourceSettings settings)
        {
            /*
             * When settings is null, user is creating the plugin
             * When settings is not null, user is editing the plugin
             */

            Settings = settings ?? new SampleWebTagSourceSettings
            {
                Url = "https://raw.githubusercontent.com/manictime/samplewebtagsource/master/ManicTime.TagSource.SampleWeb/SampleTags.txt"
            };
            Url = ((SampleWebTagSourceSettings)Settings).Url;
        }

        public override async Task<bool> BeforeOk()
        {
            /*
             * This is a chance to verify the data. If user didn't enter the correct values, return false
             * Once this function returns true, OnOk will be called.
             * */

            try
            {
                IsRefreshing = true;
                try
                {
                    await WebReader.GetItemsAsync(Url);
                    return true;
                }
                finally
                {
                    IsRefreshing = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public override Task OnOk()
        {
            /*
             * Set all settings. After this function exits, Add window will close, settings will be saved and plugin isntance with these
             * settings will be created.
             * 
             */

            ((SampleWebTagSourceSettings)Settings).Url = Url;
            return TaskEx.FromResult(true);
        }
    }
}
