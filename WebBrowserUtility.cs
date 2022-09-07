namespace PAMStreetView
{
    using System;
    using System.IO;
    using System.Windows;
    using System.Windows.Controls;

    /// <summary>
    /// Class AttachedProperty for WebBrowser
    /// </summary>
    public static class WebBrowserUtility
    {
        /// <summary>
        /// Bindable Source Property
        /// </summary>
        public static readonly DependencyProperty BindableSourceProperty = DependencyProperty.RegisterAttached("BindableSource", typeof(string), typeof(WebBrowserUtility), new UIPropertyMetadata(null, BindableSourcePropertyChanged));

        /// <summary>
        /// get Bindable Source Property
        /// </summary>
        /// <param name="obj">object DependencyObject</param>
        /// <returns>web address value</returns>
        public static string GetBindableSource(DependencyObject obj)
        {
            return (string)obj.GetValue(BindableSourceProperty);
        }

        /// <summary>
        /// set Bindable Source Property
        /// </summary>
        /// <param name="obj">object DependencyObject</param>
        /// <param name="value">web address value</param>
        public static void SetBindableSource(DependencyObject obj, string value)
        {
            obj.SetValue(BindableSourceProperty, value);
        }

        /// <summary>
        /// BindableSource PropertyChanged
        /// </summary>
        /// <param name="o">object DependencyObject</param>
        /// <param name="e">Dependency PropertyChanged EventArgs</param>
        public static void BindableSourcePropertyChanged(DependencyObject o, DependencyPropertyChangedEventArgs e)
        {
            if (o is WebBrowser browser)
            {
                string uri = e.NewValue as string;
                browser.Source = !string.IsNullOrEmpty(uri) ? new Uri(uri) : null;

            }
        }
    }
}
