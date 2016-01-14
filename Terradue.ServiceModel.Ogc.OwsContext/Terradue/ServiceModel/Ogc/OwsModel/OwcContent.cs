using System;

namespace Terradue.ServiceModel.Ogc.OwsModel {

    /// <summary>
    /// Content
    /// </summary>
    /// <description>
    /// This object is a generic container for any content
    /// </description>
    /// \xrefitem rmodp "RM-ODP" "RM-ODP Doc"
    /// \ingroup OWSContext
    public class OwcContent {

        /// <summary>
        /// Type of the inline content
        /// </summary>
        /// <value>The type.</value>
        public string Type { get; set; }

        /// <summary>
        /// Referenced Content
        /// </summary>
        /// <value>The URL.</value>
        public Uri Url { get; set; }

        /// <summary>
        /// Actual content in the content element 
        /// </summary>
        /// <value>The content.</value>
        public string Content { get; set; }

        /// <summary>
        /// Application specific content 
        /// </summary>
        /// <value>The extension.</value>
        public object Extension { get; set; }

        public OwcContent() {
        }
    }
}

