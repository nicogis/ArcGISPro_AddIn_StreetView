namespace PAMStreetView
{
    internal static class Globals
    {
        public const bool pageHosted = false;
        public const string UrlPanoAvailable = "https://www.google.com/maps/@?api=1&map_action=pano&viewpoint={1}%2C{0}";

        //pageHosted = true -> https://mysite/panoAvailable.html

        //{0} lon  - {1} lat
        //pageHosted = false -> https://www.google.com/maps/@?api=1&map_action=pano&viewpoint={1}%2C{0}
        
    }
}
