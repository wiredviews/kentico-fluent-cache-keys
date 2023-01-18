using System;
using AutoFixture.Xunit2;
using FluentAssertions;
using FluentCacheKeys;
using Xunit;

namespace KenticoFluentCacheKeys.Tests
{
    public class FluentCacheKeysTests
    {
        [Theory, AutoData]
        public void ForPage_WithDocumentId_Will_Create_A_Valid_Key(int documentId)
        {
            string key = FluentCacheKey.ForPage().WithDocumentId(documentId);

            key.Should().Be($"documentid|{documentId}");
        }

        [Theory, AutoData]
        public void ForPage_RelationshipsOfNodeId_Will_Create_A_Valid_Key(int nodeId)
        {
            string key = FluentCacheKey.ForPage().RelationshipsOfNodeId(nodeId);

            key.Should().Be($"nodeid|{nodeId}|relationships");
        }

        [Theory, AutoData]
        public void ForPage_WithNodeId_Will_Create_A_Valid_Key(int nodeId)
        {
            string key = FluentCacheKey.ForPage().WithNodeId(nodeId);

            key.Should().Be($"nodeid|{nodeId}");
        }

        [Theory, AutoData]
        public void ForPage_OfSite_WithAliasPath_Will_Create_A_Valid_Key(string siteName, string aliasPath, string culture)
        {
            string keyWithCutlure = FluentCacheKey.ForPage().OfSite(siteName).WithAliasPath(aliasPath, culture);
            string keyWithoutCulture = FluentCacheKey.ForPage().OfSite(siteName).WithAliasPath(aliasPath);

            keyWithCutlure.Should().Be($"node|{siteName}|{aliasPath}|{culture}");
            keyWithoutCulture.Should().Be($"node|{siteName}|{aliasPath}");
        }

        [Theory, AutoData]
        public void ForPage_OfSite_WithNodeGuid_Will_Create_A_Valid_Key(string siteName, Guid nodeGuid)
        {
            string key = FluentCacheKey.ForPage().OfSite(siteName).WithNodeGuid(nodeGuid);

            key.Should().Be($"nodeguid|{siteName}|{nodeGuid}");
        }

        [Theory, AutoData]
        public void ForPages_OfSite_UnderAliasPath_Will_Create_A_Valid_Key(string siteName, string aliasPath)
        {
            string key = FluentCacheKey.ForPages().OfSite(siteName).UnderAliasPath(aliasPath);

            key.Should().Be($"node|{siteName}|{aliasPath}|childnodes");
        }

        [Fact]
        public void ForPagesNodeOrder_All_Will_Create_A_Valid_Key()
        {
            string key = FluentCacheKey.ForPagesNodeOrder().All();

            key.Should().Be("nodeorder");
        }

        [Theory, AutoData]
        public void ForPages_OfSite_OfClass_Will_Create_A_Valid_Key(string siteName, string className)
        {
            string key = FluentCacheKey.ForPages().OfSite(siteName).OfClassName(className);

            key.Should().Be($"nodes|{siteName}|{className}|all");
        }

        [Theory, AutoData]
        public void ForAttachment_WithGuid_Will_Create_A_Valid_Key(Guid attachmentGuid)
        {
            string key = FluentCacheKey.ForAttachment().WithGuid(attachmentGuid);

            key.Should().Be($"attachment|{attachmentGuid}");
        }

        [Theory, AutoData]
        public void ForAttachments_OfDocumentId_Will_Create_A_Valid_Key(int documentId)
        {
            string key = FluentCacheKey.ForAttachments().OfDocumentId(documentId);

            key.Should().Be($"documentid|{documentId}|attachments");
        }

        [Fact]
        public void ForAttachments_All_Will_Create_A_Valid_Key()
        {
            string key = FluentCacheKey.ForAttachments().All();

            key.Should().Be($"cms.attachment|all");
        }

        [Theory, AutoData]
        public void ForObject_OfClassName_WithId_Will_Create_A_Valid_Key(string className, int objectId)
        {
            string key = FluentCacheKey.ForObject().OfClassName(className).WithId(objectId);

            key.Should().Be($"{className}|byid|{objectId}");
        }

        [Theory, AutoData]
        public void ForObject_OfClassName_WithName_Will_Create_A_Valid_Key(string className, string objectName)
        {
            string key = FluentCacheKey.ForObject().OfClassName(className).WithName(objectName);

            key.Should().Be($"{className}|byname|{objectName}");
        }

        [Theory, AutoData]
        public void ForObject_OfClassName_WithGuid_Will_Create_A_Valid_Key(string className, Guid objectGuid)
        {
            string key = FluentCacheKey.ForObject().OfClassName(className).WithGuid(objectGuid);

            key.Should().Be($"{className}|byguid|{objectGuid}");
        }

        [Theory, AutoData]
        public void ForMediaFile_WithGuid_Will_Create_A_Valid_Key(Guid mediaFileGuid)
        {
            string key = FluentCacheKey.ForMediaFile().WithGuid(mediaFileGuid);

            key.Should().Be($"mediafile|{mediaFileGuid}");
        }

        [Theory, AutoData]
        public void ForMediaFile_PreviewWithGuid_Will_Create_A_Valid_Key(Guid mediaFileGuid)
        {
            string key = FluentCacheKey.ForMediaFile().PreviewWithGuid(mediaFileGuid);

            key.Should().Be($"mediafile|preview|{mediaFileGuid}");
        }

        [Theory, AutoData]
        public void ForCustomTable_OfClassName_All_Will_Create_A_Valid_Key(string className)
        {
            string key = FluentCacheKey.ForCustomTable().OfClassName(className).All();

            key.Should().Be($"customtableitem.{className}|all");
        }

        [Theory, AutoData]
        public void ForCustomTable_OfClassName_WithRecordId_Will_Create_A_Valid_Key(string className, int id)
        {
            string key = FluentCacheKey.ForCustomTable().OfClassName(className).WithRecordId(id);

            key.Should().Be($"customtableitem.{className}|byid|{id}");
        }

        [Theory, AutoData]
        public void ForSetting_OfSiteId_WithCodeName_Will_Create_A_Valid_Key(int siteId, string codeName)
        {
            string key = FluentCacheKey.ForSetting().OfSiteId(siteId).WithCodeName(codeName);

            key.Should().Be($"cms.settingskey|{siteId}|{codeName}");
        }

        [Theory, AutoData]
        public void ForSetting_WithCodeName_Will_Create_A_Valid_Key(string codeName)
        {
            string key = FluentCacheKey.ForSetting().WithCodeName(codeName);

            key.Should().Be($"cms.settingskey|{codeName}");
        }
    }
}
