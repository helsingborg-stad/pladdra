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
            
      public class Variables {
      
        [JsonProperty("input")]
        public CreateAssetInput input { get; set; }
        
        [JsonProperty("condition")]
        public ModelAssetConditionInput condition { get; set; }
        
      }
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("createAsset")]
        public AssetSelection createAsset { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
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
            
      public class Variables {
      
        [JsonProperty("input")]
        public UpdateAssetInput input { get; set; }
        
        [JsonProperty("condition")]
        public ModelAssetConditionInput condition { get; set; }
        
      }
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("updateAsset")]
        public AssetSelection updateAsset { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
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
            
      public class Variables {
      
        [JsonProperty("input")]
        public DeleteAssetInput input { get; set; }
        
        [JsonProperty("condition")]
        public ModelAssetConditionInput condition { get; set; }
        
      }
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("deleteAsset")]
        public AssetSelection deleteAsset { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendMutationAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendMutationAsync<Response>(Request(variables), cancellationToken);
      }
      
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
            
      public class Variables {
      
        [JsonProperty("id")]
        public string id { get; set; }
        
      }
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("getAsset")]
        public AssetSelection getAsset { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
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
            
      public class Variables {
      
        [JsonProperty("filter")]
        public ModelAssetFilterInput filter { get; set; }
        
        [JsonProperty("limit")]
        public int? limit { get; set; }
        
        [JsonProperty("nextToken")]
        public string nextToken { get; set; }
        
      }
      
      public class Response {
      
        public class ModelAssetConnectionSelection {
        
          public class AssetSelection {
          
            [JsonProperty("id")]
            public string id { get; set; }
            
            [JsonProperty("name")]
            public string name { get; set; }
            
            [JsonProperty("type")]
            public AssetType type { get; set; }
            
            [JsonProperty("fileFormat")]
            public AssetFileFormat fileFormat { get; set; }
            
            [JsonProperty("fileName")]
            public string fileName { get; set; }
            
            [JsonProperty("fileSize")]
            public int fileSize { get; set; }
            
            public class S3ObjectSelection {
            
              [JsonProperty("bucket")]
              public string bucket { get; set; }
              
              [JsonProperty("key")]
              public string key { get; set; }
              
              [JsonProperty("region")]
              public string region { get; set; }
              
            }
            
            [JsonProperty("file")]
            public S3ObjectSelection file { get; set; }
            
            [JsonProperty("description")]
            public string description { get; set; }
            
            [JsonProperty("createdAt")]
            public string createdAt { get; set; }
            
            [JsonProperty("updatedAt")]
            public string updatedAt { get; set; }
            
          }
          
          [JsonProperty("items")]
          public System.Collections.Generic.List<AssetSelection> items { get; set; }
          
          [JsonProperty("nextToken")]
          public string nextToken { get; set; }
          
        }
        
        [JsonProperty("listAssets")]
        public ModelAssetConnectionSelection listAssets { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
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
            
      public class Variables {
      
        [JsonProperty("fileFormat")]
        public AssetFileFormat? fileFormat { get; set; }
        
        [JsonProperty("createdAtUpdatedAt")]
        public ModelAssetByFileFormatCompositeKeyConditionInput createdAtUpdatedAt { get; set; }
        
        [JsonProperty("sortDirection")]
        public ModelSortDirection? sortDirection { get; set; }
        
        [JsonProperty("filter")]
        public ModelAssetFilterInput filter { get; set; }
        
        [JsonProperty("limit")]
        public int? limit { get; set; }
        
        [JsonProperty("nextToken")]
        public string nextToken { get; set; }
        
      }
      
      public class Response {
      
        public class ModelAssetConnectionSelection {
        
          public class AssetSelection {
          
            [JsonProperty("id")]
            public string id { get; set; }
            
            [JsonProperty("name")]
            public string name { get; set; }
            
            [JsonProperty("type")]
            public AssetType type { get; set; }
            
            [JsonProperty("fileFormat")]
            public AssetFileFormat fileFormat { get; set; }
            
            [JsonProperty("fileName")]
            public string fileName { get; set; }
            
            [JsonProperty("fileSize")]
            public int fileSize { get; set; }
            
            public class S3ObjectSelection {
            
              [JsonProperty("bucket")]
              public string bucket { get; set; }
              
              [JsonProperty("key")]
              public string key { get; set; }
              
              [JsonProperty("region")]
              public string region { get; set; }
              
            }
            
            [JsonProperty("file")]
            public S3ObjectSelection file { get; set; }
            
            [JsonProperty("description")]
            public string description { get; set; }
            
            [JsonProperty("createdAt")]
            public string createdAt { get; set; }
            
            [JsonProperty("updatedAt")]
            public string updatedAt { get; set; }
            
          }
          
          [JsonProperty("items")]
          public System.Collections.Generic.List<AssetSelection> items { get; set; }
          
          [JsonProperty("nextToken")]
          public string nextToken { get; set; }
          
        }
        
        [JsonProperty("assetsByFileFormat")]
        public ModelAssetConnectionSelection assetsByFileFormat { get; set; }
        
      }
      
      public static System.Threading.Tasks.Task<GraphQLResponse<Response>> SendQueryAsync(IGraphQLClient client, Variables variables, System.Threading.CancellationToken cancellationToken = default) {
        return client.SendQueryAsync<Response>(Request(variables), cancellationToken);
      }
      
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
            
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("onCreateAsset")]
        public AssetSelection onCreateAsset { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
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
            
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("onUpdateAsset")]
        public AssetSelection onUpdateAsset { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
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
            
      
      public class Response {
      
        public class AssetSelection {
        
          [JsonProperty("id")]
          public string id { get; set; }
          
          [JsonProperty("name")]
          public string name { get; set; }
          
          [JsonProperty("type")]
          public AssetType type { get; set; }
          
          [JsonProperty("fileFormat")]
          public AssetFileFormat fileFormat { get; set; }
          
          [JsonProperty("fileName")]
          public string fileName { get; set; }
          
          [JsonProperty("fileSize")]
          public int fileSize { get; set; }
          
          public class S3ObjectSelection {
          
            [JsonProperty("bucket")]
            public string bucket { get; set; }
            
            [JsonProperty("key")]
            public string key { get; set; }
            
            [JsonProperty("region")]
            public string region { get; set; }
            
          }
          
          [JsonProperty("file")]
          public S3ObjectSelection file { get; set; }
          
          [JsonProperty("description")]
          public string description { get; set; }
          
          [JsonProperty("createdAt")]
          public string createdAt { get; set; }
          
          [JsonProperty("updatedAt")]
          public string updatedAt { get; set; }
          
        }
        
        [JsonProperty("onDeleteAsset")]
        public AssetSelection onDeleteAsset { get; set; }
        
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client) {
        return client.CreateSubscriptionStream<Response>(Request());
      }
      
      public static System.IObservable<GraphQLResponse<Response>> CreateSubscriptionStream(IGraphQLClient client, System.Action<System.Exception> exceptionHandler) {
        return client.CreateSubscriptionStream<Response>(Request(), exceptionHandler);
      }
      
    }
    
    public enum AssetFileFormat {
      GLTF,
      GLB,
      OBJ,
      FBX,
      DWG
    }
    
    public enum AssetType {
      MESH
    }
    
    public class CreateAssetInput {
    
      [JsonProperty("id")]
      public string id { get; set; }
      
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("type")]
      public AssetType type { get; set; }
      
      [JsonProperty("fileFormat")]
      public AssetFileFormat fileFormat { get; set; }
      
      [JsonProperty("fileName")]
      public string fileName { get; set; }
      
      [JsonProperty("fileSize")]
      public int fileSize { get; set; }
      
      [JsonProperty("file")]
      public S3ObjectInput file { get; set; }
      
      [JsonProperty("description")]
      public string description { get; set; }
      
    }
    
    public class DeleteAssetInput {
    
      [JsonProperty("id")]
      public string id { get; set; }
      
    }
    
    public class ModelAssetByFileFormatCompositeKeyConditionInput {
    
      [JsonProperty("eq")]
      public ModelAssetByFileFormatCompositeKeyInput eq { get; set; }
      
      [JsonProperty("le")]
      public ModelAssetByFileFormatCompositeKeyInput le { get; set; }
      
      [JsonProperty("lt")]
      public ModelAssetByFileFormatCompositeKeyInput lt { get; set; }
      
      [JsonProperty("ge")]
      public ModelAssetByFileFormatCompositeKeyInput ge { get; set; }
      
      [JsonProperty("gt")]
      public ModelAssetByFileFormatCompositeKeyInput gt { get; set; }
      
      [JsonProperty("between")]
      public System.Collections.Generic.List<ModelAssetByFileFormatCompositeKeyInput> between { get; set; }
      
      [JsonProperty("beginsWith")]
      public ModelAssetByFileFormatCompositeKeyInput beginsWith { get; set; }
      
    }
    
    public class ModelAssetByFileFormatCompositeKeyInput {
    
      [JsonProperty("createdAt")]
      public string createdAt { get; set; }
      
      [JsonProperty("updatedAt")]
      public string updatedAt { get; set; }
      
    }
    
    public class ModelAssetConditionInput {
    
      [JsonProperty("name")]
      public ModelStringInput name { get; set; }
      
      [JsonProperty("type")]
      public ModelAssetTypeInput type { get; set; }
      
      [JsonProperty("fileFormat")]
      public ModelAssetFileFormatInput fileFormat { get; set; }
      
      [JsonProperty("fileName")]
      public ModelStringInput fileName { get; set; }
      
      [JsonProperty("fileSize")]
      public ModelIntInput fileSize { get; set; }
      
      [JsonProperty("description")]
      public ModelStringInput description { get; set; }
      
      [JsonProperty("createdAt")]
      public ModelStringInput createdAt { get; set; }
      
      [JsonProperty("updatedAt")]
      public ModelStringInput updatedAt { get; set; }
      
      [JsonProperty("and")]
      public System.Collections.Generic.List<ModelAssetConditionInput> and { get; set; }
      
      [JsonProperty("or")]
      public System.Collections.Generic.List<ModelAssetConditionInput> or { get; set; }
      
      [JsonProperty("not")]
      public ModelAssetConditionInput not { get; set; }
      
    }
    
    public class ModelAssetFileFormatInput {
    
      [JsonProperty("eq")]
      public AssetFileFormat? eq { get; set; }
      
      [JsonProperty("ne")]
      public AssetFileFormat? ne { get; set; }
      
    }
    
    public class ModelAssetFilterInput {
    
      [JsonProperty("id")]
      public ModelIdInput id { get; set; }
      
      [JsonProperty("name")]
      public ModelStringInput name { get; set; }
      
      [JsonProperty("type")]
      public ModelAssetTypeInput type { get; set; }
      
      [JsonProperty("fileFormat")]
      public ModelAssetFileFormatInput fileFormat { get; set; }
      
      [JsonProperty("fileName")]
      public ModelStringInput fileName { get; set; }
      
      [JsonProperty("fileSize")]
      public ModelIntInput fileSize { get; set; }
      
      [JsonProperty("description")]
      public ModelStringInput description { get; set; }
      
      [JsonProperty("createdAt")]
      public ModelStringInput createdAt { get; set; }
      
      [JsonProperty("updatedAt")]
      public ModelStringInput updatedAt { get; set; }
      
      [JsonProperty("and")]
      public System.Collections.Generic.List<ModelAssetFilterInput> and { get; set; }
      
      [JsonProperty("or")]
      public System.Collections.Generic.List<ModelAssetFilterInput> or { get; set; }
      
      [JsonProperty("not")]
      public ModelAssetFilterInput not { get; set; }
      
    }
    
    public class ModelAssetTypeInput {
    
      [JsonProperty("eq")]
      public AssetType? eq { get; set; }
      
      [JsonProperty("ne")]
      public AssetType? ne { get; set; }
      
    }
    
    public enum ModelAttributeTypes {
      binary,
      binarySet,
      bool,
      list,
      map,
      number,
      numberSet,
      string,
      stringSet,
      _null
    }
    
    public class ModelBooleanInput {
    
      [JsonProperty("ne")]
      public bool? ne { get; set; }
      
      [JsonProperty("eq")]
      public bool? eq { get; set; }
      
      [JsonProperty("attributeExists")]
      public bool? attributeExists { get; set; }
      
      [JsonProperty("attributeType")]
      public ModelAttributeTypes? attributeType { get; set; }
      
    }
    
    public class ModelFloatInput {
    
      [JsonProperty("ne")]
      public double? ne { get; set; }
      
      [JsonProperty("eq")]
      public double? eq { get; set; }
      
      [JsonProperty("le")]
      public double? le { get; set; }
      
      [JsonProperty("lt")]
      public double? lt { get; set; }
      
      [JsonProperty("ge")]
      public double? ge { get; set; }
      
      [JsonProperty("gt")]
      public double? gt { get; set; }
      
      [JsonProperty("between")]
      public System.Collections.Generic.List<double?> between { get; set; }
      
      [JsonProperty("attributeExists")]
      public bool? attributeExists { get; set; }
      
      [JsonProperty("attributeType")]
      public ModelAttributeTypes? attributeType { get; set; }
      
    }
    
    public class ModelIdInput {
    
      [JsonProperty("ne")]
      public string ne { get; set; }
      
      [JsonProperty("eq")]
      public string eq { get; set; }
      
      [JsonProperty("le")]
      public string le { get; set; }
      
      [JsonProperty("lt")]
      public string lt { get; set; }
      
      [JsonProperty("ge")]
      public string ge { get; set; }
      
      [JsonProperty("gt")]
      public string gt { get; set; }
      
      [JsonProperty("contains")]
      public string contains { get; set; }
      
      [JsonProperty("notContains")]
      public string notContains { get; set; }
      
      [JsonProperty("between")]
      public System.Collections.Generic.List<string> between { get; set; }
      
      [JsonProperty("beginsWith")]
      public string beginsWith { get; set; }
      
      [JsonProperty("attributeExists")]
      public bool? attributeExists { get; set; }
      
      [JsonProperty("attributeType")]
      public ModelAttributeTypes? attributeType { get; set; }
      
      [JsonProperty("size")]
      public ModelSizeInput size { get; set; }
      
    }
    
    public class ModelIntInput {
    
      [JsonProperty("ne")]
      public int? ne { get; set; }
      
      [JsonProperty("eq")]
      public int? eq { get; set; }
      
      [JsonProperty("le")]
      public int? le { get; set; }
      
      [JsonProperty("lt")]
      public int? lt { get; set; }
      
      [JsonProperty("ge")]
      public int? ge { get; set; }
      
      [JsonProperty("gt")]
      public int? gt { get; set; }
      
      [JsonProperty("between")]
      public System.Collections.Generic.List<int?> between { get; set; }
      
      [JsonProperty("attributeExists")]
      public bool? attributeExists { get; set; }
      
      [JsonProperty("attributeType")]
      public ModelAttributeTypes? attributeType { get; set; }
      
    }
    
    public class ModelSizeInput {
    
      [JsonProperty("ne")]
      public int? ne { get; set; }
      
      [JsonProperty("eq")]
      public int? eq { get; set; }
      
      [JsonProperty("le")]
      public int? le { get; set; }
      
      [JsonProperty("lt")]
      public int? lt { get; set; }
      
      [JsonProperty("ge")]
      public int? ge { get; set; }
      
      [JsonProperty("gt")]
      public int? gt { get; set; }
      
      [JsonProperty("between")]
      public System.Collections.Generic.List<int?> between { get; set; }
      
    }
    
    public enum ModelSortDirection {
      ASC,
      DESC
    }
    
    public class ModelStringInput {
    
      [JsonProperty("ne")]
      public string ne { get; set; }
      
      [JsonProperty("eq")]
      public string eq { get; set; }
      
      [JsonProperty("le")]
      public string le { get; set; }
      
      [JsonProperty("lt")]
      public string lt { get; set; }
      
      [JsonProperty("ge")]
      public string ge { get; set; }
      
      [JsonProperty("gt")]
      public string gt { get; set; }
      
      [JsonProperty("contains")]
      public string contains { get; set; }
      
      [JsonProperty("notContains")]
      public string notContains { get; set; }
      
      [JsonProperty("between")]
      public System.Collections.Generic.List<string> between { get; set; }
      
      [JsonProperty("beginsWith")]
      public string beginsWith { get; set; }
      
      [JsonProperty("attributeExists")]
      public bool? attributeExists { get; set; }
      
      [JsonProperty("attributeType")]
      public ModelAttributeTypes? attributeType { get; set; }
      
      [JsonProperty("size")]
      public ModelSizeInput size { get; set; }
      
    }
    
    public class S3ObjectInput {
    
      [JsonProperty("bucket")]
      public string bucket { get; set; }
      
      [JsonProperty("key")]
      public string key { get; set; }
      
      [JsonProperty("region")]
      public string region { get; set; }
      
      [JsonProperty("localUri")]
      public string localUri { get; set; }
      
      [JsonProperty("mimeType")]
      public string mimeType { get; set; }
      
      [JsonProperty("url")]
      public string url { get; set; }
      
      [JsonProperty("_url")]
      public string _url { get; set; }
      
    }
    
    public class UpdateAssetInput {
    
      [JsonProperty("id")]
      public string id { get; set; }
      
      [JsonProperty("name")]
      public string name { get; set; }
      
      [JsonProperty("type")]
      public AssetType? type { get; set; }
      
      [JsonProperty("fileFormat")]
      public AssetFileFormat? fileFormat { get; set; }
      
      [JsonProperty("fileName")]
      public string fileName { get; set; }
      
      [JsonProperty("fileSize")]
      public int? fileSize { get; set; }
      
      [JsonProperty("file")]
      public S3ObjectInput file { get; set; }
      
      [JsonProperty("description")]
      public string description { get; set; }
      
      [JsonProperty("createdAt")]
      public string createdAt { get; set; }
      
      [JsonProperty("updatedAt")]
      public string updatedAt { get; set; }
      
    }
    
}