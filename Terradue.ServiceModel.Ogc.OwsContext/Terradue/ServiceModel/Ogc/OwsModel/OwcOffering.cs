using System;
using System.Collections.Generic;

namespace Terradue.ServiceModel.Ogc.OwsModel {
    /// <summary>OWS Offering</summary>
    /// <description>
    /// This datatype class defines the properties of a specific service binding or inline content 
    /// for an offering. The service binding is primarily characterized by a series of parameters. 
    /// The parameters valid for a specific type of service binding, e.g. WFS are defined outside 
    /// of the OWS Context core specification. Each specific service binding is defined by a URI 
    /// which references a requirement class.
    /// </description>
    /// \xrefitem rmodp "RM-ODP" "RM-ODP Doc"
    /// \ingroup OWSContext
    public class OwcOffering {

        /// <summary>
        /// Code identifying the type of service offering
        /// </summary>
        /// <value>The code.</value>
        public Uri Code { get; set; }

        /// <summary>
        /// Operations used to invoke the service
        /// </summary>
        /// \return offers \ref OwcOperation as a list of operations available to invoke the service</value>
        /// \xrefitem rmodp "RM-ODP" "RM-ODP Doc"
        public List<OwcOperation> Operations { get; set; }

        /// <summary>
        /// inline content
        /// </summary>
        /// \return offers \ref OwcContent as a list of inline contents
        /// \xrefitem rmodp "RM-ODP" "RM-ODP Doc"
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

