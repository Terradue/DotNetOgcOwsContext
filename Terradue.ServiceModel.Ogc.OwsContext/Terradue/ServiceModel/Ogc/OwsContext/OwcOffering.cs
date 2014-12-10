using System;
using System.Collections.Generic;

namespace Terradue.ServiceModel.Ogc.OwsContext {

    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = OwcNamespaces.Owc)]
    [System.Xml.Serialization.XmlRootAttribute("offering", Namespace = OwcNamespaces.Owc, IsNullable = false)]
    public class OwcOffering {


        private System.Xml.XmlNode[] itemsField;
        string code;
        OwcOperation[] operations;
        OwcContent[] contents;
        OwcStyleSet[] styleSets;

        public OwcOffering() {
        }

        public OwcOffering(Terradue.ServiceModel.Ogc.OwsModel.OwcOffering offering){
            if(offering.Code != null) this.Code = offering.Code.AbsoluteUri;

            if (offering.Content != null) {
                List<OwcContent> contents = new List<OwcContent>();
                foreach (Terradue.ServiceModel.Ogc.OwsModel.OwcContent c in offering.Content)
                    contents.Add((c.Url != null ? new OwcContent(c.Type, c.Url) : new OwcContent(c.Type, c.Content)));
                this.Contents = contents.ToArray();
            }

            if (offering.Operations != null) {
                List<OwcOperation> ops = new List<OwcOperation>();
                foreach (Terradue.ServiceModel.Ogc.OwsModel.OwcOperation o in offering.Operations)
                    ops.Add(new OwcOperation(o));
                this.Operations = ops.ToArray();
            }
        }

        [System.Xml.Serialization.XmlAnyElementAttribute()]
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

        [System.Xml.Serialization.XmlElementAttribute(ElementName = "operation")]
        public OwcOperation[] Operations {
            get {
                return operations;
            }
            set {
                operations = value;
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
    }
}

