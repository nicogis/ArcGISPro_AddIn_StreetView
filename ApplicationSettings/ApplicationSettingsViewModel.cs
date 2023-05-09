using ArcGIS.Desktop.Framework.Contracts;
using PAMStreetView.Properties;
using System.Threading.Tasks;


namespace PAMStreetView
{
    internal class ApplicationSettingsViewModel : Page
    {
        private string previousUrlPanoAvailable;

        


        private string urlPanoAvailable;
        public string UrlPanoAvailable
        {
            get { return urlPanoAvailable; }
            set
            {
                if (SetProperty(ref urlPanoAvailable, value, () => UrlPanoAvailable))
                    base.IsModified = true;
            }
        }


        private static bool generalExpanded = true;
        public bool GeneralExpanded
        {
            get { return generalExpanded; }
            set { SetProperty(ref generalExpanded, value, () => GeneralExpanded); }
        }

        


        private bool IsDirty()
        {
            if (previousUrlPanoAvailable != UrlPanoAvailable)
            {
                return true;
            }

            return false;
        }

        

        /// <summary>
        /// Invoked when the OK or apply button on the property sheet has been clicked.
        /// </summary>
        /// <returns>A task that represents the work queued to execute in the ThreadPool.</returns>
        /// <remarks>This function is only called if the page has set its IsModified flag to true.</remarks>
        protected override Task CommitAsync()
        {
            if (IsDirty())
            {
                // save the new settings
                Settings settings = Settings.Default;

                settings.UrlPanoAvailable = UrlPanoAvailable;
                
                settings.Save();

                
            }

            

            return Task.FromResult(0);
        }


        /// <summary>
        /// Called when the page loads because it has become visible.
        /// </summary>
        /// <returns>A task that represents the work queued to execute in the ThreadPool.</returns>
        protected override Task InitializeAsync()
        {
            // get the default settings
            Settings settings = Settings.Default;

            // assign to the values binding to the controls
            urlPanoAvailable = settings.UrlPanoAvailable;

            // keep track of the original values (used for comparison when saving)
            previousUrlPanoAvailable = UrlPanoAvailable;
            

            return Task.FromResult(0);
        }

        

        
    }

}
