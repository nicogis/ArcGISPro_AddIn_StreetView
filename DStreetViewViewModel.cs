namespace PAMStreetView
{
    using System;
    using System.Globalization;
    using System.Text;
    using ArcGIS.Desktop.Framework;
    using ArcGIS.Desktop.Framework.Contracts;

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


        private string _webAddress;
        public string WebAddress
        {
            get
            {
                return _webAddress;
            }

            set
            {
                SetProperty(ref _webAddress, value, () => WebAddress);
            }
        }

        private int _wbHeight;
        public int WbHeight
        {
            get
            {
                return _wbHeight;
            }

            set
            {
                SetProperty(ref _wbHeight, value, () => WbHeight);
                WebBrowserUpdate();
            }
        }

        private int _wbWidth;
        public int WbWidth
        {
            get
            {
                return _wbWidth;
            }

            set
            {
                SetProperty(ref _wbWidth, value, () => WbWidth);
                WebBrowserUpdate();
            }
        }

        public void WebBrowserUpdate()
        {
            
            if (double.IsNaN(this.currentY) || double.IsNaN(this.currentY))
            {
                return;
            }

            UriBuilder uriBuilder = new UriBuilder(new Uri(Globals.UrlPanoAvailable));

            StringBuilder sb = new StringBuilder();
            sb.AppendFormat("lat={0}", this.currentY.ToString(CultureInfo.InvariantCulture));
            sb.Append('&');
            sb.AppendFormat("long={0}", this.currentX.ToString(CultureInfo.InvariantCulture));
            sb.Append('&');
            sb.AppendFormat("width={0}", this.WbWidth - 18);
            sb.Append('&');
            sb.AppendFormat("height={0}", this.WbHeight - 16);         
            uriBuilder.Query = sb.ToString();
            this.WebAddress = uriBuilder.Uri.ToString();
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
