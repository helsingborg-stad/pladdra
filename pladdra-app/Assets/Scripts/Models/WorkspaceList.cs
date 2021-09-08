using System.Reflection;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;

using Newtonsoft.Json;

using Pladdra;
using Pladdra.Core;

namespace Pladdra.MVC.Models
{
    [System.Serializable]
    public class WorkspaceList : IModel, ISaveable
    {
        private List<API.Types.Workspace> _items;

        public List<API.Types.Workspace> items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<API.Types.Workspace>();
                }

                return _items;
            }

            set { _items = value; }
        }

        public void SaveJson()
        {
            SaveDataManager.SaveJsonData(this);
        }

        public API.Types.Workspace Get(string id)
        {
            List<API.Types.Workspace> item = items.Where(item => item.id == id).ToList();
            return item[0];
        }

        public List<API.Types.Workspace> List() => items;

        public void Create(API.Types.CreateWorkspaceInput input, out API.Types.Workspace createdItem)
        {
            string serializedJson = JsonConvert.SerializeObject(input);

            createdItem = (API.Types.Workspace)JsonConvert.DeserializeObject<API.Types.Workspace>(serializedJson);
            items.Insert(0, createdItem);

            SaveJson();
        }
        public void Create(API.Types.CreateWorkspaceInput input)
        {
            Create(input, out API.Types.Workspace createdItem);
        }

        public void Update(API.Types.UpdateWorkspaceInput input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            API.Types.Workspace updatedItem = JsonConvert.DeserializeObject<API.Types.Workspace>(serializedJson);
            API.Types.Workspace match = items.Find(item => item.id.Contains(updatedItem.id));

            items.ForEach(item =>
            {
                if (item.id == updatedItem.id)
                {
                    item = updatedItem;
                }
            });

            SaveJson();
        }

        public void Delete(API.Types.DeleteWorkspaceInput input)
        {
            List<API.Types.Workspace> updatedItems = items.Where(item => item.id != input.id).ToList();
            items = updatedItems;

            SaveJson();
        }

        public string ToJson()
        {
            return JsonConvert.SerializeObject(this);
        }

        public void LoadFromJson(string jsonToLoadFrom)
        {
            WorkspaceList jsonData = JsonConvert.DeserializeObject<WorkspaceList>(jsonToLoadFrom);

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
            return "workspaces.json";
        }
    }
}
