namespace PAMStreetView
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using ArcGIS.Core.Geometry;
    using ArcGIS.Desktop.Framework;
    using ArcGIS.Desktop.Framework.Threading.Tasks;
    using ArcGIS.Desktop.Mapping;

    /// <summary>
    /// MapTool StreetView
    /// </summary>
    internal class MapToolStreetView : MapTool
    {
        private DStreetViewViewModel pane = FrameworkApplication.DockPaneManager.Find("PAMStreetView_DStreetView") as DStreetViewViewModel;

        /// <summary>
        /// event OnToolMouseDown
        /// </summary>
        /// <param name="e">MapView MouseButton EventArgs</param>
        protected override void OnToolMouseDown(MapViewMouseButtonEventArgs e)
        {
            if (e.ChangedButton == System.Windows.Input.MouseButton.Left)
            {
                // Handle the event args to get the call to the corresponding async method
                e.Handled = true; 
            }
        }

        /// <summary>
        /// Handle MouseDown Async
        /// </summary>
        /// <param name="e">MapView MouseButton EventArgs</param>
        /// <returns>object task</returns>
        protected override Task HandleMouseDownAsync(MapViewMouseButtonEventArgs e)
        {
                return QueuedTask.Run(async() =>
                {
                    try
                    {
                        // Convert the clicked point in client coordinates to the corresponding map coordinates.
                        var mapPoint = MapView.Active.ClientToMap(e.ClientPoint);

                        SpatialReference sr = MapView.Active.Map.SpatialReference;
                        if (!sr.IsEqual(SpatialReferences.WGS84))
                        {
                           mapPoint = await Project(mapPoint, sr);
                        }

                        pane.currentX = mapPoint.X;
                        pane.currentY = mapPoint.Y;
                        pane.WebBrowserUpdate();
                    }
                    catch
                    {
                    }
                });
           
        }

        private Task<MapPoint> Project(MapPoint p, SpatialReference sr)
        {
            return QueuedTask.Run(() =>
            {
                SpatialReference srInput = SpatialReferenceBuilder.CreateSpatialReference(sr.LatestWkid);
                ProjectionTransformation projTransFromSRs = ProjectionTransformation.Create(srInput, SpatialReferences.WGS84);

                MapPoint projectedEnvEx = GeometryEngine.Instance.ProjectEx(p, projTransFromSRs) as MapPoint;

                return projectedEnvEx;
            });
        }

        private class Geometries
        {
            public List<Point> geometries =null;
            public object error = null;
        }

        private class Point
        {
            public double x = double.NaN;
            public double y = double.NaN;
        }

    }
}
