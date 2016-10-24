using System;
using System.Xml;

namespace Terradue.ServiceModel.Ogc.Owc.AtomEncoding {

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = OwcNamespaces.Owc)]
    [System.Xml.Serialization.XmlRootAttribute("styleSet", Namespace = OwcNamespaces.Owc, IsNullable = false)]
    public class OwcStyleSet {

        XmlNode[] itemsField;
        bool defaultAttr;
        string name;
        string title;
        string abstractEl;
        OwcLegenUrl legendUrl;
        OwcContent[] contents;

        public OwcStyleSet() {
        }

        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "default")]
        public bool Default {
            get {
                return defaultAttr;
            }
            set {
                defaultAttr = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "name")]
        public string Name {
            get {
                return name;
            }
            set {
                name = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "title")]
        public string Title {
            get {
                return title;
            }
            set {
                title = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "abstract")]
        public string Abstract {
            get {
                return abstractEl;
            }
            set {
                abstractEl = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "legendUrl")]
        public OwcLegenUrl LegendUrl {
            get {
                return legendUrl;
            }
            set {
                legendUrl = value;
            }
        }

        [System.Xml.Serialization.XmlAnyElementAttribute()]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "content")]
        public OwcContent[] Contents {
            get {
                return contents;
            }
            set {
                contents = value;
            }
        }

        [System.SerializableAttribute()]
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = OwcNamespaces.Owc)]
        public class OwcLegenUrl {

            public OwcLegenUrl () {}
            string type;
            Uri href;

            [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "type")]
            public string Type {
                get {
                    return type;
                }
                set {
                    type = value;
                }
            }

            [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "href")]
            public string Url {
                get {
                    return href.ToString();
                }
                set {
                    href = new Uri(value);
                }
            }

            [System.Xml.Serialization.XmlIgnore]
            public Uri Href {
                get {
                    return href;
                }
                set {
                    href = value;
                }
            }


        }
    }
}

