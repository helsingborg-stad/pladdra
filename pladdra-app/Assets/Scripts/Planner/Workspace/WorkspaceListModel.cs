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
    public class WorkspaceListModel : IModel, ISaveable
    {
        private List<Core.Types.Workspace> _items;
        public List<Core.Types.Workspace> items
        {
            get
            {
                if (_items == null)
                {
                    _items = new List<Core.Types.Workspace>();
                }

                return _items;
            }

            set { _items = value; }
        }

        public void SaveJson()
        {
            SaveDataManager.SaveJsonData(this);
        }

        public T Get<T>(string id)
        {
            List<Core.Types.Workspace> item = items.Where(item => item.id == id).ToList();
            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(item[0]));
        }

        public Core.Types.Workspace Get(string id)
        {
            return Get<Core.Types.Workspace>(id);
        }

        public List<Core.Types.Workspace> List() => items;

        public void Create(API.Types.CreateWorkspaceInput input, out Core.Types.Workspace createdItem)
        {
            string serializedJson = JsonConvert.SerializeObject(input);

            createdItem = (Core.Types.Workspace)JsonConvert.DeserializeObject<Core.Types.Workspace>(serializedJson);
            items.Insert(0, createdItem);

            SaveJson();
        }

        public void Create(API.Types.CreateWorkspaceInput input)
        {
            Create(input, out Core.Types.Workspace createdItem);
        }

        public void Update(API.Types.UpdateWorkspaceInput input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);
            Core.Types.Workspace updatedItem = JsonConvert.DeserializeObject<Core.Types.Workspace>(serializedJson);
            Core.Types.Workspace match = items.Find(item => item.id.Contains(updatedItem.id));

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
            List<Core.Types.Workspace> updatedItems = items.Where(item => item.id != input.id).ToList();
            items = updatedItems;

            SaveJson();
        }

        public string ToJson()
        {
            // var jsonString = JsonConvert.SerializeObject(this);
            // WorkspaceListModel jsonData = JsonConvert.DeserializeObject<WorkspaceListModel>(jsonString);


            // WorkspaceList jsonData = JsonConvert.DeserializeObject<WorkspaceList>(jsonString);

            return JsonConvert.SerializeObject(this);
        }

        public void LoadFromJson(string jsonToLoadFrom)
        {
            WorkspaceListModel jsonData = JsonConvert.DeserializeObject<WorkspaceListModel>(jsonToLoadFrom);

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
