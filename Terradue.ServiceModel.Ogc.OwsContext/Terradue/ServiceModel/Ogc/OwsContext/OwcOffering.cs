using System;

namespace Terradue.ServiceModel.Ogc.OwsContext {

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = OwcNamespaces.Owc)]
    [System.Xml.Serialization.XmlRootAttribute("offering", Namespace = OwcNamespaces.Owc, IsNullable = false)]
    public class OwcOffering {


        private System.Xml.XmlNode[] itemsField;
        string code;
        OwcOperation[] operations;
        OwcContent[] contents;

        public OwcOffering() {
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 3)]
        public System.Xml.XmlNode[] Any {
            get {
                return this.itemsField;
            }
            set {
                this.itemsField = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "code")]
        public string Code {
            get {
                return code;
            }
            set {
                code = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "operation", Order = 0)]
        public OwcOperation[] Operations {
            get {
                return operations;
            }
            set {
                operations = value;
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "content", Order = 1)]
        public OwcContent[] Contents {
            get {
                return contents;
            }
            set {
                contents = value;
            }
        }
    }
}

