# Kentico Fluent Cache Keys

Utility library for generating consistent cache dependency keys for Kentico CMS applications

## Examples

### Creating cache keys for pages / documents / nodes

```csharp
FluentCacheKey.Page().WithDocumentId(5);

FluentCacheKey.Page().WithNodeId(4);

FluentCacheKey.PageForSite("siteName").WithAliasPath("/path");

FluentCacheKey.PageForSite("siteName").WithAliasPath("/path", "en-us");

FluentCacheKey.Pages().WithRelationshipsToNodeId(4);

FluentCacheKey.PagesForSite("siteName").OfClass("className");

FluentCacheKey.PagesForSite("siteName").WithParentAliasPath("/path");
```

### Creating cache keys for CMS objects / custom module classes

```csharp
FluentCacheKey.Object("className").WithCodeName("codeName");

FluentCacheKey.Object("className").WithGuid(default);

FluentCacheKey.Object("className").WithId(2);

FluentCacheKey.Objects("className").All();
```

### Creating cache keys for attachments

```csharp
FluentCacheKey.Attachment().All();

FluentCacheKey.Attachment().WithGuid(default);

FluentCacheKey.Attachment().ForDocumentId(4);
```

### Creating cache keys for media files

```csharp
FluentCacheKey.MediaFile().WithGuid(default);

FluentCacheKey.MediaFile().PreviewWithGuid(default);
```
