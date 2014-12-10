using System;
using System.Collections.Generic;
using Terradue.ServiceModel.Ogc.OwsContext;
using Terradue.ServiceModel.Syndication;

namespace Terradue.ServiceModel.Ogc.OwsModel {
    /// <summary>
    /// This class is the overall container class for the OWS context document.
    /// </summary>
    public class OwsContext {

        /// <summary>
        /// Specification Reference identifying that this is an owc Context document 
        /// </summary>
        /// <value>The spec reference.</value>
        public Uri SpecReference { get; set; }

        /// <summary>
        /// Language used in the owc Context document 
        /// </summary>
        /// <value>The language.</value>
        public string Language { get; set; }

        /// <summary>
        /// Unique Identifier assigned to the OWS Context Document
        /// </summary>
        /// <value>The identifier.</value>
        public string Id { get; set; }

        /// <summary>
        /// A Human Readable Title for the OWS Context Document
        /// </summary>
        /// <value>The title.</value>
        public string Title { get; set; }

        /// <summary>
        /// Description of the Context Document Purpose/Content 
        /// </summary>
        /// <value>The abstract.</value>
        public string Abstract { get; set; }

        /// <summary>
        /// Date when the Context Document was updated
        /// </summary>
        /// <value>The update date.</value>
        public DateTimeOffset UpdateDate { get; set; }

        /// <summary>
        /// Identifier for the author of the document
        /// </summary>
        /// <value>The author.</value>
        public List<string> Authors { get; set; }

        /// <summary>
        /// Identifier for the publisher of the document
        /// </summary>
        /// <value>The publisher.</value>
        public string Publisher { get; set; }

        /// <summary>
        /// The tool/application used to create the context document and its properties
        /// </summary>
        /// <value>The creator.</value>
        public OwcCreator Creator { get; set; }

        /// <summary>
        /// Rights which apply to the context document.
        /// </summary>
        /// <value>The rights.</value>
        public string Rights { get; set; }

        /// <summary>
        /// Geographic area of interest of the users of the context document 
        /// </summary>
        /// <value>The area of interest.</value>
        public object AreaOfInterest { get; set; }

        /// <summary>
        /// A date/time interval relevant to the context document
        /// </summary>
        /// <value>The time interval of interest.</value>
        public DateTimeInterval TimeIntervalOfInterest { get; set; }

        /// <summary>
        /// Keyword related to this context document. Shall support an optional codelist parameter. 
        /// </summary>
        /// <value>The keyword.</value>
        public List<string> Keywords { get; set; }

        /// <summary>
        /// The description of a resource and its access parameters and configuration
        /// </summary>
        /// <value>The resource.</value>
        public List<OwcResource> Resources { get; set; }

        /// <summary>
        /// Additional metadata describing the context document itself. The format recommendation is ISO19115 complaint metadata. The metadata standard used should be specified
        /// </summary>
        /// <value>The context metadata.</value>
        public object ContextMetadata { get; set; }

        /// <summary>
        /// Any encoding should allow the user to extend the context content to include custom items 
        /// </summary>
        /// <value>The extension.</value>
        public object Extension { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Terradue.ServiceModel.Ogc.OwsModel.OwsContext"/> class.
        /// </summary>
        public OwsContext() {
        }

        /// <summary>
        /// Transform the current object to OwsContextAtomFeed.
        /// </summary>
        /// <returns>The ows context atom feed.</returns>
        public OwsContextAtomFeed ToOwsContextAtomFeed(){

            OwsContextAtomFeed feed = new OwsContextAtomFeed();

            feed.Title = new TextSyndicationContent(this.Title);
            feed.Description = new TextSyndicationContent(this.Abstract);
            feed.Id = this.Id;
            feed.LastUpdatedTime = this.UpdateDate;
            feed.Language = this.Language;
            feed.Publisher = this.Publisher;
            feed.Copyright = new TextSyndicationContent(this.Rights);
            feed.Where = (whereType)this.AreaOfInterest;
            feed.Date = this.TimeIntervalOfInterest;

            if(this.SpecReference != null) feed.Links.Add(new Terradue.ServiceModel.Syndication.SyndicationLink(this.SpecReference,"profile","OWC Context document specification reference",null,this.SpecReference.AbsoluteUri.Length));

            //TODO: validate type of ContextMetadata
            if(this.ContextMetadata != null) feed.Links.Add(new Terradue.ServiceModel.Syndication.SyndicationLink(new Uri((string)this.ContextMetadata),"via","Context Metadata",null,this.SpecReference.AbsoluteUri.Length));

            if (this.Authors != null) {
                foreach (string author in this.Authors) feed.Authors.Add(new SyndicationPerson(null, author, null));
            }

            if (this.Creator != null) {
                if(this.Creator.CreatorApplication != null) feed.Generator = this.Creator.CreatorApplication.Title;
                feed.Display = new Terradue.ServiceModel.Ogc.OwsContext.OwcDisplay(this.Creator.CreatorDisplay);
            }

            if (this.Keywords != null) {
                foreach (string kw in this.Keywords) feed.Categories.Add(new SyndicationCategory(kw));
            }

            if (this.Resources != null) {
                System.Collections.ObjectModel.Collection<OwsContextAtomEntry> items = new System.Collections.ObjectModel.Collection<OwsContextAtomEntry>();
                foreach (OwcResource resource in this.Resources) items.Add(resource.ToContextAtomEntry());
                feed.Items = items;
            }

//            feed.ElementExtensions = Extension.ToAtom(); //TODO: implement

            return feed;
        }
    }


}

