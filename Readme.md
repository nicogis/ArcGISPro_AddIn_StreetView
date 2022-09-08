# ArcGIS Pro StreetView Addin
- Hosted page
	- Host panoAvailable.html in your web server
	- set url of panoAvailable.html and pageHosted = true in Globals.cs
	- create api key google with referer url of panoAvailable.html
	- set api key google in panoAvailable.html
	- rebuild project in Visual Studio 2022

- No hosted page ([download release](https://github.com/nicogis/ArcGISPro_AddIn_StreetView/releases/download/v3.0/PAMStreetView.esriAddinX))
	- set url ({0} -> long and {1} -> lat) and pageHosted = false in Globals.cs
	- rebuild project in Visual Studio 2022


## Requirements
- ArcGIS Pro 3.0
- Supported platforms
	- Windows 11 (Home, Pro, Enterprise)
	- Windows 10 (Home, Pro, Enterprise) (64 bit)
	- Windows 8.1 (Pro, and Enterprise) (64 bit)
- Supported .NET
    - Microsoft .NET Runtime 6.0.5 or higher. Download .NET 6.0
- Supported IDEs
	- Visual Studio 2022 (v17.2 or higher)
		- Community Edition
		- Professional Edition
		- Enterprise Edition
