using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.IO;
using UnityEngine;
using Pladdra;

using Newtonsoft.Json;

namespace Pladdra.MVC.Models
{
    public interface IWorkspaceModel
    {
        public List<API.Types.Workspace> items { get; set; }
        public API.Types.Workspace Get(string id);
        public List<API.Types.Workspace> List();
        public void Create(API.Types.CreateWorkspaceInput input);
        public void Update(API.Types.UpdateWorkspaceInput input);
        public void Delete(API.Types.DeleteWorkspaceInput input);
    }

    public class WorkspaceModel : IWorkspaceModel
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

        public API.Types.Workspace Get(string id)
        {
            List<API.Types.Workspace> item = items.Where(item => item.id == id).ToList();
            return item[0];
        }

        public List<API.Types.Workspace> List() => items;

        public void Create(API.Types.CreateWorkspaceInput input)
        {
            string serializedJson = JsonConvert.SerializeObject(input);

            Debug.Log(serializedJson);
            API.Types.Workspace createdItem = (API.Types.Workspace)JsonConvert.DeserializeObject<API.Types.Workspace>(serializedJson);
            Debug.Log(createdItem);
            items.Insert(0, createdItem);
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
        }

        public void Delete(API.Types.DeleteWorkspaceInput input)
        {
            List<API.Types.Workspace> updatedItems = items.Where(item => item.id != input.id).ToList();
            items = updatedItems;
        }
    }
}
