using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using GraphQL;

namespace Pladdra.API
{
    public class Types
    {

        #region Asset
        public class Asset
        {
            #region members
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
            public S3Object file { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }

            [JsonProperty("createdAt")]
            public string createdAt { get; set; }

            [JsonProperty("updatedAt")]
            public string updatedAt { get; set; }
            #endregion
        }
        #endregion
        public enum AssetFileFormat
        {
            GLTF,
            GLB,
            OBJ,
            FBX,
            DWG
        }

        public enum AssetType
        {
            MESH
        }


        #region CreateAssetInput
        public class CreateAssetInput
        {
            #region members
            public string id { get; set; }

            [JsonRequired]
            public string name { get; set; }

            [JsonRequired]
            public AssetType type { get; set; }

            [JsonRequired]
            public AssetFileFormat fileFormat { get; set; }

            [JsonRequired]
            public string fileName { get; set; }

            [JsonRequired]
            public int fileSize { get; set; }

            [JsonRequired]
            public S3ObjectInput file { get; set; }

            public string description { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region CreateTodoInput
        public class CreateTodoInput
        {
            #region members
            public string id { get; set; }

            [JsonRequired]
            public string name { get; set; }

            public string description { get; set; }

            public S3ObjectInput image { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region DeleteAssetInput
        public class DeleteAssetInput
        {
            #region members
            [JsonRequired]
            public string id { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region DeleteTodoInput
        public class DeleteTodoInput
        {
            #region members
            [JsonRequired]
            public string id { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ListTodoQuery
        public class ListTodoQuery
        {
            #region members
            public string id { get; set; }

            [JsonRequired]
            public string name { get; set; }

            public string description { get; set; }

            public S3ObjectInput image { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelAssetConditionInput
        public class ModelAssetConditionInput
        {
            #region members
            public ModelStringInput name { get; set; }

            public ModelAssetTypeInput type { get; set; }

            public ModelAssetFileFormatInput fileFormat { get; set; }

            public ModelStringInput fileName { get; set; }

            public ModelIntInput fileSize { get; set; }

            public ModelStringInput description { get; set; }

            public List<ModelAssetConditionInput> and { get; set; }

            public List<ModelAssetConditionInput> or { get; set; }

            public ModelAssetConditionInput not { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelAssetConnection
        public class ModelAssetConnection
        {
            #region members
            [JsonProperty("items")]
            public List<Asset> items { get; set; }

            [JsonProperty("nextToken")]
            public string nextToken { get; set; }
            #endregion
        }
        #endregion

        #region ModelAssetFileFormatInput
        public class ModelAssetFileFormatInput
        {
            #region members
            public AssetFileFormat? eq { get; set; }

            public AssetFileFormat? ne { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelAssetFilterInput
        public class ModelAssetFilterInput
        {
            #region members
            public ModelIdInput id { get; set; }

            public ModelStringInput name { get; set; }

            public ModelAssetTypeInput type { get; set; }

            public ModelAssetFileFormatInput fileFormat { get; set; }

            public ModelStringInput fileName { get; set; }

            public ModelIntInput fileSize { get; set; }

            public ModelStringInput description { get; set; }

            public List<ModelAssetFilterInput> and { get; set; }

            public List<ModelAssetFilterInput> or { get; set; }

            public ModelAssetFilterInput not { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelAssetTypeInput
        public class ModelAssetTypeInput
        {
            #region members
            public AssetType? eq { get; set; }

            public AssetType? ne { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion
        public enum ModelAttributeTypes
        {
            binary,
            binarySet,
            @bool,
            list,
            map,
            number,
            numberSet,
            @string,
            stringSet,
            _null
        }


        #region ModelBooleanInput
        public class ModelBooleanInput
        {
            #region members
            public bool? ne { get; set; }

            public bool? eq { get; set; }

            public bool? attributeExists { get; set; }

            public ModelAttributeTypes? attributeType { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelFloatInput
        public class ModelFloatInput
        {
            #region members
            public double? ne { get; set; }

            public double? eq { get; set; }

            public double? le { get; set; }

            public double? lt { get; set; }

            public double? ge { get; set; }

            public double? gt { get; set; }

            public List<double?> between { get; set; }

            public bool? attributeExists { get; set; }

            public ModelAttributeTypes? attributeType { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelIdInput
        public class ModelIdInput
        {
            #region members
            public string ne { get; set; }

            public string eq { get; set; }

            public string le { get; set; }

            public string lt { get; set; }

            public string ge { get; set; }

            public string gt { get; set; }

            public string contains { get; set; }

            public string notContains { get; set; }

            public List<string> between { get; set; }

            public string beginsWith { get; set; }

            public bool? attributeExists { get; set; }

            public ModelAttributeTypes? attributeType { get; set; }

            public ModelSizeInput size { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelIntInput
        public class ModelIntInput
        {
            #region members
            public int? ne { get; set; }

            public int? eq { get; set; }

            public int? le { get; set; }

            public int? lt { get; set; }

            public int? ge { get; set; }

            public int? gt { get; set; }

            public List<int?> between { get; set; }

            public bool? attributeExists { get; set; }

            public ModelAttributeTypes? attributeType { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelSizeInput
        public class ModelSizeInput
        {
            #region members
            public int? ne { get; set; }

            public int? eq { get; set; }

            public int? le { get; set; }

            public int? lt { get; set; }

            public int? ge { get; set; }

            public int? gt { get; set; }

            public List<int?> between { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion
        public enum ModelSortDirection
        {
            ASC,
            DESC
        }


        #region ModelStringInput
        public class ModelStringInput
        {
            #region members
            public string ne { get; set; }

            public string eq { get; set; }

            public string le { get; set; }

            public string lt { get; set; }

            public string ge { get; set; }

            public string gt { get; set; }

            public string contains { get; set; }

            public string notContains { get; set; }

            public List<string> between { get; set; }

            public string beginsWith { get; set; }

            public bool? attributeExists { get; set; }

            public ModelAttributeTypes? attributeType { get; set; }

            public ModelSizeInput size { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelTodoConditionInput
        public class ModelTodoConditionInput
        {
            #region members
            public ModelStringInput name { get; set; }

            public ModelStringInput description { get; set; }

            public List<ModelTodoConditionInput> and { get; set; }

            public List<ModelTodoConditionInput> or { get; set; }

            public ModelTodoConditionInput not { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region ModelTodoConnection
        public class ModelTodoConnection
        {
            #region members
            [JsonProperty("items")]
            public List<Todo> items { get; set; }

            [JsonProperty("nextToken")]
            public string nextToken { get; set; }
            #endregion
        }
        #endregion

        #region ModelTodoFilterInput
        public class ModelTodoFilterInput
        {
            #region members
            public ModelIdInput id { get; set; }

            public ModelStringInput name { get; set; }

            public ModelStringInput description { get; set; }

            public List<ModelTodoFilterInput> and { get; set; }

            public List<ModelTodoFilterInput> or { get; set; }

            public ModelTodoFilterInput not { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region Mutation
        public class Mutation
        {
            #region members
            [JsonProperty("createAsset")]
            public Asset createAsset { get; set; }

            [JsonProperty("updateAsset")]
            public Asset updateAsset { get; set; }

            [JsonProperty("deleteAsset")]
            public Asset deleteAsset { get; set; }

            [JsonProperty("createTodo")]
            public Todo createTodo { get; set; }

            [JsonProperty("updateTodo")]
            public Todo updateTodo { get; set; }

            [JsonProperty("deleteTodo")]
            public Todo deleteTodo { get; set; }
            #endregion
        }
        #endregion

        #region Query
        public class Query
        {
            #region members
            [JsonProperty("getTodo")]
            public Todo getTodo { get; set; }

            [JsonProperty("listTodos")]
            public ModelTodoConnection listTodos { get; set; }

            [JsonProperty("getAsset")]
            public Asset getAsset { get; set; }

            [JsonProperty("listAssets")]
            public ModelAssetConnection listAssets { get; set; }
            #endregion
        }
        #endregion

        #region S3Object
        public class S3Object
        {
            #region members
            [JsonProperty("bucket")]
            public string bucket { get; set; }

            [JsonProperty("key")]
            public string key { get; set; }

            [JsonProperty("region")]
            public string region { get; set; }
            #endregion
        }
        #endregion

        #region S3ObjectInput
        public class S3ObjectInput
        {
            #region members
            [JsonRequired]
            public string bucket { get; set; }

            [JsonRequired]
            public string key { get; set; }

            [JsonRequired]
            public string region { get; set; }

            public string localUri { get; set; }

            public string mimeType { get; set; }

            public string url { get; set; }

            public string _url { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region Subscription
        public class Subscription
        {
            #region members
            [JsonProperty("onCreateTodo")]
            public Todo onCreateTodo { get; set; }

            [JsonProperty("onUpdateTodo")]
            public Todo onUpdateTodo { get; set; }

            [JsonProperty("onDeleteTodo")]
            public Todo onDeleteTodo { get; set; }

            [JsonProperty("onCreateAsset")]
            public Asset onCreateAsset { get; set; }

            [JsonProperty("onUpdateAsset")]
            public Asset onUpdateAsset { get; set; }

            [JsonProperty("onDeleteAsset")]
            public Asset onDeleteAsset { get; set; }
            #endregion
        }
        #endregion

        #region Todo
        public class Todo
        {
            #region members
            [JsonProperty("id")]
            public string id { get; set; }

            [JsonProperty("name")]
            public string name { get; set; }

            [JsonProperty("description")]
            public string description { get; set; }

            [JsonProperty("image")]
            public S3Object image { get; set; }

            [JsonProperty("createdAt")]
            public string createdAt { get; set; }

            [JsonProperty("updatedAt")]
            public string updatedAt { get; set; }

            [JsonProperty("owner")]
            public string owner { get; set; }
            #endregion
        }
        #endregion

        #region UpdateAssetInput
        public class UpdateAssetInput
        {
            #region members
            [JsonRequired]
            public string id { get; set; }

            public string name { get; set; }

            public AssetType? type { get; set; }

            public AssetFileFormat? fileFormat { get; set; }

            public string fileName { get; set; }

            public int? fileSize { get; set; }

            public S3ObjectInput file { get; set; }

            public string description { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion

        #region UpdateTodoInput
        public class UpdateTodoInput
        {
            #region members
            [JsonRequired]
            public string id { get; set; }

            public string name { get; set; }

            public string description { get; set; }

            public S3ObjectInput image { get; set; }
            #endregion

            #region methods
            public dynamic GetInputObject()
            {
                IDictionary<string, object> d = new System.Dynamic.ExpandoObject();

                var properties = GetType().GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
                foreach (var propertyInfo in properties)
                {
                    var value = propertyInfo.GetValue(this);
                    var defaultValue = propertyInfo.PropertyType.IsValueType ? Activator.CreateInstance(propertyInfo.PropertyType) : null;

                    var requiredProp = propertyInfo.GetCustomAttributes(typeof(JsonRequiredAttribute), false).Length > 0;
                    if (requiredProp || value != defaultValue)
                    {
                        d[propertyInfo.Name] = value;
                    }
                }
                return d;
            }
            #endregion
        }
        #endregion
    }

}
