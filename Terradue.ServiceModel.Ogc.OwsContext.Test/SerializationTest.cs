using NUnit.Framework;
using System;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Terradue.ServiceModel.Syndication;
using Terradue.ServiceModel.Ogc.OwsContext;
using System.Xml.Serialization;
using System.Text;
using System.Collections.Generic;
using System.Linq;

namespace Terradue.ServiceModel.Ogc.OwsContext.Test {

    [TestFixture()]
    public class SerializationTest {

        [Test()]
        public void Serialize() {

            OwsContextAtomFeed feed = new OwsContextAtomFeed();

            // display
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

            feed.Items = items;

            MemoryStream stream = new MemoryStream();

            SerializeToStream(feed, stream);

            stream.Seek(0, SeekOrigin.Begin);

            SerializeToStream(feed, Console.Out);

            XDocument doc = XDocument.Load(stream);
            Assert.NotNull(doc.Element(XName.Get("feed", OwcNamespaces.Atom)));

            Assert.NotNull(doc.Element(XName.Get("feed", OwcNamespaces.Atom)).Element(XName.Get("display", OwcNamespaces.Owc)));

            Assert.AreEqual("2010-05-30T03:54:34.000Z/2010-05-31T20:20:20.000Z", doc.Element(XName.Get("feed", OwcNamespaces.Atom)).Element(XName.Get("date", OwcNamespaces.Dc)).Value);
        }

        [Test()]
        public void DeserializeGeotiff() {

            FileStream geotiff = new FileStream("../../Terradue.ServiceModel.Ogc.OwsContext/Schemas/1.0.0/examples/geotiff.xml", FileMode.Open);
            OwsContextAtomFeed feed = DeserializeFromStream(geotiff);

            Assert.AreEqual("GeoTIFF Example", feed.Title.Text);

            Assert.AreEqual("image/tiff", feed.Items.First().Offering.Contents.First().Type);

            Assert.AreEqual("ftp://ftp.remotesensing.org/pub/geotiff/samples/gdal_eg/cea.tif", feed.Items.First().Offering.Contents.First().Url);

           
        }

        public void SerializeToStream(SyndicationFeed feed, System.IO.Stream stream) {
            var sw = XmlWriter.Create(stream, new XmlWriterSettings(){Indent = true, NamespaceHandling = NamespaceHandling.OmitDuplicates});
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(sw);
            sw.Flush();
            sw.Close();
        }

        public void SerializeToStream(SyndicationFeed feed, TextWriter writer) {
            var sw = XmlWriter.Create(writer,new XmlWriterSettings(){Indent = true, NamespaceHandling = NamespaceHandling.OmitDuplicates});
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
            atomFormatter.WriteTo(sw);
            sw.Flush();
            sw.Close();
        }

        public OwsContextAtomFeed DeserializeFromStream(Stream stream) {
            var sr = XmlReader.Create(stream);
            Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter();
            atomFormatter.ReadFrom(sr);
            sr.Close();
            return new OwsContextAtomFeed(atomFormatter.Feed, true);
        }
    }


}

