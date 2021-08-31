using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Pladdra;
using Pladdra.Core;

using Newtonsoft.Json;

namespace Pladdra.MVC.Models
{
    public interface IAssetModel : IModel
    {
        public List<AssetModel.Asset> items { get; set; }
        public bool Exists(string id);
        public AssetModel.Asset Get(string id);
        public List<AssetModel.Asset> List();
        public void Create(API.Types.Asset input);
        public void Update(API.Types.Asset input);
        public void Delete(string id);
    }

    [System.Serializable]
    public class AssetModel : IAssetModel, ISaveable
    {
        private string downloadPath = "downloads/";
        private string dataJsonPath = "assets.json";
        private List<AssetModel.Asset> _items;
        public List<AssetModel.Asset> items
        {
            get
            {
                if (_items == null)
                    _items = new List<AssetModel.Asset>();

                return _items;
            }

            set
            {
                _items = value;
                SaveJson();
            }
        }

        public void SaveJson()
        {
            SaveDataManager.SaveJsonData(this);
        }

        public bool Exists(string id)
        {
            List<AssetModel.Asset> arr = items.Where(item => item.id == id).ToList();
            return arr.Count > 0 ? true : false;
        }

        public AssetModel.Asset Get(string id)
        {
            List<AssetModel.Asset> item = items.Where(item => item.id == id).ToList();
            return item[0];
        }

        public List<AssetModel.Asset> List() => items;

        public void Create(API.Types.Asset input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            AssetModel.Asset createdItem = (AssetModel.Asset)JsonConvert.DeserializeObject<AssetModel.Asset>(serializedJson);

            DownloadMesh(createdItem);

            items.Insert(0, createdItem);
            items = items;
        }

        public void Update(API.Types.Asset input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            AssetModel.Asset updatedItem = JsonConvert.DeserializeObject<AssetModel.Asset>(serializedJson);
            AssetModel.Asset match = items.Find(item => item.id.Contains(updatedItem.id));

            DownloadMesh(updatedItem);

            items.ForEach(item =>
            {
                if (item.id == updatedItem.id)
                {
                    item = updatedItem;
                }
            });
            items = items;
        }

        public void Delete(string id)
        {
            DeleteMesh(Get(id));

            List<AssetModel.Asset> updatedItems = items.Where(item => item.id != id).ToList();
            items = updatedItems;
        }

        private void DownloadMesh(AssetModel.Asset asset)
        {
            string fileName = asset.id + "." + asset.fileFormat.ToString().ToLower();
            string path = Path.Combine(downloadPath, fileName);
            string fullPath = Path.Combine(Pladdra.App.CachePath, path);
            asset.meshPath = File.Exists(path) && asset.meshPath == null ? path : asset.meshPath;

            if (asset.meshPath == null || !File.Exists(fullPath))
            {
                string bucketKey = "public/" + asset.file.key;
                Task streamTask = S3.SaveObjectToFile(path, bucketKey, asset.file.bucket);
                streamTask.Wait();
                asset.meshPath = path;
            }
        }

        private void DeleteMesh(AssetModel.Asset asset)
        {
            if (asset.meshPath != null && File.Exists(asset.meshPath))
            {
                File.Delete(asset.meshPath);
                asset.meshPath = null;
            }
        }

        public class Asset : API.Types.Asset
        {
            [JsonProperty("previewTexturePath")]
            public string previewTexturePath;

            [JsonProperty("meshPath")]
            public string meshPath;

            [JsonProperty("prefabPath")]
            public string prefabPath;
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void LoadFromJson(string jsonToLoadFrom)
        {
            AssetModel jsonData = JsonConvert.DeserializeObject<AssetModel>(jsonToLoadFrom);

            var fields = this.GetType().GetFields(BindingFlags.Public);
            foreach (var field in jsonData.GetType().GetFields())
            {
                var value = field.GetValue(jsonData);
                if (value != null)
                    this.GetType().GetField(field.Name).SetValue(this, value);
            }

            var propeties = this.GetType().GetProperties(BindingFlags.Public);
            foreach (var propety in jsonData.GetType().GetProperties())
            {
                var value = propety.GetValue(jsonData);
                if (value != null)
                    this.GetType().GetProperty(propety.Name).SetValue(this, value);
            }
        }

        public string FileNameToUseForData()
        {
            return "assets.json";
        }
    }
}
