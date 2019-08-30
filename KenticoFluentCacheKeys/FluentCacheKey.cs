using System;

namespace FluentCacheKeys
{
    public interface IPageCacheDependencyKey { }
    public interface ISitePageCacheDependencyKey
    {
        string SiteName { get; }
    }
    public interface IPagesCacheDependencyKey { }
    public interface ISitePagesCacheDependencyKey
    {
        string SiteName { get; }
    }

    public interface IObjectCacheDependencyKey
    {
        string ClassName { get; }
    }
    public interface IObjectsCacheDependencyKey
    {
        string ClassName { get; }
    }

    public interface IAttachmentCacheDependencyKey { }
    public interface IMediaFileCacheDependencyKey { }

    /// <summary>
    /// Starting point for extension methods used to help generate cache dependency keys for Kentico CMS applications
    /// </summary>
    public class FluentCacheKey :
        IPageCacheDependencyKey,
        ISitePageCacheDependencyKey,
        IPagesCacheDependencyKey,
        ISitePagesCacheDependencyKey,
        IObjectCacheDependencyKey,
        IObjectsCacheDependencyKey,
        IAttachmentCacheDependencyKey,
        IMediaFileCacheDependencyKey
    {
        public string ClassName { get; }
        public string SiteName { get; }

        /// <summary>
        /// Builds Document and Node related cache dependency keys for a single site-independent page
        /// </summary>
        /// <returns></returns>
        public static IPageCacheDependencyKey Page() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds Document and Node related cache dependency keys for a single site-dependent page
        /// </summary>
        /// <returns></returns>
        public static ISitePageCacheDependencyKey PageForSite(string siteName) =>
            new FluentCacheKey(null, siteName);

        /// <summary>
        /// Builds Document and Node related cache dependency keys for a multiple site-independent pages
        /// </summary>
        /// <returns></returns>
        public static IPagesCacheDependencyKey Pages() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds Document and Node related cache dependency keys for multiple site-dependent pages
        /// </summary>
        /// <returns></returns>
        public static ISitePagesCacheDependencyKey PagesForSite(string siteName) =>
            new FluentCacheKey(null, siteName);

        /// <summary>
        /// Builds CMS Object and custom Module Class related cache dependency keys for a single object
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static IObjectCacheDependencyKey Object(string className) =>
            new FluentCacheKey(className, null);

        /// <summary>
        /// Builds CMS Object and custom Module Class related cache dependency keys for multiple single object
        /// </summary>
        /// <param name="className"></param>
        /// <returns></returns>
        public static IObjectsCacheDependencyKey Objects(string className) =>
            new FluentCacheKey(className, null);

        /// <summary>
        /// Builds Attachment related cache dependency keys
        /// </summary>
        /// <returns></returns>
        public static IAttachmentCacheDependencyKey Attachment() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds Media File related cache dependency keys
        /// </summary>
        /// <returns></returns>
        public static IMediaFileCacheDependencyKey MediaFile() =>
            new FluentCacheKey(null, null);

        protected FluentCacheKey(string className, string siteName)
        {
            ClassName = className;
            SiteName = siteName;
        }
    }

    public static class PageCacheDependencyExtensions
    {
        public static string WithAliasPath(this ISitePageCacheDependencyKey key, string aliasPath) =>
            $"node|{key.SiteName}|{aliasPath}";

        public static string WithAliasPath(this ISitePageCacheDependencyKey key, string aliasPath, string culture) =>
            string.IsNullOrWhiteSpace(culture)
                ? $"node|{key.SiteName}|{aliasPath}"
                : $"node|{key.SiteName}|{aliasPath}|{culture}";

        public static string WithNodeId(this IPageCacheDependencyKey _, int nodeId) =>
            $"nodeid|{nodeId}";

        public static string WithNodeGuid(this ISitePageCacheDependencyKey key, Guid nodeGuid) =>
            $"nodeguid|{key.SiteName}|{nodeGuid}";

        public static string WithDocumentId(this IPageCacheDependencyKey _, int documentId) =>
            $"documentid|{documentId}";
    }

    public static class PagesCacheDependencyExtensions
    {
        public static string WithParentAliasPath(this ISitePagesCacheDependencyKey key, string aliasPath) =>
            $"node|{key.SiteName}|{aliasPath}|childnodes";

        public static string WithRelationshipsToNodeId(this IPagesCacheDependencyKey _, int nodeId) =>
            $"nodeid|{nodeId}|relationships";

        public static string OfClass(this ISitePagesCacheDependencyKey key, string className) =>
            $"nodes|{key.SiteName}|{className}|all";
    }

    public static class AttachmentCacheDependencyExtensions
    {
        public static string ForDocumentId(this IAttachmentCacheDependencyKey _, int documentId) =>
            $"documentid|{documentId}|attachments";

        public static string WithGuid(this IAttachmentCacheDependencyKey _, Guid guid) =>
            $"attachment|{guid}";

        public static string All(this IAttachmentCacheDependencyKey _) =>
            "cms.attachment|all";
    }

    public static class ObjectCacheDependencyExtensions
    {
        public static string WithId(this IObjectCacheDependencyKey key, int id) =>
            $"{key.ClassName}|byid|{id}";

        public static string WithCodeName(this IObjectCacheDependencyKey key, string codeName) =>
            $"{key.ClassName}|byname|{codeName}";

        public static string WithGuid(this IObjectCacheDependencyKey key, Guid guid) =>
            $"{key.ClassName}|byguid|{guid}";
    }

    public static class ObjectsCacheDependencyExtensions
    {
        public static string All(this IObjectsCacheDependencyKey key) =>
            $"{key.ClassName}|all";
    }

    public static class MediaFileCacheDependencyExtensions
    {
        public static string WithGuid(this IMediaFileCacheDependencyKey _, Guid guid) =>
            $"mediafile|{guid}";

        public static string PreviewWithGuid(this IMediaFileCacheDependencyKey _, Guid guid) =>
            $"mediafile|preview|{guid}";
    }
}
