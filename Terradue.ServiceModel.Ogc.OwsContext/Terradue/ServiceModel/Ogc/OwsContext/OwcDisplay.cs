using System;
using Terradue.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Terradue.ServiceModel.Ogc.OwsContext {

    [System.Xml.Serialization.XmlTypeAttribute(TypeName = "display", Namespace = OwcNamespaces.Owc)]
    [System.Xml.Serialization.XmlRootAttribute("display", Namespace = OwcNamespaces.Owc, IsNullable = false)]
    public class OwcDisplay {

        int pixelWidth;
        int pixelHeight;
        float mmPerPixel;
        private System.Xml.XmlNode[] itemsField;

        public OwcDisplay() {
            Namespaces = new XmlSerializerNamespaces();
            Namespaces.Add("owc", OwcNamespaces.Owc);
            Namespaces.Add(string.Empty, string.Empty);
        }

        public OwcDisplay(Terradue.ServiceModel.Ogc.OwsModel.OwcDisplay display) : this() {
            this.MmPerPixel = (float)display.MmPerPixel;
            this.PixelHeight = display.PixelHeight;
            this.PixelWidth = display.PixelWidth;
        }

        public static XmlSerializer GetSerializer(){

            XmlSerializer ser = new XmlSerializer(typeof(OwcDisplay));
            return ser;

        }

        [System.Xml.Serialization.XmlNamespaceDeclarations] 
        public XmlSerializerNamespaces Namespaces;

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "pixelWidth", Order = 0)]
        public int PixelWidth {
            get {
                return pixelWidth;
            }
            set {
                pixelWidth = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "pixelHeight", Order = 1)]
        public int PixelHeight {
            get {
                return pixelHeight;
            }
            set {
                pixelHeight = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "mmPerPixel", Order = 2)]
        public float MmPerPixel {
            get {
                return mmPerPixel;
            }
            set {
                mmPerPixel = value;
            }
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 3)]
        public System.Xml.XmlNode[] Any
        {
            get
            {
                return this.itemsField;
            }
            set
            {
                if ((this.itemsField != null))
                {
                    if ((itemsField.Equals(value) != true))
                    {
                        this.itemsField = value;
                    }
                }
                else
                {
                    this.itemsField = value;
                }
            }
        }
    }
}

