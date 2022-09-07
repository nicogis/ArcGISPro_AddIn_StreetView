namespace PAMStreetView
{
    using System.Reflection;
    using System.Windows.Controls;

    /// <summary>
    /// Interaction logic for DStreetViewView.xaml
    /// </summary>
    public partial class DStreetViewView : UserControl
    {
        public DStreetViewView()
        {
            InitializeComponent();

            this.wbStreetView.Loaded += (s, e) =>
            {
                // get the underlying WebBrowser ActiveX object;
                // this code depends on SHDocVw.dll COM interop assembly,
                // generate SHDocVw.dll: "tlbimp.exe ieframe.dll",
                // and add as a reference to the project

                // workaround perchè il WebBrowser control in WPF non ha la proprietà SuppressScriptErrors mentre in windows form c'è
                //********************************************************************************************************************
                dynamic activeX = this.wbStreetView.GetType().InvokeMember("ActiveXInstance",
                        BindingFlags.GetProperty | BindingFlags.Instance | BindingFlags.NonPublic,
                        null, this.wbStreetView, new object[] { });

                activeX.Silent = true;
                //********************************************************************************************************************
            };

            
        }
    }
}
