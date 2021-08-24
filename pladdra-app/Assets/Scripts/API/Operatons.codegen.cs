using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace Pladdra.API {

    public class CreateAssetGQL {
      /// <summary>
      /// CreateAssetGQL.Request 
      /// <para>Required variables:<br/> { input=(CreateAssetInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelAssetConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CreateAssetDocument,
          OperationName = "CreateAsset",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCreateAssetGQL() {
        return Request();
      }
      
      public static string CreateAssetDocument = @"
        mutation CreateAsset($input: CreateAssetInput!, $condition: ModelAssetConditionInput) {
          createAsset(input: $input, condition: $condition) {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class UpdateAssetGQL {
      /// <summary>
      /// UpdateAssetGQL.Request 
      /// <para>Required variables:<br/> { input=(UpdateAssetInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelAssetConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = UpdateAssetDocument,
          OperationName = "UpdateAsset",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getUpdateAssetGQL() {
        return Request();
      }
      
      public static string UpdateAssetDocument = @"
        mutation UpdateAsset($input: UpdateAssetInput!, $condition: ModelAssetConditionInput) {
          updateAsset(input: $input, condition: $condition) {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class DeleteAssetGQL {
      /// <summary>
      /// DeleteAssetGQL.Request 
      /// <para>Required variables:<br/> { input=(DeleteAssetInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelAssetConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteAssetDocument,
          OperationName = "DeleteAsset",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getDeleteAssetGQL() {
        return Request();
      }
      
      public static string DeleteAssetDocument = @"
        mutation DeleteAsset($input: DeleteAssetInput!, $condition: ModelAssetConditionInput) {
          deleteAsset(input: $input, condition: $condition) {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class CreateBlockGQL {
      /// <summary>
      /// CreateBlockGQL.Request 
      /// <para>Required variables:<br/> { input=(CreateBlockInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelBlockConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CreateBlockDocument,
          OperationName = "CreateBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCreateBlockGQL() {
        return Request();
      }
      
      public static string CreateBlockDocument = @"
        mutation CreateBlock($input: CreateBlockInput!, $condition: ModelBlockConditionInput) {
          createBlock(input: $input, condition: $condition) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class UpdateBlockGQL {
      /// <summary>
      /// UpdateBlockGQL.Request 
      /// <para>Required variables:<br/> { input=(UpdateBlockInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelBlockConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = UpdateBlockDocument,
          OperationName = "UpdateBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getUpdateBlockGQL() {
        return Request();
      }
      
      public static string UpdateBlockDocument = @"
        mutation UpdateBlock($input: UpdateBlockInput!, $condition: ModelBlockConditionInput) {
          updateBlock(input: $input, condition: $condition) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class DeleteBlockGQL {
      /// <summary>
      /// DeleteBlockGQL.Request 
      /// <para>Required variables:<br/> { input=(DeleteBlockInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelBlockConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteBlockDocument,
          OperationName = "DeleteBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getDeleteBlockGQL() {
        return Request();
      }
      
      public static string DeleteBlockDocument = @"
        mutation DeleteBlock($input: DeleteBlockInput!, $condition: ModelBlockConditionInput) {
          deleteBlock(input: $input, condition: $condition) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class CreateWorkspaceGQL {
      /// <summary>
      /// CreateWorkspaceGQL.Request 
      /// <para>Required variables:<br/> { input=(CreateWorkspaceInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelWorkspaceConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = CreateWorkspaceDocument,
          OperationName = "CreateWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getCreateWorkspaceGQL() {
        return Request();
      }
      
      public static string CreateWorkspaceDocument = @"
        mutation CreateWorkspace($input: CreateWorkspaceInput!, $condition: ModelWorkspaceConditionInput) {
          createWorkspace(input: $input, condition: $condition) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    

    public class UpdateWorkspaceGQL {
      /// <summary>
      /// UpdateWorkspaceGQL.Request 
      /// <para>Required variables:<br/> { input=(UpdateWorkspaceInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelWorkspaceConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = UpdateWorkspaceDocument,
          OperationName = "UpdateWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getUpdateWorkspaceGQL() {
        return Request();
      }
      
      public static string UpdateWorkspaceDocument = @"
        mutation UpdateWorkspace($input: UpdateWorkspaceInput!, $condition: ModelWorkspaceConditionInput) {
          updateWorkspace(input: $input, condition: $condition) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    

    public class DeleteWorkspaceGQL {
      /// <summary>
      /// DeleteWorkspaceGQL.Request 
      /// <para>Required variables:<br/> { input=(DeleteWorkspaceInput) }</para>
      /// <para>Optional variables:<br/> { condition=(ModelWorkspaceConditionInput) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = DeleteWorkspaceDocument,
          OperationName = "DeleteWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getDeleteWorkspaceGQL() {
        return Request();
      }
      
      public static string DeleteWorkspaceDocument = @"
        mutation DeleteWorkspace($input: DeleteWorkspaceInput!, $condition: ModelWorkspaceConditionInput) {
          deleteWorkspace(input: $input, condition: $condition) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    

    public class GetAssetGQL {
      /// <summary>
      /// GetAssetGQL.Request 
      /// <para>Required variables:<br/> { id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetAssetDocument,
          OperationName = "GetAsset",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetAssetGQL() {
        return Request();
      }
      
      public static string GetAssetDocument = @"
        query GetAsset($id: ID!) {
          getAsset(id: $id) {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class ListAssetsGQL {
      /// <summary>
      /// ListAssetsGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { filter=(ModelAssetFilterInput), limit=(int), nextToken=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = ListAssetsDocument,
          OperationName = "ListAssets",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getListAssetsGQL() {
        return Request();
      }
      
      public static string ListAssetsDocument = @"
        query ListAssets($filter: ModelAssetFilterInput, $limit: Int, $nextToken: String) {
          listAssets(filter: $filter, limit: $limit, nextToken: $nextToken) {
            items {
              id
              name
              type
              fileFormat
              fileName
              fileSize
              file {
                bucket
                key
                region
              }
              description
              createdAt
              updatedAt
            }
            nextToken
          }
        }
        ";
      
    }
    

    public class AssetsByFileFormatGQL {
      /// <summary>
      /// AssetsByFileFormatGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { fileFormat=(AssetFileFormat), createdAtUpdatedAt=(ModelAssetByFileFormatCompositeKeyConditionInput), sortDirection=(ModelSortDirection), filter=(ModelAssetFilterInput), limit=(int), nextToken=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = AssetsByFileFormatDocument,
          OperationName = "AssetsByFileFormat",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getAssetsByFileFormatGQL() {
        return Request();
      }
      
      public static string AssetsByFileFormatDocument = @"
        query AssetsByFileFormat($fileFormat: AssetFileFormat, $createdAtUpdatedAt: ModelAssetByFileFormatCompositeKeyConditionInput, $sortDirection: ModelSortDirection, $filter: ModelAssetFilterInput, $limit: Int, $nextToken: String) {
          assetsByFileFormat(
            fileFormat: $fileFormat
            createdAtUpdatedAt: $createdAtUpdatedAt
            sortDirection: $sortDirection
            filter: $filter
            limit: $limit
            nextToken: $nextToken
          ) {
            items {
              id
              name
              type
              fileFormat
              fileName
              fileSize
              file {
                bucket
                key
                region
              }
              description
              createdAt
              updatedAt
            }
            nextToken
          }
        }
        ";
      
    }
    

    public class GetBlockGQL {
      /// <summary>
      /// GetBlockGQL.Request 
      /// <para>Required variables:<br/> { id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetBlockDocument,
          OperationName = "GetBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetBlockGQL() {
        return Request();
      }
      
      public static string GetBlockDocument = @"
        query GetBlock($id: ID!) {
          getBlock(id: $id) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class ListBlocksGQL {
      /// <summary>
      /// ListBlocksGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { filter=(ModelBlockFilterInput), limit=(int), nextToken=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = ListBlocksDocument,
          OperationName = "ListBlocks",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getListBlocksGQL() {
        return Request();
      }
      
      public static string ListBlocksDocument = @"
        query ListBlocks($filter: ModelBlockFilterInput, $limit: Int, $nextToken: String) {
          listBlocks(filter: $filter, limit: $limit, nextToken: $nextToken) {
            items {
              id
              createdAt
              updatedAt
              workspaceID
              assetID
              position {
                x
                y
                z
              }
              rotation {
                x
                y
                z
                w
              }
              owner
            }
            nextToken
          }
        }
        ";
      
    }
    

    public class GetWorkspaceGQL {
      /// <summary>
      /// GetWorkspaceGQL.Request 
      /// <para>Required variables:<br/> { id=(string) }</para>
      /// <para>Optional variables:<br/> {  }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = GetWorkspaceDocument,
          OperationName = "GetWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getGetWorkspaceGQL() {
        return Request();
      }
      
      public static string GetWorkspaceDocument = @"
        query GetWorkspace($id: ID!) {
          getWorkspace(id: $id) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    

    public class ListWorkspacesGQL {
      /// <summary>
      /// ListWorkspacesGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { filter=(ModelWorkspaceFilterInput), limit=(int), nextToken=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = ListWorkspacesDocument,
          OperationName = "ListWorkspaces",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getListWorkspacesGQL() {
        return Request();
      }
      
      public static string ListWorkspacesDocument = @"
        query ListWorkspaces($filter: ModelWorkspaceFilterInput, $limit: Int, $nextToken: String) {
          listWorkspaces(filter: $filter, limit: $limit, nextToken: $nextToken) {
            items {
              id
              name
              createdAt
              updatedAt
              description
              blocks {
                nextToken
              }
              owner
            }
            nextToken
          }
        }
        ";
      
    }
    

    public class OnCreateAssetGQL {
      /// <summary>
      /// OnCreateAssetGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = OnCreateAssetDocument,
          OperationName = "OnCreateAsset"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnCreateAssetGQL() {
        return Request();
      }
      
      public static string OnCreateAssetDocument = @"
        subscription OnCreateAsset {
          onCreateAsset {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class OnUpdateAssetGQL {
      /// <summary>
      /// OnUpdateAssetGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = OnUpdateAssetDocument,
          OperationName = "OnUpdateAsset"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnUpdateAssetGQL() {
        return Request();
      }
      
      public static string OnUpdateAssetDocument = @"
        subscription OnUpdateAsset {
          onUpdateAsset {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class OnDeleteAssetGQL {
      /// <summary>
      /// OnDeleteAssetGQL.Request 
      /// </summary>
      public static GraphQLRequest Request() {
        return new GraphQLRequest {
          Query = OnDeleteAssetDocument,
          OperationName = "OnDeleteAsset"
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnDeleteAssetGQL() {
        return Request();
      }
      
      public static string OnDeleteAssetDocument = @"
        subscription OnDeleteAsset {
          onDeleteAsset {
            id
            name
            type
            fileFormat
            fileName
            fileSize
            file {
              bucket
              key
              region
            }
            description
            createdAt
            updatedAt
          }
        }
        ";
      
    }
    

    public class OnCreateBlockGQL {
      /// <summary>
      /// OnCreateBlockGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { owner=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = OnCreateBlockDocument,
          OperationName = "OnCreateBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnCreateBlockGQL() {
        return Request();
      }
      
      public static string OnCreateBlockDocument = @"
        subscription OnCreateBlock($owner: String) {
          onCreateBlock(owner: $owner) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class OnUpdateBlockGQL {
      /// <summary>
      /// OnUpdateBlockGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { owner=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = OnUpdateBlockDocument,
          OperationName = "OnUpdateBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnUpdateBlockGQL() {
        return Request();
      }
      
      public static string OnUpdateBlockDocument = @"
        subscription OnUpdateBlock($owner: String) {
          onUpdateBlock(owner: $owner) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class OnDeleteBlockGQL {
      /// <summary>
      /// OnDeleteBlockGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { owner=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = OnDeleteBlockDocument,
          OperationName = "OnDeleteBlock",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnDeleteBlockGQL() {
        return Request();
      }
      
      public static string OnDeleteBlockDocument = @"
        subscription OnDeleteBlock($owner: String) {
          onDeleteBlock(owner: $owner) {
            id
            createdAt
            updatedAt
            workspaceID
            assetID
            position {
              x
              y
              z
            }
            rotation {
              x
              y
              z
              w
            }
            owner
          }
        }
        ";
      
    }
    

    public class OnCreateWorkspaceGQL {
      /// <summary>
      /// OnCreateWorkspaceGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { owner=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = OnCreateWorkspaceDocument,
          OperationName = "OnCreateWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnCreateWorkspaceGQL() {
        return Request();
      }
      
      public static string OnCreateWorkspaceDocument = @"
        subscription OnCreateWorkspace($owner: String) {
          onCreateWorkspace(owner: $owner) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    

    public class OnUpdateWorkspaceGQL {
      /// <summary>
      /// OnUpdateWorkspaceGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { owner=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = OnUpdateWorkspaceDocument,
          OperationName = "OnUpdateWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnUpdateWorkspaceGQL() {
        return Request();
      }
      
      public static string OnUpdateWorkspaceDocument = @"
        subscription OnUpdateWorkspace($owner: String) {
          onUpdateWorkspace(owner: $owner) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    

    public class OnDeleteWorkspaceGQL {
      /// <summary>
      /// OnDeleteWorkspaceGQL.Request 
      /// <para>Required variables:<br/> {  }</para>
      /// <para>Optional variables:<br/> { owner=(string) }</para>
      /// </summary>
      public static GraphQLRequest Request(object variables = null) {
        return new GraphQLRequest {
          Query = OnDeleteWorkspaceDocument,
          OperationName = "OnDeleteWorkspace",
          Variables = variables
        };
      }

      /// <remarks>This method is obsolete. Use Request instead.</remarks>
      public static GraphQLRequest getOnDeleteWorkspaceGQL() {
        return Request();
      }
      
      public static string OnDeleteWorkspaceDocument = @"
        subscription OnDeleteWorkspace($owner: String) {
          onDeleteWorkspace(owner: $owner) {
            id
            name
            createdAt
            updatedAt
            description
            blocks {
              items {
                id
                createdAt
                updatedAt
                workspaceID
                assetID
                owner
              }
              nextToken
            }
            owner
          }
        }
        ";
      
    }
    
}