using System;

namespace Terradue.ServiceModel.Ogc.OwsModel {
    /// <summary>
    /// This datatype class provides place to encode information related to the creator of the context document. 
    /// It includes the creator application and any relevant properties or settings for the application. 
    /// </summary>
    public class OwcCreator {

        /// <summary>
        /// The name, reference and version of the creator application used to create the context document
        /// </summary>
        /// <value>The creator application.</value>
        public OwcApplication CreatorApplication { get; set; }

        /// <summary>
        /// Properties of the display in use when the context document was created (for display based applications only).
        /// </summary>
        /// <value>The creator display.</value>
        public OwcDisplay CreatorDisplay { get; set; }

        /// <summary>
        /// Any encoding should allow the user to extend the Creator information to include custom items 
        /// </summary>
        /// <value>The extension.</value>
        public object Extension { get; set; }

        public OwcCreator() {
        }
    }

    /************************************************************************************************************/

    /// <summary>
    /// This datatype class provides place to encode information related to the creator context when the document was produced. It includes the creator application and relevant properties or settings for the application.
    /// </summary>
    public class OwcApplication {

        /// <summary>
        /// Title or name of the application (for display purposes)
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// URI describing the creator application
        /// </summary>
        /// <value>The URI.</value>
        public Uri Uri { get; set; }

        /// <summary>
        /// Version of the application.
        /// </summary>
        /// <value>The version.</value>
        public string Version { get; set; }

        public OwcApplication() {
        }
    }

    /************************************************************************************************************/

    /// <summary>
    /// This datatype class provides place to encode information related to the display area used
    /// in the creator application when the OWS Context document was produced. This set of 
    /// properties only applies to creator applications which are using a geographic display and is 
    /// supporting information to the exploiter of the OWS Context document. Note the elements 
    /// within creator display are intended as supporting information (metadata) for clients and 
    /// not properties which should control the display size of the client opening the document.
    /// </summary>
    public class OwcDisplay {

        /// <summary>
        /// Pixel width of the display specified by Area of Interest.
        /// </summary>
        /// <value>The width of the pixel.</value>
        public int PixelWidth { get; set; }

        /// <summary>
        /// Pixel height of the display specified by Area of Interest
        /// </summary>
        /// <value>The height of the pixel.</value>
        public int PixelHeight { get; set; }

        /// <summary>
        /// The number of mm per pixel for the display. If no value is available the field should be set to NULL.
        /// </summary>
        /// <value>The mm per pixel.</value>
        public double MmPerPixel { get; set; }

        /// <summary>
        /// Any encoding should allow the user to extend the display information to include custom items 
        /// </summary>
        /// <value>The extension.</value>
        public object Extension { get; set; }

        public OwcDisplay() {
        }
    }
}

