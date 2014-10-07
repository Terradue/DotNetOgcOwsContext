using System;
using Terradue.ServiceModel.Syndication;
using System.Xml;

namespace Terradue.ServiceModel.Ogc.OwsContext
{

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = OwcNamespaces.Owc)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = OwcNamespaces.Owc, IsNullable = false)]
	public class OwcContent
	{
        string type;
        Uri href;
        string text;
        XmlNode[] itemsField;

        public OwcContent(){
            Text = "";
            this.type = "text";
        }

        public OwcContent(string type, Uri href){
            Href = href;
            this.type = type;
        }

        public OwcContent(string type, string text){
            Text = text;
            this.type = type;
        }

        public OwcContent(string type, XmlNode[] any){
            Any = any;
            this.type = type;
        }

        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "href")]
        public string Url {
            get {
                return Href.ToString();
            }
            set {
                Href = new Uri(value);
            }
        }

        [System.Xml.Serialization.XmlIgnore]
        public Uri Href {
            get {
                return href;
            }
            set {
                text = null;
                href = value;
                itemsField = null;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "type")]
        public string Type {
            get {
                return type;
            }
            set {
                type = value;
            }
        }

        [System.Xml.Serialization.XmlTextAttribute()]
        public string Text {
            get {
                return text;
            }
            set {
                href = null;
                itemsField = null;
                text = value;
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
                this.text = null;
                this.href = null;
                this.itemsField = value;
            }
        }
	}


}

