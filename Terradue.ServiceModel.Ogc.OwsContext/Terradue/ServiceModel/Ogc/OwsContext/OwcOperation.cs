using System;
using Terradue.ServiceModel.Syndication;

namespace Terradue.ServiceModel.Ogc.OwsContext {
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = OwcNamespaces.Owc)]
    [System.Xml.Serialization.XmlRootAttribute("operation", Namespace = OwcNamespaces.Owc, IsNullable = false)]
    public class OwcOperation {

        string method;
        string code;
        Uri href;
        private System.Xml.XmlNode[] itemsField;

        OwcContent result;

        public OwcOperation() {
        }

        public OwcOperation(string code, Uri href) {
            this.href = href;
            this.code = code;
            this.method = null;
        }

        public OwcOperation(Terradue.ServiceModel.Ogc.OwsModel.OwcOperation operation) : this(operation.Code, operation.RequestURL){
            this.Method = operation.Method;
            if(operation.Request != null)
                this.Result = (operation.Request.Url != null ? new OwcContent(operation.Request.Type, operation.Request.Url) : new OwcContent(operation.Request.Type, operation.Request.Content));
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

        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "href")]
        public string Url {
            get {
                return href.ToString();
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
                href = value;
            }
        }

        [System.Xml.Serialization.XmlAttributeAttribute(AttributeName = "method")]
        public string Method {
            get {
                return method;
            }
            set {
                method = value;
            }
        }

        [System.Xml.Serialization.XmlAnyElementAttribute(Order = 3)]
        public System.Xml.XmlNode[] Any {
            get {
                return this.itemsField;
            }
            set {
                if ((this.itemsField != null)) {
                    if ((itemsField.Equals(value) != true)) {
                        this.itemsField = value;
                    }
                } else {
                    this.itemsField = value;
                }
            }
        }

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "result", Order = 0)]
        public OwcContent Result {
            get {
                return result;
            }
            set {
                result = value;
            }
        }

    }

}

