using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using UnityEngine;
using Pladdra;
using Pladdra.Core;
using Pladdra.Components;
using Piglet;

using Newtonsoft.Json;

namespace Pladdra.MVC.Models
{
    public interface IAssetModel : IModel
    {
        public List<Pladdra.Core.Types.Asset> items { get; set; }
        public bool Exists(string id);
        public Pladdra.Core.Types.Asset Get(string id);
        public List<Pladdra.Core.Types.Asset> List();
        public void Create(API.Types.Asset input);
        public void Update(API.Types.Asset input);
        public void Delete(string id);
    }

    [System.Serializable]
    public class AssetModel : IAssetModel, ISaveable
    {
        private string downloadPath = "downloads/";
        private string dataJsonPath = "assets.json";
        private List<Pladdra.Core.Types.Asset> _items;
        public List<Pladdra.Core.Types.Asset> items
        {
            get
            {
                if (_items == null)
                    _items = new List<Pladdra.Core.Types.Asset>();

                return _items;
            }

            set
            {
                _items = value;
                SaveJson();
            }
        }

        public bool Exists(string id)
        {
            List<Pladdra.Core.Types.Asset> arr = items.Where(item => item.id == id).ToList();
            return arr.Count > 0 ? true : false;
        }

        public Pladdra.Core.Types.Asset Get(string id)
        {
            List<Pladdra.Core.Types.Asset> item = items.Where(item => item.id == id).ToList();
            return item[0];
        }

        public List<Pladdra.Core.Types.Asset> List() => items;

        public void Create(Pladdra.API.Types.Asset input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            Pladdra.Core.Types.Asset createdItem = (Pladdra.Core.Types.Asset)JsonConvert.DeserializeObject<Pladdra.Core.Types.Asset>(serializedJson);
            Create(createdItem);
        }

        public void Create(Pladdra.Core.Types.Asset input)
        {
            items.Insert(0, input);
            items = items;
        }

        public void Update(Pladdra.API.Types.Asset input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);

            var existingAsset = Get(input.id);
            var updatedAsset = JsonConvert.DeserializeObject<Pladdra.Core.Types.Asset>(serializedJson);
            updatedAsset.meshPath = existingAsset.meshPath;
            updatedAsset.previewTexturePath = existingAsset.previewTexturePath;

            Update(updatedAsset);
        }

        public void Update(Pladdra.Core.Types.Asset input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            Pladdra.Core.Types.Asset updatedItem = JsonConvert.DeserializeObject<Pladdra.Core.Types.Asset>(serializedJson);
            Pladdra.Core.Types.Asset match = items.Find(item => item.id.Contains(updatedItem.id));

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

            List<Pladdra.Core.Types.Asset> updatedItems = items.Where(item => item.id != id).ToList();
            items = updatedItems;
        }

        private void DeleteMesh(Pladdra.Core.Types.Asset asset)
        {
            if (asset.meshPath != null && File.Exists(asset.meshPath))
            {
                File.Delete(asset.meshPath);
                asset.meshPath = null;
            }
        }

        private void SaveJson()
        {
            SaveDataManager.SaveJsonData(this);
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void LoadFromJson(string jsonToLoadFrom)
        {
            Debug.Log(jsonToLoadFrom);
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
