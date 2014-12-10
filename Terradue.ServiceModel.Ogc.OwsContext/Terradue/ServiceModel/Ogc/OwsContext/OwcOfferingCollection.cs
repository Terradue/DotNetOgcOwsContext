using System;
using Terradue.ServiceModel.Syndication;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Collections;
using System.Collections.ObjectModel;

namespace Terradue.ServiceModel.Ogc.OwsContext {
    public class OwcOfferingCollection {

        SyndicationElementExtensionCollection elementExtensions;


        public OwcOfferingCollection(SyndicationElementExtensionCollection coll) : base() {
            this.elementExtensions = coll;
        }

        public void Add(OwcOffering item){
            elementExtensions.Add("offering", OwcNamespaces.Owc, item);
        }

        public void Add(List<OwcOffering> items){
            foreach(OwcOffering item in items) elementExtensions.Add(item, new XmlSerializer(typeof(OwcOffering)));
        }

        public void Clear() {
            var offerings = elementExtensions.ReadElementExtensions<SyndicationElementExtension>("offering", OwcNamespaces.Owc);
            foreach (var offering in offerings) {
                elementExtensions.Remove(offering);
            }
        }

        public int Count {
            get {
                var offerings = elementExtensions.ReadElementExtensions<SyndicationElementExtension>("offering", OwcNamespaces.Owc);
                return offerings.Count;
            }
        }
            
        public Collection<OwcOffering> GetOfferings() {
            var offerings = elementExtensions.ReadElementExtensions<OwcOffering>("offering", OwcNamespaces.Owc, new XmlSerializer(typeof(OwcOffering)));
            return offerings;
        }

    }
}

