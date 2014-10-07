using System;
using Terradue.ServiceModel.Syndication;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Terradue.ServiceModel.Ogc.OwsContext {
    public class OwsContextAtomFeed : SyndicationFeed {

        public OwsContextAtomFeed() : base() {

            AttributeExtensions.Add(new System.Xml.XmlQualifiedName("owc", XNamespace.Xmlns.NamespaceName), OwcNamespaces.Owc);

        }

        public OwsContextAtomFeed(SyndicationFeed feed, bool cloneItems) : base(feed, cloneItems) {
        }

        public OwcDisplay Display {
            get {
                var displays = ElementExtensions.ReadElementExtensions<OwcDisplay>("dispay", OwcNamespaces.Owc, new XmlSerializer(typeof(OwcDisplay)));
                if (displays.Count() > 0) {
                    return displays.First();
                } else {
                    return null;
                }
            }
            set {
                var displays = ElementExtensions.ReadElementExtensions<SyndicationElementExtension>("dispay", OwcNamespaces.Owc);
                foreach (var display in displays) {
                    ElementExtensions.Remove(display);
                }
                ElementExtensions.Add(value, new XmlSerializer(typeof(OwcDisplay)));
            }
        }

        public string Publisher {
            get {
                var publishers = ElementExtensions.ReadElementExtensions<string>("publisher", OwcNamespaces.Dc);
                if (publishers.Count() > 0) {
                    return publishers.First();
                } else {
                    return null;
                }
            }
            set {
                var publishers = ElementExtensions.ReadElementExtensions<SyndicationElementExtension>("publisher", OwcNamespaces.Dc);
                foreach (var publisher in publishers) {
                    ElementExtensions.Remove(publisher);
                }
                ElementExtensions.Add(value);
            }
        }

        public DateTimeInterval Date {
            get {
                var dates = ElementExtensions.ReadElementExtensions<string>("date", OwcNamespaces.Dc);
                if (dates.Count() > 0) {
                    return DateTimeInterval.Parse(dates.First());
                } else {
                    return null;
                }
            }
            set {
                var dates = ElementExtensions.ReadElementExtensions<SyndicationElementExtension>("date", OwcNamespaces.Dc);
                foreach (var date in dates) {
                    ElementExtensions.Remove(date);
                }
                ElementExtensions.Add("date", OwcNamespaces.Dc, value.ToString());
            }
        }

        public whereType Where {
            get {
                var wheres = ElementExtensions.ReadElementExtensions<whereType>("where", OwcNamespaces.GeoRss, new XmlSerializer(typeof(whereType)));
                if (wheres.Count() > 0) {
                    return wheres.First();
                } else {
                    return null;
                }
            }
            set {
                var dates = ElementExtensions.ReadElementExtensions<SyndicationElementExtension>("where", OwcNamespaces.GeoRss);
                foreach (var date in dates) {
                    ElementExtensions.Remove(date);
                }
                ElementExtensions.Add(value, new XmlSerializer(typeof(whereType)));
            }
        }

        public new IEnumerable<OwsContextAtomEntry> Items {
            get {
                List<OwsContextAtomEntry> items = new List<OwsContextAtomEntry>();
                foreach (var it in base.Items) {
                    items.Add(new OwsContextAtomEntry(it));
                }
                return items;
            }
            set {
                base.Items = new List<OwsContextAtomEntry>(value);
            }
        }
    }
}

