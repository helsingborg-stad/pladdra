using Newtonsoft.Json;
using GraphQL;
using GraphQL.Client.Abstractions;

namespace Pladdra.GraphQL
{

    public class CreateAssetGQL
    {
        /// <summary>
        /// CreateAssetGQL.Request 
        /// <para>Required variables:<br/> { input=(CreateAssetInput) }</para>
        /// <para>Optional variables:<br/> { condition=(ModelAssetConditionInput) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = CreateAssetDocument,
                OperationName = "CreateAsset",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getCreateAssetGQL()
        {
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


    public class UpdateAssetGQL
    {
        /// <summary>
        /// UpdateAssetGQL.Request 
        /// <para>Required variables:<br/> { input=(UpdateAssetInput) }</para>
        /// <para>Optional variables:<br/> { condition=(ModelAssetConditionInput) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = UpdateAssetDocument,
                OperationName = "UpdateAsset",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getUpdateAssetGQL()
        {
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


    public class DeleteAssetGQL
    {
        /// <summary>
        /// DeleteAssetGQL.Request 
        /// <para>Required variables:<br/> { input=(DeleteAssetInput) }</para>
        /// <para>Optional variables:<br/> { condition=(ModelAssetConditionInput) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = DeleteAssetDocument,
                OperationName = "DeleteAsset",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getDeleteAssetGQL()
        {
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


    public class CreateTodoGQL
    {
        /// <summary>
        /// CreateTodoGQL.Request 
        /// <para>Required variables:<br/> { input=(CreateTodoInput) }</para>
        /// <para>Optional variables:<br/> { condition=(ModelTodoConditionInput) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = CreateTodoDocument,
                OperationName = "CreateTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getCreateTodoGQL()
        {
            return Request();
        }

        public static string CreateTodoDocument = @"
        mutation CreateTodo($input: CreateTodoInput!, $condition: ModelTodoConditionInput) {
          createTodo(input: $input, condition: $condition) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class UpdateTodoGQL
    {
        /// <summary>
        /// UpdateTodoGQL.Request 
        /// <para>Required variables:<br/> { input=(UpdateTodoInput) }</para>
        /// <para>Optional variables:<br/> { condition=(ModelTodoConditionInput) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = UpdateTodoDocument,
                OperationName = "UpdateTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getUpdateTodoGQL()
        {
            return Request();
        }

        public static string UpdateTodoDocument = @"
        mutation UpdateTodo($input: UpdateTodoInput!, $condition: ModelTodoConditionInput) {
          updateTodo(input: $input, condition: $condition) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class DeleteTodoGQL
    {
        /// <summary>
        /// DeleteTodoGQL.Request 
        /// <para>Required variables:<br/> { input=(DeleteTodoInput) }</para>
        /// <para>Optional variables:<br/> { condition=(ModelTodoConditionInput) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = DeleteTodoDocument,
                OperationName = "DeleteTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getDeleteTodoGQL()
        {
            return Request();
        }

        public static string DeleteTodoDocument = @"
        mutation DeleteTodo($input: DeleteTodoInput!, $condition: ModelTodoConditionInput) {
          deleteTodo(input: $input, condition: $condition) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class GetTodoGQL
    {
        /// <summary>
        /// GetTodoGQL.Request 
        /// <para>Required variables:<br/> { id=(string) }</para>
        /// <para>Optional variables:<br/> {  }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = GetTodoDocument,
                OperationName = "GetTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getGetTodoGQL()
        {
            return Request();
        }

        public static string GetTodoDocument = @"
        query GetTodo($id: ID!) {
          getTodo(id: $id) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class ListTodosGQL
    {
        /// <summary>
        /// ListTodosGQL.Request 
        /// <para>Required variables:<br/> {  }</para>
        /// <para>Optional variables:<br/> { filter=(ModelTodoFilterInput), limit=(int), nextToken=(string) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = ListTodosDocument,
                OperationName = "ListTodos",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getListTodosGQL()
        {
            return Request();
        }

        public static string ListTodosDocument = @"
        query ListTodos($filter: ModelTodoFilterInput, $limit: Int, $nextToken: String) {
          listTodos(filter: $filter, limit: $limit, nextToken: $nextToken) {
            items {
              id
              name
              description
              createdAt
              updatedAt
              owner
            }
            nextToken
          }
        }
        ";

    }


    public class GetAssetGQL
    {
        /// <summary>
        /// GetAssetGQL.Request 
        /// <para>Required variables:<br/> { id=(string) }</para>
        /// <para>Optional variables:<br/> {  }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = GetAssetDocument,
                OperationName = "GetAsset",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getGetAssetGQL()
        {
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


    public class ListAssetsGQL
    {
        /// <summary>
        /// ListAssetsGQL.Request 
        /// <para>Required variables:<br/> {  }</para>
        /// <para>Optional variables:<br/> { filter=(ModelAssetFilterInput), limit=(int), nextToken=(string) }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = ListAssetsDocument,
                OperationName = "ListAssets",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getListAssetsGQL()
        {
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
              description
              createdAt
              updatedAt
            }
            nextToken
          }
        }
        ";

    }


    public class OnCreateTodoGQL
    {
        /// <summary>
        /// OnCreateTodoGQL.Request 
        /// <para>Required variables:<br/> { owner=(string) }</para>
        /// <para>Optional variables:<br/> {  }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = OnCreateTodoDocument,
                OperationName = "OnCreateTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getOnCreateTodoGQL()
        {
            return Request();
        }

        public static string OnCreateTodoDocument = @"
        subscription OnCreateTodo($owner: String!) {
          onCreateTodo(owner: $owner) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class OnUpdateTodoGQL
    {
        /// <summary>
        /// OnUpdateTodoGQL.Request 
        /// <para>Required variables:<br/> { owner=(string) }</para>
        /// <para>Optional variables:<br/> {  }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = OnUpdateTodoDocument,
                OperationName = "OnUpdateTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getOnUpdateTodoGQL()
        {
            return Request();
        }

        public static string OnUpdateTodoDocument = @"
        subscription OnUpdateTodo($owner: String!) {
          onUpdateTodo(owner: $owner) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class OnDeleteTodoGQL
    {
        /// <summary>
        /// OnDeleteTodoGQL.Request 
        /// <para>Required variables:<br/> { owner=(string) }</para>
        /// <para>Optional variables:<br/> {  }</para>
        /// </summary>
        public static GraphQLRequest Request(object variables = null)
        {
            return new GraphQLRequest
            {
                Query = OnDeleteTodoDocument,
                OperationName = "OnDeleteTodo",
                Variables = variables
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getOnDeleteTodoGQL()
        {
            return Request();
        }

        public static string OnDeleteTodoDocument = @"
        subscription OnDeleteTodo($owner: String!) {
          onDeleteTodo(owner: $owner) {
            id
            name
            description
            image {
              bucket
              key
              region
            }
            createdAt
            updatedAt
            owner
          }
        }
        ";

    }


    public class OnCreateAssetGQL
    {
        /// <summary>
        /// OnCreateAssetGQL.Request 
        /// </summary>
        public static GraphQLRequest Request()
        {
            return new GraphQLRequest
            {
                Query = OnCreateAssetDocument,
                OperationName = "OnCreateAsset"
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getOnCreateAssetGQL()
        {
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


    public class OnUpdateAssetGQL
    {
        /// <summary>
        /// OnUpdateAssetGQL.Request 
        /// </summary>
        public static GraphQLRequest Request()
        {
            return new GraphQLRequest
            {
                Query = OnUpdateAssetDocument,
                OperationName = "OnUpdateAsset"
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getOnUpdateAssetGQL()
        {
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


    public class OnDeleteAssetGQL
    {
        /// <summary>
        /// OnDeleteAssetGQL.Request 
        /// </summary>
        public static GraphQLRequest Request()
        {
            return new GraphQLRequest
            {
                Query = OnDeleteAssetDocument,
                OperationName = "OnDeleteAsset"
            };
        }

        /// <remarks>This method is obsolete. Use Request instead.</remarks>
        public static GraphQLRequest getOnDeleteAssetGQL()
        {
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