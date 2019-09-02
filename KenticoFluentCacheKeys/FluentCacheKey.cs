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

    public interface IObjectCacheDependencyKey { }
    public interface IObjectOfClassNameCacheDependencyKey
    {
        string ClassName { get; }
    }

    public interface IObjectsCacheDependencyKey { }
    public interface IObjectsOfClassNameCacheDependencyKey
    {
        string ClassName { get; }
    }

    public interface IAttachmentCacheDependencyKey { }
    public interface IAttachmentsCacheDependencyKey { }
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
        IObjectOfClassNameCacheDependencyKey,
        IObjectsOfClassNameCacheDependencyKey,
        IObjectsCacheDependencyKey,
        IAttachmentCacheDependencyKey,
        IAttachmentsCacheDependencyKey,
        IMediaFileCacheDependencyKey
    {
        public string ClassName { get; }
        public string SiteName { get; }

        /// <summary>
        /// Builds Document and Node related cache dependency keys for a single page
        /// </summary>
        /// <returns></returns>
        public static IPageCacheDependencyKey ForPage() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds Document and Node related cache dependency keys for a multiple pages
        /// </summary>
        /// <returns></returns>
        public static IPagesCacheDependencyKey ForPages() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds CMS Object and custom Module Class related cache dependency keys for a single object
        /// </summary>
        /// <returns></returns>
        public static IObjectCacheDependencyKey ForObject() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds CMS Object and custom Module Class related cache dependency keys for multiple objects
        /// </summary>
        /// <returns></returns>
        public static IObjectsCacheDependencyKey ForObjects() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds Attachment related cache dependency keys
        /// </summary>
        /// <returns></returns>
        public static IAttachmentCacheDependencyKey ForAttachment() =>
            new FluentCacheKey(null, null);

        public static IAttachmentsCacheDependencyKey ForAttachments() =>
            new FluentCacheKey(null, null);

        /// <summary>
        /// Builds Media File related cache dependency keys
        /// </summary>
        /// <returns></returns>
        public static IMediaFileCacheDependencyKey ForMediaFile() =>
            new FluentCacheKey(null, null);

        internal FluentCacheKey(string className, string siteName)
        {
            ClassName = className;
            SiteName = siteName;
        }
    }

    public static class PageCacheDependencyExtensions
    {
        public static string WithDocumentId(this IPageCacheDependencyKey _, int documentId) =>
            $"documentid|{documentId}";

        public static string RelationshipsOfNodeId(this IPageCacheDependencyKey _, int nodeId) =>
            $"nodeid|{nodeId}|relationships";

        public static string WithNodeId(this IPageCacheDependencyKey _, int nodeId) =>
            $"nodeid|{nodeId}";

        public static ISitePageCacheDependencyKey OfSite(this IPageCacheDependencyKey page, string siteName) =>
            new FluentCacheKey(null, siteName);

        public static string WithAliasPath(this ISitePageCacheDependencyKey key, string aliasPath) =>
            $"node|{key.SiteName}|{aliasPath}";

        public static string WithAliasPath(this ISitePageCacheDependencyKey key, string aliasPath, string culture) =>
            string.IsNullOrWhiteSpace(culture)
                ? $"node|{key.SiteName}|{aliasPath}"
                : $"node|{key.SiteName}|{aliasPath}|{culture}";

        public static string WithNodeGuid(this ISitePageCacheDependencyKey key, Guid nodeGuid) =>
            $"nodeguid|{key.SiteName}|{nodeGuid}";
    }

    public static class PagesCacheDependencyExtensions
    {
        public static ISitePagesCacheDependencyKey OfSite(this IPagesCacheDependencyKey page, string siteName) =>
            new FluentCacheKey(null, siteName);

        public static string UnderAliasPath(this ISitePagesCacheDependencyKey key, string aliasPath) =>
            $"node|{key.SiteName}|{aliasPath}|childnodes";

        public static string OfClassName(this ISitePagesCacheDependencyKey key, string className) =>
            $"nodes|{key.SiteName}|{className}|all";
    }

    public static class AttachmentCacheDependencyExtensions
    {
        public static string WithGuid(this IAttachmentCacheDependencyKey _, Guid guid) =>
            $"attachment|{guid}";
    }

    public static class AttachmentsCacheKeyDependencyExtensions
    {
        public static string OfDocumentId(this IAttachmentsCacheDependencyKey _, int documentId) =>
            $"documentid|{documentId}|attachments";

        public static string All(this IAttachmentsCacheDependencyKey _) =>
            "cms.attachment|all";
    }

    public static class ObjectOfClassNameClassCacheDependencyExtensions
    {
        public static IObjectOfClassNameCacheDependencyKey OfClassName(this IObjectCacheDependencyKey key, string className) =>
            new FluentCacheKey(className, null);

        public static string WithId(this IObjectOfClassNameCacheDependencyKey key, int objectId) =>
            $"{key.ClassName}|byid|{objectId}";

        public static string WithName(this IObjectOfClassNameCacheDependencyKey key, string objectName) =>
            $"{key.ClassName}|byname|{objectName}";

        public static string WithGuid(this IObjectOfClassNameCacheDependencyKey key, Guid objectGuid) =>
            $"{key.ClassName}|byguid|{objectGuid}";
    }

    public static class ObjectsOfClassNameCacheDependencyExtensions
    {
        public static IObjectsOfClassNameCacheDependencyKey OfClassName(this IObjectsCacheDependencyKey key, string className) =>
            new FluentCacheKey(className, null);

        public static string All(this IObjectsOfClassNameCacheDependencyKey key) =>
            $"{key.ClassName}|all";
    }

    public static class MediaFileCacheDependencyExtensions
    {
        public static string WithGuid(this IMediaFileCacheDependencyKey _, Guid mediaFileGuid) =>
            $"mediafile|{mediaFileGuid}";

        public static string PreviewWithGuid(this IMediaFileCacheDependencyKey _, Guid mediaFileGuid) =>
            $"mediafile|preview|{mediaFileGuid}";
    }
}
