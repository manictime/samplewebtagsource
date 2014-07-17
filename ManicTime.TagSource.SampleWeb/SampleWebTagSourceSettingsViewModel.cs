using System;
using System.Threading.Tasks;
using System.Windows;
using Finkit.ManicTime.Common.TagSources;
using ManicTime.TagSource.SampleWeb.Helpers;

namespace ManicTime.TagSource.SampleWeb
{
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
            Settings = settings ?? new SampleWebTagSourceSettings();
            Url = ((SampleWebTagSourceSettings)Settings).Url;
        }

        public override async Task<bool> BeforeOk()
        {
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
            ((SampleWebTagSourceSettings)Settings).Url = Url;
            return TaskEx.FromResult(true);
        }
    }
}
