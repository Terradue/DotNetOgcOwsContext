using System;
using NUnit.Framework;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Xml.Linq;
using System.Linq;
using Terradue.OpenSearch.Result;

namespace Terradue.ServiceModel.Ogc.Owc.AtomEncoding.Test {

    [TestFixture]
    public class SerializationTests {

        [Test]
        public void DateExtensions() {

			var feed = AtomFeed.Load(XmlReader.Create(File.OpenRead("../in/offeringdateext.xml")));

			OwsContextAtomFeed ows = new OwsContextAtomFeed(feed.Feed, true);

			SerializationTest.SerializeToStream(ows, Console.OpenStandardOutput());

        }
    }
}

