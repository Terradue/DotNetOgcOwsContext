using System;
using System.Collections.Generic;

namespace Terradue.ServiceModel.Ogc.OwsModel {
    /// <summary>
    /// This datatype class defines the properties of a specific service binding or inline content 
    /// for an offering. The service binding is primarily characterized by a series of parameters. 
    /// The parameters valid for a specific type of service binding, e.g. WFS are defined outside 
    /// of the OWS Context core specification. Each specific service binding is defined by a URI 
    /// which references a requirement class.
    /// </summary>
    public class OwcOffering {

        /// <summary>
        /// Code identifying the type of service offering
        /// </summary>
        /// <value>The code.</value>
        public Uri Code { get; set; }

        /// <summary>
        /// Operations used to invoke the service
        /// </summary>
        /// <value>The operation.</value>
        public List<OwcOperation> Operations { get; set; }

        /// <summary>
        /// inline content
        /// </summary>
        /// <value>The content.</value>
        public List<OwcContent> Content { get; set; }

        /// <summary>
        /// Style sets to style the in-line content
        /// </summary>
        /// <value>The style set.</value>
        public List<OwcStyleSet> StyleSet { get; set; }

        /// <summary>
        /// Any specific content
        /// </summary>
        /// <value>The extension.</value>
        public object Extension { get; set; }

        public OwcOffering() {
        }
    }
}

