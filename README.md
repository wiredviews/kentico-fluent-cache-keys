# Kentico Fluent Cache Keys

Utility library for generating consistent cache dependency keys for Kentico CMS applications

[Install the NuGet Package](https://www.nuget.org/packages/WiredViews.Kentico.FluentCacheKeys/)

## Examples

### Creating cache keys for pages / documents / nodes

```csharp
FluentCacheKey.ForPage().WithDocumentId(5);

FluentCacheKey.ForPage().WithNodeId(4);

FluentCacheKey.ForPage().RelationshipsOfNodeId(4);

FluentCacheKey.ForPage().OfSite("siteName").WithAliasPath("/path");

FluentCacheKey.ForPage().OfSite("siteName").WithAliasPath("/path", "en-us");

FluentCacheKey.ForPages().OfSite("siteName").OfClassName("className");

FluentCacheKey.ForPages().OfSite("siteName").UnderAliasPath("/path");
```

### Creating cache keys for CMS objects / custom module classes

```csharp
FluentCacheKey.ForObject().OfClassName("className").WithCodeName("codeName");

FluentCacheKey.ForObject().OfClassName("className").WithGuid(default);

FluentCacheKey.ForObject().OfClassName("className").WithId(2);

FluentCacheKey.ForObjects().OfClassName("className").All();
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
