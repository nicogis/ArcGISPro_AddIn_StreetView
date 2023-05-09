namespace PAMStreetView
{
    using ArcGIS.Desktop.Framework;
    using ArcGIS.Desktop.Framework.Contracts;
    using PAMStreetView.Properties;
    using System.Globalization;

    internal class DStreetViewViewModel : DockPane
    {
        private const string _dockPaneID = "PAMStreetView_DStreetView";

        protected DStreetViewViewModel() { }

        /// <summary>
        /// Show the DockPane.
        /// </summary>
        internal static void Show()
        {
            DockPane pane = FrameworkApplication.DockPaneManager.Find(_dockPaneID);
            if (pane == null)
            {
                return;
            }

            pane.Activate();
        }


        internal double currentX = double.NaN;
        internal double currentY = double.NaN;


        private string webAddress;
        public string WebAddress
        {
            get
            {
                return webAddress;
            }

            set
            {
                SetProperty(ref webAddress, value, () => WebAddress);
            }
        }

        private int wbHeight;
        public int WbHeight
        {
            get
            {
                return wbHeight;
            }

            set
            {
                SetProperty(ref wbHeight, value, () => WbHeight);
                WebBrowserUpdate();
            }
        }

        private int wbWidth;
        public int WbWidth
        {
            get
            {
                return wbWidth;
            }

            set
            {
                SetProperty(ref wbWidth, value, () => WbWidth);
                WebBrowserUpdate();
            }
        }

        public void WebBrowserUpdate()
        {
            
            if (double.IsNaN(this.currentY) || double.IsNaN(this.currentY))
            {
                return;
            }


            this.WebAddress = Settings.Default.UrlPanoAvailable.Replace("#Longitude#", this.currentX.ToString(CultureInfo.InvariantCulture)).Replace("#Latitude#", this.currentY.ToString(CultureInfo.InvariantCulture)).Replace("#Width#", (this.WbWidth - 18).ToString()).Replace("#Height#", (this.WbHeight - 16).ToString());

            
        }

    }

    /// <summary>
    /// Button implementation to show the DockPane.
    /// </summary>
    internal class DStreetView_ShowButton : Button
    {
        
        /// <summary>
        /// event OnClick
        /// </summary>
        protected override void OnClick()
        {
            DStreetViewViewModel.Show();
        }
    }
}
