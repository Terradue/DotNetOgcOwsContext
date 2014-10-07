﻿using System.Xml;
using System.Xml.Linq;

namespace Terradue.ServiceModel.Ogc.OwsContext {

    public static class XElementExtensions {
        public static XmlElement ToXmlElement(this XElement el) {
            var doc = new XmlDocument();
            doc.Load(el.CreateReader());
            return doc.DocumentElement;
        }
    }
}