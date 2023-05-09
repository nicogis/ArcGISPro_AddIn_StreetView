namespace PAMStreetView
{
    using ArcGIS.Desktop.Framework;
    using ArcGIS.Desktop.Framework.Contracts;

    internal class PAMStreetViewModule : Module
    {
        private static PAMStreetViewModule _this = null;

        /// <summary>
        /// Retrieve the singleton instance to this module here
        /// </summary>
        public static PAMStreetViewModule Current
        {
            get
            {
                return _this ?? (_this = (PAMStreetViewModule)FrameworkApplication.FindModule("PAMStreetView_Module"));
            }
        }

        #region Overrides
        /// <summary>
        /// Called by Framework when ArcGIS Pro is closing
        /// </summary>
        /// <returns>False to prevent Pro from closing, otherwise True</returns>
        protected override bool CanUnload()
        {
            //TODO - add your business logic
            //return false to ~cancel~ Application close
            return true;
        }

        #endregion Overrides

    }
}
