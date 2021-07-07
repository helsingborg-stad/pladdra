using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace Pladdra {

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
    
}