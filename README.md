# Kentico Fluent Cache Keys

Utility library for generating consistent cache dependency keys for Kentico CMS applications

[Install the NuGet Package](https://www.nuget.org/packages/WiredViews.Kentico.FluentCacheKeys/)

## Examples

### Creating cache keys for pages / documents / nodes

```csharp
FluentCacheKey.ForPage().WithDocumentId(5);

FluentCacheKey.ForPage().WithNodeId(4);

FluentCacheKey.ForPage().RelationshipsOfNodeId(4);

FluentCacheKey.ForPageOfSite("siteName").WithAliasPath("/path");

FluentCacheKey.ForPageOfSite("siteName").WithAliasPath("/path", "en-us");

FluentCacheKey.ForPagesOfSite("siteName").OfClassName("className");

FluentCacheKey.ForPagesOfSite("siteName").UnderAliasPath("/path");
```

### Creating cache keys for CMS objects / custom module classes

```csharp
FluentCacheKey.ForObjectOfClassName("className").WithCodeName("codeName");

FluentCacheKey.ForObjectOfClassName("className").WithGuid(default);

FluentCacheKey.ForObjectOfClassName("className").WithId(2);

FluentCacheKey.ForObjectsOfClassName("className").All();
```

### Creating cache keys for attachments

```csharp
FluentCacheKey.ForAttachment().WithGuid(default);

FluentCacheKey.ForAttachments().OfDocumentId(4);

FluentCacheKey.ForAttachments().All();
```

### Creating cache keys for media files

```csharp
FluentCacheKey.ForMediaFile().WithGuid(default);

FluentCacheKey.ForMediaFile().PreviewWithGuid(default);
```
