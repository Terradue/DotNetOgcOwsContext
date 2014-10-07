[![Build Status](https://travis-ci.org/Terradue/DotNetOgcOwsContext.svg)]

# DotNetOgcOwsContext - OGC OWS Context library for .Net

Terradue.ServiceModel.Ogc.OwsContext is a library targeting .NET 4.0 and above providing an model to represent and manipulate OWS context documents

Reference: http://www.opengeospatial.org/standards/owc

## Usage examples

### OWS Context document creation and serialization 

```c#
// First create the doc
OwsContextAtomFeed feed = new OwsContextAtomFeed();

// add a display element
OwcDisplay display = new OwcDisplay() { PixelWidth = 800, PixelHeight = 600, MmPerPixel = 100 };
var displayAny = new System.Collections.Generic.List<XmlElement>();
display.Any = displayAny.ToArray();
feed.Display = display;

// date
DateTimeInterval interval = new DateTimeInterval();
interval.StartDate = DateTime.Parse("2010-05-30T05:54:34+02");
interval.EndDate = DateTime.Parse("2010-05-31T20:20:20.000Z");
feed.Date = interval;

// georss
whereType georss =  whereType.Deserialize("<georss:where xmlns:georss=\"http://www.georss.org/georss/10\">\n<gml:Polygon xmlns:gml=\"http://www.opengis.net/gml\">\n<gml:exterior>\n<gml:LinearRing>\n<gml:posList>45 -2 45 8 55 8 55 -2 45 -2</gml:posList>\n</gml:LinearRing>\n</gml:exterior>\n</gml:Polygon>\n</georss:where>");
feed.Where = georss;

/// entries
List<OwsContextAtomEntry> items = new List<OwsContextAtomEntry>();
OwsContextAtomEntry item = new OwsContextAtomEntry();
OwcOffering offering = new OwcOffering();
List<XmlNode> offeringAny = new List<XmlNode>();
offering.Any = offeringAny.ToArray();
List<OwcOperation> ops = new List<OwcOperation>();
ops.Add(new OwcOperation("GetCapabilities", new Uri("http://ows.genesi-dec.eu/geoserver/385d7d71-650a-414b-b8c7-739e2c0b5e76/wms?SERVICE=WMS&SERVICE=WMS&VERSION=1.1.1&REQUEST=GetCapabilitiesVERSION=1.3.0&REQUEST=GetCapabilities")));
offering.Operations = ops.ToArray();
item.Offering = offering;
items.Add(item);

//serialization
var sw = XmlWriter.Create(Console.Out, new XmlWriterSettings(){Indent = true, NamespaceHandling = NamespaceHandling.OmitDuplicates});
Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
atomFormatter.WriteTo(sw);
sw.Flush();
sw.Close();
```

### Deserialization and OWS Context document manipulation 

```c#
FileStream geotiff = new FileStream("../../Terradue.ServiceModel.Ogc.OwsContext/Schemas/1.0.0/examples/geotiff.xml", FileMode.Open);
OwsContextAtomFeed feed = DeserializeFromStream(geotiff);
Console.Write(feed.Items.First().Offering.Contents.First().Url);
```

## Supported Platforms

* .NET 4.0 (Desktop / Server)
* Xamarin.iOS / Xamarin.Android / Xamarin.Mac
* Mono 3.0+

## Getting Started

Terradue.ServiceModel.Ogc.OwsContext is available as NuGet package in releases.

```
Install-Package Terradue.ServiceModel.Ogc.OwsContext
```

## Build

Terradue.ServiceModel.Ogc.OwsContext is a single assembly designed to be easily deployed anywhere. 

To compile it yourself, you’ll need:

* Visual Studio 2012 or later, or Xamarin Studio

To clone it locally click the "Clone in Desktop" button above or run the 
following git commands.

```
git clone git@github.com:Terradue/DotNetOgcOwsContext.git DotNetOgcOwsContext
```

## TODO

* More tests

## Copyright and License

Copyright (c) 2014 Terradue

Licensed under the [GPL v2 License](https://github.com/Terradue/DotNetOgcOwsContext/blob/master/LICENSE)
