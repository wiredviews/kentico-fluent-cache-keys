# Kentico Fluent Cache Keys

Utility library for generating consistent cache dependency keys for Kentico CMS applications

[Install the NuGet Package](https://www.nuget.org/packages/WiredViews.Kentico.FluentCacheKeys/)

## Examples

### Creating cache keys for pages / documents / nodes

```csharp
FluentCacheKey.ForPage().WithDocumentId(5);

FluentCacheKey.ForPage().WithNodeId(4);

FluentCacheKey.ForPage().RelationshipsOfNodeId(4);

FluentCacheKey.ForPage().OfSite("Sandbox").WithAliasPath("/home");

FluentCacheKey.ForPage().OfSite("Sandbox").WithAliasPath("/home", "en-us");

FluentCacheKey.ForPages().OfSite("Sandbox").OfClassName(HomePage.CLASS_NAME);

FluentCacheKey.ForPages().OfSite("Sandbox").UnderAliasPath("/home");
```

### Creating cache keys for CMS objects / custom module classes

```csharp
FluentCacheKey.ForObject().OfClassName(UserInfo.OBJECT_TYPE).WithName("administrator");

FluentCacheKey.ForObject().OfClassName(UserInfo.OBJECT_TYPE).WithGuid(new Guid("9fb0c012-5d9b-4eb6-b5cd-0bb0daffaca0"));

FluentCacheKey.ForObject().OfClassName(UserInfo.OBJECT_TYPE).WithId(2);

FluentCacheKey.ForObjects().OfClassName(UserInfo.OBJECT_TYPE).All();
```

### Creating cache keys for attachments

```csharp
FluentCacheKey.ForAttachment().WithGuid(new Guid("9fb0c012-5d9b-4eb6-b5cd-0bb0daffaca0"));

FluentCacheKey.ForAttachments().OfDocumentId(4);

FluentCacheKey.ForAttachments().All();
```

### Creating cache keys for media files

```csharp
FluentCacheKey.ForMediaFile().WithGuid(new Guid("9fb0c012-5d9b-4eb6-b5cd-0bb0daffaca0"));

FluentCacheKey.ForMediaFile().PreviewWithGuid(new Guid("9fb0c012-5d9b-4eb6-b5cd-0bb0daffaca0"));
```

### Creating cache keys for custom tables

```csharp
FluentCacheKey.ForCustomTable().OfClassName("MyCustomTable).All();

FluentCacheKey.ForCustomTable().OfClassName("MyCustomTable").WithRecordId(5);
```

## References

### Kentico Documentation
- [Setting cache dependencies](https://docs.kentico.com/k12sp/configuring-kentico/configuring-caching/setting-cache-dependencies) for cache dependency key examples.

- [Caching in custom code](https://docs.kentico.com/k12sp/configuring-kentico/configuring-caching/caching-in-custom-code) for examples of how to use these keys.

### Blog Posts
- [Kentico 12: Design Patterns Part 12 - Database Query Caching Patterns](https://dev.to/seangwright/kentico-12-design-patterns-part-12-database-query-caching-patterns-43hc) for best practices for caching in your application.